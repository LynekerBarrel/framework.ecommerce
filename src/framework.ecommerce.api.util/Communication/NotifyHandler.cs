using System.Collections.Generic;
using System.Linq;

namespace framework.ecommerce.auth.util.Communication
{
    public class NotifyHandler : INotifyHandler
    {
        private List<Notify> _notify;
        public NotifyHandler()
        {
            _notify = new List<Notify>();
        }
        public List<Notify> GetNotify()
        {
            return _notify;
        }

        public void Handle(Notify notify)
        {
            _notify.Add(notify);
        }

        public bool HasNotify()
        {
            return _notify.Any();
        }
    }
}
