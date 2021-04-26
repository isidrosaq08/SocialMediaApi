using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Core.QueryFilter
{
    public class PostQueryFilter
    {
        public int? UserId { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
