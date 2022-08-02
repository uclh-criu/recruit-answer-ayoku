using Microsoft.EntityFrameworkCore;
using NIHR.UCLH.Research.DAL.DataService.Interface;
using NIHR.UCLH.Research.DAL.NIHR.UCLH.Research.DAL;
using NIHR.UCLH.Research.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                //VisitStartDate = b.VisitStartDatetime,
                //VisitEndDate = b.VisitEndDatetime,

            }).AsNoTracking();

        
            return patients;
        }

        public async Task<IEnumerable<AgeDTO>> GetAdmissionByAgeAsync(int age)
        {
            
            using var context = await _contextFactory.CreateDbContextAsync();           
            var sqlQuery = await context.Admission.Join(context.Patient,p=>p.Patient.PatientId,e=>e.PatientId,(p, e)=> new
                                                        {   
                                                            PatientId = p.PatientId,
                                                            Ethnicity = e.Ethnicity,
                                                            AdmissionSource = p.AdmissionSource,
                                                            DischargeTo = p.DischargeTo,
                                                            Age = e.YearOfBirth,
                                                            SexAtBirth = e.SexAtBirth
                                                        })
                                                    .Where(a => (DateTime.Now.Year - a.Age) == age)
                                                    .Select(b => new AgeDTO()
                                                    {
                                                        Admission = new AdmissionDTO()
                                                        {
                                                            AdmissionSource = b.AdmissionSource,                                                           
                                                            DischargeTo = b.DischargeTo,
                                                            PatientId = b.PatientId,
                                                        },                                                                                   
                                                        Ethnicity = b.Ethnicity,
                                                        SexAtBirth = b.SexAtBirth,
                                                        
                                                    }).ToListAsync();
           var result = sqlQuery.DistinctBy(q => q.Admission.PatientId);

            return result;
        }

       

        public async Task<IEnumerable<EthincityDTO>> GetAdmissionByEthincityAsync(string ethincity)
        {           
            using var context = await _contextFactory.CreateDbContextAsync();


            var sqlQuery = await context.Admission.Join(context.Patient,p=>p.PatientId,e=>e.PatientId,(p,e)=> new 
                                                        {
                                                        PatientId = p.PatientId,
                                                        Ethnicity = p.Patient.Ethnicity,
                                                         AdmissionSource = p.AdmissionSource,
                                                         DischargeTo = p.DischargeTo,
                                                         Age = (DateTime.Now.Year - p.Patient.YearOfBirth),
                                                         SexAtBirth = p.Patient.SexAtBirth
                                                       })
                                       .Where(a => a.Ethnicity.Equals(ethincity))
                                                  
                                       .Select(b => new EthincityDTO()
                                       {
                                           Admission = new AdmissionDTO()
                                           {
                                               AdmissionSource = b.AdmissionSource,                                              
                                               DischargeTo = b.DischargeTo,
                                               PatientId = b.PatientId,
                                           },
                                           Age = (DateTime.Now.Year - b.Age),
                                           SexAtBirth = b.SexAtBirth

                                       }).ToListAsync();

            var result = sqlQuery.DistinctBy(a => a.Admission.PatientId);

            return result;
          
        }

        public async Task<IEnumerable<GenderDTO>> GetAdmissionBySexAsync(string gender)
        {
           
            using var context = await _contextFactory.CreateDbContextAsync();

            var sqlQuery = await context.Admission.Join(context.Patient, p => p.Patient.PatientId, e => e.PatientId, (p, e) => new
                                    {
                                        PatientId = p.PatientId,
                                        Ethnicity = p.Patient.Ethnicity,
                                        AdmissionSource = p.AdmissionSource,
                                        DischargeTo = p.DischargeTo,
                                        Age = (DateTime.Now.Year - p.Patient.YearOfBirth),
                                        SexAtBirth = e.SexAtBirth
                                    })
                                    .Where(a => a.SexAtBirth.Equals(gender))
                                    .Select(b => new GenderDTO()
                                      {
                                          Admission = new AdmissionDTO()
                                          {
                                              AdmissionSource = b.AdmissionSource,                                            
                                              DischargeTo = b.DischargeTo,
                                              PatientId = b.PatientId,
                                          },                                         
                                          Ethnicity = b.Ethnicity,
                                          Age = (DateTime.Now.Year - b.Age)                                       

                                      }).ToListAsync();

            var result = sqlQuery.DistinctBy(a => a.Admission.PatientId);

            return result;
        }
       
    }
}
