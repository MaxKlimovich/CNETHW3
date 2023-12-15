using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server;

public class UDPServer
{
    public async Task Server()
    {
        UdpClient udpClient = new UdpClient(12345);
        IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 0);
        CancellationTokenSource cts = new CancellationTokenSource();

        Console.WriteLine("Сервер ждет сообщение от клиента...");

        while (!cts.IsCancellationRequested)
        {
            byte[] buffer = udpClient.Receive(ref iPEndPoint);

            var messageTxt = Encoding.UTF8.GetString(buffer);
            Console.WriteLine($"Получено {buffer.Length} байт");

            byte[] reply = Encoding.UTF8.GetBytes("Сообщение получено");

            int bytes = await udpClient.SendAsync(reply, iPEndPoint);
            Console.WriteLine($"Отправлено {bytes} байт");

            Message? message = Message.DeserializeFromJson(messageTxt);
            if (message.Text.Equals("exit")) cts.Cancel();
            message.Print();
        }

        Console.WriteLine("Сервер остановлен.");
        Console.ReadLine();
    }
}