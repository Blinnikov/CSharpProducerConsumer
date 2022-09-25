using System.Collections.Concurrent;

namespace ProducerConsumerDemo.ConcurrentQueueImpl;

public class Channel<T> : IReader<T>, IWriter<T>
{
    private bool _finished = false;
    private ConcurrentQueue<T> _queue = new();
    private SemaphoreSlim _semaphore = new(0);

    public async Task<T> Read(int id)
    {
        Console.WriteLine($"Starting to read by consumer {id}");
        await _semaphore.WaitAsync();
        Console.WriteLine($"Semaphore opened to consumer {id}");
        
        if (_queue.TryDequeue(out var message))
        {
            Console.WriteLine($"Queue - {_queue.Count}, {_queue.IsEmpty}");
            return message;
        }
        
        Console.WriteLine($"Queue - {_queue.Count}, {_queue.IsEmpty}");

        return default;
    }

    public bool IsComplete => _finished;

    public void Send(T message)
    {
        _queue.Enqueue(message);
        _semaphore.Release();
    }

    public void Complete()
    {
        _finished = true;
    }
}