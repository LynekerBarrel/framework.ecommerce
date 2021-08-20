using System.Collections.Generic;

namespace framework.ecommerce.auth.util.Communication
{
    public interface INotifyHandler
    {
        bool HasNotify();
        List<Notify> GetNotify();
        void Handle(Notify notify);
    }
}