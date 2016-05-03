using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TTB.Pages
{
	public partial class Oplysningsskema : ContentPage
	{
		public Oplysningsskema ()
		{
			InitializeComponent ();
		}

        public void OpenSignPage(object sender, EventArgs args)
        {
            SignPage sign = new SignPage();
            Navigation.PushAsync(sign);
            sign.onSave += (filename) =>
            {
                Navigation.PopAsync();
            };
        }
	}
}
