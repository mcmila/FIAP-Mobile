using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace auladesabado
{
	public partial class CadastrarPage : ContentPage
	{
		public CadastrarPage()
		{
			InitializeComponent();
			datepicker.MinimumDate = new System.DateTime(1900, 1, 1);
			datepicker.MaximumDate = DateTime.Now;
		}

		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			App.Current.MainPage = new LoginPage();
		}

		async void cancelClicked(object sender, System.EventArgs e)
		{
			await Navigation.PopModalAsync(true);

			//https://onedrive.live.com/?authkey=%21AK%2DxRfUs%5FUT1b7E&id=55A7F5FB440D73BE%21183953&cid=55A7F5FB440D73BE
		}
	}
}