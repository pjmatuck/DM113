using static System.Net.WebRequestMethods;

public class MessageGetAll {
    public static string Route => "/";
    public static string[] Methods => new string[] {Http.Post.ToString()};
    public static Delegate Handler => HandlerAction;

    private static async Task<IResult> HandlerAction(MessageDTO msg, AppDbContext db)
    {
        db.Messages.Add(new Message (
            Guid.NewGuid(), msg.Content, msg.IsUrgent));
        db.SaveChanges();
        
        return Results.Ok();
    }
}