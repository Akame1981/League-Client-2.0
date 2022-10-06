
namespace LolTest
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lvlLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.StartButton = new System.Windows.Forms.PictureBox();
            this.CancelButton = new System.Windows.Forms.PictureBox();
            this.FriendsPanel = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StartButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CancelButton)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1238, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lvlLabel
            // 
            this.lvlLabel.AutoSize = true;
            this.lvlLabel.Location = new System.Drawing.Point(48, 186);
            this.lvlLabel.Name = "lvlLabel";
            this.lvlLabel.Size = new System.Drawing.Size(45, 13);
            this.lvlLabel.TabIndex = 1;
            this.lvlLabel.Text = "%level%";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(44, 17);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(49, 13);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "%name%";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 150);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.nameLabel);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lvlLabel);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(151, 217);
            this.panel1.TabIndex = 6;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(724, 509);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(82, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "AutoAccept";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 9000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // StartButton
            // 
            this.StartButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.StartButton.Image = ((System.Drawing.Image)(resources.GetObject("StartButton.Image")));
            this.StartButton.Location = new System.Drawing.Point(625, 436);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(93, 110);
            this.StartButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.StartButton.TabIndex = 9;
            this.StartButton.TabStop = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Image = ((System.Drawing.Image)(resources.GetObject("CancelButton.Image")));
            this.CancelButton.Location = new System.Drawing.Point(657, 403);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(31, 27);
            this.CancelButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CancelButton.TabIndex = 10;
            this.CancelButton.TabStop = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // FriendsPanel
            // 
            this.FriendsPanel.Location = new System.Drawing.Point(1196, 73);
            this.FriendsPanel.Name = "FriendsPanel";
            this.FriendsPanel.Size = new System.Drawing.Size(200, 453);
            this.FriendsPanel.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1408, 563);
            this.Controls.Add(this.FriendsPanel);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StartButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CancelButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lvlLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.PictureBox StartButton;
        private System.Windows.Forms.PictureBox CancelButton;
        private System.Windows.Forms.FlowLayoutPanel FriendsPanel;
    }
}

