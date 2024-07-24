using GourmetGame.WindowsForms.Core.DisplayMessage;
using GourmetGame.WindowsForms.Core.InputDialogBox;
using GourmetGame.WindowsForms.Services;
using Microsoft.Extensions.DependencyInjection;

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
                Application.Run(serviceProvider.GetRequiredService<FrmPrincipal>());
            }
        }
        private static void ConfigureServices(ServiceCollection services)
        {
            services
                .AddScoped<IGourmetGameService, GourmetGameService>()
                .AddScoped<FrmPrincipal>()
                .AddScoped<IDisplayMessageService, DisplayMessageService>()
                .AddScoped<IInputDialogBox, InputDialogBox>();
        }
    }
}