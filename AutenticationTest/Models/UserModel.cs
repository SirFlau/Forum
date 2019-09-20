using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutenticationTest.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public byte[] Image { get; set; }

        public string ImageType { get; set; }
        public string ApplicationUser_Id { get; set; }

        [ForeignKey("ApplicationUser_Id")]
        ApplicationUser ApplicationUser { get; set; }
    }
}