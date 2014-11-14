using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ESRI.ArcGIS.Desktop.AddIns;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.esriSystem;

namespace fieldDivider
{
    public class fieldDividerButton : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public fieldDividerButton()
        {
        }

        protected override void OnClick()
        {
            //
            //  TODO: Sample code showing how to access button host
            //
            ArcMap.Application.CurrentTool = null;
            UID dockWinID = new UIDClass();
            dockWinID.Value = ThisAddIn.IDs.fieldDividerWindow;
            IDockableWindow fieldDividerWindow = ArcMap.DockableWindowManager.GetDockableWindow(dockWinID);
            if (!fieldDividerWindow.IsVisible())
            {
                fieldDividerWindow.Show(true);
            }
            else
            {
                fieldDividerWindow.Show(false);
            }
        }
        protected override void OnUpdate()
        {
            Enabled = ArcMap.Application != null;
        }
    }

}
