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

        public CashBookRegisterStore()
        {
            //cashBookRegisters = new List<CashBookRegister>();

            cashBookRegisters = new List<CashBookRegister>()
            {
                new CashBookRegister { Id = Guid.NewGuid().ToString(),TransactionDate=DateTime.Now, Description="This is an CashBookRegister description." ,CRAmount=500},
                new CashBookRegister { Id = Guid.NewGuid().ToString(), TransactionDate=DateTime.Now,Description = "Second CashBookRegister" ,DRAmount=200 },
                new CashBookRegister { Id = Guid.NewGuid().ToString(),  TransactionDate=DateTime.Now,Description="This is an CashBookRegister description.",CRAmount=300 },
                new CashBookRegister { Id = Guid.NewGuid().ToString(), TransactionDate=DateTime.Now, Description="This is an CashBookRegister description." ,DRAmount=150}
            };
        }

        public async Task<bool> AddItemAsync(CashBookRegister item)
        {
            cashBookRegisters.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(CashBookRegister item)
        {
            var oldItem = cashBookRegisters.Where((CashBookRegister arg) => arg.Id == item.Id).FirstOrDefault();
            cashBookRegisters.Remove(oldItem);
            cashBookRegisters.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = cashBookRegisters.Where((CashBookRegister arg) => arg.Id == id).FirstOrDefault();
            cashBookRegisters.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<CashBookRegister> GetItemAsync(string id)
        {
            return await Task.FromResult(cashBookRegisters.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<CashBookRegister>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(cashBookRegisters);
        }
    }
}