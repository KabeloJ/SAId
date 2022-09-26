using Core.AccountDetails.Access;
using Core.AccountDetails.Application;
using Core.AccountDetails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AccountDetails
{
    public class AccountDetailsServices : IAccountDetailsServices
    {
        IAccountDetailAccess _data;
        public AccountDetailsServices(IAccountDetailAccess data)
        {
            _data = data;
        }
        public AccountDetailsModel Get(string UserId)
        {
            var data =  _data.Get(UserId);
            if (data != null)
            {
                data.isPostalAddressSameAsPhysical = (Boolean)data.IsPostalAddressSameAsPhysical;
            }
            return data;
        }
        bool ModelIsValid(AccountDetailsModel model)
        {

            model.Errors = new List<string>();
            if (string.IsNullOrEmpty(model.IdNumber) || string.IsNullOrWhiteSpace(model.IdNumber))
            {
                model.Errors.Add("Passport / Id Number is required");
            }
            if (model.Nationality == "South African" && model.IdNumber != null && model.IdNumber.Length != 13)
            {
                model.Errors.Add("Id Number must be 13 numbers");
            }
            if (!model.isPostalAddressSameAsPhysical)
            {
                if (string.IsNullOrEmpty(model.PostalStreetNumber) || string.IsNullOrWhiteSpace(model.PostalStreetNumber))
                {
                    model.Errors.Add("Postal street name & number are required");
                }
                if (string.IsNullOrEmpty(model.PostalSuburb) || string.IsNullOrWhiteSpace(model.PostalSuburb))
                {
                    model.Errors.Add("Postal Suburb is required");
                }
                if (string.IsNullOrEmpty(model.PostalCity) || string.IsNullOrWhiteSpace(model.PostalCity))
                {
                    model.Errors.Add("Postal City is required");
                }
                if (string.IsNullOrEmpty(model.PostalPostalCode) || string.IsNullOrWhiteSpace(model.PostalPostalCode))
                {
                    model.Errors.Add("Postal Postal code is required");
                }
                if (string.IsNullOrEmpty(model.PostalCountryCode) || string.IsNullOrWhiteSpace(model.PostalCountryCode))
                {
                    model.Errors.Add("Country code is required");
                }
            }
            if (model.Errors.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public AccountDetailsModel Save(AccountDetailsModel model, string? UserId, bool applyingFormSomeone)
        {
            if (model != null)
            {
                if (!ModelIsValid(model))
                {
                    return model;
                }

                model.IsPostalAddressSameAsPhysical = model.isPostalAddressSameAsPhysical;
                if (model.AspNetUserId == null)
                {
                    //Create
                    if (applyingFormSomeone)
                    {
                        model.AspNetUserId = model.IdNumber;
                    }
                    else
                    {
                        model.AspNetUserId = UserId;
                    }
                    model.AspNetUserId = _data.Create(model);
                    return model;
                }
                else
                {
                    //Update
                    model.AspNetUserId = _data.Update(model);
                    return model;
                }
            }
            return model;
        }

        public AccountDetailsModel Save(AccountDetailsModel model, string? UserId, bool applyingFormSomeone, bool savingForLater = false)
        {
            if (model != null && savingForLater)
            {
                model.IsPostalAddressSameAsPhysical = model.isPostalAddressSameAsPhysical;
                if (model.AspNetUserId == null)
                {
                    //Create
                    if (applyingFormSomeone)
                    {
                        model.AspNetUserId = model.IdNumber;
                    }
                    else
                    {
                        model.AspNetUserId = UserId;
                    }
                    model.AspNetUserId = _data.Create(model);
                    return model;
                }
                else
                {
                    //Update
                    model.AspNetUserId = _data.Update(model);
                    return model;
                }
            }
            return model;
        }
    }
}
