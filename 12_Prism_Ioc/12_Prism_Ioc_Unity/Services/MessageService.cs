using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_Prism_Ioc_Unity.Services
{

    // 服务实现
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hello Prism DI!";
        }
    }
}
