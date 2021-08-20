using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace framework.ecommerce.util.Data
{
    public class Claims : IClaims
    {
        public List<string> GetClaimsFromFile()
        {
            var assembly = typeof(Claims).GetTypeInfo().Assembly;
            Stream resource = assembly.GetManifestResourceStream("framework.ecommerce.util.Data.Claims.json");

            var regras = ToEncodedString(resource);

            return null;
        }
        private string ToEncodedString(Stream stream, Encoding enc = null)
        {
            enc = enc ?? Encoding.UTF8;

            byte[] bytes = new byte[stream.Length];
            stream.Position = 0;
            stream.Read(bytes, 0, (int)stream.Length);
            string data = enc.GetString(bytes);

            return enc.GetString(bytes);
        }
    }
}
