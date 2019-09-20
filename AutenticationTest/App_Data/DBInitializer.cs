using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AutenticationTest.App_data
{
    public class DBInitializer : DropCreateDatabaseIfModelChanges<AuthenticateDB>, IDatabaseInitializer<AuthenticateDB>
    {
        protected override void Seed(AuthenticateDB context)
        {
            base.Seed(context);
        }
    }
}