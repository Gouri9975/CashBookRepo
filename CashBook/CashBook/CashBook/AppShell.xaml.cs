using CashBook.ViewModels;
using CashBook.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace CashBook
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(NewCashRegisterPage), typeof(NewCashRegisterPage));
            Routing.RegisterRoute(nameof(NewCashWithdrawRegisterPage), typeof(NewCashWithdrawRegisterPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }

}
