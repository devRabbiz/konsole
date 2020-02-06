﻿using System;

namespace Konsole
{
    public class StyleTheme
    {
        // can globally override the default theme.
        public static Func<StyleTheme> GlobalDefault = () => new StyleTheme();
        public static StyleTheme Default
        {
            get { return GlobalDefault(); }
        }
        
        public StyleTheme(Style active, Style inactive, Style disabled = null)
        {
            Active = active;
            Inactive = inactive;
            Disabled = disabled ?? inactive;
        }

        public StyleTheme(ConsoleColor foreground, ConsoleColor background)
        {
            Active = new Style(foreground, background);
            Inactive = Active;
            Disabled = Active;
        }

        public StyleTheme() 
        { 
            //Active = Style
        }

        public Style Active { get; }
        public Style Inactive { get; }
        public Style Disabled { get; }
        public StyleTheme WithActive(Style active)
        {
            return new StyleTheme(active, Inactive, Disabled);
        }

        public StyleTheme WithForeground(ConsoleColor color)
        {
            return new StyleTheme(
                Active.WithForeground(color),
                Inactive.WithForeground(color),
                Disabled.WithForeground(color)
            );
        }
        public StyleTheme WithColor(Colors colors)
        {
            return new StyleTheme(
                Active.WithColors(colors),
                Inactive.WithColors(colors),
                Disabled.WithColors(colors)
            );
        }


        public StyleTheme WithInactive(Style inactive)
        {
            return new StyleTheme(Active, inactive, Disabled);
        }
        public StyleTheme WithDisabled(Style disabled)
        {
            return new StyleTheme(Active, Inactive, disabled);
        }
    }

     

    public static class StyleThemeExtensions
    {
        public static Style GetActive(this StyleTheme src, ControlStatus status)
        {
            switch (status)
            {
                case ControlStatus.Active:
                    return src.Active;
                case ControlStatus.Inactive:
                    return src.Inactive;
                case ControlStatus.Disabled:
                    return src.Disabled;
                case ControlStatus.Undefined:
                    return src.Active;
                default:
                    return src.Active;
            }
        }
    }


}