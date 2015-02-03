using System.Collections.Generic;

namespace CommunityHospital.Models
{
    public class Thana
    {
        public int ThanaId { set; get; }
        public string Name { set; get; }
        public virtual ICollection<ServiceCenter> ServiceCenterList { set; get; }
    }
}