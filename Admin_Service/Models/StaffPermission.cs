using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin_Service.Models
{
    public enum Permission
    {
        Purchasing, ViewCustMsg, EditInvoice
    }

    public class StaffPermission
    {
        public int StaffPermissionID { get; set; }
        public string StaffID { get; set; }
        public Permission? Permission { get; set; }

    }
}
