﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using LINQtoCSV;
using System;
using System.Collections.Generic;

namespace NIHR.UCLH.Research.Domain
{
    public partial class Admission
    {
        [CsvColumn(Name ="admission_id")]
        public int AdmissionId { get; set; }

        [CsvColumn(Name = "patient_id")]
        public int PatientId { get; set; }
        
        [CsvColumn(Name = "visit_start_date", OutputFormat ="YYYY-MM-DD")]
        public DateTime VisitStartDate { get; set; }
       
        [CsvColumn(Name = "visit_start_datetime", OutputFormat = "dd-MM-yyyy HH:mm:ss")]
        public DateTime VisitStartDatetime { get; set; }
       
        [CsvColumn(Name = "visit_end_date", OutputFormat = "YYYY-MM-DD")]
        public DateTime VisitEndDate { get; set; }
        
        [CsvColumn(Name = "visit_end_datetime", OutputFormat = "dd-MM-yyyy HH:mm:ss")]
        public DateTime VisitEndDatetime { get; set; }
       
        [CsvColumn(Name = "admission_source")]
        public string AdmissionSource { get; set; }
       
        [CsvColumn(Name = "discharge_to")]
        public string DischargeTo { get; set; }
        
        public virtual Patient Patient { get; set; }
    }
}