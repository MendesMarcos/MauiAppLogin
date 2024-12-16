namespace MauiAppLogin;

public partial class Login : ContentPage
{
   public Login()
   {
      InitializeComponent();
   }

   private async void Button_Clicked(object sender, EventArgs e)
   {
      try
      {
         List<DadosUsuarios> usuarios = new List<DadosUsuarios>()
         {
            new DadosUsuarios()
            {
               Usuario = "pri",
               Senha = "1405"
            },
            new DadosUsuarios()
            {
               Usuario = "marcos",
               Senha = "123"
            }
         };

         DadosUsuarios dadosDigitados = new DadosUsuarios()
         {
            Usuario = txt_usuario.Text,
            Senha = txt_senha.Text
         };

         if(usuarios.Any(u => dadosDigitados.Usuario == u.Usuario 
                           && dadosDigitados.Senha == u.Senha))
         {
            await SecureStorage.Default.SetAsync("usuarioLogado", dadosDigitados.Usuario);

            App.Current.MainPage = new Protegida();
         }
         else {
            throw new Exception("Credenciais incorretas.");
         }

      }
      catch (Exception ex)
      {
         await DisplayAlert("Alerta", ex.Message, "Fechar");
      }
   }
}