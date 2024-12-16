namespace MauiAppLogin
{
   public partial class App : Application
   {
      public App()
      {
         InitializeComponent();
      }

      protected override Window CreateWindow(IActivationState? activationState)
      {
         try
         {
            var window = new Window(new AppShell());

            window.Width = 400;
            window.Height = 600;

            return window;
         }
         catch (Exception ex)
         {
            throw new Exception(ex.Message);
         }

      }
   }
}