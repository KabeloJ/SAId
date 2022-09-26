using Access.Context;
using AutoMapper;
using Core.AccountDetails.Access;
using Core.AccountDetails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Access.Access
{
    public class AccountDetailAccess : IAccountDetailAccess
    {
        IMapper _map;
        public AccountDetailAccess(IMapper map)
        {
            _map = map;
        }

        public string Create(AccountDetailsModel model)
        {
            using (var db = new HomeAffairsDBContext())
            {
                var data = _map.Map<AccountDetail>(model);
                db.AccountDetails.Add(data);
                db.SaveChanges();
                return model.AspNetUserId;
            }
        }

        public AccountDetailsModel Get(string userId)
        {
            using (var db = new HomeAffairsDBContext())
            {
                var data = db.AccountDetails.Where(x => x.AspNetUserId == userId).FirstOrDefault();
                return _map.Map<AccountDetailsModel>(data);
            }
        }

        public string Update(AccountDetailsModel model)
        {
            using (var db = new HomeAffairsDBContext())
            {
                var data = _map.Map<AccountDetail>(model);
                var target = db.AccountDetails.Where(x => x.AspNetUserId == model.AspNetUserId).FirstOrDefault();
                db.Entry(target).CurrentValues.SetValues(data);
                db.SaveChanges();
                return data.AspNetUserId;
            }
        }
    }
}
