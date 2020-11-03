using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UUI.Docking
{
    public interface IDockContent : IContextMenuStripHost
    {
        DockContentHandler DockHandler { get; }
        void OnActivated(EventArgs e);
        void OnDeactivate(EventArgs e);
    }
}
