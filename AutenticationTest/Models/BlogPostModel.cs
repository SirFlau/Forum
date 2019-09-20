using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutenticationTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;

    namespace Forum.Models
    {
        public class BlogPostModel
        {
            public Guid Id { get; set; }
            public string Subject { get; set; }
            public DateTime CreatedDate { get; set; }
            public string Content { get; set; }
            public Guid Topic_Id { get; set; }
            public Guid User_Id { get; set; }

            [ForeignKey("Topic_Id")]
            public TopicModel Topic { get; set; }

            [ForeignKey("User_Id")]
            public UserModel User { get; set; }
        }
    }
}