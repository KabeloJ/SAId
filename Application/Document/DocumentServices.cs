using Core.Document.Access;
using Core.Document.Application;
using Core.Document.Models;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Document
{
    public class DocumentServices : IDocumentServices
    {
        private readonly IDocumentAccess _data;
        public DocumentServices(IDocumentAccess access)
        {
            _data = access;
        }
        public DocumentModel Create(DocumentModel model)
        {
            if (model != null)
            {
                model.DateUploaded = DateTime.Now;
                model.Id = _data.Create(model);
            }
            return model;
        }

        public void Delete(string id)
        {
            _data.Delete(id);
        }

        public DocumentModel Get(string id)
        {
            return _data.Get(id);
        }

        public List<DocumentModel> GetByApplicationId(string appId)
        {
            return _data.GetByApplicationId(appId);
        }

        public async Task<DocumentModel> UploadFile(IBrowserFile e, DocumentModel model)
        {
            try
            {
                var file = e;
                if (file == null)
                {
                    return model;
                }
                else
                {
                    using (var ms = new MemoryStream())
                    {
                        var fileData = file.OpenReadStream(file.Size);
                        await fileData.CopyToAsync(ms);

                        model.Base64String = Convert.ToBase64String(ms.ToArray());
                        model.MimeType = file.ContentType;
                        model.FileName = file.Name;

                        return model;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
                return model;
            }
        }
    }
}
