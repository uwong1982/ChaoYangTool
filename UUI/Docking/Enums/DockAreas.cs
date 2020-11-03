using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UUI.Docking
{
    [Flags]
    [Serializable]
    [Editor(typeof(DockAreasEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public enum DockAreas
    {
        Float = 1,
        DockLeft = 2,
        DockRight = 4,
        DockTop = 8,
        DockBottom = 16,
        Document = 32
    }
}
