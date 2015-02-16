using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Apples4Oranges
{
    public partial class HomePage : TabbedPage
    {
        public HomePage()
        {
          InitializeComponent();
          this.Title = "Apples 4 Oranges";

          this.ItemSource = new string[] { "STUFF", "WHERE", "WANT" };
          this.ItemTemplate = new DataTemplate(() => { return new ContentPage(); }); 
        }
    }
}
