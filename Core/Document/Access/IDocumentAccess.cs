using Core.Document.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Document.Access
{
    public interface IDocumentAccess
    {
        string Create(DocumentModel model);
        void Delete(string id);
        DocumentModel Get(string id);
        List<DocumentModel> GetByApplicationId(string id);
    }
}
