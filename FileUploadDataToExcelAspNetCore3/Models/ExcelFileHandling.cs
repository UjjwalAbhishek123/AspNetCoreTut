using ClosedXML.Excel;

namespace FileUploadDataToExcelAspNetCore3.Models
{
    public class ExcelFileHandling
    {
        //this method will create an Excel sheet and store it in Memory Stream Object
        //MEMORY STREAM is a temporary memory space in which data is stored without saving it to the actual file system
        public MemoryStream CreateExcelFile(List<Employee> employees)
        {
            //create object of workbook i.e. Crates new Excel Workbook
            var workbook = new XLWorkbook();

            //add worksheet to workbook
            //worksheet name => Employees
            IXLWorksheet worksheet = workbook.Worksheets.Add("Employees");

            //create cells of excel sheet in worksheet
            //First row is Header Row
            worksheet.Cell(1, 1).Value = "Id";//row 1, col1 => Id column
            worksheet.Cell(1, 2).Value = "Name";//row 1, col 2
            worksheet.Cell(1, 3).Value = "Department";
            worksheet.Cell(1, 4).Value = "Salary";
            worksheet.Cell(1, 5).Value = "Position";
            worksheet.Cell(1, 6).Value = "Date Of Joining";

            //Data store from 2nd row
            int row = 2;

            //Loop through each employees and fill worksheet
            //for each employee increase row by 1
            foreach (var emp in employees)
            {
                worksheet.Cell(row, 1).Value = emp.Id; //row 2, col 1 => Fill with employee Id
                worksheet.Cell(row, 2).Value = emp.Name; //row 2, col 2 => Fill with employee Name
                worksheet.Cell(row, 3).Value = emp.Department; //row 2, col 3 => Fill with employee Department
                worksheet.Cell(row, 4).Value = emp.Salary; //row 2, col 4 => Fill with employee Salary
                worksheet.Cell(row, 5).Value = emp.Position; //row 2, col 5 => Fill with employee Position
                worksheet.Cell(row, 6).Value = emp.DateOfJoining; //row 2, col 6 => Fill with employee Date of joining

                //increase row with 1 for every new entry in next row
                row++;
            }

            //Create MemoryStream object
            var stream = new MemoryStream();

            //Save current workbook in MemoryStream object
            workbook.SaveAs(stream);

            //The Position property gets or sets the current position within the stream.
            //This is the next position a read, write, or seek operation will occur from.
            stream.Position = 0;

            return stream;
        }
    }
}
