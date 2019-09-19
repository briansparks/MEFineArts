﻿using MEFineArts.Data.Persistence.DataModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MEFineArts.Data.Persistence.Interfaces
{
    public interface IDataManager
    {
        Task<Guid?> GetUser(string userName, string password);
        Task<List<Content>> GetContent();
        Task<string> InsertOrUpdateContent(string title, string page, string contentType, string value);
    }
}
