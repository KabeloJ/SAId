using System;
using System.Collections.Generic;

namespace Access.Context
{
    public partial class Document
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string FileName { get; set; } = null!;
        public string MimeType { get; set; } = null!;
        public string Base64String { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public DateTime DateUploaded { get; set; }
        public string? ApplicationId { get; set; }
        public bool? Profile { get; set; }
    }
}
