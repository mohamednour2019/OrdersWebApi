using Orders.Presentation.API.Middlewares;
using Orders.Presentation.API.ServicesConfiguration;
using Serilog;
var builder = WebApplication.CreateBuilder(args);

//dependency injections
builder.Services.RegisterServices();
builder.ConfigureHosts();
var app = builder.Build();

app.UseSerilogRequestLogging();
// Configure the HTTPS request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandlingMiddleware();
}

app.UseHsts();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();

app.UseHttpsRedirection();

app.MapControllers();
app.UseSwagger();//creates endpoints for swagger.json
app.UseSwaggerUI(c =>
{
    // Configure Swagger UI to display the Swagger JSON for each API version
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order API v1");
    //c.SwaggerEndpoint("/swagger/v2/swagger.json", "Order API v2");
});//creates swagger UI for Testing Api Endpoints and Action Methods
app.Run();
