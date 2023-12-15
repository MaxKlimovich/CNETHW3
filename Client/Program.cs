using Client;

internal class Program
{
    static void Main(string[] args)
    {
        new Task(() => UDPClient.SendMessage("Li4e")).RunSynchronously();
        Console.ReadKey();
    }
}