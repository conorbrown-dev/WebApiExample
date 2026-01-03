// LYTIP: This is the entry point of the entire application.  

// LYTIP: The below are using statements which pull in scoped contexts of code called namespaces
// Namespaces are a logical scope within a project (class library, Web API, etc.) that contain methods within classes, enums, etc.
// For example if we have some repositories all underneath the Repositories namespace, we can add a using statement for it and have access to everything within the repositories namespace
// Namespaces are most often are named after the folder structure they're in

using Microsoft.EntityFrameworkCore; // This namespace allows us to use the AddDbContext() method
using WebApplication1.Context; // This brings in our AppDbContext namespace
using WebApplication1.Repositories; // Allows us to reference/use every repository we have
using WebApplication1.Services; // Similarly this allows to access us the classes (UserService), etc. within the Services namespace.

var builder = WebApplication.CreateBuilder(args); // This creates a builder which we can use to add our dependencies, wire up auth, etc.

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// These services are added with a Scoped lifecycle. This means that we get a new instance of the dependency (IUserService, etc.) for every web request.
// Once the web request completes the instance is disposed of and a new one will be constructed on the next web request.
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepo, UserRepo>();


builder.Services.AddControllers(); // This just tells .NET that we want to be able to use controllers in our application
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(); // This is a nifty tool for generating API clients for this application.
// Normally when writing a decoupled frontend (React, or standalone Blazor) you would have to handwrite an ApiClient with all the requests and responses, and endpoints yourself.
// When using OpenApi/Swagger you can generate an ApiClient that does all of this for you.
// All you have to do after that is called methods on the ApiClient that was generated.

var app = builder.Build(); // This wires up all the dependencies and features that the application will use and creates the WebApplication object

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) app.MapOpenApi(); // Here we check if the environment is Development, if so, make OpenApi available as an endpoint.
// For other non-development environments we don't want to expose our API to the public.

app.UseHttpsRedirection(); // This will force Https redirects within the application. So if someone hits your app at http://myawesomeApp.com the application will redirect it to https://myawesomeApp.com

app.UseAuthorization(); // This allows using [Authorize] attributes for endpoints which will not allow unauthenticated/unauthorized users to access the endpoint

app.MapControllers(); // This wires up all of the controlers we've created and sets them up to be accessible

app.Run(); // This just starts the application up.