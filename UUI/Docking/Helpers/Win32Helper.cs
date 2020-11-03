﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UUI.Docking
{
    public static class Win32Helper
    {
        private static readonly bool _isRunningOnMono = Type.GetType("Mono.Runtime") != null;

        public static bool IsRunningOnMono { get { return _isRunningOnMono; } }

        internal static Control ControlAtPoint(Point pt)
        {
            return Control.FromChildHandle(NativeMethods.WindowFromPoint(pt));
        }

        internal static uint MakeLong(int low, int high)
        {
            return (uint)((high << 16) + low);
        }

        internal static uint HitTestCaption(Control control)
        {
            var captionRectangle = new Rectangle(0, 0, control.Width, control.ClientRectangle.Top - control.PointToClient(control.Location).X);
            return captionRectangle.Contains(Control.MousePosition) ? (uint)2 : 0;
        }
    }
}