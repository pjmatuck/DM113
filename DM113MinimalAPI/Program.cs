var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();
var app = builder.Build();

var routeGroup = app.MapGroup("message");
new MessageEndpoints(routeGroup);

app.Run();

public record Message(Guid id, string Content, bool IsUrgent);

public record MessageDTO(string Content, bool IsUrgent);