using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UUI.ThemeVS2015
{
    /// <summary>
    /// Visual Studio 2015 Light theme.
    /// </summary>
    public class VS2015DarkTheme : VS2015ThemeBase
    {
        public VS2015DarkTheme()
            : base(Decompress(Resources.vs2015dark_vstheme))
        {
        }
    }
}
