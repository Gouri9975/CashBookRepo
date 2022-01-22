using CashBook.Models;
using CashBook.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CashBook.Views
{
    public partial class NewCashRegisterPage : ContentPage
    {
        public Item Item { get; set; }

        public NewCashRegisterPage()
        {
            InitializeComponent();
            BindingContext = new NewCashBookRegisterViewModel("CR");
        }
    }
}