using CashBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashBook.Services
{
    public class CashBookRegisterStore : IDataStore<CashBookRegister>
    {
        readonly List<CashBookRegister> cashBookRegisters;
        public static CashBookRegisterDatabase database;
        CashBookRegisterDatabase cashBookRegisterDatabase = new CashBookRegisterDatabase();
        public CashBookRegisterStore()
        {
          
        }

        public async Task<bool> AddItemAsync(CashBookRegister item)
        {
            database= await CashBookRegisterDatabase.Instance;
            await database.SaveItemAsync(item,true);        
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(CashBookRegister item)
        {
            database = await CashBookRegisterDatabase.Instance;        
            await database.SaveItemAsync(item, false);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            database = await CashBookRegisterDatabase.Instance;
            await database.DeleteItemAsync(await GetItemAsync(id));
            return await Task.FromResult(true);
        }

        public async Task<CashBookRegister> GetItemAsync(string id)
        {
            database = await CashBookRegisterDatabase.Instance;
            return await database.GetItemAsync(id);
        }

        public async Task<IEnumerable<CashBookRegister>> GetItemsAsync(bool forceRefresh = false)
        {
            database = await CashBookRegisterDatabase.Instance;
            return await  database.GetItemsAsync();           
        }
    }
}