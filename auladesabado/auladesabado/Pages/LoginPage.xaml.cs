using System;
using System.Collections.Generic;

using Xamarin.Forms;

using Acr.UserDialogs;
using System.Threading.Tasks;

namespace auladesabado
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();
		}

		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			UserDialogs.Instance.ShowLoading("Logando como " + txtLogin.Text);
			await Task.Delay(3000);
			UserDialogs.Instance.HideLoading();
			//DisplayAlert(txtLogin.Text,txtSenha.Text, "OK", "Cancelar");
		}
	}
}