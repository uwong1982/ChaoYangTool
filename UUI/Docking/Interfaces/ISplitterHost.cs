using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UUI.Docking
{
    public interface ISplitterHost : ISplitterDragSource
    {
        DockPanel DockPanel { get; }
        DockState DockState { get; }
        bool IsDockWindow { get; }
    }
}
