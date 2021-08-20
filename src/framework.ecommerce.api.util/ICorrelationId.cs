
namespace framework.ecommerce.api.util
{
    public interface ICorrelationId
    {
        public string Id { get; }
        void SetCorrelationId(string id);
    }
}
