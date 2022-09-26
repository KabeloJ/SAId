using Core.AccountDetails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AccountDetails.Access
{
    public interface IAccountDetailAccess
    {
        string Create(AccountDetailsModel model);
        string Update(AccountDetailsModel model);
        AccountDetailsModel Get(string userId);
    }
}
