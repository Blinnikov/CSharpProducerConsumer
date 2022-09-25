namespace ProducerConsumerDemo.ConcurrentQueueImpl;

public interface IReader<T>
{
    Task<T> Read(int id);
    bool IsComplete { get; }
}