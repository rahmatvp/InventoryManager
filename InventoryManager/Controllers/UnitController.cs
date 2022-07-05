using InventoryManager.Data;
using InventoryManager.Interfaces;
using InventoryManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace InventoryManager.Controllers
{
    public class UnitController : Controller
    {
        //public IActionResult Index()
        //{
        //    //List<Unit> units = _context.units.ToList();  
        //    //return View(units);

        //    List<Unit> units = _unitRepo.GetItems();  /*kl ini pake repository pattern*/
        //    return View(units);

        //}

        public IActionResult Index(string sortExpression="")
        {
            ViewData["sortParamName"] = "name";
            ViewData["sortParamDesc"] = "description";

            ViewData["SortIconName"] = "";
            ViewData["SortIconDesc"] = "";

            SortOrder sortOrder;
            string sortProperty;

            switch (sortExpression.ToLower())
            {
                case "name_desc":
                    sortOrder = SortOrder.Descending;
                    sortProperty = "name";
                    ViewData["sortParamName"] = "name";
                    ViewData["SortIconName"] = "fa fa-arrow-up";
                    break;
                case "description":
                    sortOrder = SortOrder.Ascending;
                    sortProperty = "description";
                    ViewData["sortParamDesc"] = "description_Desc";
                    ViewData["SortIconDesc"] = "fa fa-arrow-down";
                    break;
                case "description_desc":
                    sortOrder = SortOrder.Descending;
                    sortProperty = "description";
                    ViewData["sortParamDesc"] = "description";
                    ViewData["SortIconDesc"] = "fa fa-arrow-up";
                    break;
                default : //default order by name asc
                    sortOrder = SortOrder.Ascending;
                    sortProperty = "name";
                    ViewData["sortParamName"] = "name_desc";
                    ViewData["SortIconName"] = "fa fa-arrow-down";
                    break;

            }


            List<Unit> units = _unitRepo.GetItems(sortProperty, sortOrder);  /*kl ini pake repository pattern*/
            return View(units);

        }

        public IActionResult Create()
        {
            Unit unit = new Unit();
            return View(unit);
        }

        [HttpPost]
        public IActionResult Create(Unit unit)
        {
            try
            {
              unit = _unitRepo.Create(unit);
            }
            catch
            {

            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            //Unit unit = GetUnit(id);
            Unit unit = _unitRepo.GetUnit(id);
            return View(unit);
        }

        public IActionResult Edit(int id)
        {
            Unit unit = _unitRepo.GetUnit(id);
            return View(unit);
        }

        [HttpPost]
        public IActionResult Edit(Unit unit)
        {
            try
            {
                //_context.units.Update(unit);
                //_context.SaveChanges();

                unit = _unitRepo.Edit(unit);
            }
            catch
            {

            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Unit unit = _unitRepo.GetUnit(id);
            return View(unit);
        }

        [HttpPost]
        public IActionResult Delete(Unit unit)
        {
            try
            {
                //_context.units.Remove(unit);
                //_context.SaveChanges();
                unit = _unitRepo.Delete(unit);
            }
            catch
            {

            }

            return RedirectToAction(nameof(Index));
        }

        private readonly InventoryContext _context;
        private readonly IUnit _unitRepo;

       // public UnitController(InventoryContext context,IUnit unitRepo)
        public UnitController(IUnit unitRepo) /*diganti menjadi menggunakan repository pattern*/
        {
            //_context = context;
            _unitRepo = unitRepo;
        }

        //public Unit GetUnit(int id)
        //{
        //    Unit unit = _context.units.Where(u => u.Id == id).FirstOrDefault();

        //    return unit;
        //}


    }
}
