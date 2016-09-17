using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace auladesabado
{
	public partial class deznetPage : ContentPage
	{
		public deznetPage()
		{
			InitializeComponent();
		}

		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new NavigationPage(new UserTabbedPage()));
		}

		async void Recuperar_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PushModalAsync(new NavigationPage(new RecuperarPage()));
		}
	}
}