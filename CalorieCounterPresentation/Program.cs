using CalorieCounterPresentation.LoginUI;

namespace CalorieCounterPresentation
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
            Application.Run(new LoginForm());
        }

        // 14.02.2023

        // password mail
        // database tables

        // 15.02.2023

        // formlarý ekleme/düzenleme
        // kýyas raporlarý
    }
}