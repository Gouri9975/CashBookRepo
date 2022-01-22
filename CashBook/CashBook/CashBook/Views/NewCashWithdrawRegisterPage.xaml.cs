using CashBook.Models;
using CashBook.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CashBook.Views
{
    public partial class NewCashWithdrawRegisterPage : ContentPage
    {
        public Item Item { get; set; }

        public NewCashWithdrawRegisterPage()
        {
            InitializeComponent();
            BindingContext = new NewCashBookRegisterViewModel("DR");
        }
    }
}