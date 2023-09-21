using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SocialMedia_FrontEnd;
using SocialMedia_FrontEnd.Services.Comments;
using SocialMedia_FrontEnd.Services.Posts;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IPostInterface, PostService>();
builder.Services.AddScoped<ICommentInterface, CommentService>(); 

await builder.Build().RunAsync();
