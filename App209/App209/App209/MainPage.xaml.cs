using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App209
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        BarcodeModel barCodeModel;

        public MainPage()
        {
            InitializeComponent();

            barCodeModel = new BarcodeModel();
            barCodeModel.decodedData = "defaultValue";
            this.BindingContext = barCodeModel;

            MessagingCenter.Subscribe<object, BarcodeModel>(new object(), "barCodeScanned", (sender, arg) =>
            {
                BarcodeModel tempbarCodeModel = arg as BarcodeModel;
                barCodeModel.decodedData = tempbarCodeModel.decodedData;
            });
        }
    }

    public class BarcodeModel : INotifyPropertyChanged
    {
        private string data;
        public event PropertyChangedEventHandler PropertyChanged;

        public BarcodeModel()
        {

        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string decodedData
        {
            get { return data; }
            set { data = value; OnPropertyChanged(); }
        }
    }
}
