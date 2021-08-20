using System.Collections.Generic;

namespace framework.ecommerce.api.auth.domain.Dto.Base
{
    public class Response<T> where T: class
    {
        public bool Success { get; set; }
        public T Object { get; set; }
        public List<string> Messages { get; set; }
    }
}
