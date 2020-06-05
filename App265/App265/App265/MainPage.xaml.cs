using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App265
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new model();
        }
    }

    public class model : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ObservableCollection<ImageSource> Images
        {
            get => _images;
            set
            {
                _images = value;
                OnPropertyChanged("Images");
            }
        }

        public ObservableCollection<ImageSource> _images { get; private set; }

        public model() {

            Images = new ObservableCollection<ImageSource>();
            Images.Add(ImageSource.FromFile("logo.jpg"));
            Images.Add(ImageSource.FromFile("sample.jpg"));
            Images.Add(ImageSource.FromFile("ttt.png"));
        }
    }
}
