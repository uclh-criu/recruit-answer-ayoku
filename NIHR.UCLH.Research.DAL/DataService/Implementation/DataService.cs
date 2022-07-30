using Microsoft.EntityFrameworkCore;
using NIHR.UCLH.Research.DAL.DataService.Interface;
using NIHR.UCLH.Research.DAL.NIHR.UCLH.Research.DAL;
using NIHR.UCLH.Research.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIHR.UCLH.Research.DAL.DataService.Implementation
{
    public class DataService : IDataService
    {

        private readonly IDbContextFactory<NIHRUCLHResearchDBContext> _contextFactory;
        public DataService(IDbContextFactory<NIHRUCLHResearchDBContext> contextFactory)
        {
            _contextFactory= contextFactory;
        }
        public async Task<IEnumerable<AdmissionDTO>> GetAllAdmissionAsync()
        {
           
            using var context = await _contextFactory.CreateDbContextAsync();

         

            IQueryable<AdmissionDTO> patients =  context.Admission.Select(b => new AdmissionDTO()
            {
                AdmissionSource = b.AdmissionSource,
                DischargeTo = b.DischargeTo,               
                VisitStartDate = b.VisitStartDatetime,
                VisitEndDate = b.VisitEndDatetime,

            }).AsNoTracking();

        
            return patients;
        }

        public async Task<IEnumerable<AgeDTO>> GetAdmissionByAgeAsync(int age)
        {
            
            using var context = await _contextFactory.CreateDbContextAsync();
            // patients.AddRange(await context.Admission.Where(a => (DateTime.Now.Year - a.YearOfBirth).Equals(age)).ToListAsync());
            //   patients.AddRange(await context.Admission.Where(a => a.PatientId.Equals(context.Patient.Where(b=>b.PatientId))
            var patients = await context.Admission.Where(a => (DateTime.Now.Year - a.Patient.YearOfBirth).Equals(age))
                                        .Select(b => new AgeDTO()
                                        {
                                            Admission = new AdmissionDTO()
                                            {
                                                AdmissionSource = b.AdmissionSource,
                                                VisitStartDate = b.VisitStartDatetime,
                                                VisitEndDate = b.VisitEndDatetime,
                                                DischargeTo = b.DischargeTo,
                                            },                                                                                   
                                            Ethnicity = b.Patient.Ethnicity,
                                            SexAtBirth = b.Patient.SexAtBirth,
                                            

                                        }).ToListAsync();

            return patients;
        }

       

        public async Task<IEnumerable<EthincityDTO>> GetAdmissionByEthincityAsync(string ethincity)
        {           
            using var context = await _contextFactory.CreateDbContextAsync();           

            var patients =await context.Admission.Where(a => a.Patient.Ethnicity.Equals(ethincity))
                                       .Select(b => new EthincityDTO()
                                                {
                                                   Admission = new AdmissionDTO()
                                                   {
                                                       AdmissionSource = b.AdmissionSource,
                                                       VisitStartDate = b.VisitStartDatetime,
                                                       VisitEndDate = b.VisitEndDatetime,
                                                       DischargeTo = b.DischargeTo,
                                                   },                                           
                                                    Age = (DateTime.Now.Year - b.Patient.YearOfBirth),
                                                    SexAtBirth = b.Patient.SexAtBirth
                                                  
                                                   
                                                }).ToListAsync();
            
            return  patients;
          
        }

        public async Task<IEnumerable<GenderDTO>> GetAdmissionBySexAsync(string gender)
        {
           
            using var context = await _contextFactory.CreateDbContextAsync();           

            var patients = await context.Admission.Where(a => a.Patient.SexAtBirth.Equals(gender))
                                      .Select(b => new GenderDTO()
                                      {
                                          Admission = new AdmissionDTO()
                                          {
                                              AdmissionSource = b.AdmissionSource,
                                              VisitStartDate = b.VisitStartDatetime,
                                              VisitEndDate = b.VisitEndDatetime,
                                              DischargeTo = b.DischargeTo,
                                          },                                         
                                          Ethnicity = b.Patient.Ethnicity,
                                          Age = (DateTime.Now.Year - b.Patient.YearOfBirth)
                                        

                                      }).ToListAsync();

            return  patients;
        }
    }
}
