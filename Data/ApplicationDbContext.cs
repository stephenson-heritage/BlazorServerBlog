using System;
using System.Collections.Generic;
using System.Text;
using BlazorServerBlog.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerBlog.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public virtual DbSet<BlogEntry> Entries { get; set; }
        public virtual DbSet<BlogComment> Comments { get; set; }

        public virtual DbSet<IdentityUser> Profiles { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
