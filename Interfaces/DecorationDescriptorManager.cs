using ColossalFramework;
using System.Collections.Generic;

namespace Klyte.SuburbStyler.Interfaces
{
    internal abstract class DecorationDescriptorManager<D, I> : Singleton<D>
        where D : DecorationDescriptorManager<D, I>
        where I : PrefabInfo
    {
        public abstract ICollection<I> ListPrefabs();
    }
}
