using System.Collections.Generic;

namespace CommunityHospital.Models
{
    public class ServiceCenter
    {
        public int ServiceCenterId { set; get; }
        public string Name { set; get; }
        public string Code { set; get; }
        public string Password { set; get; }
        public int DistrictId { set; get; }
        public int ThanaId { set; get; }
        public virtual District ADistrict { set; get; }
        public virtual Thana AThana { set; get; }
       // public virtual ICollection<AllocateMedicine> AllocateMedicines { set; get; } 
    }
}