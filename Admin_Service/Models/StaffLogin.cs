using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin_Service.Models
{
    public class StaffLogin
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public ICollection<StaffPermission> StaffPermision { get; set; }
    }
}
