using System.Collections.Generic;

namespace Klyte.SuburbStyler.Model
{
    #region District Decoration
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
    #endregion

    #region Divider Definitions
    public abstract class DividerDefinition
    {
        public string Name { get; set; }

        /// <summary>
        /// width of the prop (or repeat distance)
        /// </summary>
        public float Width { get; set; }

        /// <summary>
        /// depth of the prop or tree. the generator will inset the dividers by the half depth.
        /// Can be 0.0 to place props on the lot border.
        /// </summary>
        public float Depth { get; set; }
    }

    public class TreeDividerDefinition : DividerDefinition
    {
        public string TreePrefabName { get; set; }
    }

    public class PropDividerDefinition : DividerDefinition
    {
        public string PropPrefabName { get; set; }
    }
    #endregion
}
