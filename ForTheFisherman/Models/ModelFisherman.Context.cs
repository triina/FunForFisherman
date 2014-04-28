﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ForTheFisherman.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class FishermanDBEntities1 : DbContext
    {
        public FishermanDBEntities1()
            : base("name=FishermanDBEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Catch> Catch { get; set; }
        public DbSet<Fisherman> Fisherman { get; set; }
        public DbSet<FishingMethod> FishingMethod { get; set; }
        public DbSet<FishingSession> FishingSession { get; set; }
        public DbSet<FishSpecies> FishSpecies { get; set; }
        public DbSet<GeoCoordinates> GeoCoordinates { get; set; }
        public DbSet<LocationMarking> LocationMarking { get; set; }
        public DbSet<Lure> Lure { get; set; }
        public DbSet<LureType> LureType { get; set; }
        public DbSet<Water> Water { get; set; }
    
        public virtual int Create_Tables()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Create_Tables");
        }
    
        public virtual int Drop_Tables()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Drop_Tables");
        }
    
        public virtual int Insert_Test_Data()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Insert_Test_Data");
        }
    
        public virtual int Rebuild()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Rebuild");
        }
    }
}
