﻿using System;
using Xamarin.Forms;
using Acquaint.Util;
using Acquaint.Models;
using Acquaint.ViewModels;

namespace Acquaint.Views
{
	public partial class ListPage : ContentPage
	{
		protected ListViewModel ViewModel => BindingContext as ListViewModel;

		public ListPage()
		{
			InitializeComponent();
            BindingContext = new ListViewModel();
		}

        async void ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is Acquaintance a))
                return;

            await Navigation.PushAsync(new DetailPage(a));

            ((ListView)sender).SelectedItem = null;
        }
        void ItemTapped(object sender, ItemTappedEventArgs e) =>
            ((ListView)sender).SelectedItem = null;


		protected override async void OnAppearing()
		{
			base.OnAppearing();

            //Update the list if needed. View Model handles this logic.
            await ViewModel.ExecuteLoadCommand();		
		}

       
    }
}

