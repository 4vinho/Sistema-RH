namespace BusMessageServiceAPI;

public interface IRabbitMQMessageSenderService<TData>
{
    public Task<Response<bool?>> SendMessage(TData message, string queueName);
}
