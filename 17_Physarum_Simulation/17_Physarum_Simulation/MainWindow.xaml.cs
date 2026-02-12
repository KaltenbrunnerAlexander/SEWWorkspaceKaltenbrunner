using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace _17_Physarum_Simulation
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int WIDTH = 800;
        const int HEIGHT = 800;
        const int NUM_PARTICLES = 1200;

        const float SPEED = 1.5f;
        const float TURN_ANGLE = 0.4f;
        const int SENSOR_OFFSET = 9;
        const float SENSOR_ANGLE = 0.5f;
        const float DECAY = 0.01f;
        const float DIFFUSION = 0.2f;

        // 2D-Pheromon-Array
        float[,] trail = new float[WIDTH, HEIGHT];

        // 1D-Array für das Bild (BGRA)
        byte[] pixels;

        List<Particle> particles = new List<Particle>();
        Random rnd = new Random();

        WriteableBitmap bitmap;

        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            bitmap = new WriteableBitmap(
                WIDTH, HEIGHT, 96, 96,
                PixelFormats.Bgra32, null);

            pixels = new byte[WIDTH * HEIGHT * 4];
            Display.Source = bitmap;

            for (int i = 0; i < NUM_PARTICLES; i++)
                particles.Add(new Particle(WIDTH, HEIGHT, rnd));

            // Initialisiere Pheromone: zufällige Werte zwischen 0 und 1
            for (int x = 0; x < WIDTH; x++)
                for (int y = 0; y < HEIGHT; y++)
                    trail[x, y] = (float)rnd.NextDouble();

            // Optional: ein paar strukturierende Linien/Spuren als Startvariation
            for (int s = 0; s < 800; s++)
            {
                int sx = rnd.Next(WIDTH);
                int sy = rnd.Next(HEIGHT);
                float angle = (float)(rnd.NextDouble() * Math.PI * 2);
                int len = rnd.Next(8, 40);
                float intensity = 0.2f + (float)rnd.NextDouble() * 0.6f;
                for (int l = 0; l < len; l++)
                {
                    int lx = (sx + (int)(Math.Cos(angle) * l) + WIDTH) % WIDTH;
                    int ly = (sy + (int)(Math.Sin(angle) * l) + HEIGHT) % HEIGHT;
                    trail[lx, ly] = Math.Min(1f, trail[lx, ly] + intensity);
                }
            }

            timer.Interval = TimeSpan.FromMilliseconds(33); // ~30 FPS
            timer.Tick += UpdateSimulation;
            timer.Start();
        }

        float Sense(Particle p, float offset)
        {
            float angle = p.Angle + offset;
            int x = (int)(p.X + Math.Cos(angle) * SENSOR_OFFSET + WIDTH) % WIDTH;
            int y = (int)(p.Y + Math.Sin(angle) * SENSOR_OFFSET + HEIGHT) % HEIGHT;
            return trail[x, y];
        }

        void UpdateSimulation(object sender, EventArgs e)
        {
            // Partikel bewegen und Pheromon ablagern
            foreach (var p in particles)
            {
                float f = Sense(p, 0);
                float l = Sense(p, SENSOR_ANGLE);
                float r = Sense(p, -SENSOR_ANGLE);

                if (l > f && l > r) p.Angle += TURN_ANGLE;
                else if (r > f && r > l) p.Angle -= TURN_ANGLE;
                else p.Angle += (float)(rnd.NextDouble() - 0.5) * 0.1f;

                p.X = (p.X + (float)Math.Cos(p.Angle) * SPEED + WIDTH) % WIDTH;
                p.Y = (p.Y + (float)Math.Sin(p.Angle) * SPEED + HEIGHT) % HEIGHT;

                int ix = (int)p.X;
                int iy = (int)p.Y;
                trail[ix, iy] = Math.Min(1f, trail[ix, iy] + 0.6f);
            }

            // Diffusion & Decay auf Pheromon-Array
            for (int x = 1; x < WIDTH - 1; x++)
                for (int y = 1; y < HEIGHT - 1; y++)
                {
                    float sum =
                        trail[x - 1, y] +
                        trail[x + 1, y] +
                        trail[x, y - 1] +
                        trail[x, y + 1];

                    trail[x, y] =
                        trail[x, y] * (1 - DECAY) +
                        (sum / 4f - trail[x, y]) * DIFFUSION;

                    // clamp in [0,1]
                    if (trail[x, y] < 0f) trail[x, y] = 0f;
                    else if (trail[x, y] > 1f) trail[x, y] = 1f;
                }

            // Wähle zufälligen Exponenten zufall ∈ [1,2] und wende ihn an
            float zufall = 1f + (float)rnd.NextDouble(); // 1..2
            ApplyExponent(zufall);

            // Konvertiere Pheromone ins 1D-Bild und zeige es
            PheromonesToImage();
            bitmap.WritePixels(
                new Int32Rect(0, 0, WIDTH, HEIGHT),
                pixels, WIDTH * 4, 0);
        }

        // Hebt jeden Pheromon-Wert auf Potenz zufall (zufall zwischen 1 und 2 empfohlen)
        void ApplyExponent(float zufall)
        {
            for (int x = 0; x < WIDTH; x++)
                for (int y = 0; y < HEIGHT; y++)
                {
                    float v = trail[x, y];
                    // numerisch stabil: Math.Pow auf double, dann cast
                    v = (float)Math.Pow(Math.Max(0.0, v), zufall);
                    // optional: leichte Re-Normalisierung, damit Werte nicht zu klein werden
                    trail[x, y] = Math.Min(1f, v);
                }
        }

        // Wandelt Pheromon-Werte (0..1) in Graustufen 0..255 um und füllt das 1D-Byte-Array pixels (BGRA)
        void PheromonesToImage()
        {
            // Keine teure Initialisierung pro Pixel mehr nötig; wir schreiben direkt
            int idx = 0;
            for (int y = 0; y < HEIGHT; y++)
            {
                for (int x = 0; x < WIDTH; x++)
                {
                    float v = trail[x, y];
                    // Clamp auf [0,1]
                    if (v < 0f) v = 0f;
                    else if (v > 1f) v = 1f;
                    byte b = (byte)(v * 255f); // 0 -> 0, 1 -> 255

                    pixels[idx++] = b; // B
                    pixels[idx++] = b; // G
                    pixels[idx++] = b; // R
                    pixels[idx++] = 255; // A
                }
            }
        }
    }
}