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

namespace Klyte.SuburbStyler
{
    public class SSController : MonoBehaviour
    {

        private UIButton m_openSSPanelButton;

        private void Start()
        {
            CreateSsPanel();
        }


        /// <summary>
        /// This method will be hooked at Klyte Commons to point to the whole Klyte Mods Panel
        /// </summary>
        /// 
        public UIComponent GetMainReference()
        {
            return SSPanel.Instance.MainPanel;
        }

        /// <summary>
        /// This method will be hooked at Klyte Commons to create a new tab at the 45's button instead of new button at the game toolbar
        /// </summary>

        private void CreateSsPanel()
        {
            UITabstrip toolStrip = ToolsModifierControl.mainToolbar.GetComponentInChildren<UITabstrip>();
            KlyteUtils.createUIElement(out m_openSSPanelButton, null);
            m_openSSPanelButton.size = new Vector2(43f, 49f);
            m_openSSPanelButton.tooltip = "Suburb Styler (v" + SuburbStyler.version + ")";
            m_openSSPanelButton.atlas = SSToolbarTextureAtlas.instance.atlas;
            m_openSSPanelButton.focusedColor = new Color32(128, 183, 240, 255);
            m_openSSPanelButton.hoveredColor = new Color32(128, 240, 183, 255);
            m_openSSPanelButton.disabledColor = new Color32(0, 0, 0, 255);
            m_openSSPanelButton.normalBgSprite = "SuburbStylerIcon";
            m_openSSPanelButton.focusedBgSprite = "SuburbStylerIcon";
            m_openSSPanelButton.hoveredBgSprite = "SuburbStylerIcon";
            m_openSSPanelButton.pressedBgSprite = "SuburbStylerIcon";
            m_openSSPanelButton.disabledBgSprite = "SuburbStylerIcon";
            m_openSSPanelButton.focusedFgSprite = "ToolbarIconGroup6Focused";
            m_openSSPanelButton.hoveredFgSprite = "ToolbarIconGroup6Hovered";
            m_openSSPanelButton.normalFgSprite = "";
            m_openSSPanelButton.pressedFgSprite = "ToolbarIconGroup6Pressed";
            m_openSSPanelButton.disabledFgSprite = "";
            m_openSSPanelButton.playAudioEvents = true;
            m_openSSPanelButton.tabStrip = true;

            KlyteUtils.createUIElement(out UIPanel ssPanelContainerRoot, null);

            toolStrip.AddTab("SuburbStyler", m_openSSPanelButton.gameObject, ssPanelContainerRoot.gameObject);
            KlyteUtils.createUIElement(out UIPanel ssPanelContainer, ssPanelContainerRoot.transform);

            ssPanelContainer.absolutePosition = new Vector4(0, 0, 0, 0);
            ssPanelContainer.clipChildren = false;

            KlyteUtils.createUIElement(out UIPanel ssInternalPanel, ssPanelContainer.transform);
            ssInternalPanel.area = new Vector4(400, 200, 875, 550);
            ssInternalPanel.gameObject.AddComponent<SSPanel>();
        }
        /// <summary>
        /// This method will be hooked at Klyte Commons to close the whole KC button instead of the SS window
        /// </summary>
        public static void OpenSsPanel()
        {
            if (SuburbStyler.instance.controller.m_openSSPanelButton.state != UIButton.ButtonState.Focused)
            {
                SuburbStyler.instance.controller.m_openSSPanelButton.SimulateClick();
            }
        }
        /// <summary>
        /// This method will be hooked at Klyte Commons to open the SS tab at the 45's button instead of local button
        /// </summary>
        public static void CloseSsPanel()
        {
            if (SuburbStyler.instance.controller.m_openSSPanelButton.state == UIButton.ButtonState.Focused)
            {
                SuburbStyler.instance.controller.m_openSSPanelButton.SimulateClick();
            }
        }
    }
}
