using System.Collections.Generic;

namespace CommunityHospital.Models
{
    public class District
    {
        public int DistrictId { set; get; }
        public string Name { set; get; }
        
        public virtual ICollection<ServiceCenter> ServiceCenterList { set; get; }

    }
}