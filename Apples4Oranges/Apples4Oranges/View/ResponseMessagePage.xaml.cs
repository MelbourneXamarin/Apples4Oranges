using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apples4Oranges.ViewModel;
using Xamarin.Forms;
using Apples4Oranges.Controls;

namespace Apples4Oranges
{
    public partial class ResponseMessagePage : ContentPage
    {
        public ResponseMessagePage(long responseId)
        {
            InitializeComponent();
            listViewResponseMessages.ItemsSource = AppViewModel.ResponseMessages.Where(x=>x.Response.Id == responseId);

            listViewResponseMessages.VerticalOptions = LayoutOptions.FillAndExpand;

            listViewResponseMessages.ItemTemplate = new DataTemplate(CreateMessageCell);
        }
        private Cell CreateMessageCell()
        {
            var timestampLabel = new Label();
            timestampLabel.SetBinding(Label.TextProperty, new Binding("Timestamp", stringFormat: "[{0:HH:mm}]"));
            timestampLabel.TextColor = Color.Silver;
            timestampLabel.Font = Font.SystemFontOfSize(14);

            var authorLabel = new Label();
            authorLabel.SetBinding(Label.TextProperty, new Binding("Response.UserName", stringFormat: "{0}: "));
            authorLabel.TextColor = Device.OnPlatform(Color.Blue, Color.Yellow, Color.Yellow);
            authorLabel.Font = Font.SystemFontOfSize(14);

            var messageLabel = new Label();
            messageLabel.SetBinding(Label.TextProperty, new Binding("Body"));
            messageLabel.Font = Font.SystemFontOfSize(14);

            var stack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { authorLabel, messageLabel }
            };

            if (Device.Idiom == TargetIdiom.Tablet)
            {
                stack.Children.Insert(0, timestampLabel);
            }

            var view = new MessageViewCell
            {
                View = stack
            };
            return view;
        }
    }
}
