﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Windows.Control
{
    public partial class PagerControl : UserControl
    {
        #region 构造函数

        public PagerControl()
        {
            InitializeComponent();
        }

        #endregion

        #region 分页字段和属性

        private int pageIndex = 1;
        /// <summary>
        /// 当前页面
        /// </summary>
        public virtual int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }

        private int pageSize = 100;
        /// <summary>
        /// 每页记录数
        /// </summary>
        public virtual int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        private int recordCount = 0;
        /// <summary>
        /// 总记录数
        /// </summary>
        public virtual int RecordCount
        {
            get { return recordCount; }
            set { recordCount = value; }
        }

        private int pageCount = 0;
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount
        {
            get
            {
                if (pageSize != 0)
                {
                    pageCount = GetPageCount();
                }
                return pageCount;
            }
        }

        private string jumpText;
        /// <summary>
        /// 跳转按钮文本
        /// </summary>
        public string JumpText
        {
            get
            {
                if (string.IsNullOrEmpty(jumpText))
                {
                    jumpText = "跳转";
                }
                return jumpText;
            }
            set { jumpText = value; }
        }


        #endregion

        #region 页码变化触发事件

        public event EventHandler OnPageChanged;

        #endregion

        #region 分页及相关事件功能实现

        private void SetFormCtrEnabled()
        {
            lnkFirst.Enabled = true;
            lnkPrev.Enabled = true;
            lnkNext.Enabled = true;
            lnkLast.Enabled = true;
            btnGo.Enabled = true;
        }

        /// <summary>
        /// 计算总页数
        /// </summary>
        /// <returns></returns>
        private int GetPageCount()
        {
            if (PageSize == 0)
            {
                return 0;
            }
            int pageCount = RecordCount / PageSize;
            if (RecordCount % PageSize == 0)
            {
                pageCount = RecordCount / PageSize;
            }
            else
            {
                pageCount = RecordCount / PageSize + 1;
            }
            return pageCount;
        }
        /// <summary>
        /// 外部调用
        /// </summary>
        public void DrawControl(int count)
        {
            recordCount = count;
            DrawControl(false);
        }
        /// <summary>
        /// 页面控件呈现
        /// </summary>
        private void DrawControl(bool callEvent)
        {
            btnGo.Text = JumpText;
            lblCurrentPage.Text = PageIndex.ToString();
            lblPageCount.Text = PageCount.ToString();
            lblTotalCount.Text = RecordCount.ToString();
            txtPageSize.Text = PageSize.ToString();

            if (callEvent && OnPageChanged != null)
            {
                OnPageChanged(this, null);//当前分页数字改变时，触发委托事件
            }
            SetFormCtrEnabled();
            if (PageCount == 1)//有且仅有一页
            {
                lnkFirst.Enabled = false;
                lnkPrev.Enabled = false;
                lnkNext.Enabled = false;
                lnkLast.Enabled = false;
                btnGo.Enabled = false;
            }
            else if (PageIndex == 1)//第一页
            {
                lnkFirst.Enabled = false;
                lnkPrev.Enabled = false;
            }
            else if (PageIndex == PageCount)//最后一页
            {
                lnkNext.Enabled = false;
                lnkLast.Enabled = false;
            }
        }

        #endregion

        #region 相关控件事件

        private void lnkFirst_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PageIndex = 1;
            DrawControl(true);
        }

        private void lnkNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PageIndex = Math.Min(PageCount, PageIndex + 1);
            DrawControl(true);
        }

        private void lnkLast_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PageIndex = PageCount;
            DrawControl(true);
        }

        /// <summary>
        /// enter键功能
        /// </summary>
        private void txtPageNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnGo_Click(null, null);
        }

        #endregion

        bool isTextChanged = false;

        private void btnGo_Click(object sender, EventArgs e)
        {
            int num = 0;
            if (int.TryParse(txtPageNum.Text.Trim(), out num) && num > 0)
            {
                PageIndex = num;
                DrawControl(true);
            }
        }

        public void SetPageSize(int pageSize)
        {
            this.pageSize = pageSize;
            this.txtPageSize.Text = pageSize.ToString();
        }

        private void lnkPrev_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (PageIndex > 1)
            {
                PageIndex -= 1;
                DrawControl(true);
            }
        }

        /// <summary>
        /// 获取首页页号
        /// </summary>
        /// <returns></returns>
        public int GetFirstRow()
        {
            if (this.PageIndex <= 1)
            {
                return 1;
            }
            return this.PageSize * (PageIndex - 1) + 1;
        }

        /// <summary>
        /// 获取最后一行页号
        /// </summary>
        /// <returns></returns>
        public int GetLastRow()
        {
            if (this.PageIndex <= 0)
            {
                return this.pageSize;
            }
            return this.pageSize * this.PageIndex;
        }

        public void SetRecordCount(int count)
        {
            this.RecordCount = count;
            this.lblTotalCount.Text = count.ToString();
        }

        private void txtPageSize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int result = 0;

                if (int.TryParse(this.txtPageSize.Text.Trim(), out result))
                {
                    this.PageSize = result;
                    DrawControl(true);
                }
                else
                {
                    this.txtPageSize.Clear();
                    this.txtPageSize.Focus();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPageSize_TextChanged(object sender, EventArgs e)
        {
            int result = 0;

            if (!int.TryParse(this.txtPageSize.Text.Trim(), out result))
            {
                this.txtPageSize.Clear();
                this.txtPageSize.Focus();
            }
            else
            {
                SetPageSize(result);  
            }
        }
    }
}
