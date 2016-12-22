using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DisposalManagement.Models
{
    public class ManagerInitializer : DropCreateDatabaseIfModelChanges<DisposalManagementContext>
    {
        protected override void Seed(DisposalManagementContext context)
        {
            Manager Larry = new Manager
            {
                Name = "Larry",
                Email="Larry@Deb.com",
                PostalCode="2000"
            };
            Manager Barry = new Manager
            {
                Name = "Barry",
                Email = "Barry@Deb.com",
                PostalCode = "2600"
            };
            Manager Harry = new Manager
            {
                Name = "Harry",
                Email = "Harry@Deb.com",
                PostalCode = "2640"
            };
            context.Managers.Add(Larry);
            context.Managers.Add(Barry);
            context.Managers.Add(Harry);
            context.SaveChanges();
        }
    }
}