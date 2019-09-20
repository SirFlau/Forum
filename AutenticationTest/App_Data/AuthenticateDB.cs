using AutenticationTest.Models;
using AutenticationTest.Models.Forum.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AutenticationTest.App_data
{
    public class AuthenticateDB : IdentityDbContext<ApplicationUser>
    {
        public AuthenticateDB()
            : base("AuthenticateDB")
        {
            //Database.SetInitializer<AuthenticateDB>(null);
        }
        public static AuthenticateDB Create()
        {
            return new AuthenticateDB();
        }

        public DbSet<BlogPostModel> Posts { get; set; }
        public DbSet<TopicModel> Topics { get; set; }

        public System.Data.Entity.DbSet<AutenticationTest.Models.UserModel> UserModels { get; set; }
        //public DbSet<ApplicationUser> Users { get; set; }
    }
}