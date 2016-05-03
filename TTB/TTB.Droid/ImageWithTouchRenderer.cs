using System;
using System.ComponentModel;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using TTB;
using TTB.Droid;

[assembly: ExportRenderer(typeof(ImageWithTouch), typeof(ImageWithTouchRenderer))]
namespace TTB.Droid
{
    public class ImageWithTouchRenderer : ViewRenderer<ImageWithTouch, DrawView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ImageWithTouch> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                SetNativeControl(new DrawView(Context));
                Element.Save = Control.Save;
                Element.Clear = Control.Clear;
            }
        }
    }
}