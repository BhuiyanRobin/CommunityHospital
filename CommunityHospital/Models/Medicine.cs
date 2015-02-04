using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace CommunityHospital.Models
{
    public class Medicine
    {
        
        public int MedicineId { set; get; }

        [DisplayName ("Geniric Name")]
        public string Name { set; get; }

        [DisplayName ("Mg/Ml")]
        public string Weight { set; get; }
        public virtual ICollection<AllocateMedicine> AllocateMedicines { set; get; }
    }
}