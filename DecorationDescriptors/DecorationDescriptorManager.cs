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

namespace Klyte.SuburbStyler.DecorationDescriptors
{
    internal class TreeDescriptorManager : DecorationDescriptorManager<TreeDescriptorManager, TreeInfo>
    {
        public override ICollection<TreeInfo> ListPrefabs()
        {
            return Resources.FindObjectsOfTypeAll<TreeInfo>();
        }
    }
}
