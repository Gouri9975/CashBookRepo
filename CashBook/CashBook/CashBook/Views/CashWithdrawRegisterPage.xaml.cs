using CashBook.Models;
using CashBook.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CashBook.Views
{
    public partial class CashWithdrawRegisterPage : ContentPage
    {
        public Item Item { get; set; }

        public CashWithdrawRegisterPage()
        {
            InitializeComponent();
            BindingContext = new CashBookRegisterViewModel("DR");
        }
    }
}