using NIHR.UCLH.Research.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIHR.UCLH.Research.DAL.DataService.Interface
{
    public interface IDataService
    {
        Task<IEnumerable<AdmissionDTO>> GetAllAdmissionAsync();      
        Task<IEnumerable<GenderDTO>> GetAdmissionBySexAsync(string sex);
        Task<IEnumerable<EthincityDTO>> GetAdmissionByEthincityAsync(string ethincity);
        Task<IEnumerable<AgeDTO>> GetAdmissionByAgeAsync(int age);
    }
}
