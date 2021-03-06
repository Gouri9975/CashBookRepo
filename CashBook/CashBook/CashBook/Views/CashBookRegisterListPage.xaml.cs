using CashBook.Models;
using CashBook.ViewModels;
using CashBook.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CashBook.Views
{
    public partial class CashBookRegisterListPage : ContentPage
    {
        CashBookRegistersViewModel _viewModel;

        public CashBookRegisterListPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new CashBookRegistersViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}