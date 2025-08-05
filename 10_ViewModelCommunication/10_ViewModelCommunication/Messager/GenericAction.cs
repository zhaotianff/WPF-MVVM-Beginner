using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomViewModelCommunication.Messager
{
    public class GenericAction<T> :GenericAction
    {
        private Action<T> genericAction;

        public GenericAction(Action<T> action)
        {
            this.genericAction = action;
        }

        public void Invoke(T message)
        {
            genericAction?.Invoke(message);
        }
    }

    public class GenericAction
    {
        private Action action;

        public GenericAction()
        {

        }

        public GenericAction(Action action)
        {
            this.action = action;
        }
    }
}
