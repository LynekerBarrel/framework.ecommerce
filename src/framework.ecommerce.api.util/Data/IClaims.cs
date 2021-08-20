using System.Collections.Generic;

namespace framework.ecommerce.util.Data
{
    public interface IClaims
    {
        List<string> GetClaimsFromFile();
    }
}