using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin_Service.Models
{
    public class Staff
    {
        public int ID { get; set; }
        public string StaffName { get; set; }
        public string StaffSurname { get; set; }
        public string StaffRole { get; set; } = "Staff";

        public ICollection<StaffPermission> StaffPermision { get; set; }
    }
}
