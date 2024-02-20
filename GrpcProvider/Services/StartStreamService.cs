using Grpc.Core;
using GrpcProvider;

public class StartStreamService : StreamService.StreamServiceBase
{
    public override async Task StartStream(IAsyncStreamReader<StreamMessage> requestStream, IServerStreamWriter<StreamMessage> responseStream, ServerCallContext context)
    {
        if(requestStream != null){
            if(!await requestStream.MoveNext()){
                return;
            }
        }

        if(!string.IsNullOrEmpty(requestStream?.Current.Content)){
            return;
        }

        var message = requestStream?.Current.Content;
        Console.WriteLine($"Mensagem {message} de {requestStream?.Current.User} recebida.");
        await responseStream.WriteAsync(new StreamMessage {
            User = "Server",
            Content = $"Mensagem do servidor. Hora: {DateTime.UtcNow:f}"
        });
    }
}