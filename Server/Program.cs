using System.Net.Sockets;
using System.Net;

using System.Text;
using System.Net.Security;
using Server;

internal class Program
{
    static void Main(string[] args)
    {
        var server = new UDPServer();
        server.Server();
    }
}