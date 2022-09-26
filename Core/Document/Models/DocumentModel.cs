using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Document.Models
{
    public class DocumentModel
    {
        public DocumentModel()
        {
            AltId = Guid.NewGuid().ToString();
        }
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string FileName { get; set; } = null!;
        public string MimeType { get; set; } = null!;
        public string Base64String { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public DateTime DateUploaded { get; set; }
        public string? ApplicationId { get; set; }
        public string AltId { get; set; }
        public bool? Profile { get; set; }
        public bool ViewOnly { get; set; }
    }
}
