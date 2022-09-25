using System.Threading.Channels;

namespace ProducerConsumerDemo.ChannelImpl;

public static class Demo
{
    private static readonly Channel<string> _channel = Channel.CreateUnbounded<string>();

    public static void Run()
    {
        Task.WaitAll(
            ProduceMany(_channel.Writer, 30),
            Consume(_channel.Reader, 1),
            Consume(_channel.Reader, 2)
        );
    }

    private static async Task ProduceMany(ChannelWriter<string> writer, int amount)
    {
        await Task.WhenAll(
            Produce(writer, amount, 0),
            Produce(writer, amount, 1),
            Produce(writer, amount, 2)
        );
        
        writer.Complete();
    }

    private static async Task Produce (ChannelWriter<string> writer, int amount, int id) {
        for (int i = 0; i < amount; i++)
        {
            var val = id * amount + i;
            Console.WriteLine($"Writing {val}");
            await writer.WriteAsync(val.ToString());
            await Task.Delay(100);
        }
        
        Console.WriteLine($"Writing completed by {id}");
    }
    
    private static async Task Consume(ChannelReader<string> reader, int id)
    {
        await foreach (var msg in reader.ReadAllAsync())
        {
            Console.WriteLine($"Read from channel by {id} - {msg}");
        }
    
        Console.WriteLine("Reading completed");
    }
}