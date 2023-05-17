using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacBusinessModule());
    });

// Add services to the container.
builder.Services.AddConnections();
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


builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllers();

app.Run();
