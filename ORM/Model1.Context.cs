﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ORM
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LocalDatabaseBlogEntities1 : DbContext
    {
        public LocalDatabaseBlogEntities1()
            : base("name=LocalDatabaseBlogEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Record> Records { get; set; }
        public virtual DbSet<Resours> Resourses { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Sign> Signs { get; set; }
        public virtual DbSet<Theme> Themes { get; set; }
    }
}
