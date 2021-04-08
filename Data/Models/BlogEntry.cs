using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BlazorServerBlog.Data.Models
{
    public class BlogEntry : IComparable<BlogEntry>
    {
        public uint BlogEntryId { get; set; }


        [Column(TypeName = "varchar(120)")]
        public string Title { get; set; }

        public string Content { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Time { get; set; }

        public virtual IdentityUser User { get; set; }
        public virtual ICollection<BlogComment> Comments { get; set; }

        public int CompareTo(BlogEntry other)
        {
            if (this.Time > other.Time)
            {
                return -1;
            }
            else if (this.Time < other.Time)
            {
                return 1;
            }

            return 0;
        }
    }

}