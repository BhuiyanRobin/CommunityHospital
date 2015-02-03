using System.Collections.Generic;
using CommunityHospital.Models;

namespace CommunityHospital.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ServiceCenterGateway>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ServiceCenterGateway context)
        {
            //var thanas = new List<Thana>
            //{
            //    new Thana {Name = " Dashmina"},
            //    new Thana {Name = "Galachipa "},
            //    new Thana {Name = " Kalapara "},
            //    new Thana {Name = " Mirzaganj "},
            //    new Thana {Name = "Patuakhali Sadar"},
            //    new Thana {Name = "Rangabali"},
            //    new Thana {Name = "  Dumki"},
            //    new Thana {Name = "Naniyachar "},
            //    new Thana {Name = " Belaichhari  "},
            //    new Thana {Name = " Barkal "},
            //    new Thana {Name = " Kaptai "},
            //    new Thana {Name = "Savar"},
            //};
            //thanas.ForEach(s => context.Thanas.AddOrUpdate(s));
            //context.SaveChanges();
            //var relations = new List<DistrictThanaRelationship>
            //{
            //    new DistrictThanaRelationship {DistrictId = 1, ThanaId = 2},
            //    new DistrictThanaRelationship {DistrictId = 1, ThanaId = 1},
            //    new DistrictThanaRelationship {DistrictId = 1, ThanaId = 3},
            //    new DistrictThanaRelationship {DistrictId = 2, ThanaId = 4},
            //    new DistrictThanaRelationship {DistrictId = 3, ThanaId = 5},
            //    new DistrictThanaRelationship {DistrictId = 4, ThanaId = 6},
            //    new DistrictThanaRelationship {DistrictId = 5, ThanaId = 7},
            //    new DistrictThanaRelationship {DistrictId = 5, ThanaId = 8},
            //    new DistrictThanaRelationship {DistrictId = 4, ThanaId = 9},
            //    };
            //relations.ForEach(s => context.Relations.AddOrUpdate(s));
            //context.SaveChanges();

            //var serviceCenters = new List<ServiceCenter>
            //{
            //    new ServiceCenter
            //    {
            //        ThanaId = 2,
            //        DistrictId = 3,
            //        Name = "GouriporCommunityHospital",
            //        Code = "GOCH",
            //        Password = "GOCH"
            //    },
            //};
            //serviceCenters.ForEach(s => context.ServiceCenters.AddOrUpdate(s));
            //context.SaveChanges();
            //var medicines = new List<Medicine>
            //{
            //    new Medicine{Name = "Parasitamol",Weight = "20gr"},
            //    new Medicine{Name = "Setam Plus",Weight = "35gr"},
            //    new Medicine{Name = "Napa Extra",Weight = "40gr"},
            //    new Medicine{Name = "Filwel",Weight = "20gr"},
            //};
            //medicines.ForEach(s => context.Medicines.AddOrUpdate(s));
            //context.SaveChanges();

            var allocateMedicines = new List<AllocateMedicine>
            {
                new AllocateMedicine {  ServiceCenterId = 1, MedicineId = 1,DistrictThanaRelationshipId = 1},
                new AllocateMedicine { ServiceCenterId = 3, MedicineId = 2,DistrictThanaRelationshipId=2},
            };
            allocateMedicines.ForEach(s => context.AllocateMedicines.AddOrUpdate(s));
            context.SaveChanges();
        }
    }
}
