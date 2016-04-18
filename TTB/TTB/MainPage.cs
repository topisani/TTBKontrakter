using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace TTB
{
    class MainPage : ContentPage
    {
        private const int PalleteSpacing = 3;
        private ImageWithTouch DrawingImage;
        private Dictionary<string, Color> ColorPallete;

        public MainPage()
        {
            Title = "Tid til Børn formular dippedut";
            var layout = new AbsoluteLayout();

            var saveButton = new Button { Text = "Save" };
            AbsoluteLayout.SetLayoutBounds(saveButton, new Rectangle(.25, 1, .25, .1));
            AbsoluteLayout.SetLayoutFlags(saveButton, AbsoluteLayoutFlags.All);

            var drawSignature = new ImageWithTouch
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White
            };
            AbsoluteLayout.SetLayoutBounds(drawSignature, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(drawSignature, AbsoluteLayoutFlags.All);

            layout.Children.Add(saveButton);
            layout.Children.Add(drawSignature);

            Content = layout;
        }

        private Frame BuildDrawingFrame()
        {
            DrawingImage = new ImageWithTouch
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White
            };

            var palleteFrame = new Frame
            {
                BackgroundColor = Color.White,
                HasShadow = false,
                OutlineColor = Color.Black,
                Content = DrawingImage
            };

            return palleteFrame;
        }

        #region Event Handlers

        #endregion

    }
}
