using Klyte.SuburbStyler.DecorationDescriptors;
using Klyte.SuburbStyler.Interfaces;

namespace Klyte.SuburbStyler.MainWindow.Tabs
{
    internal class SSDecorationTabTrees : SSDecorationTab<TreeDescriptorManager, TreeInfo>
    {
        public override string TabIcon => "SubBarLandscapingTrees";

        public override string TabDescriptionLocale => "MAIN_CATEGORY[LandscapingTrees]";
    }
}
