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
    public sealed class SuburbStyler : BasicIUserMod<SuburbStyler, SSLocaleUtils, SSResourceLoader, MonoBehaviour>
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

        private UIButton m_openKCPanelButton;
        private UIPanel m_ssPanelContainer;


        internal UIPanel SsPanelContainer
        {
            get {
                if (m_ssPanelContainer == null)
                {
                    UITabstrip toolStrip = ToolsModifierControl.mainToolbar.GetComponentInChildren<UITabstrip>();
                    KlyteUtils.createUIElement(out m_openKCPanelButton, null);
                    m_openKCPanelButton.size = new Vector2(43f, 49f);
                    m_openKCPanelButton.tooltip = "Suburb Styler (v" + SuburbStyler.version + ")";
                    m_openKCPanelButton.atlas = SSCommonTextureAtlas.instance.atlas;
                    m_openKCPanelButton.focusedColor = new Color32(128, 183, 240, 255);
                    m_openKCPanelButton.hoveredColor = new Color32(128, 240, 183, 255);
                    m_openKCPanelButton.disabledColor = new Color32(0, 0, 0, 255);
                    m_openKCPanelButton.normalBgSprite = "SuburbStylerIcon";
                    m_openKCPanelButton.focusedBgSprite = "SuburbStylerIcon";
                    m_openKCPanelButton.hoveredBgSprite = "SuburbStylerIcon";
                    m_openKCPanelButton.pressedBgSprite = "SuburbStylerIcon";
                    m_openKCPanelButton.disabledBgSprite = "SuburbStylerIcon";
                    m_openKCPanelButton.focusedFgSprite = "ToolbarIconGroup6Focused";
                    m_openKCPanelButton.hoveredFgSprite = "ToolbarIconGroup6Hovered";
                    m_openKCPanelButton.normalFgSprite = "";
                    m_openKCPanelButton.pressedFgSprite = "ToolbarIconGroup6Pressed";
                    m_openKCPanelButton.disabledFgSprite = "";
                    m_openKCPanelButton.playAudioEvents = true;
                    m_openKCPanelButton.tabStrip = true;

                    KlyteUtils.createUIElement(out m_ssPanelContainer, null);

                    toolStrip.AddTab("SuburbStyler", m_openKCPanelButton.gameObject, m_ssPanelContainer.gameObject);

                    m_ssPanelContainer.absolutePosition = new Vector3();
                    m_ssPanelContainer.clipChildren = false;
                }

                return m_ssPanelContainer;
            }
        }


        public static void OpenKCPanel()
        {
            if (instance.m_openKCPanelButton.state != UIButton.ButtonState.Focused)
            {
                instance.m_openKCPanelButton.SimulateClick();
            }
        }
        public static void CloseKCPanel()
        {
            if (instance.m_openKCPanelButton.state == UIButton.ButtonState.Focused)
            {
                instance.m_openKCPanelButton.SimulateClick();
            }
        }
    }
}
