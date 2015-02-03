using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityHospital.Models
{
    public class AllocateMedicine
    {
        public int AllocateMedicineId { set; get; }
        public int DistrictThanaRelationshipId { set; get; }
        public int ServiceCenterId { set; get; }
        public int MedicineId { set; get; }
        public virtual District ADistrict { set; get; }
        public virtual Thana AThana { set; get; }
        public virtual ServiceCenter AServiceCenter { set; get; }
        public virtual Medicine AMedicine { set; get; }
    }
}