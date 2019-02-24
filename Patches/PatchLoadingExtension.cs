using System.Reflection;
using Harmony;
using ICities;

namespace Klyte.SuburbStyler.Patches
{
    public class PatchLoadingExtension : LoadingExtensionBase
    {
        private HarmonyInstance _harmony;

        public override void OnCreated(ILoading loading)
        {
            _harmony = HarmonyInstance.Create("Klyte.SuburbStyler");

            var originalMethod =
                typeof(BuildingAI).GetMethod("RenderProps", BindingFlags.NonPublic | BindingFlags.Instance);
            var prefix = typeof(BuildingAiRenderPropsPatch).GetMethod("Prefix");
            var postfix = typeof(BuildingAiRenderPropsPatch).GetMethod("Postfix");

            _harmony.Patch(originalMethod, new HarmonyMethod(prefix), new HarmonyMethod(postfix), null);

            BuildingDecorationManager.Ensure();
        }

        public override void OnReleased()
        {
            var originalMethod =
                typeof(BuildingAI).GetMethod("RenderProps", BindingFlags.NonPublic | BindingFlags.Instance);
            _harmony.Unpatch(originalMethod, HarmonyPatchType.Prefix);
            _harmony.Unpatch(originalMethod, HarmonyPatchType.Postfix);
        }
    }
}
