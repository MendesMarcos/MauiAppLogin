namespace MauiAppLogin;

public partial class Protegida : ContentPage
{
   public Protegida()
   {
      InitializeComponent();

      string? usuarioLogado = null;

      Task.Run(async () =>
      {
         usuarioLogado = await SecureStorage.Default.GetAsync("usuarioLogado");
         lbl_boasVindas.Text = $"Bem-vindo(a) {usuarioLogado}";
      });
   }

   private async void Button_Clicked(object sender, EventArgs e)
   {
      bool conf = await DisplayAlert("Sair", "Deseja sair do App?", "Sim", "Não");

      if (conf)
      {
         SecureStorage.Default.Remove("usuarioLogado");
         App.Current.MainPage = new Login();
      }
   }
}