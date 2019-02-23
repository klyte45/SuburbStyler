using ColossalFramework;
using ColossalFramework.UI;
using Klyte.SuburbStyler.DecorationDescriptors;
using Klyte.SuburbStyler.Extensors;
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

namespace Klyte.SuburbStyler.MainWindow.Tabs
{
    internal class SSDecorationTabTrees : SSDecorationTab<TreeDescriptorManager, TreeInfo>
    {
        public override string TabIcon => "SubBarLandscapingTrees";

        public override string TabDescriptionLocale => "MAIN_CATEGORY[LandscapingTrees]";
    }
}
