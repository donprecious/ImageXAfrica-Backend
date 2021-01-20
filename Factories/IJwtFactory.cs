using System.Threading.Tasks;
using System.Security.Claims;

namespace Factories
{
 public interface IJwtFactory
    {
        Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity );
       Task<ClaimsIdentity> GenerateClaimsIdentity(string userName,string id);
    }
}