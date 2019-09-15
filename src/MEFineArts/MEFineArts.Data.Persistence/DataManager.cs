using MEFineArts.Data.Persistence.DataModels;
using MEFineArts.Data.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MEFineArts.Data.Persistence
{
    public class DataManager : IDataManager
    {
        private IRepository repository;

        public DataManager(IRepository argRepository)
        {
            repository = argRepository;
        }

        public async Task<Guid?> GetUser(string userName, string password)
        {
            try
            {
                return await repository.GetUser(userName, password);
            } 
            catch (Exception ex)
            {
                //log
            }

            return null;
        }

        public async Task<List<Content>> GetContent()
        {
            try
            {
                return await repository.GetContent();
            }
            catch (Exception ex)
            {
                //log
            }

            return null;
        }
    }
}
