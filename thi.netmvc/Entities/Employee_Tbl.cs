using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace thi.netmvc.Entities
{
    public class Employee_Tbl
    {
        [Key]
        public int EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public int IdUser { get; set; }
        [ForeignKey("user")]
        public User User { get; set; }
        public int IDepartment { get; set; }
        [ForeignKey("Departiment_Tbl")]
        public Department_Tbl Department { get; set; }

        public string Rank { get; set; }

    }
}
