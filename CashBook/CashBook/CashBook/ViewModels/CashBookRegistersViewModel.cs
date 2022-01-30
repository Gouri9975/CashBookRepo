using CashBook.Models;
using CashBook.Services;
using CashBook.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;

namespace CashBook.ViewModels
{
    public class CashBookRegistersViewModel : BaseViewModel
    {
        private CashBookRegister _selectedCashBookRegister;

        public ObservableCollection<CashBookRegister> CashBookRegisterList { get; }
      
        

        decimal _TotalDR = 0;
        public decimal TotalDR
        {
            get { return _TotalDR; }
            set { SetProperty(ref _TotalDR, value); }
        }

        decimal _TotalCR = 0;
        public decimal TotalCR
        {
            get { return _TotalCR; }
            set { SetProperty(ref _TotalCR, value); }
        }
        decimal _Balance = 0;
        public decimal Balance
        {
            get { return _Balance; }
            set { SetProperty(ref _Balance, value); }
        }

        public Command LoadCashBookRegistersCommand { get; }
        public Command DepositeCashBookRegisterCommand { get; }
        public Command WithdrawCashBookRegisterCommand { get; }

        public Command<CashBookRegister> CashBookRegisterTapped { get; }
        public IDataStore<CashBookRegister> DataStore => DependencyService.Get<IDataStore<CashBookRegister>>();

        public CashBookRegistersViewModel()
        {
            Title = "CashBookRegister";
            CashBookRegisterList = new ObservableCollection<CashBookRegister>();
            LoadCashBookRegistersCommand = new Command(async () => await ExecuteLoadCashBookRegistersCommand());

            CashBookRegisterTapped = new Command<CashBookRegister>(OnCashBookRegisterSelected);

            DepositeCashBookRegisterCommand = new Command(OnDepositeCashBookRegisterCommand);
            WithdrawCashBookRegisterCommand = new Command(OnWithdrawCashBookRegisterCommand);
        }

        async Task ExecuteLoadCashBookRegistersCommand()
        {
            IsBusy = true;

            try
            {
                CashBookRegisterList.Clear();
               
                var CashBookRegisters = await DataStore.GetItemsAsync(true);
                foreach (var CashBookRegister in CashBookRegisters)
                {
                    CashBookRegisterList.Add(CashBookRegister);
                }
                TotalDR = CashBookRegisters.Sum(P => P.DRAmount);
                TotalCR = CashBookRegisters.Sum(P => P.CRAmount);
                Balance = TotalCR - TotalDR;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public string itemId;
        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                //LoadItemId(value);
            }
        }
        public void OnAppearing()
        {
            IsBusy = true;
            SelectedCashBookRegister = null;
        }

        public CashBookRegister SelectedCashBookRegister
        {
            get => _selectedCashBookRegister;
            set
            {
                SetProperty(ref _selectedCashBookRegister, value);
                OnCashBookRegisterSelected(value);
            }
        }

        private async void OnDepositeCashBookRegisterCommand(object obj)
        {
            await Shell.Current.GoToAsync(nameof(CashRegisterPage));

        }
        private async void OnWithdrawCashBookRegisterCommand(object obj)
        {
            await Shell.Current.GoToAsync(nameof(CashWithdrawRegisterPage));
        }
       
        async void OnCashBookRegisterSelected(CashBookRegister CashBookRegister)
        {
            if (CashBookRegister == null)
                return;
            if(CashBookRegister.CRAmount>0)
            {
                  await Shell.Current.GoToAsync($"{nameof(CashRegisterPage)}?{nameof(CashBookRegisterViewModel.CashRegisterId)}={CashBookRegister.Id}");

            }
            else
            {
                await Shell.Current.GoToAsync($"{nameof(CashWithdrawRegisterPage)}?{nameof(CashBookRegisterViewModel.CashRegisterId)}={CashBookRegister.Id}");

            }
        


            // This will push the CashBookRegisterDetailPage onto the navigation stack
            //  await Shell.Current.GoToAsync($"{nameof(CashBookRegisterDetailPage)}?{nameof(CashBookRegisterDetailViewModel.CashBookRegisterId)}={CashBookRegister.Id}");
        }
    }
}