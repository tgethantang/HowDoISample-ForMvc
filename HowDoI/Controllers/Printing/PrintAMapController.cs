﻿using System.Collections.ObjectModel;
using System.Web.Mvc;
using ThinkGeo.MapSuite.Core;
using ThinkGeo.MapSuite.MvcEdition;

namespace CSharp_HowDoISamples
{
    public partial class PrintingController : Controller
    {
        public ActionResult PrintAMap()
        {
            Map map1 = new Map("Map1", new System.Web.UI.WebControls.Unit(100, System.Web.UI.WebControls.UnitType.Percentage), 510);
            map1.CurrentExtent = new RectangleShape(-131.22, 55.05, -54.03, 16.91);
            map1.MapUnit = GeographyUnit.DecimalDegree;

            WorldMapKitWmsWebOverlay worldMapKitOverlay = new WorldMapKitWmsWebOverlay();
            map1.CustomOverlays.Add(worldMapKitOverlay);

            ShapeFileFeatureLayer usStatesLayer = new ShapeFileFeatureLayer(Server.MapPath("~/App_Data/STATES.SHP"));
            usStatesLayer.ZoomLevelSet.ZoomLevel01.DefaultAreaStyle = AreaStyles.State2;
            usStatesLayer.ZoomLevelSet.ZoomLevel01.DefaultAreaStyle.OutlinePen.StartCap = DrawingLineCap.Round;
            usStatesLayer.ZoomLevelSet.ZoomLevel01.ApplyUntilZoomLevel = ApplyUntilZoomLevel.Level20;

            LayerOverlay staticOverlay = new LayerOverlay();
            staticOverlay.IsBaseOverlay = false;
            staticOverlay.Layers.Add(usStatesLayer);

            map1.CustomOverlays.Add(staticOverlay);

            return View(map1);
        }
    }
}