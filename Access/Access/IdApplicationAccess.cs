using Access.Context;
using AutoMapper;
using Core.AccountDetails.Models;
using Core.IdApplication.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Access.Access
{
    public class IdApplicationAccess : IIdApplicationAccess
    {
        private readonly IMapper _map;
        public IdApplicationAccess(IMapper map)
        {
            _map = map;
        }

        public bool ApplicationExist(string? idNumber)
        {
            using (var db = new HomeAffairsDBContext())
            {
                if (idNumber != null)
                {
                    var c = db.ApplicationForms.Where(x => x.IdNumber == idNumber).Count();
                    if (c > 0)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public string Create(AccountDetailsModel model)
        {
            using (var db = new HomeAffairsDBContext())
            {
                var data = _map.Map<ApplicationForm>(model);
                data.Id = Guid.NewGuid().ToString();
                if (model.FormExt != null)
                {
                    data.ApplicationType = model.FormExt.ApplicationType;
                    data.ApplicationStatus = model.FormExt.ApplicationStatus;
                    data.SubmissionDate = model.FormExt.SubmissionDate;
                    data.ApprovedDate = model.FormExt.ApprovedDate;
                    data.ApprovedBy = model.FormExt.ApprovedBy;
                }
                db.ApplicationForms.Add(data);
                db.SaveChanges();
                return data.Id;

            }
        }

        public List<AccountDetailsModel> GetAll()
        {
            using (var db = new HomeAffairsDBContext())
            {
                var data = db.ApplicationForms.AsQueryable();
                var models=  _map.Map<List<AccountDetailsModel>>(data);
                if (models != null)
                {
                    foreach (var item in models)
                    {
                        item.FormExt = new FormExt();
                        item.FormExt.ApplicationType = data.Where(x=>x.Id == item.Id).FirstOrDefault()?.ApplicationType;
                        item.FormExt.ApplicationStatus = data.Where(x=>x.Id == item.Id).FirstOrDefault()?.ApplicationStatus;
                        item.FormExt.SubmissionDate = data.Where(x=>x.Id == item.Id).FirstOrDefault().SubmissionDate;
                        item.FormExt.ApprovedDate = data.Where(x=>x.Id == item.Id).FirstOrDefault()?.ApprovedDate;
                        item.FormExt.ApprovedBy = data.Where(x=>x.Id == item.Id).FirstOrDefault()?.ApprovedBy;
                    }

                }
                return models;
            }
        }

        public AccountDetailsModel GetById(string applicationId)
        {
            using (var db = new HomeAffairsDBContext())
            {
                var data = db.ApplicationForms.Find(applicationId);
                var item = _map.Map<AccountDetailsModel>(data);
                if (data != null)
                {

                    item.FormExt = new FormExt();
                    item.FormExt.ApplicationType = data.ApplicationType;
                    item.FormExt.ApplicationStatus = data.ApplicationStatus;
                    item.FormExt.SubmissionDate = data.SubmissionDate;
                    item.FormExt.ApprovedDate = data.ApprovedDate;
                    item.FormExt.ApprovedBy = data.ApprovedBy;
                }
                return item;
            }
        }

        public List<AccountDetailsModel> GetBySubmitter(string submitterId)
        {
            using (var db = new HomeAffairsDBContext())
            {
                var data = db.ApplicationForms.Where(x=>x.AppliedBy == submitterId).ToList();
                var models = _map.Map<List<AccountDetailsModel>>(data);
                if (models != null)
                {
                    foreach (var item in models)
                    {
                        item.FormExt = new FormExt();
                        item.FormExt.ApplicationType = data.Where(x => x.Id == item.Id).FirstOrDefault()?.ApplicationType;
                        item.FormExt.ApplicationStatus = data.Where(x => x.Id == item.Id).FirstOrDefault()?.ApplicationStatus;
                        item.FormExt.SubmissionDate = data.Where(x => x.Id == item.Id).FirstOrDefault().SubmissionDate;
                        item.FormExt.ApprovedDate = data.Where(x => x.Id == item.Id).FirstOrDefault()?.ApprovedDate;
                        item.FormExt.ApprovedBy = data.Where(x => x.Id == item.Id).FirstOrDefault()?.ApprovedBy;
                    }

                }
                return models;
            }
        }

        public string Update(AccountDetailsModel model)
        {
            using (var db = new HomeAffairsDBContext())
            {
                var data = _map.Map<ApplicationForm>(model);
                if (model.FormExt != null)
                {
                    data.ApplicationType = model.FormExt.ApplicationType;
                    data.ApplicationStatus = model.FormExt.ApplicationStatus;
                    data.SubmissionDate = model.FormExt.SubmissionDate;
                    data.ApprovedDate = model.FormExt.ApprovedDate;
                    data.ApprovedBy = model.FormExt.ApprovedBy;
                }
                var target = db.ApplicationForms.Find(data.Id);
                db.Entry(target).CurrentValues.SetValues(data);
                db.SaveChanges();
                return data.Id;

            }
        }
    }
}
