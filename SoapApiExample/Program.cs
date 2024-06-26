using Microsoft.EntityFrameworkCore;
using SoapCore;
using SoapApiExample.Data;
using SoapApiExample.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPersonService, PersonService>();

builder.Services.AddSoapCore();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseRouting();
// Specify the serializer options explicitly to avoid ambiguity
app.UseEndpoints(endpoints =>
{
    var soapOptions = new SoapEncoderOptions
    {
        WriteEncoding = System.Text.Encoding.UTF8
    };
    endpoints.UseSoapEndpoint<IPersonService>("/PersonService.svc", soapOptions, SoapSerializer.XmlSerializer);
});
app.Run();
