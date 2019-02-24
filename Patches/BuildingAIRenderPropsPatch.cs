namespace Klyte.SuburbStyler.Patches
{
    public static class BuildingAiRenderPropsPatch
    {
        public static void Prefix(BuildingAI __instance, ushort buildingID, ref Building data, out BuildingInfo.Prop[] __state)
        {
            var districtId = DistrictManager.instance.GetDistrict(data.m_position);

            if (districtId != 0 && __instance.m_info.name == "L1 3x4 Detached08")
            {
                __state = __instance.m_info.m_props;
                __instance.m_info.m_props = BuildingDecorationManager.instance.SampleProps;
            }
            else
            {
                __state = null;
            }
        }

        public static void Postfix(BuildingAI __instance, BuildingInfo.Prop[] __state)
        {
            if (__state != null)
            {
                __instance.m_info.m_props = __state;
            }
        }
    }
}
