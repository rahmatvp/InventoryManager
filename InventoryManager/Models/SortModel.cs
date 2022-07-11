using Microsoft.Data.SqlClient;

namespace InventoryManager.Models
{
    public class SortModel
    {
        public string sortProperty { get; set; }
        public SortOrder sortOrder { get; set; }

        private List<SortableColumn> sortableColumns = new List<SortableColumn>();

        public void AddColumn(string colname)
        {
            SortableColumn tmp = this.sortableColumns.Where(c => c.columnName.ToLower() == colname.ToLower()).SingleOrDefault();
            if (tmp == null)
                sortableColumns.Add(new SortableColumn() { columnName = colname });
        }
         
        public SortableColumn GetColumn(string colname)
        {
            SortableColumn tmp = this.sortableColumns.Where(c => c.columnName.ToLower() == colname.ToLower()).SingleOrDefault();
            if (tmp == null)
                sortableColumns.Add(new SortableColumn() { columnName = colname });

            return tmp;
        }

        public void ApplySort(string sortExpression)
        {
            //ViewData["sortParamName"] = "name";
            //ViewData["sortParamDesc"] = "description";

            //ViewData["SortIconName"] = "";
            //ViewData["SortIconDesc"] = "";

            this.GetColumn("name").SortIcon = "";
            this.GetColumn("description").SortIcon = "";
            this.GetColumn("name").SortExpression = "name";
            this.GetColumn("description").SortExpression = "description";


            switch (sortExpression.ToLower())
            {
                case "name_desc":
                    this.sortOrder = SortOrder.Descending;
                    this.sortProperty = "name";
                    //ViewData["sortParamName"] = "name";
                    //ViewData["SortIconName"] = "fa fa-arrow-up";
                    this.GetColumn("name").SortIcon = "fa fa-arrow-up";
                    this.GetColumn("name").SortExpression = "name";
                    break;
                case "description":
                    this.sortOrder = SortOrder.Ascending;
                    this.sortProperty = "description";
                    //ViewData["sortParamDesc"] = "description_Desc";
                    //ViewData["SortIconDesc"] = "fa fa-arrow-down";
                    this.GetColumn("description").SortIcon = "fa fa-arrow-down";
                    this.GetColumn("description").SortExpression = "description_Desc";
                    break;
                case "description_desc":
                    this.sortOrder = SortOrder.Descending;
                    this.sortProperty = "description";
                    //ViewData["sortParamDesc"] = "description";
                    //ViewData["SortIconDesc"] = "fa fa-arrow-up";
                    this.GetColumn("description").SortIcon = "fa fa-arrow-up";
                    this.GetColumn("description").SortExpression = "description";
                    break;
                default: //default order by name asc
                    this.sortOrder = SortOrder.Ascending;
                    this.sortProperty = "name";
                    //ViewData["sortParamName"] = "name_desc";
                    //ViewData["SortIconName"] = "fa fa-arrow-down";
                    this.GetColumn("name").SortIcon = "name_desc";
                    this.GetColumn("name").SortExpression = "fa fa-arrow-down";
                    break;

            }

        }
    }

    public class SortableColumn
    {
        public string columnName { get; set; }
        public string SortExpression { get; set; }
        public string SortIcon { get; set; }
    }
}
