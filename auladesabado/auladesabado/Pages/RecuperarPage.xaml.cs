using System;
using System.Collections.Generic;
using Acr.UserDialogs;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace auladesabado
{
	public partial class RecuperarPage : ContentPage
	{
		public RecuperarPage()
		{
			InitializeComponent();
		}

		void btnEnviar_Clicked(object sender, System.EventArgs e)
		{
			//DisplayAlert("Recuperar", "Senha enviada para: " + txtRecuperar.Text, "OK");

			UserDialogs.Instance.ShowSuccess("Senha enviada para: " + txtRecuperar.Text);
		}

		async void btnCancelar_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PopModalAsync();
		}
	}
}