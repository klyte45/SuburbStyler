using ColossalFramework;
using ColossalFramework.UI;
using Klyte.SuburbStyler.Interfaces;
using Klyte.SuburbStyler.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace Klyte.SuburbStyler.TextureAtlas
{
    public class SSCommonTextureAtlas : TextureAtlasDescriptor<SSCommonTextureAtlas, SSResourceLoader>
    {
        protected override string ResourceName => "UI.Images.sprites.png";
        protected override string CommonName => "SuburbStylerSprites";
        public override string[] SpriteNames => new string[] {
                  "SSIcon","AutoNameIcon","AutoColorIcon","RemoveUnwantedIcon","ConfigIcon","24hLineIcon", "PerHourIcon","AbsoluteMode","RelativeMode"
                };
    }
}
