﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Test_Wpf_App
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Test_WPF_1Entities : DbContext
    {
        public Test_WPF_1Entities()
            : base("name=Test_WPF_1Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<Distribution> Distributions { get; set; }
        public virtual DbSet<SalesInfo> SalesInfoes { get; set; }
        public virtual DbSet<SKUTable> SKUTables { get; set; }
    
        public virtual ObjectResult<spGetUserByUseremail_Result> spGetUserByUseremail(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetUserByUseremail_Result>("spGetUserByUseremail", emailParameter);
        }
    }
}
