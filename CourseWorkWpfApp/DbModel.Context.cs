﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CourseWorkWpfApp
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=DatabaseContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Abonement> Abonement { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Coach> Coach { get; set; }
        public DbSet<Contract> Contract { get; set; }
        public DbSet<GroupService> GroupService { get; set; }
        public DbSet<PersonalService> PersonalService { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<ServicePosition> ServicePosition { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<ViewCoaches> ViewCoaches { get; set; }
        public DbSet<ViewAbonements> ViewAbonements { get; set; }
        public DbSet<ViewGroupService> ViewGroupService { get; set; }
        public DbSet<ViewPersonalService> ViewPersonalService { get; set; }
        public DbSet<CoachesNames> CoachesNames { get; set; }
    }
}
