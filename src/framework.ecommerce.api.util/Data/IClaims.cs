using System.Collections.Generic;

namespace framework.ecommerce.api.util.Data
{
    public interface IClaims
    {
        List<string> GetClaimsFromFile();
    }
}