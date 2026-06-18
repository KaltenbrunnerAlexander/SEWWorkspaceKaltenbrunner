// NEU HINZUGEFÜGT (Aufgabe 1d): CounterService
// Dieses Service stellt einen einfachen Zähler bereit.
// Da es als Singleton registriert wird, startet der Zähler bei jedem Server-Neustart bei 0.

namespace RestApiBook.Services
{
    // Interface für den CounterService (gute Praxis für Dependency Injection)
    public interface ICounterService
    {
        // Erhöht den Zähler um 1 und gibt den aktuellen Wert zurück
        int Increment();

        // Gibt den aktuellen Zählerstand zurück ohne zu erhöhen
        int GetCount();
    }

    // Implementierung des CounterService
    public class CounterService : ICounterService
    {
        // Der Zähler startet bei 0. Da der Service als Singleton registriert ist,
        // wird er bei jedem Neustart des Servers zurückgesetzt.
        private int _count = 0;

        // Erhöht den Zähler um 1 und gibt den neuen Wert zurück
        public int Increment()
        {
            _count++;
            return _count;
        }

        // Gibt den aktuellen Zählerstand zurück
        public int GetCount()
        {
            return _count;
        }
    }
}
