using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _1_ComplexDataObject
{
    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publish { get; set; }
        public string Price { get; set; }
        public string Date { get; set; }
        public string Descrption { get; set; }
        public string CoverImageUrl { get; set; }
    }

    /// <summary>
    /// 这里仅作演示，正常只定义Book类型即可
    /// </summary>
    public class ObservableBook : INotifyPropertyChanged
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

        private string price;

        public string Price 
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


        public void RaiseChanged([CallerMemberName]string memberName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
    }
}
