using Core.Document.Models;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Document.Application
{
    public interface IDocumentServices
    {
        Task<DocumentModel> UploadFile(IBrowserFile e, DocumentModel model);
        DocumentModel Get(string id);
        List<DocumentModel> GetByApplicationId(string appId);
        DocumentModel Create(DocumentModel model);
        void Delete(string id);

    }
}
