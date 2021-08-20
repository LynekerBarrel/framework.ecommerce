using System;

namespace framework.ecommerce.api.util
{
    public class ClinicaId : IClinicaId
    {
        public ClinicaId()
        {

        }
        public Guid Id { get; private set; }
        public void SetClinicaId(Guid id)
        {
            Id = id;
        }
    }
}
