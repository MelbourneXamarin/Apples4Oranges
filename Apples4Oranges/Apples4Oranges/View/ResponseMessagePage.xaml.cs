using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apples4Oranges.ViewModel;
using Xamarin.Forms;

namespace Apples4Oranges
{
    public partial class ResponseMessagePage : ContentPage
    {
        public ResponseMessagePage(long responseId)
        {
            InitializeComponent();
            listViewResponseMessages.ItemsSource = AppViewModel.ResponseMessages.Where(x=>x.ResponseId == responseId);
        }		 
    }
}
