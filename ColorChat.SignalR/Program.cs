using ColorChat.SignalR.Hubs;

namespace ColorChat.SignalR
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add SignalR services to the container
            builder.Services.AddSignalR();

            // Build the configuration 
            var app = builder.Build();

            //app.UseRouting();

            // Add SignalR to the middleware pipeline
            app.MapHub<ColorChatHub>("/colorChat");
            app.MapGet("/", () => "Welcome");

            app.Run();
        }
    }
}
