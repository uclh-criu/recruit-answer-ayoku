namespace NIHR.UCLH.Research.Web.Services.Interfaces
{
    public interface IRequestService
    {
        Task<int> GetAdmissionByAge(int age);
        Task<int> GetAdmissionByGender(string gender);
        Task<int> GetAdmissionByEthinicity(string region);

    }
}
