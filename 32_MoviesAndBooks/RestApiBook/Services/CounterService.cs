// NEU (Aufgabe 1d): CounterService – einfacher Zähler
// Als Singleton registriert → Zähler startet bei jedem Server-Neustart bei 0
namespace RestApiBook.Services
{
    public interface ICounterService
    {
        int Increment();
        int GetCount();
    }

    public class CounterService : ICounterService
    {
        private int _count = 0;

        public int Increment()
        {
            _count++;
            return _count;
        }

        public int GetCount() => _count;
    }
}
