using LINQtoCSV;
using NIHR.UCLH.Research.DAL.NIHR.UCLH.Research.DAL;
using NIHR.UCLH.Research.Domain;

namespace NIHR.UCLH.Research.DAL
{
    public class DbInitializer
    {
        public static void ReadCsv(NIHRUCLHResearchDBContext context)
        {
            
            var csvFileDescription = new CsvFileDescription
            {
                FirstLineHasColumnNames = true,
                IgnoreUnknownColumns = true,
                SeparatorChar = ',',
                UseFieldIndexForReadingData = false,
            };

            var csvContext = new CsvContext();
            var patients =  csvContext.Read<Patient>("../../../sw-dev-b7/resources/patient.csv", csvFileDescription);
            var admissions = csvContext.Read<Admission>("../../../sw-dev-b7/resources/admission.csv", csvFileDescription);
            
            
            //if(admissions != null)
            //{
            //    foreach(var admission in admissions)
            //    {
            //        context.Admission.Update(admission);
            //    }
            //    context.SaveChanges();
            //}
            context.Patient.AddRange(patients);          
            context.SaveChanges();
            //context.Admission.AddRange(admission);  
            context.Admission.AddRange(admissions);
            //context.ChangeTracker.DetectChanges();
            context.SaveChanges();
        }


        
    }
}
