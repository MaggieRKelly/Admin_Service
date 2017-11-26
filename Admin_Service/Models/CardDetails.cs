using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Admin_Service.Models
{
    public class CardDetails
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public long CardNum { get; set; }
        public string ExpDate { get; set; }
        public int CvsNum { get; set; }

        public ICollection<StaffPermission> StaffPermission { get; set; }
    }
}
