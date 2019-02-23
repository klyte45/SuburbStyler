using ColossalFramework.Globalization;
using ColossalFramework.UI;
using Klyte.SuburbStyler.MainWindow.Tabs;
using Klyte.SuburbStyler.TextureAtlas;
using Klyte.SuburbStyler.UI;
using Klyte.SuburbStyler.Utils;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Klyte.SuburbStyler.MainWindow
{

    public class SSPanel : UICustomControl
    {
        private static SSPanel m_instance;
        private UIComponent m_controlContainer;

        public static SSPanel Instance => m_instance;
        public UIPanel MainPanel { get; private set; }
        private UIScrollablePanel m_profileList;
        private UITabstrip m_tabstripCategories;



        #region Awake
        private void Awake()
        {
            m_instance = this;
            m_controlContainer = GetComponent<UIComponent>();
            m_controlContainer.name = "SSPanel";
            m_controlContainer.isInteractive = false;

            var lateralListWidth = 180;


            KlyteUtils.createUIElement(out UIPanel _mainPanel, GetComponent<UIPanel>().transform, "SSListPanel", new Vector4(0, 0, m_controlContainer.width, m_controlContainer.height));
            MainPanel = _mainPanel;
            MainPanel.backgroundSprite = "MenuPanel2";



            CreateTitleBar();
            KlyteUtils.CreateScrollPanel(_mainPanel, out m_profileList, out UIScrollbar scrollbar, lateralListWidth, m_controlContainer.height - 110, new Vector3(10, 100));

            KlyteUtils.createUIElement(out m_tabstripCategories, MainPanel.transform, "SSTabstrip", new Vector4(lateralListWidth + 30, 50, MainPanel.width - 340, 40));

            KlyteUtils.createUIElement(out UITabContainer tabContainer, MainPanel.transform, "SSTabContainer", new Vector4(lateralListWidth + 30, 90, MainPanel.width - 350, MainPanel.height - 90));
            m_tabstripCategories.tabPages = tabContainer;

            UIButton tabTrees = CreateTabTemplate();
            KlyteUtils.createUIElement(out UIPanel containerTrees, null);
            containerTrees.area = new Vector4(0, 0, tabContainer.width, tabContainer.height);
            containerTrees.backgroundSprite = "MainPanelInfo";
            containerTrees.color = Color.gray;
            m_tabstripCategories.AddTab(typeof(SSDecorationTabTrees).Name, tabTrees.gameObject, containerTrees.gameObject);
            var tabController = containerTrees.gameObject.AddComponent<SSDecorationTabTrees>();
            tabTrees.normalFgSprite = tabController.TabIcon;
            tabTrees.tooltipLocaleID = tabController.TabDescriptionLocale;
            tabTrees.isTooltipLocalized = true;

            m_tabstripCategories.selectedIndex = -1;
            //_mainPanel.gameObject.AddComponent<SSVehicleList>();
            //CreateTitleRow(out UIPanel title, _mainPanel);

            //SetPreviewWindow();
            //CreateRemoveUnwantedButton();

            //KlyteUtils.createUIElement(out UIPanel exportPanel, MainPanel.transform, "ImportExportPanel", new Vector4(480, 275, 380, 275));
            //exportPanel.gameObject.AddComponent<SSConfigFilesPanel>();

        }

        private void OnOpenClosePanel(UIComponent component, bool value)
        {
            if (value)
            {
                SuburbStyler.instance.showVersionInfoPopup();
            }
            if (m_tabstripCategories.selectedIndex < 0)
            {
                m_tabstripCategories.selectedIndex = 0;
            }
        }

        private void CreateTitleBar()
        {
            KlyteUtils.createUIElement(out UILabel titlebar, MainPanel.transform, "SSPanel", new Vector4(75, 10, MainPanel.width - 150, 20));
            titlebar.autoSize = false;
            titlebar.text = $"{SuburbStyler.instance.SimpleName} v{SuburbStyler.version}";
            titlebar.textAlignment = UIHorizontalAlignment.Center;
            KlyteUtils.createDragHandle(titlebar, SSController.GetMainReference());

            KlyteUtils.createUIElement(out UISprite logo, MainPanel.transform, "SSLogo", new Vector4(22, 5f, 32, 32));
            logo.atlas = SSCommonTextureAtlas.instance.atlas;
            logo.spriteName = "SSIcon";
            KlyteUtils.createDragHandle(logo, SSController.GetMainReference());
        }
        #endregion

        private void Update()
        {
            RotateCamera();
        }

        private AVOPreviewRenderer m_previewRenderer;
        private UITextureSprite m_preview;
        private UIPanel m_previewPanel;
        private VehicleInfo m_lastInfo;
        private UILabel m_previewTitle;

        public VehicleInfo PreviewInfo
        {
            get => m_lastInfo;
            set {
                m_lastInfo = value;
                m_previewTitle.text = Locale.Get("VEHICLE_TITLE", value.name);
            }
        }

        private void SetPreviewWindow()
        {
            KlyteUtils.createUIElement(out m_previewPanel, MainPanel.transform);
            m_previewPanel.backgroundSprite = "GenericPanel";
            m_previewPanel.width = MainPanel.width - 520f;
            m_previewPanel.height = m_previewPanel.width / 2;
            m_previewPanel.relativePosition = new Vector3(510, 80);
            KlyteUtils.createUIElement(out m_preview, m_previewPanel.transform);
            this.m_preview.size = m_previewPanel.size;
            this.m_preview.relativePosition = Vector3.zero;
            KlyteUtils.createElement(out m_previewRenderer, MainPanel.transform);
            this.m_previewRenderer.size = this.m_preview.size * 2f;
            this.m_preview.texture = this.m_previewRenderer.texture;
            m_previewRenderer.zoom = 3;
            m_previewRenderer.cameraRotation = 40;

            KlyteUtils.createUIElement(out m_previewTitle, MainPanel.transform, "previewTitle", new Vector4(510, 50, m_previewPanel.width, 30));
            m_previewTitle.textAlignment = UIHorizontalAlignment.Center;
        }

        public void RotateCamera()
        {
            if (m_lastInfo != default(VehicleInfo) && m_previewPanel.isVisible)
            {
                this.m_previewRenderer.cameraRotation -= 2;
                RedrawModel();
            }
        }

        private void RedrawModel()
        {
            if (m_lastInfo == default(VehicleInfo))
            {
                m_previewPanel.isVisible = false;
                return;
            }
            m_previewPanel.isVisible = true;
            m_previewRenderer.RenderVehicle(m_lastInfo, Color.HSVToRGB(Math.Abs(m_previewRenderer.cameraRotation) / 360f, .5f, .5f), true);
        }

        private static UIButton CreateTabTemplate()
        {
            KlyteUtils.createUIElement(out UIButton tabTemplate, null, "SSTabTemplate");
            KlyteUtils.initButton(tabTemplate, false, "GenericTab");
            tabTemplate.autoSize = false;
            tabTemplate.width = 40;
            tabTemplate.height = 40;
            tabTemplate.foregroundSpriteMode = UIForegroundSpriteMode.Scale;
            return tabTemplate;
        }
    }
}
