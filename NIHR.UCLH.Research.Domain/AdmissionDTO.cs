using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIHR.UCLH.Research.Domain
{
    public class AdmissionDTO
    {

        public string AdmissionSource { get; set; }
        public string DischargeTo { get; set; }
        public int PatientId { get; set; }
        //public DateTime VisitStartDate { get; set; }        
        //public DateTime VisitEndDate { get; set; }
    }
}
