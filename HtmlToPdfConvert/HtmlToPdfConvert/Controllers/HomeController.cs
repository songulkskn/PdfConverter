using HtmlToPdfConvert.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HtmlToPdfConvert.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

     public IActionResult GeneratePdf(string html)
        {

            html = html.Replace("StrTag", "<").Replace("EndTag", ">");
            HtmlToPdf ohtmlToPdf = new HtmlToPdf();
            PdfDocument pdfDocument = ohtmlToPdf.ConvertHtmlString(html);
            byte[] pdf = pdfDocument.Save();
            pdfDocument.Close();
            return File(

                pdf,
                "application/pdf",
                "StudentList.pdf"
                ) ; 
        }
    }
}
