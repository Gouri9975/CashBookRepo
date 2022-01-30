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
            Routing.RegisterRoute(nameof(CashRegisterPage), typeof(CashRegisterPage));
            Routing.RegisterRoute(nameof(CashWithdrawRegisterPage), typeof(CashWithdrawRegisterPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }

}
