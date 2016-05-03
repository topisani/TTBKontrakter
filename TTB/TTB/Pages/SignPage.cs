using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace TTB
{
    public delegate void SignatureSavedEventHandler(string path);
	public class SignPage : ContentPage
	{
        public event SignatureSavedEventHandler onSave;
        public string Filename { get; set; } = "signature";
		public SignPage ()
        {
            Title = "Underskrift";

            var drawSignature = new ImageWithTouch();

            var saveButton = new Button { Text = "Gem" };
            saveButton.Clicked += (sender, args) =>
            {
                onSave(drawSignature.Save(Filename));
            };

            var clearButton = new Button { Text = "Slet" };
            clearButton.Clicked += (sender, args) =>
            {
                drawSignature.Clear();
            };

            var layout = new RelativeLayout();

            layout.Children.Add(drawSignature,
                widthConstraint: Constraint.RelativeToParent(l => l.Bounds.Width),
                heightConstraint: Constraint.RelativeToParent(l => l.Bounds.Height - 50)
            );
            layout.Children.Add(saveButton,
                yConstraint: Constraint.RelativeToView(drawSignature, (l, v) => v.Bounds.Bottom),
                widthConstraint: Constraint.RelativeToParent(l => l.Bounds.Width / 2),
                heightConstraint: Constraint.Constant(50)
            );
            layout.Children.Add(clearButton,
                yConstraint: Constraint.RelativeToView(drawSignature, (l, v) => v.Bounds.Bottom),
                xConstraint: Constraint.RelativeToParent(l => l.Bounds.Width / 2),
                widthConstraint: Constraint.RelativeToParent(l => l.Bounds.Width / 2),
                heightConstraint: Constraint.Constant(50)
            );

            Content = layout;
        }
    }
}
