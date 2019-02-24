namespace Klyte.SuburbStyler.Model
{
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
}
