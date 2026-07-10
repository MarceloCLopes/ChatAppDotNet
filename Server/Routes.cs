namespace Server;

public static class Routes
{
    public static void MapRoutes(this WebApplication app)
    {
        var route = app.MapGroup("");

        route.MapGet("", () => "Server is up and running");
        // Add more routes here
    }

}
