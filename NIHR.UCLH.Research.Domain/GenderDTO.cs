using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIHR.UCLH.Research.Domain
{
    public class GenderDTO
    {
        public AdmissionDTO Admission { get; set; }
        public int Age { get; set; }
        public string Ethnicity { get; set; }
    }
}
