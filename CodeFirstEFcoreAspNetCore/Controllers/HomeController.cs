using CodeFirstEFcoreAspNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CodeFirstEFcoreAspNetCore.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //we will use this object to access DbSet(Database Table)
        private readonly StudentDbContext _studentDb;

        public HomeController(StudentDbContext studentDb)
        {
            _studentDb = studentDb;
        }

        //making methods asynchrnous
        public async Task<IActionResult> Index()
        {
            //Access Students data from DbSet as List
            var stdData = await _studentDb.Students.ToListAsync();

            //pass stdData to view
            return View(stdData);
        }

        //Create Method GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        //when user clicks Create button after filling data, data will be received heres
        //when form submitted data will get stored in "std" object
        [HttpPost]
        [ValidateAntiForgeryToken] //prevent cross site request forgery
        public async Task<IActionResult> Create(Student std)
        {
            //check if modelstate is valid, then add/insert created data to DbSet i.e Students Table
            if (ModelState.IsValid)
            {
                await _studentDb.Students.AddAsync(std);
                await _studentDb.SaveChangesAsync();

                TempData["insert_success"] = "Data inserted...";

                //after inserting return to action Index() of Home Controller
                return RedirectToAction("Index", "Home");
            }
            //on error atleast return student details
            return View(std);
        }

        //GET method Details
        public async Task<IActionResult> Details(int? id)
        {
            //Checking if id == null, or _studentDB.Students == null, then return NotFound()
            if(id==null || _studentDb.Students == null)
            {
                return NotFound();
            }

            //Access Students data from DbSet as List
            //checking if the Id is present in Model, then send the row related to id in stdData
            var stdData = await _studentDb.Students.FirstOrDefaultAsync(x => x.Id == id);

            //checking if stdData is null, that is no value
            if(stdData == null)
            {
                return NotFound();
            }

            //pass stdData to view
            return View(stdData);
        }

        //GET Edit method
        public async Task<IActionResult> Edit(int? id)
        {
            //Checking if id == null, or _studentDB.Students == null, then return NotFound()
            if (id == null || _studentDb.Students == null)
            {
                return NotFound();
            }

            var stdData = await _studentDb.Students.FindAsync(id);

            //checking if stdData is null, that is no value
            if (stdData == null)
            {
                return NotFound();
            }

            //pass stdData to view
            return View(stdData);
        }

        //POST Edit method => when Save button is clicked
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Student std)
        {
            //check if id parameter is not equal to Id property of Student class, give NotFound
            if(id!= std.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //if model is valid, then update the std object in Students table
                _studentDb.Students.Update(std);

                await _studentDb.SaveChangesAsync();

                TempData["update_success"] = "Data updated...";

                return RedirectToAction("Index", "Home");
            }

            return View(std);
        }

        //GET Detete method
        public async Task<IActionResult> Delete(int? id)
        {
            //Checking if id == null, or _studentDB.Students == null, then return NotFound()
            if (id == null || _studentDb.Students == null)
            {
                return NotFound();
            }

            //checking if the Id is present in Model, then send the row related to id in stdData
            var stdData = await _studentDb.Students.FirstOrDefaultAsync(x => x.Id == id);

            //checking if stdData is null, that is no value
            if (stdData == null)
            {
                return NotFound();
            }

            return View(stdData);
        }

        //POST Detete method
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            //checking if the Id is present in Model, then send the row related to id in stdData
            var stdData = await _studentDb.Students.FindAsync(id);

            //checking if stdData is null, that is no value
            if (stdData != null)
            {
                //if stdData is not null, i.e. data is present that we want to delete, then remove from table Students and update database
                _studentDb.Students.Remove(stdData);
            }
            await _studentDb.SaveChangesAsync();

            TempData["delete_success"] = "Data deteted...";

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
