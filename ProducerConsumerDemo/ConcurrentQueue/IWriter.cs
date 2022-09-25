namespace ProducerConsumerDemo.ConcurrentQueue;

public interface IWriter<T>
{
    void Send(T message);
    void Complete();
}