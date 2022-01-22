using CashBook.Models;
using CashBook.Services;
using CashBook.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CashBook.ViewModels
{
    public class CashBookRegistersViewModel : BaseViewModel
    {
        private CashBookRegister _selectedCashBookRegister;

        public ObservableCollection<CashBookRegister> CashBookRegisterList { get; }
        public Command LoadCashBookRegistersCommand { get; }
        public Command AddCashBookRegisterCommand { get; }
        public Command<CashBookRegister> CashBookRegisterTapped { get; }
        public IDataStore<CashBookRegister> DataStore => DependencyService.Get<IDataStore<CashBookRegister>>();

        public CashBookRegistersViewModel()
        {
            Title = "CashBookRegister";
            CashBookRegisterList = new ObservableCollection<CashBookRegister>();
            LoadCashBookRegistersCommand = new Command(async () => await ExecuteLoadCashBookRegistersCommand());

            CashBookRegisterTapped = new Command<CashBookRegister>(OnCashBookRegisterSelected);

            AddCashBookRegisterCommand = new Command(OnAddCashBookRegister);
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

        private async void OnAddCashBookRegister(object obj)
        {
            //await Shell.Current.GoToAsync(nameof(NewCashBookRegisterPage));
        }

        async void OnCashBookRegisterSelected(CashBookRegister CashBookRegister)
        {
            if (CashBookRegister == null)
                return;

            // This will push the CashBookRegisterDetailPage onto the navigation stack
          //  await Shell.Current.GoToAsync($"{nameof(CashBookRegisterDetailPage)}?{nameof(CashBookRegisterDetailViewModel.CashBookRegisterId)}={CashBookRegister.Id}");
        }
    }
}