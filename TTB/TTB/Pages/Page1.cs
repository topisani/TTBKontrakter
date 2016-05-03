using Xamarin.Forms;

namespace TTB
{
	public class Page1 : ContentPage
	{
		public Page1 ()
		{
            Title = "Information";
			Content = new StackLayout {
				Children = {
                    new Label { Text = "Navn" },
                    new Entry { Placeholder = "Niels Mortensen"},
				}
			};
		}
    }
}
