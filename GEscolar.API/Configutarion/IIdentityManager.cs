using GEscolar.Domain.ViewModels;

namespace GEscolar.API.Configutarion
{
    public interface IIdentityManager
    {
        Task<LoginResponseViewModel> GenerateJwt(string email);
    }
}
