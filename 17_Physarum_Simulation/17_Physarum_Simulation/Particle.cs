using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_Physarum_Simulation
{
    public class Particle
    {
        public float X;
        public float Y;
        public float Angle;

        public Particle(int width, int height, Random rnd)
        {
            X = width / 2f;
            Y = height / 2f;
            Angle = (float)(rnd.NextDouble() * Math.PI * 2);
        }
    }
}
