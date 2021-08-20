
using System;

namespace framework.ecommerce.api.util
{
    public interface IClinicaId
    {
        public Guid Id { get; }
        void SetClinicaId(Guid id);
    }
}
