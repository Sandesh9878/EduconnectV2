using InstituteGrpcService;

namespace Educonnect.Student.Mobile.API.Services.Institute
{
    public interface IInstituteService
    {
        Task<InstitutesResponse> GetInstitutes();
    }
}
