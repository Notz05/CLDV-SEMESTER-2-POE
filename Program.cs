using Azure.Storage.Blobs;
using Azure.Data.Tables;
using Azure.Storage.Queues;
using Azure.Storage.Files.Shares;
using ABCRetailWebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Retrieve the single connection string from configuration
var storageConnectionString = builder.Configuration.GetConnectionString("AzureStorage");

// Ensure the connection string is not null or empty
if (string.IsNullOrEmpty(storageConnectionString))
{
    throw new InvalidOperationException("The connection string 'AzureStorage' is missing or invalid.");
}

// Register your custom services
builder.Services.AddSingleton(new BlobServiceClient(storageConnectionString));
builder.Services.AddSingleton(new TableServiceClient(storageConnectionString));
builder.Services.AddSingleton(new QueueServiceClient(storageConnectionString));
builder.Services.AddSingleton(new ShareServiceClient(storageConnectionString));

// Register your service classes
builder.Services.AddSingleton<BlobService>();
builder.Services.AddSingleton<TableService>();
builder.Services.AddSingleton<QueueService>();
builder.Services.AddSingleton<FileService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
