using System.Collections;
using System.Collections.Generic;

namespace CommunityHospital.Models
{
    public class Medicine
    {
        public int MedicineId { set; get; }
        public string Name { set; get; }
        public string Weight { set; get; }
        public virtual ICollection<AllocateMedicine> AllocateMedicines { set; get; }
    }
}