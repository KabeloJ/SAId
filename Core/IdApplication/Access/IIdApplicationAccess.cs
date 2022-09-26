using Core.AccountDetails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IdApplication.Access
{
    public interface IIdApplicationAccess
    {
        string Create(AccountDetailsModel model);
        string Update(AccountDetailsModel model);
        List<AccountDetailsModel> GetAll();
        List<AccountDetailsModel> GetBySubmitter(string submitterId);
        AccountDetailsModel GetById(string applicationId);
        bool ApplicationExist(string? idNumber);
    }
}
