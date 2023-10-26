namespace Marketplace.Domain.Interfaces
{
    public interface ITypedConsumer<in T>
    {
        public Task ConsumeAsync(T message, CancellationToken cancellationToken);
    }
}
