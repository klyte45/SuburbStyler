using ColossalFramework;
using ColossalFramework.Globalization;
using ColossalFramework.UI;
using ICities;
using Klyte.SuburbStyler.Extensors;
using Klyte.SuburbStyler.i18n;
using Klyte.SuburbStyler.Interfaces;
using Klyte.SuburbStyler.TextureAtlas;
using Klyte.SuburbStyler.UI;
using Klyte.SuburbStyler.Utils;
using System;
using System.Linq;
using System.Reflection;
using UnityEngine;

[assembly: AssemblyVersion("0.0.0.9999")]
namespace Klyte.SuburbStyler
{
    public sealed class SuburbStyler : BasicIUserMod<SuburbStyler, SSLocaleUtils, SSResourceLoader, SSController>
    {
        public override string SimpleName => "Suburb Styler";
        public override string Description => "Allows customizing decoration in lots of the low level residences at the districts";

        public override void doErrorLog(string fmt, params object[] args)
        {
            KlyteUtils.doErrorLog(fmt, args);
        }

        public override void doLog(string fmt, params object[] args)
        {
            KlyteUtils.doLog(fmt, args);
        }

        public override void LoadSettings()
        {

        }

        public SuburbStyler()
        {
            Construct();
            LocaleManager.eventLocaleChanged += new LocaleManager.LocaleChangedHandler(AutoLoadLocale);
        }

        public override void TopSettingsUI(UIHelperExtension ext)
        {

        }

        public override void Group9SettingsUI(UIHelperExtension group9)
        {
            group9.AddDropdownLocalized("SS_MOD_LANG", SSLocaleUtils.instance.getLanguageIndex(), SSLocaleUtils.currentLanguageId.value, delegate (int idx)
            {
                SSLocaleUtils.currentLanguageId.value = idx;
                loadLocale(true);
            });
        }

        public void AutoLoadLocale()
        {
            loadLocale(false);
        }
    }
}
