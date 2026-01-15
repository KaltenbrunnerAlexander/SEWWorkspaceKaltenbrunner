namespace AsnycChatServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AsyncChatServer server = new AsyncChatServer();
            server.Run().Wait();
        }
    }
}
