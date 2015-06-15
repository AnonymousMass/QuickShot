namespace CaptureItPlus
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Media;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using System.Xml.Serialization;
    using CaptureItPlus.Capturemodes;
    using dotnetthoughts.CaptureItPlus;
    using Microsoft.Win32;
    using System.Xml;

    public static class Common
    {
        private static bool _isCaptureIsActive;
        public static bool IsCaptureIsActive
        {
            get
            {
                return _isCaptureIsActive;
            }
            set
            {
                _isCaptureIsActive = value;
            }
        }

        public enum CaptureModes
        {
            FreeForm,Rectangle
        }      

        public static IEnumerable<ICaptureMode> LoadPlugins(ToolStripMenuItem toolCaptures, EventHandler executeHandler)
        {
            toolCaptures.DropDownItems.Clear();
            var bootStrapper = new GenericBootStrapper<ICaptureMode>();
            bootStrapper.Compose();

            if (null != bootStrapper.Items)
            {
                List<ICaptureMode> captureModes = new List<ICaptureMode>(bootStrapper.Items);
                captureModes.Sort(delegate(ICaptureMode capturemode1, ICaptureMode capturemode2)
                {
                    return capturemode1.Name.CompareTo(capturemode2.Name);
                });

                foreach (var menuItem in captureModes)
                {
                    if (menuItem.IsEnabled)
                    {
                        var capturemode = new ToolStripMenuItem(menuItem.Text);
                        capturemode.Click += executeHandler;
                        capturemode.Tag = menuItem;
                        toolCaptures.DropDownItems.Add(capturemode);
                    }
                }
            }
            return bootStrapper.Items;
        }

    }
}

