namespace NIHR.UCLH.Research.Web.Services.Interfaces
{
    public interface IRequestService
    {
        Task<IList<AgeModel>> GetAdmissionByAge(int age);
        Task<IList<GenderModel>> GetAdmissionByGender(string gender);
        Task<IList<EthincityModel>> GetAdmissionByEthinicity(string region);

    }
}
