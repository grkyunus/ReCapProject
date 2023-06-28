using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using Core.Utilities.Security.Jwt;
using Microsoft.IdentityModel.Tokens;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Core.Utilities.Security.Encryption;
using Core.Utilities.IoC;
using Core.DependencyResolvers;
using Core.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacBusinessModule());
    });

// Add services to the container.
// builder.Services.AddConnections();
builder.Services.AddControllers();

#region Servisler

//builder.Services.AddSingleton<IBrandService,BrandManager>();
//builder.Services.AddSingleton<IBrandDal,EfBrandDal>();
//builder.Services.AddSingleton<ICarService,CarManager>();
//builder.Services.AddSingleton<ICarDal,EfCarDal>();
//builder.Services.AddSingleton<IColorService,ColorManager>();
//builder.Services.AddSingleton<IColorDal,EfColorDal>();
//builder.Services.AddSingleton<ICustomerService,CustomerManager>();
//builder.Services.AddSingleton<ICustomerDal,EfCustomerDal>();
//builder.Services.AddSingleton<IRentalService,RentalManager>();
//builder.Services.AddSingleton<IRentalDal,EfRentalDal>();
//builder.Services.AddSingleton<IUserService,UserManager>();
//builder.Services.AddSingleton<IUserDal,EfUserDal>();



#endregion

builder.Services.AddCors();

var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelpler.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });
// Buraya farklý eklemeler yapýlabilir bunun için bu sistem oluþturuldu.
builder.Services.AddDependencyResolvers(new ICoreModule[]
{
    new CoreModule()
});


builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors(builder => builder.WithOrigins("http://localhost:4200*-*-").AllowAnyHeader());

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllers();

app.Run();
