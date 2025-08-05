using CustomViewModelCommunication.Commands;
using CustomViewModelCommunication.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomViewModelCommunication.ViewModels
{
    public class SendViewModel
    {
        public RelayCommand SendMessageCommand { get; private set; }

        public SendViewModel()
        {
            SendMessageCommand = new RelayCommand(SendMessage);
        }

        private void SendMessage()
        {
            DateTimeMessage dateTimeMessage = new DateTimeMessage();
            dateTimeMessage.DatetimeNow = DateTime.Now.ToString();
            Messager.Messager.Instance.Send<DateTimeMessage>(dateTimeMessage);
        }
    }
}
