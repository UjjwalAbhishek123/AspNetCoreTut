using FileHandlingGeneratePDFaspNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace FileHandlingGeneratePDFaspNetCore.Controllers
{
    public class FileUploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //generate Invoice PDF using iText
        public IActionResult GenerateInvoicePDF()
        {
            //Sample invoice data
            //In Real-time you will get the data from the database
            var invoice = new Invoice
            {
                InvoiceNumber = "INV-DOTNET-100",
                Date = DateTime.Now,
                CustomerName = "Ujjwal Abhishek",
                Items = new List<InvoiceItem>
                {
                    new InvoiceItem { ItemName = "Item 1", Quantity = 2, UnitPrice = 15.0m },
                    new InvoiceItem { ItemName = "Item 2", Quantity = 3, UnitPrice = 10.0m },
                    new InvoiceItem { ItemName = "Item 3", Quantity = 1, UnitPrice = 35.0m }
                },
                PaymentMode = "COD"
            };

            //Sets the Total Amount
            invoice.TotalAmount = invoice.Items.Sum(x => x.TotalPrice);

            //create object of PDFService
            PDFService pdfService = new PDFService();

            //Call GeneratePDF() of PDFService passing Invoice Data
            var pdfFile = pdfService.GeneratePDF(invoice);

            //return PDF File
            return File(pdfFile, "application/pdf", "Invoice.pdf");
        }

        [Route("fileupload/download-pdf")]
        public IActionResult DownloadPDF()
        {
            return View("DownloadPDF");
        }

        //generate Password Protected Invoice PDF
        public IActionResult GeneratePasswordProtectedInvoicePDF()
        {
            //Sample invoice data
            //In Real-time you will get the data from the database
            var invoice = new Invoice
            {
                InvoiceNumber = "INV-DOTNET-100",
                Date = DateTime.Now,
                CustomerName = "Ujjwal Abhishek",
                Items = new List<InvoiceItem>
                {
                    new InvoiceItem { ItemName = "Item 1", Quantity = 2, UnitPrice = 15.0m },
                    new InvoiceItem { ItemName = "Item 2", Quantity = 3, UnitPrice = 10.0m },
                    new InvoiceItem { ItemName = "Item 3", Quantity = 1, UnitPrice = 35.0m }
                },
                PaymentMode = "COD"
            };

            //Sets the Total Amount
            invoice.TotalAmount = invoice.Items.Sum(x => x.TotalPrice);

            //create object of PDFService
            PDFService pdfService = new PDFService();

            //Call GeneratePDF() of PDFService passing Invoice Data
            var pdfFile = pdfService.GeneratePasswordProtectedPDF(invoice);

            //return PDF File
            return File(pdfFile, "application/pdf", "PasswordProtectedInvoice.pdf");
        }

        [Route("fileupload/download-password-protected-pdf")]
        public IActionResult DownloadPasswordProtectedPDF()
        {
            return View("DownloadPasswordProtectedPDF");
        }
    }
}
