namespace RestApiBook
{
    public class CounterService
    {
        private int _count = 0;

        public int Increment()
        {
            _count++;
            return _count;
        }
    }
}