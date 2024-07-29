using System;
using System.Windows.Forms;
using AutoMapper;
using DataAccessLibrary;
using MarkCapturing.Presenter;
using MarkCapturing.Views;
using Microsoft.Extensions.DependencyInjection;


static class Program
{
    public static FormNavigationController FormNavController = new FormNavigationController();

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        var services = new ServiceCollection();
        // Add your services and configurations here
        services.AddSingleton<FormNavigationController>();
        services.AddTransient<FormLogin>();

        // Configure AutoMapper
        //services.AddAutoMapper(typeof(MappingProfile));
        // Configure AutoMapper
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
            // Add profiles for other mappings as needed
        });

        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);

        // Build the service provider
        var serviceProvider = services.BuildServiceProvider();

        // Resolve the FormNavigationController from the service provider
        var formNavController = serviceProvider.GetRequiredService<FormNavigationController>();

        // Show the initial form
        formNavController.ShowForm(serviceProvider.GetRequiredService<FormLogin>());

        Application.Run();
    }


    static void ConfigureServices(IServiceCollection services)
    {
        // Add AutoMapper
       // services.AddAutoMapper(typeof(Program));

        // Other service registrations...
    }
}
