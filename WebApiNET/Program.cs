using Microsoft.EntityFrameworkCore;
using WebApiNET.Models;
using WebApiNET.Data;
using WebApiNET.Functions;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UsersDB>(opt => opt.UseInMemoryDatabase("UserList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

byte[] key = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

byte[] iv = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/Users", async (Users user, UsersDB db) =>
{
    db.User.Add(user);
    await db.SaveChangesAsync();

    return Results.Created($"/Users{user.Id}", user);
});

app.MapGet("/Users", async (UsersDB db) => await db.User.ToListAsync());

app.MapPost("/Encrypt", (TextToEncrypt textToEncrypt) =>
{
    var encryptText = textToEncrypt.text;

    byte[] encryptedPassword = TextEncrypt.EncryptFunction(encryptText, key, iv);

    var newEncrypt = new Encrypt
    {
        encrypted = encryptedPassword
    };
    var jsonEncrypt = JsonSerializer.Serialize(newEncrypt);

    return jsonEncrypt;
});

app.MapPost("/Decrypt", (Encrypt textToDecrypt) =>
{
    byte[] encryptText = textToDecrypt.encrypted;

    string decryptedPassword = TextDecrypt.DecryptFunction(encryptText, key, iv);

    var newDecrypt = new Decrypt
    {
        decrypted = decryptedPassword
    };
    var jsonEncrypt = JsonSerializer.Serialize(newDecrypt);

    return jsonEncrypt;
});

app.Run();