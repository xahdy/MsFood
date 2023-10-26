using ActiveMQ.Artemis.Client;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Cadastro.Infra.Services
{
    public class MessageProducer
    {
        private readonly IAnonymousProducer _producer;
        public MessageProducer(IAnonymousProducer producer)
        {
            _producer = producer;
        }

        public async Task PublishAsync<T>(T message)
        {
            var serialized = JsonSerializer.Serialize(message, new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            });
            var address = typeof(T).Name;
            var msg = new Message(serialized);
            await _producer.SendAsync(address, msg);
        }
    }
}
