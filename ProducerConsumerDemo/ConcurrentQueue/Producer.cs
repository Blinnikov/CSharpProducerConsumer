using ProducerConsumerDemo.ConcurrentQueue;

namespace ProducerConsumerDemo;

public static class Producer
{
    public static async Task Produce (IWriter<string> writer) {
        for (int i = 0; i < 10; i++)
        {
            writer.Send(i.ToString());
            await Task.Delay(100);
        }

        writer.Complete();
        Console.WriteLine($"Writing completed - {((Channel<string>)writer).IsComplete}");
    }
}