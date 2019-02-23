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

namespace Klyte.SuburbStyler.Interfaces
{
    internal abstract class DecorationDescriptorManager<D, I> : Singleton<D>
        where D : DecorationDescriptorManager<D, I>
        where I : PrefabInfo
    {
        public abstract ICollection<I> ListPrefabs();
    }
}
