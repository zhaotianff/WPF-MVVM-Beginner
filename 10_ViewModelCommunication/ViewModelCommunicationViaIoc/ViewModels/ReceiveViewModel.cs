using ViewModelCommunicationViaIoc.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelCommunicationViaIoc.ViewModels
{
    public class ReceiveViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> messageList = new ObservableCollection<string>();

        public ObservableCollection<string> MessageList
        {
            get
            {
                return messageList;
            }

            set
            {
                messageList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MessageList"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public ReceiveViewModel()
        {
            
        }


        public void AddDateTimeMessage(DateTimeMessage message)
        {
            messageList.Add(message.DatetimeNow);
        }
    }
}
