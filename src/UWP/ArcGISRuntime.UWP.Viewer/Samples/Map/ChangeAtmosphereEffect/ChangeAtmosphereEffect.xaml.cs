﻿// Copyright 2018 Esri.
//
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License.
// You may obtain a copy of the License at: http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an 
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific 
// language governing permissions and limitations under the License.

using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.UI;
using System;

namespace ArcGISRuntime.UWP.Samples.ChangeAtmosphereEffect
{
    [ArcGISRuntime.Samples.Shared.Attributes.Sample(
        "Change atmosphere effect",
        "Map",
        "Change the appearance of the atmosphere in a scene.",
        "",
        "3D", "AtmosphereEffect", "Scene")]
    public partial class ChangeAtmosphereEffect
    {
        private readonly string _elevationServiceUrl = "http://elevation3d.arcgis.com/arcgis/rest/services/WorldElevation3D/Terrain3D/ImageServer";

        public ChangeAtmosphereEffect()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            // Create the scene with a basemap.
            MySceneView.Scene = new Scene(Basemap.CreateImagery());
            
            // Add an elevation source to the scene.
            Surface surface = new Surface();
            surface.ElevationSources.Add(new ArcGISTiledElevationSource(new Uri(_elevationServiceUrl)));
            MySceneView.Scene.BaseSurface = surface;

            // Set the initial viewpoint.
            Camera camera = new Camera(64.416919, -14.483728, 100, 318, 105, 0);
            MySceneView.SetViewpointCamera(camera);

            // Apply the selected atmosphere effect option.
            AtmosphereEffectPicker.SelectionChanged += (o, e) =>
            {
                switch (AtmosphereEffectPicker.SelectedIndex)
                {
                    case 0:
                        MySceneView.AtmosphereEffect = AtmosphereEffect.Realistic;
                        break;
                    case 1:
                        MySceneView.AtmosphereEffect = AtmosphereEffect.HorizonOnly;
                        break;
                    case 2:
                        MySceneView.AtmosphereEffect = AtmosphereEffect.None;
                        break;
                }
            };
        }
    }
}
