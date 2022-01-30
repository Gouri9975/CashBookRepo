using CashBook.Models;
using CashBook.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CashBook.Views
{
    public partial class CashRegisterPage : ContentPage
    {
        public Item Item { get; set; }

        public CashRegisterPage()
        {
            InitializeComponent();
            BindingContext = new CashBookRegisterViewModel("CR");
        }
    }
}