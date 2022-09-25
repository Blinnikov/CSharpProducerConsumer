namespace ProducerConsumerDemo.ConcurrentQueue;

public static class Demo
{
    public static void Run()
    {
        var channel = new Channel<string>();
        Task.WaitAll(
            Producer.Produce(channel),
            Consumer.Consume(channel, 1),
            Consumer.Consume(channel, 2)
        );
    }
}