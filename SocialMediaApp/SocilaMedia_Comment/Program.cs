using Microsoft.EntityFrameworkCore;
using SocialMedia_Comment.Data;
using SocialMedia_Comment.Extensions;
using SocilaMedia_Comment.Services;
using SocilaMedia_Comment.Services.Iservice;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
});


//register Services
builder.Services.AddScoped<ICommentInterface, CommentService>();

//Register Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//Adding cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
   builder.WithOrigins("https://localhost:7122")
        .WithHeaders().
        AllowAnyMethod());

});

//add Custom Services
builder.AddSwaggenGenExtension();
builder.AddAppAuthentication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMigration();
app.UseCors();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
