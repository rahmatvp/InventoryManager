using InventoryManager.Models;
using Microsoft.Data.SqlClient;

namespace InventoryManager.Interfaces
{
    public interface IUnit
    {
        //List<Unit> GetItems();
        List<Unit> GetItems(string SortProperty, SortOrder sortOrder);

        Unit GetUnit(int id);

        Unit Create(Unit unit);

        Unit Edit(Unit unit);

        Unit Delete(Unit unit);
    }
}
