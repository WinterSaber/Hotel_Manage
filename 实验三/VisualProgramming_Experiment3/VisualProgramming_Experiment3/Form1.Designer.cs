namespace VisualProgramming_Experiment3
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.labelrun = new System.Windows.Forms.Label();
            this.labelposition = new System.Windows.Forms.Label();
            this.labeldirect = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("宋体", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label1.Location = new System.Drawing.Point(304, 310);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelrun
            // 
            this.labelrun.AutoSize = true;
            this.labelrun.BackColor = System.Drawing.Color.Pink;
            this.labelrun.Font = new System.Drawing.Font("宋体", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelrun.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelrun.Location = new System.Drawing.Point(226, 119);
            this.labelrun.Name = "labelrun";
            this.labelrun.Size = new System.Drawing.Size(290, 38);
            this.labelrun.TabIndex = 1;
            this.labelrun.Text = "这是一个跑马灯";
            // 
            // labelposition
            // 
            this.labelposition.AutoSize = true;
            this.labelposition.Location = new System.Drawing.Point(124, 241);
            this.labelposition.Name = "labelposition";
            this.labelposition.Size = new System.Drawing.Size(55, 15);
            this.labelposition.TabIndex = 2;
            this.labelposition.Text = "label2";
            // 
            // labeldirect
            // 
            this.labeldirect.AutoSize = true;
            this.labeldirect.Location = new System.Drawing.Point(548, 241);
            this.labeldirect.Name = "labeldirect";
            this.labeldirect.Size = new System.Drawing.Size(37, 15);
            this.labeldirect.TabIndex = 3;
            this.labeldirect.Text = "方向";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labeldirect);
            this.Controls.Add(this.labelposition);
            this.Controls.Add(this.labelrun);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelrun;
        private System.Windows.Forms.Label labelposition;
        private System.Windows.Forms.Label labeldirect;
    }
}

