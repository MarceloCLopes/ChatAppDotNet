using Server;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient",
        policy =>
        {
            policy.WithOrigins("https://localhost:7000", "http://localhost:5125") // URL do Blazor WebAssembly
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials(); // necessário para SignalR
        });
});

builder.Services.AddSignalR();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseRouting();
// Ativa CORS antes de mapear endpoints
app.UseCors("AllowBlazorClient");

app.MapRoutes();
app.UseHttpsRedirection();

app.MapHub<ChatHub>("/chatHub");
app.Run();