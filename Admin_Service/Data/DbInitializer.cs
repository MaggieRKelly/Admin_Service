using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin_Service.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Admin_Service.Data
{
    public static class DbInitializer
    {
        public static void Initialize(StaffContext context)
        {
            context.Database.EnsureCreated();

            //look for any Staff
            if (context.Staff.Any())
            {
                return; //DB has been seeded
            }
            var staff = new Staff[]
            {
                new Staff{StaffName="Maggie", StaffSurname="Kelly", PurchasingPermission=true,
                            ViewCustMsgPermission=true, EditInvPermission=true, EditCardPermission=true},
                new Staff{StaffName="Rob", StaffSurname="Brown", PurchasingPermission=true,
                            ViewCustMsgPermission=true, EditInvPermission=true,},
                new Staff{StaffName="chris", StaffSurname="Culley", PurchasingPermission=true,
                            ViewCustMsgPermission=true, EditInvPermission=true,},

    };
            foreach (Staff s in staff)
            {
                context.Staff.Add(s);
            }
            context.SaveChanges();

            var CardDetails = new CardDetails[]
                {
                new CardDetails { ID=1, CardNum=1234567891234567, CvsNum=246,
                    ExpDate ="12-12-2018" }
                };
            foreach (CardDetails c in CardDetails)
            {
                context.CardDetails.Add(c);
            }
            context.SaveChanges();

        }
    }
}
