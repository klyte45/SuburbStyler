using Klyte.SuburbStyler.Utils;

namespace Klyte.SuburbStyler.i18n
{
    public class SSLocaleUtils : KlyteLocaleUtils<SSLocaleUtils, SSResourceLoader>
    {
        public override string prefix => "SS_";

        protected override string packagePrefix => "Klyte.SuburbStyler";
    }
}
