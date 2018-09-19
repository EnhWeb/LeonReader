﻿using LeonDirectUI.Container;
using LeonDirectUI.DUIControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeonReader.Client.DirectUI.Container
{
    /// <summary>
    /// 卡片控件基础容器
    /// </summary>
    public class CardContainer : ContainerBase
    {

        #region 自定义属性
        //TODO: 添加自定义属性到这里

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get => DUITitleLabel.Text; set => DUITitleLabel.Text = value; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get => DUIDescriptionLabel.Text; set => DUIDescriptionLabel.Text = value; }

        /// <summary>
        /// 预览图
        /// </summary>
        public Image PreviewImage { get => DUIPreviewImageBox.Image; set => DUIPreviewImageBox.Image = value; }

        #endregion

        #region 虚拟控件

        /// <summary>
        /// 预览图像区域
        /// </summary>
        protected ControlBase DUIPreviewImageBox;

        /// <summary>
        /// 文章标题区域
        /// </summary>
        protected ControlBase DUITitleLabel;

        /// <summary>
        /// 文章描述区域
        /// </summary>
        protected ControlBase DUIDescriptionLabel;

        /// <summary>
        /// 发布时间区域
        /// </summary>
        protected ControlBase DUIPublishTimeLabel;

        /// <summary>
        /// 状态区域
        /// </summary>
        protected ControlBase DUIStateLabel;

        /// <summary>
        /// 主按钮区域
        /// </summary>
        protected ControlBase DUIMainButton;

        /// <summary>
        /// 已读按钮区域
        /// </summary>
        protected ControlBase DUIReadedButton;

        /// <summary>
        /// 定位文件夹按钮
        /// </summary>
        protected ControlBase DUILocationButton;

        /// <summary>
        /// 在浏览器打开按钮
        /// </summary>
        protected ControlBase DUIBrowserButton;

        /// <summary>
        /// 删除按钮
        /// </summary>
        protected ControlBase DUIDeleteButton;

        #endregion

        #region 样式布局

        /// <summary>
        /// 卡片样式
        /// </summary>
        public enum CardStyles
        {
            /// <summary>
            /// 精简
            /// </summary>
            Small = 0,
            /// <summary>
            /// 正常
            /// </summary>
            Normal = 1,
            /// <summary>
            /// 巨幅
            /// </summary>
            Large = 2,
        }

        protected CardStyles _style = CardStyles.Normal;
        /// <summary>
        /// 卡片类型
        /// </summary>
        public CardStyles Style
        {
            get => _style;
            set
            {
                if (_style != value)
                {
                    _style = value;
                    //切换布局方法
                    ResetLayout(value);
                    //立即调整布局
                    Relayout(this.DisplayRectangle.Width, this.DisplayRectangle.Height);
                }
            }
        }

        /// <summary>
        /// 重新布局方法委托
        /// </summary>
        protected delegate void RelayoutDelegate(int width, int height);

        /// <summary>
        /// 重新布局方法委托
        /// </summary>
        protected RelayoutDelegate Relayout;

        #endregion

        public CardContainer()
        {
            Relayout = NormalLayout;
        }

        #region 布局

        /// <summary>
        /// 初始化卡片控件容器布局
        /// </summary>
        public override void InitializeLayout()
        {
            //创建虚拟控件对象 并 维护子虚拟控件列表
            Add(DUIPublishTimeLabel = new ControlBase());
            Add(DUIDescriptionLabel = new ControlBase());
            Add(DUIPreviewImageBox = new ControlBase());
            Add(DUIStateLabel = new ControlBase());
            Add(DUITitleLabel = new ControlBase());
            Add(DUILocationButton = new ControlBase());
            Add(DUIReadedButton = new ControlBase());
            Add(DUIBrowserButton = new ControlBase());
            Add(DUIDeleteButton = new ControlBase());
            Add(DUIMainButton = new ControlBase());

            /*
            e.Graphics.FillRectangle(Brushes.Red, previewImageRectangle);
            e.Graphics.FillRectangle(Brushes.Orange, titleRectangle);
            e.Graphics.FillRectangle(Brushes.LightGreen, mainButtonRectangle);
            e.Graphics.FillRectangle(Brushes.DodgerBlue, deleteButtonRectangle);
            e.Graphics.FillRectangle(Brushes.BlueViolet, browserButtonRectangle);
            e.Graphics.FillRectangle(Brushes.CadetBlue, locationButtonRectangle);
            e.Graphics.FillRectangle(Brushes.CornflowerBlue, readedButtonRectangle);
            e.Graphics.FillRectangle(Brushes.Pink, stateRectangle);
             */
            #region 发布时间标签

            DUIPublishTimeLabel.Name = "发布时间标签";
            DUIPublishTimeLabel.Text = DateTime.Now.ToString();
            DUIPublishTimeLabel.ForeColor = Color.Gray;
            DUIPublishTimeLabel.Image = null;/* TODO: 发布时间图标 */
            DUIPublishTimeLabel.ImageAlign = ContentAlignment.MiddleLeft;
            DUIPublishTimeLabel.ShowEllipsis = true;
            DUIPublishTimeLabel.TextAlign = ContentAlignment.MiddleCenter;
            DUIPublishTimeLabel.BackColor = Color.MediumPurple;
            #endregion

            #region 文章描述标签

            DUIDescriptionLabel.Name = "文章描述标签";
            DUIDescriptionLabel.Text = "文章描述内容";
            DUIDescriptionLabel.TextAlign = ContentAlignment.MiddleCenter;
            DUIDescriptionLabel.ShowEllipsis = true;
            DUIDescriptionLabel.BackColor = Color.LightGray;
            #endregion

            DUITitleLabel.Name = "标题标签";
            DUITitleLabel.Text = "标题标签";
            DUITitleLabel.ForeColor = Color.Orange;
            DUITitleLabel.BackColor = Color.Red;
            DUITitleLabel.ShowEllipsis = true;
            DUITitleLabel.Mouseable = true;
            DUITitleLabel.Font = new Font(DUITitleLabel.Font, FontStyle.Bold);
            DUITitleLabel.Click += (s, e) => { /* TODO: 抛出点击标题事件 */ };
            DUITitleLabel.MouseEnter += (s, e) => { DUITitleLabel.ForeColor = Color.OrangeRed; };
            DUITitleLabel.MouseLeave += (s, e) => { DUITitleLabel.ForeColor = Color.Orange; };
            DUITitleLabel.MouseDown += (s, e) => { DUITitleLabel.ForeColor = Color.Chocolate; };
            DUITitleLabel.MouseUp += (s, e) => { DUITitleLabel.ForeColor = Color.OrangeRed; };

            DUIPreviewImageBox.Name = "预览图像框";
            DUIPreviewImageBox.Text = string.Empty;
            DUIPreviewImageBox.BackColor = Color.Silver;
            DUIPreviewImageBox.Image = null;
            DUIPreviewImageBox.ImageAlign = ContentAlignment.MiddleCenter;
            DUIPreviewImageBox.Click += (s, e) => { Console.WriteLine("点击预览图像区域"); };
        }

        /// <summary>
        /// 响应卡片控件容器布局
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public override void ResetSize(int width, int height)
        {
            //通过委托调用对应样式的绘制方法
            Relayout(width, height);
        }

        /// <summary>
        /// 根据布局样式重新绑定布局委托
        /// </summary>
        /// <param name="styles">布局样式</param>
        protected virtual void ResetLayout(CardStyles styles)
        {
            switch (styles)
            {
                case CardStyles.Normal:
                    {
                        Relayout = NormalLayout;
                        break;
                    }
                case CardStyles.Small:
                    {
                        Relayout = SmallLayout;
                        break;
                    }
                case CardStyles.Large:
                    {
                        Relayout = LargeLayout;
                        break;
                    }
            }
        }

        /// <summary>
        /// 精简布局
        /// </summary>
        protected virtual void SmallLayout(int width, int height)
        {
            //精简布局
        }

        /// <summary>
        /// 正常布局
        /// </summary>
        protected virtual void NormalLayout(int width, int height)
        {
            /*
            previewImageRectangle.X = previewImageRectangle.Y = 0;
            previewImageRectangle.Width = Math.Min((int)((25.0 / 14.0) * this.DisplayRectangle.Height), this.DisplayRectangle.Width);
            previewImageRectangle.Height = this.DisplayRectangle.Height;

            deleteButtonRectangle.Y = 0;
            deleteButtonRectangle.Width = Math.Min(this.DisplayRectangle.Width - previewImageRectangle.Right, 28);
            deleteButtonRectangle.Height = 28;
            deleteButtonRectangle.X = this.DisplayRectangle.Width - deleteButtonRectangle.Width;

            browserButtonRectangle.Y = 0;
            browserButtonRectangle.Width = Math.Min(deleteButtonRectangle.Left - previewImageRectangle.Right, 28);
            browserButtonRectangle.Height = 28;
            browserButtonRectangle.X = deleteButtonRectangle.Left - browserButtonRectangle.Width;

            locationButtonRectangle.Y = 0;
            locationButtonRectangle.Width = Math.Min(browserButtonRectangle.Left - previewImageRectangle.Right, 28);
            locationButtonRectangle.Height = 28;
            locationButtonRectangle.X = browserButtonRectangle.Left - locationButtonRectangle.Width;

            readedButtonRectangle.Y = 0;
            readedButtonRectangle.Width = Math.Min(locationButtonRectangle.Left - previewImageRectangle.Right, 28);
            readedButtonRectangle.Height = 28;
            readedButtonRectangle.X = locationButtonRectangle.Left - readedButtonRectangle.Width;

            titleRectangle.X = previewImageRectangle.Right;
            titleRectangle.Y = 0;
            titleRectangle.Width = Math.Max(readedButtonRectangle.Left - previewImageRectangle.Right, 0);
            titleRectangle.Height = 28;

            mainButtonRectangle.Width = Math.Min(this.DisplayRectangle.Width - previewImageRectangle.Width, 112);
            mainButtonRectangle.Height = 28;
            mainButtonRectangle.X = this.DisplayRectangle.Width - mainButtonRectangle.Width;
            mainButtonRectangle.Y = Math.Max(DisplayRectangle.Height - 28, titleRectangle.Bottom);

            stateRectangle.Height = 28;
            stateRectangle.Width = Math.Min(mainButtonRectangle.Left - previewImageRectangle.Right, 180);
            stateRectangle.X = Math.Max(mainButtonRectangle.Left - stateRectangle.Width, 0);
            stateRectangle.Y = mainButtonRectangle.Y;

            publishTimeRectangle.X = previewImageRectangle.Right;
            publishTimeRectangle.Y = mainButtonRectangle.Top;
            publishTimeRectangle.Width = Math.Max(stateRectangle.Left - previewImageRectangle.Width, 0);
            publishTimeRectangle.Height = 28;

            descriptionRectangle = new Rectangle(titleRectangle.Left, titleRectangle.Bottom, mainButtonRectangle.Right - previewImageRectangle.Right, Math.Max(0, mainButtonRectangle.Top - titleRectangle.Bottom));
             */
        }

        /// <summary>
        /// 巨幅布局
        /// </summary>
        protected virtual void LargeLayout(int width, int height)
        {

        }

        #endregion

        /*


        e.Graphics.DrawRectangle(Pens.DarkRed, previewImageRectangle.Left, previewImageRectangle.Top, previewImageRectangle.Width - 1, previewImageRectangle.Height - 1);
        e.Graphics.DrawRectangle(Pens.DarkOrange, titleRectangle.Left, titleRectangle.Top, titleRectangle.Width - 1, titleRectangle.Height - 1);
        e.Graphics.DrawRectangle(Pens.Green, mainButtonRectangle.Left, mainButtonRectangle.Top, mainButtonRectangle.Width - 1, mainButtonRectangle.Height - 1);
        e.Graphics.DrawRectangle(Pens.Gray, descriptionRectangle.Left, descriptionRectangle.Top, descriptionRectangle.Width - 1, descriptionRectangle.Height - 1);
        e.Graphics.DrawRectangle(Pens.DeepSkyBlue, deleteButtonRectangle.Left, deleteButtonRectangle.Top, deleteButtonRectangle.Width - 1, deleteButtonRectangle.Height - 1);
        e.Graphics.DrawRectangle(Pens.DeepSkyBlue, browserButtonRectangle.Left, browserButtonRectangle.Top, browserButtonRectangle.Width - 1, browserButtonRectangle.Height - 1);
        e.Graphics.DrawRectangle(Pens.DeepSkyBlue, locationButtonRectangle.Left, locationButtonRectangle.Top, locationButtonRectangle.Width - 1, locationButtonRectangle.Height - 1);
        e.Graphics.DrawRectangle(Pens.DeepSkyBlue, readedButtonRectangle.Left, readedButtonRectangle.Top, readedButtonRectangle.Width - 1, readedButtonRectangle.Height - 1);
        e.Graphics.DrawRectangle(Pens.DeepPink, stateRectangle.Left, stateRectangle.Top, stateRectangle.Width - 1, stateRectangle.Height - 1);
        e.Graphics.DrawRectangle(Pens.Purple, publishTimeRectangle.Left, publishTimeRectangle.Top, publishTimeRectangle.Width - 1, publishTimeRectangle.Height - 1);

        e.Graphics.DrawString($"Style: {Style}, delegate: {Relayout.Method.Name}", this.Font, Brushes.White, Point.Empty);
         */
    }
}