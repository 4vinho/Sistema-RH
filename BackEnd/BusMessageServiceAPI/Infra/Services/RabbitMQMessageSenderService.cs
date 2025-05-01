using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BusMessageServiceAPI;

public class RabbitMQMessageSenderService<TData> : IRabbitMQMessageSenderService<TData>
{
    private readonly string _hostName;
    private readonly string _userName;
    private readonly string _passWord;
    private IConnection _connection;

    public RabbitMQMessageSenderService()
    {
        _hostName = "localhost";
        _userName = "guest";
        _passWord = "guest";
    }

    public async Task<Response<bool?>> SendMessage(TData message, string queueName)
    {
        if (message == null)
            return new Response<bool?>(400, "Message is null", false);
        var factory = new ConnectionFactory
        {
            HostName = _hostName,
            UserName = _userName,
            Password = _passWord
        };

        _connection = await factory.CreateConnectionAsync();
        using var channel = await _connection.CreateChannelAsync();

        await channel.QueueDeclareAsync(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

        byte[]? body = GetMessageAsByteArray(message);
        if (body == null)
            return new Response<bool?>(500, "Erro ao converter mensagem para byte array", false);

        var props = new BasicProperties();

        await channel.BasicPublishAsync<BasicProperties>(
            exchange: "",
            routingKey: queueName,
            mandatory: false,
            basicProperties: props,
            body: body
        );

        return new Response<bool?>(200, "Message sent successfully", false);
    }

    private byte[]? GetMessageAsByteArray(TData message)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        if (message == null)
            return null;

        var json = JsonSerializer.Serialize((TData)(object)message, options);
        return Encoding.UTF8.GetBytes(json);
    }
}
