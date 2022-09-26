using Core.AccountDetails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AccountDetails.Application
{
    public interface IAccountDetailsServices
    {
        AccountDetailsModel Save(AccountDetailsModel model, string? UserId, bool applyingFormSomeone);
        AccountDetailsModel Save(AccountDetailsModel model, string? UserId, bool applyingFormSomeone, bool savingForLater = false);
        AccountDetailsModel Get(string UserId); 
    }
}
