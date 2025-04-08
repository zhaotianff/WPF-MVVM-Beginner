using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _3_ShowBookListWithAdd.Models
{
    public class Book : INotifyPropertyChanged
    {
        private string title;

        public string Title
        {
            get => title;
            set
            {
                title = value;
                RaiseChanged();
            }
        }

        private string author;
        public string Author
        {
            get => author;
            set
            {
                author = value;
                RaiseChanged();
            }
        }

        private string publish;

        public string Publish
        {
            get => publish;
            set
            {
                publish = value;
                RaiseChanged();
            }
        }

        private float price;

        public float Price
        {
            get => price;
            set
            {
                price = value;
                RaiseChanged();
            }
        }

        private string date;
        public string Date
        {
            get => date;
            set
            {
                date = value;
                RaiseChanged();
            }
        }

        private string description;

        public string Descrption
        {
            get => description;
            set
            {
                description = value;
                RaiseChanged();
            }
        }


        private string coverImageUrl;

        public string CoverImageUrl
        {
            get => coverImageUrl;
            set
            {
                coverImageUrl = value;
                RaiseChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;


        public void RaiseChanged([CallerMemberName] string memberName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
    }
}
