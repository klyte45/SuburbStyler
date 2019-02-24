using ColossalFramework;
using ColossalFramework.UI;
using Klyte.SuburbStyler.Extensors;
using Klyte.SuburbStyler.Utils;
using System;
using UnityEngine;

namespace Klyte.SuburbStyler.Interfaces
{
    internal abstract class SSDecorationTab : UICustomControl
    {
        public abstract string TabIcon { get; }
        public abstract string TabDescriptionLocale { get; }
    }
    internal abstract class SSDecorationTab<D, I> : SSDecorationTab
        where D : DecorationDescriptorManager<D, I>
        where I : PrefabInfo
    {
        private UIPanel m_mainPanel;
        private UIScrollablePanel m_scrollPanel;

        public virtual void AfterAwake() { }

        public void Awake()
        {
            m_mainPanel = GetComponent<UIPanel>();

            KlyteUtils.CreateScrollPanel(m_mainPanel, out m_scrollPanel, out UIScrollbar scrollbar, m_mainPanel.width, m_mainPanel.height - 10, new Vector3(0, 0));
            m_scrollPanel.autoLayout = true;
            m_scrollPanel.autoLayoutDirection = LayoutDirection.Vertical;

            AfterAwake();

            LoadList();
        }

        public void LoadList()
        {
            foreach (Transform child in m_scrollPanel?.transform)
            {
                GameObject.Destroy(child?.gameObject);
            }
            var itemList = Singleton<D>.instance.ListPrefabs();
            foreach (var item in itemList)
            {
                KlyteUtils.createUIElement(out UIPanel prefabLine, m_scrollPanel.transform, item.name, new Vector4(0, 0, m_scrollPanel.width, 40));
                TabListLine lineItem = prefabLine.gameObject.AddComponent<TabListLine>();
                lineItem.PrefabInfo = item;
            }
            OnNameSort();
        }

        private static int CompareNames(UIComponent left, UIComponent right)
        {
            var component = left.GetComponent<TabListLine>();
            var component2 = right.GetComponent<TabListLine>();
            return string.Compare(component.EffectiveText, component2.EffectiveText, StringComparison.InvariantCulture);
        }


        private void OnNameSort()
        {
            if (m_scrollPanel.components.Count == 0)
                return;
            KlyteUtils.Quicksort(m_scrollPanel.components, new Comparison<UIComponent>(CompareNames), false);
        }

    }

    internal class TabListLine : UICustomControl
    {
        private static readonly Color32 m_backgroundColor = new Color32(49, 52, 58, 255);
        private static readonly Color32 m_foregroundColor = new Color32(185, 221, 254, 255);
        private static readonly Color32 m_selectionBgColor = new Color32(233, 201, 148, 255);

        private UIPanel m_mainPanel;
        private UICheckBox m_checkbox;
        private UIPanel m_preview;
        private PrefabInfo m_prefabInfo;

        private bool m_mouseIsOver;

        internal OnCheckUncheckPrefab m_callback;
        internal PrefabInfo PrefabInfo
        {
            get {
                return m_prefabInfo;
            }
            set {
                m_checkbox.text = value.GetLocalizedTitle();
                m_preview.atlas = value.m_InfoTooltipAtlas;
                m_preview.backgroundSprite = value.m_InfoTooltipThumbnail;
                m_prefabInfo = value;
            }
        }

        internal string EffectiveText => m_checkbox.text;

        void Awake()
        {
            m_mainPanel = GetComponent<UIPanel>();
            m_mainPanel.autoLayout = true;
            m_mainPanel.autoLayoutDirection = LayoutDirection.Horizontal;
            m_mainPanel.wrapLayout = false;
            m_mainPanel.padding.left = 10;
            var uiHelper = new UIHelperExtension(m_mainPanel);
            m_checkbox = uiHelper.AddCheckbox("<<>>", false, (x) => { m_callback?.Invoke(x); }) as UICheckBox;
            m_checkbox.width = m_mainPanel.width - 144;
            m_checkbox.height = 40;
            m_checkbox.label.height = 40;
            m_checkbox.label.verticalAlignment = UIVerticalAlignment.Middle;
            m_preview = m_mainPanel.AddUIComponent<UIPanel>();
            m_preview.area = new Vector4(0, 0, 134, 40);

            m_checkbox.isInteractive = false;
            m_checkbox.label.isInteractive = false;
            m_preview.isInteractive = false;
            m_mainPanel.eventClicked += (x, y) => m_checkbox.isChecked = !m_checkbox.isChecked;

            m_mouseIsOver = false;
            m_mainPanel.eventMouseEnter += new MouseEventHandler(OnMouseEnter);
            m_mainPanel.eventMouseLeave += new MouseEventHandler(OnMouseLeave);
            m_mainPanel.backgroundSprite = "InfoviewPanel";
            SetBackgroundColor();

            component.eventZOrderChanged += delegate (UIComponent c, int r)
            {
                SetBackgroundColor();
            };
        }

        private void SetBackgroundColor()
        {
            Color32 backgroundColor = m_backgroundColor;
            backgroundColor.a = (byte)((base.component.zOrder % 2 != 0) ? 127 : 255);
            if (m_mouseIsOver)
            {
                backgroundColor.r = (byte)Mathf.Min(255, backgroundColor.r * 3 >> 1);
                backgroundColor.g = (byte)Mathf.Min(255, backgroundColor.g * 3 >> 1);
                backgroundColor.b = (byte)Mathf.Min(255, backgroundColor.b * 3 >> 1);
            }
            m_mainPanel.color = backgroundColor;
        }

        private void OnMouseEnter(UIComponent comp, UIMouseEventParameter param)
        {
            if (!m_mouseIsOver)
            {
                m_mouseIsOver = true;
                SetBackgroundColor();
            }
        }

        private void OnMouseLeave(UIComponent comp, UIMouseEventParameter param)
        {
            if (m_mouseIsOver)
            {
                m_mouseIsOver = false;
                SetBackgroundColor();
            }
        }



    }
    internal delegate void OnCheckUncheckPrefab(bool chk);
}
