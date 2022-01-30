using CashBook.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CashBook.Services
{
    public class CashBookRegisterDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<CashBookRegisterDatabase> Instance = new AsyncLazy<CashBookRegisterDatabase>(async () =>
        {
            var instance = new CashBookRegisterDatabase();
            CreateTableResult result = await Database.CreateTableAsync<CashBookRegister>();
            return instance;
        });

        public CashBookRegisterDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }
        public Task<List<CashBookRegister>> GetItemsAsync()
        {
            return Database.Table<CashBookRegister>().ToListAsync();
        }

        public Task<List<CashBookRegister>> GetItemsNotDoneAsync()
        {
            // SQL queries are also possible
            return Database.QueryAsync<CashBookRegister>("SELECT * FROM [CashBookRegister] WHERE [Done] = 0");
        }

        public Task<CashBookRegister> GetItemAsync(string id)
        {
            return Database.Table<CashBookRegister>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(CashBookRegister item,bool isAdd)
        {
            if (!isAdd)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(CashBookRegister item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
