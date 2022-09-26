using Access.Context;
using AutoMapper;
using Core.Document.Access;
using Core.Document.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Access.Access
{

    public class DocumentAccess : IDocumentAccess
    {
        private readonly IMapper _map;
        public DocumentAccess(IMapper map)
        {
            _map = map;
        }
        public string Create(DocumentModel model)
        {
            using (var db = new HomeAffairsDBContext())
            {
                var data = _map.Map<Document>(model);
                data.Id = Guid.NewGuid().ToString();
                db.Documents.Add(data);
                db.SaveChanges();
                return data.Id;

            }
        }
        public DocumentModel Get(string id)
        {
            using (var db = new HomeAffairsDBContext())
            {
                var data = db.Documents.Find(id);
                return _map.Map<DocumentModel>(data);
            }
        }
        public List<DocumentModel> GetByApplicationId(string id)
        {
            using (var db = new HomeAffairsDBContext())
            {
                var data = db.Documents.Where(x => x.ApplicationId == id).ToList();
                return _map.Map<List<DocumentModel>>(data);
            }
        }
        public void Delete(string id)
        {
            using (var db = new HomeAffairsDBContext())
            {
                var data = db.Documents.Find(id);
                db.Documents.Remove(data);
                db.SaveChanges();
            }
        }
    }
}
