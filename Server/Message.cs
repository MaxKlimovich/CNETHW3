using System.Text.Json;

namespace Server;

public class Message
{
    public string? Text { get; set; }

    public DateTime DateTime { get; set; }

    public string? NickNameFrom { get; set; }
    public string? NickNameTo { get; set; }

    public string SerializeMessageToJson() => JsonSerializer.Serialize(this);

    public static Message? DeserializeFromJson(string message) => JsonSerializer.Deserialize<Message>(message);

    public void Print()
    {
        Console.WriteLine(ToString());
    }
    public override string ToString()
    {
        return $"{this.DateTime} Получено сообщение {this.Text} от {this.NickNameFrom}";
    }
}