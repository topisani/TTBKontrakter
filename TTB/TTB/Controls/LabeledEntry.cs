using Xamarin.Forms;

namespace TTB.Controls
{
	public class LabeledEntry : ContentView
	{
        public string Label { get; set; }
        public View View { get; set; } = new Entry();
		public LabeledEntry ()
		{
            StackLayout layout = new StackLayout();
            layout.Children.Add(new Label
            {
                Text = Label
            });
            layout.Children.Add(View);
            Content = layout;
		}
	}
}
