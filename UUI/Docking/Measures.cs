using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UUI.Docking
{
    public class Measures
    {
        public int SplitterSize = 4;
        public int AutoHideSplitterSize = 4;
        public int AutoHideTabLineWidth = 6;
        public int DockPadding { get; set; }
    }

    internal static class MeasurePane
    {
        public const int MinSize = 24;
    }
}