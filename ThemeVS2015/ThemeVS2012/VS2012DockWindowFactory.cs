using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UUI.Docking;

namespace UUI.ThemeVS2012
{
    internal class VS2012DockWindowFactory : DockPanelExtender.IDockWindowFactory
    {
        public DockWindow CreateDockWindow(DockPanel dockPanel, DockState dockState)
        {
            return new VS2012DockWindow(dockPanel, dockState);
        }
    }
}
