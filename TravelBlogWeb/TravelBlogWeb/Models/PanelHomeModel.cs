using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelBlogWeb.Models
{
    public class PanelHomeModel
    {
        public int UserCount { get; set; }
        public int BlogCount { get; set; }
        public int CommentCount { get; set; }
        public int PendingCommentsCount { get; set; }
        public int ApprovedCommentsCount { get; set; }
        public int LikesCount { get; set; }
        public List<BlogComment> PendingComments { get; set; }
        public List<BlogComment> ApprovedComments { get; set; }

    }
}