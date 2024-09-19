using iText.Kernel.Pdf;
using iText.Kernel.XMP.Impl;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace FileHandlingGeneratePDFaspNetCore.Models
{
    public class PDFService
    {
        public byte[] GeneratePDF(Invoice invoice)
        {
            //Define your memory stream which will temporarily hold PDF
            using (MemoryStream stream = new MemoryStream())
            {
                //Initialize PDF writer
                //Writes PDF data to specified MemoryStream
                //used for creating PDF files
                PdfWriter writer = new PdfWriter(stream);

                //Initialize PDF document
                //represents the PDF document you are creating or manipulating
                PdfDocument pdf = new PdfDocument(writer);

                //Initialize document
                //provides a high-level API for adding content to a PDF document
                //It simplifies the process of adding elements such as paragraphs, tables, images, and more to the PDF
                Document document = new Document(pdf);

                //Add content to the Document
                //HEADER row
                document.Add(new Paragraph("Invoice")
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(20));

                //Invoice data
                document.Add(new Paragraph($"Invoice Number: {invoice.InvoiceNumber}"));
                document.Add(new Paragraph($"Date: {invoice.Date.ToShortDateString()}"));
                document.Add(new Paragraph($"Customer Name: {invoice.CustomerName}"));
                document.Add(new Paragraph($"Payment Mode: {invoice.PaymentMode}"));

                //Creating Table in PDF for invoice items
                Table table = new Table(new float[] { 3, 1, 1, 1 });
                //constructor takes an array of float values that define the column widths of the table
                //new float[] { 3, 1, 1, 1 } part specifies the widths of the columns in the table.
                //3: The width of the first column is set to 3 units(e.g., inches, centimeters, depending on the measurement units used).
                //1: The widths of the second, third, and fourth columns are set to 1 unit each.

                //Set the width of the table to occupy 100% of the available width in the PDF document’s page.
                table.SetWidth(UnitValue.CreatePercentValue(100));

                //Add a header cell with the text "Item Name" to the table.
                table.AddHeaderCell("Item Name");
                table.AddHeaderCell("Quantity");
                table.AddHeaderCell("Unit Price");
                table.AddHeaderCell("Total");

                //populating a table in a PDF document with data from an invoice.Items collection
                foreach (var item in invoice.Items)
                {
                    //Adds a cell to the table for the item's name.
                    table.AddCell(new Cell().Add(new Paragraph(item.ItemName)));

                    //Adds a cell for the item's quantity.
                    table.AddCell(new Cell().Add(new Paragraph(item.Quantity.ToString())));

                    //Adds a cell for the item's unit price, formatted as currency.
                    table.AddCell(new Cell().Add(new Paragraph(item.UnitPrice.ToString("C"))));

                    //Adds a cell for the item's total price, formatted as currency.
                    table.AddCell(new Cell().Add(new Paragraph(item.TotalPrice.ToString("C"))));
                }

                //Add Table to PDF
                document.Add(table);

                //Total Amount
                document.Add(new Paragraph($"Total Amount: {invoice.TotalAmount.ToString("C")}"))
                    .SetTextAlignment(TextAlignment.RIGHT);

                //Close the document
                document.Close();

                return stream.ToArray();
            }
        }
    }
}
