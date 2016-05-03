using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TTB
{
    public class ImageWithTouch : Image
    {
        public Func<string, string> Save { get; set; }
        public Action Clear { get; set; }
    }
}