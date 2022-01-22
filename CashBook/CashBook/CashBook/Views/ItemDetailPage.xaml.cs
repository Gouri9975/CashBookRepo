using CashBook.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace CashBook.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}