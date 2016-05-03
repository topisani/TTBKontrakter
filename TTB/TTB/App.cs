using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTB.Pages;
using Xamarin.Forms;

namespace TTB
{
	public class App : Application
	{
		public App ()
		{
            // The root page of your application
            MainPage = new NavigationPage(new Oplysningsskema());
            NavigationPage.SetHasBackButton(MainPage, false);
            NavigationPage.SetHasNavigationBar(MainPage, false);
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
