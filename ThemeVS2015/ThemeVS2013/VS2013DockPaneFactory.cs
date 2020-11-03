using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UUI.Docking;

namespace UUI.ThemeVS2013
{
    public class VS2013DockPaneFactory : DockPanelExtender.IDockPaneFactory
    {
        public DockPane CreateDockPane(IDockContent content, DockState visibleState, bool show)
        {
            return new VS2013DockPane(content, visibleState, show);
        }

        [SuppressMessage("Microsoft.Naming", "CA1720:AvoidTypeNamesInParameters", MessageId = "1#")]
        public DockPane CreateDockPane(IDockContent content, FloatWindow floatWindow, bool show)
        {
            return new VS2013DockPane(content, floatWindow, show);
        }

        public DockPane CreateDockPane(IDockContent content, DockPane previousPane, DockAlignment alignment, double proportion, bool show)
        {
            return new VS2013DockPane(content, previousPane, alignment, proportion, show);
        }

        [SuppressMessage("Microsoft.Naming", "CA1720:AvoidTypeNamesInParameters", MessageId = "1#")]
        public DockPane CreateDockPane(IDockContent content, Rectangle floatWindowBounds, bool show)
        {
            return new VS2013DockPane(content, floatWindowBounds, show);
        }
    }
}
