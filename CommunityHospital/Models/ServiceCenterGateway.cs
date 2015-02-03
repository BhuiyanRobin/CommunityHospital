using System.Data.Entity;

namespace CommunityHospital.Models
{
    public class ServiceCenterGateway:DbContext
    {
        public ServiceCenterGateway() : base("Connection")
        {
            Configuration.ProxyCreationEnabled = false;
        }
        
        public DbSet<District> Districts { set; get; }
        public DbSet<Thana> Thanas { set; get; }
        public DbSet<ServiceCenter> ServiceCenters { set; get; }
        public DbSet<DistrictThanaRelationship> Relations { set; get; }
        public DbSet<Medicine> Medicines { set; get; }
        public DbSet<AllocateMedicine> AllocateMedicines { set; get; } 


        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{

        //    modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        //    modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        //}
    }
}