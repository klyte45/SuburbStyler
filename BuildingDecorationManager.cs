using ColossalFramework;
using UnityEngine;

namespace Klyte.SuburbStyler
{
    public class BuildingDecorationManager : Singleton<BuildingDecorationManager>
    {
        public BuildingInfo.Prop[] SampleProps
        {
            get
            {
                if (_sampleProps == null)
                {
                    ComposeSampleProps();
                }
                return _sampleProps;
            }
        }
        private BuildingInfo.Prop[] _sampleProps;

        public void ComposeSampleProps()
        {
            var grillProp = PrefabCollection<PropInfo>.FindLoaded("grill");
            var tree = PrefabCollection<TreeInfo>.FindLoaded("Tree3variant");
            _sampleProps = new[]
            {
                // back:
                new BuildingInfo.Prop()
                {
                    m_prop = grillProp,
                    m_tree = null,
                    m_position = new Vector3(-12, 0, -16),
                    m_angle = 0,
                    m_probability = 100,
                    m_fixedHeight = true,
                    m_finalProp = grillProp,
                    m_finalTree = null,
                    m_requiredLength = 4,
                    m_radAngle = 0,
                    m_index = 0
                },
                new BuildingInfo.Prop()
                {
                    m_prop = null,
                    m_tree = tree,
                    m_position = new Vector3(-4, 0, -16),
                    m_angle = 0,
                    m_probability = 100,
                    m_fixedHeight = true,
                    m_finalProp = null,
                    m_finalTree = tree,
                    m_requiredLength = 4,
                    m_radAngle = 0,
                    m_index = 1
                },
                new BuildingInfo.Prop()
                {
                    m_prop = null,
                    m_tree = tree,
                    m_position = new Vector3(4, 0, -16),
                    m_angle = 0,
                    m_probability = 100,
                    m_fixedHeight = true,
                    m_finalProp = null,
                    m_finalTree = tree,
                    m_requiredLength = 4,
                    m_radAngle = 0,
                    m_index = 2
                },
                new BuildingInfo.Prop()
                {
                    m_prop = grillProp,
                    m_tree = null,
                    m_position = new Vector3(12, 0, -16),
                    m_angle = 0,
                    m_probability = 100,
                    m_fixedHeight = true,
                    m_finalProp = grillProp,
                    m_finalTree = null,
                    m_requiredLength = 4,
                    m_radAngle = 0,
                    m_index = 3
                },
                // front:
                new BuildingInfo.Prop()
                {
                    m_prop = grillProp,
                    m_tree = null,
                    m_position = new Vector3(0, 0, 16),
                    m_angle = 0,
                    m_probability = 100,
                    m_fixedHeight = true,
                    m_finalProp = grillProp,
                    m_finalTree = null,
                    m_requiredLength = 4,
                    m_radAngle = 0,
                    m_index = 4
                },
                new BuildingInfo.Prop()
                {
                    m_prop = null,
                    m_tree = tree,
                    m_position = new Vector3(-12, 0, 16),
                    m_angle = 0,
                    m_probability = 100,
                    m_fixedHeight = true,
                    m_finalProp = null,
                    m_finalTree = tree,
                    m_requiredLength = 4,
                    m_radAngle = 0,
                    m_index = 5
                },
                new BuildingInfo.Prop()
                {
                    m_prop = null,
                    m_tree = tree,
                    m_position = new Vector3(12, 0, 16),
                    m_angle = 0,
                    m_probability = 100,
                    m_fixedHeight = true,
                    m_finalProp = null,
                    m_finalTree = tree,
                    m_requiredLength = 4,
                    m_radAngle = 0,
                    m_index = 6
                },
            };
        }
    }
}
