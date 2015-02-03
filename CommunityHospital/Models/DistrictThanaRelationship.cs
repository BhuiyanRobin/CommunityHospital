using System.Collections.Generic;

namespace CommunityHospital.Models
{
    public class DistrictThanaRelationship
    {
        public int DistrictThanaRelationshipId { set; get; }
        public int DistrictId { set; get; }
        public int ThanaId { set; get; }
        public virtual District ADistrict { set; get; }
        public virtual ICollection<Thana> Thanas { set; get; }

        //public virtual ICollection<District> DistrictList { set; get; } 
    }
}