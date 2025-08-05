using ViewModelCommunicationViaIoc.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace ViewModelCommunicationViaIoc.ViewModels
{
    public class SendViewModel
    {
        public RelayCommand SendMessageCommand { get; private set; }

        protected ReceiveViewModel receiveViewModel;

        public SendViewModel(ReceiveViewModel receiveViewModel)
        {
            SendMessageCommand = new RelayCommand(SendMessage);

            this.receiveViewModel = receiveViewModel;
        }

        private void SendMessage()
        {
            DateTimeMessage dateTimeMessage = new DateTimeMessage();
            dateTimeMessage.DatetimeNow = DateTime.Now.ToString();
            receiveViewModel.AddDateTimeMessage(dateTimeMessage);
        }
    }
}
