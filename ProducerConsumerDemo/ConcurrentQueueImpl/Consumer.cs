namespace ProducerConsumerDemo.ConcurrentQueueImpl;

public static class Consumer
{
    public static async Task Consume(IReader<string> reader, int id)
    {
        while (!reader.IsComplete)
        {
            Console.WriteLine($"reader.IsComplete - {reader.IsComplete}");
            var msg = await reader.Read(id);
            Console.WriteLine(msg);
        }
    
        Console.WriteLine("Reading completed");
    }
}