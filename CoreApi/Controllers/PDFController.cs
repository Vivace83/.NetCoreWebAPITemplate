using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoreApi.Helpers;
using CoreApi.Utility;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class PDFController : Controller
    {
        private IConverter _converter;

        public PDFController(IConverter converter)
        {
            this._converter = converter;
        }

        [AllowAnonymous] //FOR_TESTING
        [HttpGet]
        public IActionResult GetAllApplicationsPDF(int id)
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "Application Document"
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = TemplateGenerator.GetHTMLString(),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                HeaderSettings = { },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Right = "Page [page] of [toPage]" }
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            var file = _converter.Convert(pdf);
            return File(file, "application/pdf");
        }
    }
}
