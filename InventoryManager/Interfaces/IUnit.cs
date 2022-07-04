using InventoryManager.Models;

namespace InventoryManager.Interfaces
{
    public interface IUnit
    {
        List<Unit> GetItems();

        Unit GetUnit(int id);

        Unit Create(Unit unit);

        Unit Edit(Unit unit);

        Unit Delete(Unit unit);
    }
}
