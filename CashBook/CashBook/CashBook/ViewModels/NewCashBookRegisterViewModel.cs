using CashBook.Models;
using CashBook.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CashBook.ViewModels
{
    [QueryProperty(nameof(CashRegisterId), nameof(CashRegisterId))]
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
        public string cashRegisterId;
        public string CashRegisterId
        {
            get
            {
                return cashRegisterId;
            }
            set
            {
                cashRegisterId = value;
                if(!String.IsNullOrEmpty(cashRegisterId))

                LoadItemId(value);
            }
        }
        public async void LoadItemId(string itemId)
        {
            try
            {
                 var item = await DataStore.GetItemAsync(itemId);
                TransactionDate = item.TransactionDate;
                if(item.CRAmount>0)
                Amount = item.CRAmount;
                else
                Amount = item.DRAmount;
                Description = item.Description;
            }
            catch (Exception)
            {
               // Debug.WriteLine("Failed to Load Item");
            }
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
            if (string.IsNullOrEmpty(CashRegisterId))
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

            }
            else
            {
                if (Type.Equals("CR"))
                {
                    CashBookRegister NewCashBookRegister = new CashBookRegister()
                    {
                        Id = CashRegisterId,
                        TransactionDate = TransactionDate,
                        CRAmount = Amount,
                        Description = Description
                    };
                    await DataStore.UpdateItemAsync(NewCashBookRegister);
                }
                else
                {
                    CashBookRegister NewCashBookRegister = new CashBookRegister()
                    {
                        Id = CashRegisterId,
                        TransactionDate = TransactionDate,
                        DRAmount = Amount,
                        Description = Description
                    };
                    await DataStore.UpdateItemAsync(NewCashBookRegister);
                }
               
            }
                

           

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
