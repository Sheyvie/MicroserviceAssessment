using Microsoft.EntityFrameworkCore;
using SocialMedia_Post.Data;
using SocialMedia_Post.Extensions;
using SocialMedia_Post.Services;
using SocialMedia_Post.Services.Iservices;

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

//registering base urls for the services
builder.Services.AddHttpClient("Comment", c => c.BaseAddress = new Uri(builder.Configuration["ServiceUrl:CommentApi"]));
//register Services
builder.Services.AddScoped<IPostInterface, PostService>();
builder.Services.AddScoped<ICommentInterface, CommentService>();

//Register Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
app.UseHttpsRedirection();
//using authentication
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
