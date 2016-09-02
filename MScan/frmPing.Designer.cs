namespace MScan
{
    partial class frmPing
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.labPing = new System.Windows.Forms.Label();
            this.txtBoxPing = new System.Windows.Forms.TextBox();
            this.btnPing = new System.Windows.Forms.Button();
            this.listBoxPing = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // labPing
            // 
            this.labPing.AutoSize = true;
            this.labPing.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labPing.Location = new System.Drawing.Point(13, 15);
            this.labPing.Name = "labPing";
            this.labPing.Size = new System.Drawing.Size(176, 16);
            this.labPing.TabIndex = 0;
            this.labPing.Text = "请输入主机地址或名称:";
            // 
            // txtBoxPing
            // 
            this.txtBoxPing.Location = new System.Drawing.Point(208, 13);
            this.txtBoxPing.Name = "txtBoxPing";
            this.txtBoxPing.Size = new System.Drawing.Size(318, 21);
            this.txtBoxPing.TabIndex = 1;
            // 
            // btnPing
            // 
            this.btnPing.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPing.Location = new System.Drawing.Point(552, 12);
            this.btnPing.Name = "btnPing";
            this.btnPing.Size = new System.Drawing.Size(106, 22);
            this.btnPing.TabIndex = 2;
            this.btnPing.Text = "PING";
            this.btnPing.UseVisualStyleBackColor = true;
            this.btnPing.Click += new System.EventHandler(this.btnPing_Click);
            // 
            // listBoxPing
            // 
            this.listBoxPing.AllowDrop = true;
            this.listBoxPing.FormattingEnabled = true;
            this.listBoxPing.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.listBoxPing.ItemHeight = 12;
            this.listBoxPing.Location = new System.Drawing.Point(12, 48);
            this.listBoxPing.Name = "listBoxPing";
            this.listBoxPing.Size = new System.Drawing.Size(646, 316);
            this.listBoxPing.TabIndex = 3;
            // 
            // frmPing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 396);
            this.Controls.Add(this.listBoxPing);
            this.Controls.Add(this.btnPing);
            this.Controls.Add(this.txtBoxPing);
            this.Controls.Add(this.labPing);
            this.Name = "frmPing";
            this.Text = "Ping探测";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labPing;
        private System.Windows.Forms.TextBox txtBoxPing;
        private System.Windows.Forms.Button btnPing;
        private System.Windows.Forms.ListBox listBoxPing;
    }
}

