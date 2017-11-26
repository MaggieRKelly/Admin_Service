using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin_Service.Models
{
    public enum Permission
    {
        Purchasing, ViewCustMsg, EditInvoice, EditCardDetails
    }

    public class StaffPermission
    {
        public int StaffPermissionID { get; set; }
        public int CardID { get; set;}
        public int StaffID { get; set; }
        public Permission? Permission { get; set; }

        public Staff Staff { get; set; }
        public CardDetails CardDetails { get; set; }
    }
}
