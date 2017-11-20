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
                new Staff{StaffName="Maggie", StaffSurname="Kelly"},
                new Staff{StaffName="Rob", StaffSurname="Brown"},
                new Staff{StaffName="chris", StaffSurname="Culley"},
            };
            foreach (Staff s in staff)
            {
                context.Staff.Add(s);
            }
            context.SaveChanges();

            var staffPermission = new StaffPermission[]
          {
                new StaffPermission{StaffID="1", Permission=Permission.Purchasing},
                new StaffPermission{StaffID="1", Permission=Permission.EditInvoice},
                new StaffPermission{StaffID="1", Permission=Permission.ViewCustMsg},
                new StaffPermission{StaffID="2", Permission=Permission.Purchasing},
                new StaffPermission{StaffID="2", Permission=Permission.EditInvoice},
                new StaffPermission{StaffID="2", Permission=Permission.ViewCustMsg},
                new StaffPermission{StaffID="3", Permission=Permission.Purchasing},
                new StaffPermission{StaffID="3", Permission=Permission.EditInvoice},
                new StaffPermission{StaffID="3", Permission=Permission.ViewCustMsg},
          };
            foreach (StaffPermission p in staffPermission)
            {
                context.StaffPermission.Add(p);
            }
            context.SaveChanges();

        }
    }
}
