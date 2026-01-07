using DestJamfInterface.Components;
using Auth0.AspNetCore.Authentication;
using System;
using Serilog;
using Microsoft.VisualBasic;
// new test 

namespace DestJamfInterface;

public class Program
{

    public static void Main(string[] args)
    {

        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(@"C:\DestJamfInterface\SinkLog.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
        Log.Information(messageTemplate: "Information");

        //try 
        //{
        //    Log.Information(messageTemplate: "Information");
        //    Log.Debug(messageTemplate: "This is our debug log");
          
        //    Log.Verbose(messageTemplate: "This is our verbose log");
        //    Log.Warning(messageTemplate: "This is our warning log");
        //    Log.Error(messageTemplate: "This is our error log");
        //    Log.Fatal(messageTemplate: "This is our fatal error log");
        //    //var a = 0;
        //    //var b = 1 / a;          /// this intentionally creates error to log below divide by zero
        //    //Log.Information("a");
        //    //Log.Information("b");

        //    //Log.Information("Dividing {a} by {b}");
        //}
        //catch (Exception ex)
        //{
        //    Log.Error(ex, messageTemplate: "This is our error log");
        //}
        //finally
        //{
        //   // Log.Information(messageTemplate: "Log closing things here");
        //    //Log.CloseAndFlushAsync();
        //}
      // Console.ReadLine();

        //test change in github.com
        
        var builder = WebApplication.CreateBuilder(args);

        // var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        // Bacher added this for Adding Auth0 login
        //builder.Services
        //.AddAuth0WebAppAuthentication(options =>
        //{
        //    options.Domain = builder.Configuration["Auth0:Domain"]!;
        //    options.ClientId = builder.Configuration["Auth0:AppClientId"]!;
        //});


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true); 
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        //*************************************//

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
           .AddInteractiveServerRenderMode();

        // Bacher added this for Adding Auth0 login
        //app.UseAuthentication();
        //app.UseAuthorization();

        app.Run();

    }    // end of Main


} // end of class Program



