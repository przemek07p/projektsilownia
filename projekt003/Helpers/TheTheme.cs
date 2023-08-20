using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace projekt003.Helpers
{
   public static class TheTheme
    {
        public static void SetTheme()
        {
            switch (Setting.Theme)
            {
                //default
                case 0:
                    App.Current.UserAppTheme = OSAppTheme.Unspecified;
                    break;
                //light
                case 1:
                    App.Current.UserAppTheme = OSAppTheme.Light;
                    break;
                //dark
                case 2:
                    App.Current.UserAppTheme = OSAppTheme.Dark;
                    break;
            }
        }

    }
}
