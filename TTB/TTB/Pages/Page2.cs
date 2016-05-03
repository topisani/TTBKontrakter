using Xamarin.Forms;

namespace TTB.Pages
{
	public class Indmeldelsesblanket : ContentPage
	{
		public Indmeldelsesblanket ()
		{
            Title = "Indmeldelsesblanket";
			Content = new StackLayout {
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}
