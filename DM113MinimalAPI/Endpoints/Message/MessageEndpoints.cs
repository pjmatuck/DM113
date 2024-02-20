public class MessageEndpoints {
    public RouteGroupBuilder builder;
    public MessageEndpoints(RouteGroupBuilder b){
        builder = b;
        SetupEndpoints();
    }   
    void SetupEndpoints()
    {
        builder.MapMethods(MessageGetAll.Route, 
            MessageGetAll.Methods, MessageGetAll.Handler);
    }
}