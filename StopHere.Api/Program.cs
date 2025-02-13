using StopHere.Api.Common.Api.Extensions;
using StopHere.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.AddApiConfiguration();
builder.AddConfigurationServices();
builder.AddCrossOrigin();
builder.AddDataContext();
builder.AddSecurity();
builder.AddDocumentation();
builder.AddServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.ConfigureDevEnvironment();

app.UseSecurity();
app.UseHttpsRedirection();
app.MapEndpoints();

app.Run();