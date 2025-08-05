using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomViewModelCommunication.Messages
{
    public class DateTimeDisplay
    {
        public string DatetimeNow { get; set; }
    }

    public class DateTimeMessage : ValueChangedMessage<DateTimeDisplay>
    {
        public DateTimeMessage(DateTimeDisplay value) : base(value)
        {
        }
    }
}
