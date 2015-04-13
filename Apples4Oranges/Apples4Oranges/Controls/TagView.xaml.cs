using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Apples4Oranges.Controls
{
    public partial class TagView: ContentView
    {
        public TagView()
        {
            InitializeComponent();
            labelTag.GestureRecognizers.Add(new TapGestureRecognizer((view) => OnTagTapped()));
            labelTagRemove.GestureRecognizers.Add(new TapGestureRecognizer((view) => OnTagTapped()));
        }

        /// <summary>
        /// Backing Storage for the Tag property
        /// </summary>
        public static readonly BindableProperty TagProperty =
            BindableProperty.Create<TagView, String>(w => w.Tag,
                                defaultValue: string.Empty,
                                defaultBindingMode: BindingMode.OneWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var ctrl = (TagView)bindable;
            ctrl.labelTag.Text = newValue;
        });


        
        /// <summary>
        /// Orientation (Horizontal or Vertical)
        /// </summary>
        public String Tag
        {
            get { return (String)GetValue(TagProperty); }
            set
            {
                SetValue(TagProperty, value);
                labelTag.Text = value;
            }
        }

        
        void OnTagTapped()
        {
            if (labelTag.Text == "Add...")
                return;

            this.IsVisible = false;
        }
    }
}
