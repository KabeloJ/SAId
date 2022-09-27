using Core.AccountDetails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Email.Application
{
    public interface IEmailServices
    {
        Task SendEmail(AccountDetailsModel model);
    }
}
