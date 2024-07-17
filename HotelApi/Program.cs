using HotelApi.Extension;

var builder = WebApplication.CreateBuilder(args);
builder.AddBuilderConfigurations();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddAppConfigurations();
app.Run();
