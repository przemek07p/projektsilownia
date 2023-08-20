using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace projekt003.Helpers
{
    public static class Setting
    {
        // 0 = default, 1 = light, 2 = dark
        const int theme = 0;
        public static int Theme
        {
            get => Preferences.Get(nameof(Theme), theme);
            set => Preferences.Set(nameof(Theme), value);
        }
    }
}
