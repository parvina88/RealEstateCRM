using System.Security.Claims;

namespace RealEstate.Application.Interfaces
{
    public interface ITokenService
    {
        public string CreateTokenByClaims(IList<Claim> user, out DateTime expireDate);
        public string CreateRefreshToken(IList<Claim> user);
    }
}

