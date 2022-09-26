using Access.Context;
using AutoMapper;
using Core.AccountDetails.Models;
using Core.Document.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Access
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AccountDetail, AccountDetailsModel>().ReverseMap();
            CreateMap<Document, DocumentModel>().ReverseMap();
            CreateMap<ApplicationForm, AccountDetailsModel>().ReverseMap();
        }
    }
}
