using Core.AccountDetails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IdApplication.Application
{
    public interface IIdApplicationServices
    {
        AccountDetailsModel Update(AccountDetailsModel model, string action);
        AccountDetailsModel GetById(string applicationId);
        AccountDetailsModel Save(AccountDetailsModel model, string userId, string applicationType);
        AccountDetailsModel SaveForLater(AccountDetailsModel model, string userId, string applicationType);
        List<AccountDetailsModel> GetAll();
        List<AccountDetailsModel> GetBySubmitter(string submitterId);

    }
}
