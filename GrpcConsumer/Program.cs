using Grpc.Core;
using Grpc.Net.Client;
using GrpcProvider;

namespace GrpcConsumer;

class Program
{
    static async Task Main(string[] args)
    {
        using var channel = GrpcChannel.ForAddress("http://localhost:5020");
        var service = new StreamService.StreamServiceClient(channel);

        using var stream = service.StartStream();
        var responseFromServer = Task.Run(async () => {
            await foreach(var message in stream.ResponseStream.ReadAllAsync()){
                Console.WriteLine(
                    $"User: {message.User}\nContent: {message.Content}"
                );
            }
        });
        Console.WriteLine("Escreva uma mensagem:");
        while(true){
            var text = Console.ReadLine();
            if(string.IsNullOrEmpty(text)){
                break;
            }
            Console.WriteLine("Enviando mensagem...");
            await stream.RequestStream.WriteAsync(new StreamMessage {
                User = "PJ",
                Content = text
            });
        }

        Console.WriteLine("Fim!");
        await stream.RequestStream.CompleteAsync();
        await responseFromServer;
    }
}
