using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using CommunityHospital.Models;

namespace CominityClinicApp.Models
{
    public class Diseases
    {
        public int DiseasesId { get; set; }

        [DisplayName ("Disease Name")]
        public string Name { get; set; }

        [DisplayName ("Disease Description")]
        public string Description { get; set; }

        [DisplayName("Treatment Procedure")]
        public string TreatmentProcedure { get; set; }

        
        public int MedicineId { get; set; }

       
        public virtual Medicine aMedicine { get; set; }
    }
}