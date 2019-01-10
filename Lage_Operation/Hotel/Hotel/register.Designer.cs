namespace Hotel
{
    partial class register
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(register));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.passw = new System.Windows.Forms.TextBox();
            this.ensurepw = new System.Windows.Forms.TextBox();
            this.employee = new System.Windows.Forms.RadioButton();
            this.manager = new System.Windows.Forms.RadioButton();
            this.enroll = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.empowerp = new System.Windows.Forms.Label();
            this.textempower = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.skinCheckBox1 = new CCWin.SkinControl.SkinCheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("楷体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(60, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "用 户 名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("楷体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(60, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "登陆密码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("楷体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(59, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "确认密码：";
            // 
            // username
            // 
            this.username.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.username.Location = new System.Drawing.Point(221, 101);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(168, 30);
            this.username.TabIndex = 3;
            // 
            // passw
            // 
            this.passw.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.passw.Location = new System.Drawing.Point(221, 161);
            this.passw.Name = "passw";
            this.passw.Size = new System.Drawing.Size(168, 30);
            this.passw.TabIndex = 4;
            this.passw.UseSystemPasswordChar = true;
            // 
            // ensurepw
            // 
            this.ensurepw.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ensurepw.Location = new System.Drawing.Point(221, 255);
            this.ensurepw.Name = "ensurepw";
            this.ensurepw.Size = new System.Drawing.Size(168, 30);
            this.ensurepw.TabIndex = 5;
            this.ensurepw.UseSystemPasswordChar = true;
            // 
            // employee
            // 
            this.employee.AutoSize = true;
            this.employee.BackColor = System.Drawing.Color.Transparent;
            this.employee.Checked = true;
            this.employee.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.employee.Location = new System.Drawing.Point(472, 102);
            this.employee.Name = "employee";
            this.employee.Size = new System.Drawing.Size(70, 24);
            this.employee.TabIndex = 6;
            this.employee.TabStop = true;
            this.employee.Text = "员工";
            this.employee.UseVisualStyleBackColor = false;
            // 
            // manager
            // 
            this.manager.AutoSize = true;
            this.manager.BackColor = System.Drawing.Color.Transparent;
            this.manager.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.manager.Location = new System.Drawing.Point(472, 148);
            this.manager.Name = "manager";
            this.manager.Size = new System.Drawing.Size(90, 24);
            this.manager.TabIndex = 7;
            this.manager.Text = "管理员";
            this.manager.UseVisualStyleBackColor = false;
            this.manager.CheckedChanged += new System.EventHandler(this.manager_CheckedChanged);
            // 
            // enroll
            // 
            this.enroll.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.enroll.Location = new System.Drawing.Point(86, 394);
            this.enroll.Name = "enroll";
            this.enroll.Size = new System.Drawing.Size(118, 44);
            this.enroll.TabIndex = 8;
            this.enroll.Text = "注册";
            this.enroll.UseVisualStyleBackColor = true;
            this.enroll.Click += new System.EventHandler(this.enroll_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(313, 394);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 44);
            this.button2.TabIndex = 9;
            this.button2.Text = "关闭";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // empowerp
            // 
            this.empowerp.AutoSize = true;
            this.empowerp.BackColor = System.Drawing.Color.Transparent;
            this.empowerp.Font = new System.Drawing.Font("楷体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.empowerp.ForeColor = System.Drawing.Color.Crimson;
            this.empowerp.Location = new System.Drawing.Point(12, 320);
            this.empowerp.Name = "empowerp";
            this.empowerp.Size = new System.Drawing.Size(178, 24);
            this.empowerp.TabIndex = 10;
            this.empowerp.Text = "验证授权密码：";
            this.empowerp.Visible = false;
            // 
            // textempower
            // 
            this.textempower.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textempower.Location = new System.Drawing.Point(221, 320);
            this.textempower.Name = "textempower";
            this.textempower.Size = new System.Drawing.Size(168, 30);
            this.textempower.TabIndex = 11;
            this.textempower.UseSystemPasswordChar = true;
            this.textempower.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(441, 191);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(173, 159);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(620, 303);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 47);
            this.button1.TabIndex = 13;
            this.button1.Text = "选择头像";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // skinCheckBox1
            // 
            this.skinCheckBox1.AutoSize = true;
            this.skinCheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinCheckBox1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinCheckBox1.DownBack = null;
            this.skinCheckBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinCheckBox1.Location = new System.Drawing.Point(298, 207);
            this.skinCheckBox1.MouseBack = null;
            this.skinCheckBox1.Name = "skinCheckBox1";
            this.skinCheckBox1.NormlBack = null;
            this.skinCheckBox1.SelectedDownBack = null;
            this.skinCheckBox1.SelectedMouseBack = null;
            this.skinCheckBox1.SelectedNormlBack = null;
            this.skinCheckBox1.Size = new System.Drawing.Size(91, 24);
            this.skinCheckBox1.TabIndex = 14;
            this.skinCheckBox1.Text = "密码可见";
            this.skinCheckBox1.UseVisualStyleBackColor = false;
            this.skinCheckBox1.CheckedChanged += new System.EventHandler(this.skinCheckBox1_CheckedChanged);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(620, 250);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(114, 47);
            this.button3.TabIndex = 15;
            this.button3.Text = "自主上传";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Firebrick;
            this.label4.Location = new System.Drawing.Point(428, 353);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(186, 19);
            this.label4.TabIndex = 16;
            this.label4.Text = "像素大小：133*133";
            // 
            // register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(758, 449);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.skinCheckBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textempower);
            this.Controls.Add(this.empowerp);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.enroll);
            this.Controls.Add(this.manager);
            this.Controls.Add(this.employee);
            this.Controls.Add(this.ensurepw);
            this.Controls.Add(this.passw);
            this.Controls.Add(this.username);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "register";
            this.Text = "注册";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox passw;
        private System.Windows.Forms.TextBox ensurepw;
        private System.Windows.Forms.RadioButton employee;
        private System.Windows.Forms.RadioButton manager;
        private System.Windows.Forms.Button enroll;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label empowerp;
        private System.Windows.Forms.TextBox textempower;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Button button1;
        private CCWin.SkinControl.SkinCheckBox skinCheckBox1;
        public System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
    }
}