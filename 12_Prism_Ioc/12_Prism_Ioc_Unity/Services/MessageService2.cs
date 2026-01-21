using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_Prism_Ioc_Unity.Services
{
    public class MessageService2 : IMessageService
    {
        public string GetMessage()
        {
            return "Hello Prism DI 2222222!";
        }
    }
}
