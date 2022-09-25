namespace ProducerConsumerDemo.ConcurrentQueueImpl;

public interface IWriter<T>
{
    void Send(T message);
    void Complete();
}