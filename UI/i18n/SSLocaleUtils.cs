using ColossalFramework.Globalization;
using Klyte.SuburbStyler.Utils;
using System;

namespace Klyte.SuburbStyler.i18n
{
    public class SSLocaleUtils : KlyteLocaleUtils<SSLocaleUtils, SSResourceLoader>
    {
        public override string prefix => "SS_";

        protected override string packagePrefix => "Klyte.SuburbStyler";
    }
}
