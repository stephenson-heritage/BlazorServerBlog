using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BlazorServerBlog.Data.Models
{
    public class BlogComment
    {
        public uint BlogCommentId { get; set; }

        public string Content { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Time { get; set; }

        public virtual IdentityUser User { get; set; }
        public virtual BlogEntry BlogEntry { get; set; }

    }

}