using InventoryManager.Data;
using InventoryManager.Interfaces;
using InventoryManager.Models;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace InventoryManager.Repositories
{
    public class UnitRepository : IUnit
    {
        private readonly InventoryContext _context;

        public UnitRepository(InventoryContext context)
        {
            _context = context;
        }

        public Unit Create(Unit unit)
        {
            _context.units.Add(unit);
            _context.SaveChanges();
            return unit;
        }

        public Unit Delete(Unit unit)
        {
            _context.units.Remove(unit);
            _context.SaveChanges();
            return unit;
        }

        //public List<Unit> GetItems()
        //{
        //    List<Unit> units = _context.units.ToList();
        //    return units;
        //}
        public List<Unit> GetItems(string SortProperty, SortOrder sortOrder) //nambah sorting
        {
            List<Unit> units = _context.units.ToList();

            if (SortProperty.ToLower() == "name") 
            {
                if (sortOrder== SortOrder.Ascending)
                {
                    units =units.OrderBy(n => n.Name).ToList();
                }
                else
                {
                    units = units.OrderByDescending(n => n.Name).ToList();
                }
            }
            else
            {
                if (sortOrder == SortOrder.Ascending)
                {
                    units = units.OrderBy(n => n.Description).ToList();
                }
                else
                {
                    units = units.OrderByDescending(n => n.Description).ToList();
                }

            }

            return units;
        }

        public Unit GetUnit(int id)
        {
            Unit unit = _context.units.Where(u => u.Id == id).FirstOrDefault();

            return unit;
        }

        public Unit Edit(Unit unit)
        {
            _context.units.Update(unit);
            _context.SaveChanges();
            return unit;
        }
    }
}
