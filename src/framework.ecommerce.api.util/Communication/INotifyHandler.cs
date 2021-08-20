using System.Collections.Generic;

namespace framework.ecommerce.api.auth.util.Communication
{
    public interface INotifyHandler
    {
        bool HasNotify();
        List<Notify> GetNotify();
        void Handle(Notify notify);
    }
}