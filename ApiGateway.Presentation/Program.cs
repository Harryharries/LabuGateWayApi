using Ocelot.DependencyInjection;
using Ocelot.Cache.CacheManager;
using eCommerce.SharedLibrary.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot().AddCacheManager(x=>x.WithDictionaryHandle());
JWTAuthenticationScheme.AddJWTAuthenticationScheme(builder.Services, builder.Configuration);
builder.Services.AddCors(options=>
{
    options.AddDefaultPolicy(policy=>
    {
        policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});
app.UseCors();
app.UseHttpsRedirection();
app.Run();