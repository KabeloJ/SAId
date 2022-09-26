using Core.AccountDetails.Models;
using Core.IdApplication.Access;
using Core.IdApplication.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IdApplication
{
    public class IdApplicationServices : IIdApplicationServices
    {
        private readonly IIdApplicationAccess _data;
        public IdApplicationServices(IIdApplicationAccess data)
        {
            _data = data;
        }
        public AccountDetailsModel Save(AccountDetailsModel model, string userId, string applicationType)
        {
            if (model != null && userId != null)
            {
                model.ErrorMessage = null;
                if (applicationType != "Re-Issuing")
                {
                    if (model.IdNumber != null)
                    {
                        if (_data.ApplicationExist(model.IdNumber))
                        {
                            model.ErrorMessage = $"Application with Id Number/Passport {model.IdNumber} already exist.";
                            return model;
                        }
                    }
                    else
                    {
                        model.ErrorMessage = $"Id Number/Passport cannot be empty";
                        return model;
                    }
                }
                if (model.Id == null)
                {
                    model.FormExt = new FormExt()
                    {
                        ApplicationStatus = "Pending",
                        ApplicationType = applicationType,
                        SubmissionDate = DateTime.Now,
                    };
                    model.AppliedBy = userId;
                    model.Id = _data.Create(model);
                }
                else
                {
                    model.Id = _data.Update(model);
                }

            }
            return model;
        }
        public AccountDetailsModel SaveForLater(AccountDetailsModel model, string userId, string applicationType)
        {
            if (model != null && userId != null)
            {
                    model.FormExt = new FormExt()
                    {
                        ApplicationStatus = "Paused",
                        ApplicationType = applicationType,
                        SubmissionDate = DateTime.Now,
                    };
                    model.AppliedBy = userId;
                    if (model.Id == null)
                    {
                        model.Id = _data.Create(model);
                    }
                    else
                    {
                        model.Id = _data.Update(model);
                    }

            }
            return model;
        }

        public List<AccountDetailsModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<AccountDetailsModel> GetBySubmitter(string submitterId)
        {
            if (submitterId != null)
            {
                return _data.GetBySubmitter(submitterId);
            }
            return null;
        }

        public string Update(AccountDetailsModel model)
        {
            throw new NotImplementedException();
        }

        public AccountDetailsModel GetById(string applicationId)
        {
            return _data.GetById(applicationId);
        }
    }
}
