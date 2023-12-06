using System.ComponentModel.DataAnnotations;

namespace thi.netmvc.Entities
{
    public class Department_Tbl
    {
        [Key]
        public int IDepartment { get; set; }
        public string DepartmentName { set; get; }
        public string DepartmentCode { set; get; }
        public string Location { set; get; }
        public string Number { set; get; }
    }
}
