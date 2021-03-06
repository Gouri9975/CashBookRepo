using CashBook.Services;
using CashBook.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CashBook
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

         
            DependencyService.Register<CashBookRegisterStore>();
           
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
