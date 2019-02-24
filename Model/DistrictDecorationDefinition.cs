using System.Collections.Generic;

namespace Klyte.SuburbStyler.Model
{
    public class DistrictDecoration
    {
        public string Name { get; set; }

        public List<TreeElement> Trees { get; set; }

        // Value between 0.0 and 1.0
        public float TreeDensity { get; set; }

        public List<DividerElement> Dividers { get; set; }

        // Value between 0.0 and 1.0
        public float DividerDensity { get; set; }

        public List<GroundElement> GroundElement { get; set; }

        // Value between 0.0 and 1.0
        public float GroundDensity { get; set; }
    }

    public class TreeElement : DistrictDecorationElement
    {
        public string TreePrefabName { get; set; }
    }

    public class DividerElement : DistrictDecorationElement
    {
        public string DividerDefinitionName { get; set; }
    }

    public class GroundElement : DistrictDecorationElement
    {
        public string GroundDecoratorName { get; set; }
    }

    public class DistrictDecorationElement
    {
        public int Weight { get; set; }
    }
}
