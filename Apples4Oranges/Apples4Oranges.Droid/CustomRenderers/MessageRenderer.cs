using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using System.ComponentModel;
using System.Net;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using View = Android.Views.View;
using Apples4Oranges.ViewModel;
using Apples4Oranges.Controls;
using Apples4Oranges.Droid.CustomRenderers;
using Apples4Oranges.Model;
using System.Collections.ObjectModel;
[assembly: ExportRenderer(typeof(MessageViewCell), typeof(MessageRenderer))]

namespace Apples4Oranges.Droid.CustomRenderers
{
    public class MessageRenderer : ViewCellRenderer
    {
        protected override View GetCellCore(Cell item, View convertView, ViewGroup parent, Context context)
        {
            var inflatorservice = (LayoutInflater)Forms.Context.GetSystemService(Android.Content.Context.LayoutInflaterService);
            
            var textMsgVm = item.BindingContext as ResponseMessage;
                
            if (textMsgVm != null)
            {
                if (textMsgVm.ImageId.HasValue)
                {
                    var template = (LinearLayout)inflatorservice.Inflate(textMsgVm.User.UserId == AppViewModel.CurrentUserId ? Resource.Layout.image_item_owner : Resource.Layout.image_item_opponent, null, false);
                    template.FindViewById<TextView>(Resource.Id.timestamp).Text = textMsgVm.Timestamp.ToString("HH:mm");
                    template.FindViewById<TextView>(Resource.Id.nick).Text = textMsgVm.User.UserId == AppViewModel.CurrentUserId ? "Me:" : textMsgVm.User.UserHandle + ":";
                    template.FindViewById<ImageView>(Resource.Id.image).SetImageBitmap(GetImageBitmapFromUrl(textMsgVm.ImageUrl));
                    return template;
                }
                else
                {
                    var template = (LinearLayout)inflatorservice.Inflate(textMsgVm.User.UserId == AppViewModel.CurrentUserId ? Resource.Layout.message_item_owner : Resource.Layout.message_item_opponent, null, false);
                    template.FindViewById<TextView>(Resource.Id.timestamp).Text = textMsgVm.Timestamp.ToString("HH:mm");
                    template.FindViewById<TextView>(Resource.Id.nick).Text = textMsgVm.User.UserId == AppViewModel.CurrentUserId ? "Me:" : textMsgVm.User.UserHandle + ":";
                    template.FindViewById<TextView>(Resource.Id.message).Text = textMsgVm.Body;
                    return template;
                }
            }

            return base.GetCellCore(item, convertView, parent, context);
        }

        private Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;
            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }
            return imageBitmap;
        }


        protected override void OnCellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnCellPropertyChanged(sender, e);
        }
    }
}