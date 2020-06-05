using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using QRCoder;
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

            BindingContext = new Model();
        }
    }

    public class Model : INotifyPropertyChanged
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

        private ObservableCollection<ImageSource> _images = new ObservableCollection<ImageSource>();

        public Model() {

            Images = new ObservableCollection<ImageSource>();

            var imageOne = GetQrImageAsBytes();
            var imageTwo = GetQrImageAsBytes();
            var imageThree = GetQrImageAsBytes();

            // This works
            //Images.Add(ImageSource.FromFile("logo.jpg"));
            //Images.Add(ImageSource.FromFile("sample.jpg"));
            //Images.Add(ImageSource.FromFile("ttt.png"));

            Images.Add(ImageSource.FromStream(() => new MemoryStream(imageOne)));
            Images.Add(ImageSource.FromStream(() => new MemoryStream(imageTwo)));
            Images.Add(ImageSource.FromStream(() => new MemoryStream(imageThree)));
        }

        private byte[] GetQrImageAsBytes()
        {
            var randomText = Guid.NewGuid().ToString();
            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(randomText, QRCodeGenerator.ECCLevel.L);
            var qRCode = new PngByteQRCode(qrCodeData);
            var qrCodeBytes = qRCode.GetGraphic(20);
            return qrCodeBytes;
        }
    }
}
