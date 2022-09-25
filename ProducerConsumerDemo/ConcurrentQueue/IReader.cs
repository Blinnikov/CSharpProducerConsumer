namespace ProducerConsumerDemo.ConcurrentQueue;

public interface IReader<T>
{
    Task<T> Read(int id);
    bool IsComplete { get; }
}