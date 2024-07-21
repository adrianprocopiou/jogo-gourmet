using GourmetGame.Application.Core.Dispatchers;
using GourmetGame.Application.Core.Senders;
using GourmetGame.Application.Data.Contexts;
using GourmetGame.Application.Pratos.Repositories;
using GourmetGame.WindowsForms.Core.DisplayMessage;
using GourmetGame.WindowsForms.Core.InputDialogBox;
using GourmetGame.WindowsForms.Services;
using Microsoft.Extensions.DependencyInjection;
using ApplicationContext = GourmetGame.Application.Data.Contexts.ApplicationContext;

namespace GourmetGame.WindowsForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();
            ConfigureServices(services);
            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                System.Windows.Forms.Application.Run(serviceProvider.GetRequiredService<FrmPrincipal>());
            }
        }
        private static void ConfigureServices(ServiceCollection services)
        {
            services
                .AddScoped<IGourmetGameService, GourmetGameService>()
                .AddScoped<FrmPrincipal>()
                .AddScoped<IDisplayMessageService, DisplayMessageService>()
                .AddScoped<IDispatcher, Dispatcher>()
                .AddScoped<IInputDialogBox, InputDialogBox>()
                .AddScoped<ICategoriaPratoRepository, CategoriaPratoRepository>()
                .AddSingleton<IApplicationContext, ApplicationContext>();

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(IDispatcher).Assembly);
            });
        }
    }
}