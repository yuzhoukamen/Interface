using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Windows
{
    public partial class Frm_Tips : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private Image m_Image = null;

        /// <summary>
        /// 
        /// </summary>
        private EventHandler evtHandler = null;

        /// <summary>
        /// 
        /// </summary>
        public Frm_Tips()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (m_Image != null)
            {

                //获得当前gif动画下一步要渲染的帧。

                UpdateImage();

                //将获得的当前gif动画需要渲染的帧显示在界面上的某个位置。

                e.Graphics.DrawImage(m_Image, new Rectangle(5, 5, m_Image.Width, m_Image.Height));

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Tips_Load(object sender, EventArgs e)
        {
            //为委托关联一个处理方法

            evtHandler = new EventHandler(OnImageAnimate);

            //获取要加载的gif动画文件

            m_Image = Image.FromFile(Application.StartupPath + "\\Pictures\\tips.gif");

            //调用开始动画方法

            BeginAnimate();
        }

        /// <summary>
        /// 开始动画方法
        /// </summary>
        private void BeginAnimate()
        {

            if (m_Image != null)
            {

                //当gif动画每隔一定时间后，都会变换一帧，那么就会触发一事件，该方法就是将当前image每变换一帧时，都会调用当前这个委托所关联的方法。

                ImageAnimator.Animate(m_Image, evtHandler);

            }

        }

        /// <summary>
        /// 委托所关联的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnImageAnimate(Object sender, EventArgs e)
        {

            //该方法中，只是使得当前这个winfor重绘，然后去调用该winform的OnPaint（）方法进行重绘)

            this.Invalidate();

        }

        /// <summary>
        /// 获得当前gif动画的下一步需要渲染的帧，当下一步任何对当前gif动画的操作都是对该帧进行操作)
        /// </summary>
        private void UpdateImage()
        {

            ImageAnimator.UpdateFrames(m_Image);

        }

        /// <summary>
        /// 关闭显示动画，该方法可以在winform关闭时，或者某个按钮的触发事件中进行调用，以停止渲染当前gif动画。
        /// </summary>
        private void StopAnimate()
        {

            m_Image = null;

            ImageAnimator.StopAnimate(m_Image, evtHandler);

        }

        /// <summary>
        /// 写消息
        /// </summary>
        /// <param name="msg"></param>
        public void WriteMsg(string msg)
        {
            this.lblTips.Text = msg;
        }
    }
}
