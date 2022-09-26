using Core.Document.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SAId.Web.Pages
{
    public class DownloadModel : PageModel
    {
        private readonly IDocumentServices _services;
        public DownloadModel(IDocumentServices services)
        {
            _services = services;
        }
        public IActionResult OnGet(string id)
        {
            var doc = _services.Get(id);
            if (doc != null)
            {
                return File(Convert.FromBase64String(doc.Base64String), doc.MimeType, doc.FileName);
            }
            return null;
        }
    }
}
