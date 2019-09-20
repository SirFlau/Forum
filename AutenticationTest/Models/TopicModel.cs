using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AutenticationTest.Models
{
    public class TopicModel
    {
        public Guid Id { get; set; }

        [DisplayName("Topic")]
        public string Name { get; set; }

    }

}