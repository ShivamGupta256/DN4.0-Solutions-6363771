using Confluent.Kafka;

class Program
{
    static async Task Main(string[] args)
    {
        var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

        using var producer = new ProducerBuilder<Null, string>(config).Build();

        Console.WriteLine("Enter messages (type 'exit' to quit):");

        string? message;
        while ((message = Console.ReadLine()) != "exit")
        {
            await producer.ProduceAsync("chat-topic", new Message<Null, string> { Value = message });
            Console.WriteLine("Message sent.");
        }
    }
}
