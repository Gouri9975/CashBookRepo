using CashBook.Models;
using CashBook.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CashBook.ViewModels
{
    public class NewCashBookRegisterViewModel : BaseViewModel
    {
        private string text;
        private string description;
        public IDataStore<CashBookRegister> DataStore => DependencyService.Get<IDataStore<CashBookRegister>>();

        private string Type;
        public NewCashBookRegisterViewModel(string type)
        {
            Type = type;
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return 
                 !String.IsNullOrWhiteSpace(description) && Amount>0;
        }


        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
        private DateTime transactionDate=DateTime.Now;
        public DateTime TransactionDate
        {
            get => transactionDate;
            set => SetProperty(ref transactionDate, value);
        }
        private decimal amount;
        public decimal Amount
        {
            get => amount;
            set => SetProperty(ref amount, value);
        }
       

       
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            if (Type.Equals("CR"))
            {
                CashBookRegister NewCashBookRegister = new CashBookRegister()
                {
                    Id = Guid.NewGuid().ToString(),
                    TransactionDate = TransactionDate,
                    CRAmount = Amount,
                    Description = Description
                };
                await DataStore.AddItemAsync(NewCashBookRegister);
            }
            else
            {
                CashBookRegister NewCashBookRegister = new CashBookRegister()
                {
                    Id = Guid.NewGuid().ToString(),
                    TransactionDate = TransactionDate,
                    DRAmount = Amount,
                    Description = Description
                };
                await DataStore.AddItemAsync(NewCashBookRegister);
            }

           

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
