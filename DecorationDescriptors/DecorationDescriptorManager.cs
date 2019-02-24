using Klyte.SuburbStyler.Interfaces;
using System.Collections.Generic;
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
