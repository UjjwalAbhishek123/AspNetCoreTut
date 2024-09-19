using FileUploadDataToExcelAspNetCore3.Models;
using Microsoft.AspNetCore.Mvc;

namespace FileUploadDataToExcelAspNetCore3.Controllers
{
    public class FileUploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //it will return file to user
        public IActionResult ExportToExcel()
        {
            //get employee data from DB
            //EFCoreDbContext dbContext = new EFCoreDbContext();

            // Using statement ensures proper disposal of the DbContext after use
            using (var dbContext = new EFCoreDbContext())
            {
                //it will have all the employees as List
                var employees = dbContext.Employees.ToList();

                //creating object of ExcelFileHandling where we created Excel sheet
                ExcelFileHandling excelFileHandling = new ExcelFileHandling();

                //calling CreateExcelFile()
                var stream = excelFileHandling.CreateExcelFile(employees);

                //Give name to Excel File
                string excelName = $"Employees-{Guid.NewGuid()}.xlsx";

                // 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' is the MIME type for Excel files
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
            }
        }

        public IActionResult DownloadExcel()
        {
            return View();
        }
    }
}
