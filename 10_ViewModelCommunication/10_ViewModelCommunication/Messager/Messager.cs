using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomViewModelCommunication.Messager
{
    public class Messager
    {
        private static object obj = new object();
        private static Messager instance;
        private Dictionary<Type, List<GenericAction>> recipientsActions = new Dictionary<Type, List<GenericAction>>();

        public static Messager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (obj)
                    {
                        if (instance == null)
                            instance = new Messager();
                    }
                }

                return instance;
            }
        }

        public void Register<TMessage>(Action<TMessage> action)
        {
            var messageType = typeof(TMessage);


            List<GenericAction> list;

            if (!recipientsActions.ContainsKey(messageType))
            {
                list = new List<GenericAction>();
                recipientsActions.Add(messageType, list);
            }
            else
            {
                list = recipientsActions[messageType];
            }

            list.Add(new GenericAction<TMessage>(action));

        }

        public void Send<TMessage>(TMessage message)
        {
            var messageType = typeof(TMessage);

            List<GenericAction> list = new List<GenericAction>();

            if (recipientsActions.ContainsKey(messageType))
            {
                list = recipientsActions[messageType];
            }

            foreach (GenericAction<TMessage> action in list)
            {
                action.Invoke(message);
            }
        }
    }
}
