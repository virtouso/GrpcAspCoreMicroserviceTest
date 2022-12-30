using GrpcServer.Rpc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddGrpc();
var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", async context =>
    {
        var endpointDataSource = context
            .RequestServices.GetRequiredService<EndpointDataSource>();
        await context.Response.WriteAsJsonAsync(new
        {
            results = endpointDataSource
                .Endpoints
                .OfType<RouteEndpoint>()
                .Where(e => e.DisplayName?.StartsWith("gRPC") == true)
                .Select(e => new
                {
                    name = e.DisplayName, 
                    pattern = e.RoutePattern.RawText,
                    order = e.Order
                })
                .ToList()
        });
    });
                
    endpoints.MapGrpcService<GreetServer>();
});



app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();