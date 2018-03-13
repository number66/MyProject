namespace spi_test_csharp3
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ButtonOpen = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.OpenPortBar = new System.Windows.Forms.ProgressBar();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ReadButton = new System.Windows.Forms.Button();
            this.ViewButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonOpen
            // 
            this.ButtonOpen.Location = new System.Drawing.Point(3, 3);
            this.ButtonOpen.Name = "ButtonOpen";
            this.ButtonOpen.Size = new System.Drawing.Size(42, 23);
            this.ButtonOpen.TabIndex = 1;
            this.ButtonOpen.Text = "Open";
            this.ButtonOpen.UseVisualStyleBackColor = true;
            this.ButtonOpen.Click += new System.EventHandler(this.ButtonOpen_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Enabled = false;
            this.CloseButton.Location = new System.Drawing.Point(3, 61);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(42, 23);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // OpenPortBar
            // 
            this.OpenPortBar.Location = new System.Drawing.Point(3, 32);
            this.OpenPortBar.Name = "OpenPortBar";
            this.OpenPortBar.Size = new System.Drawing.Size(42, 23);
            this.OpenPortBar.TabIndex = 3;
            // 
            // SaveButton
            // 
            this.SaveButton.Enabled = false;
            this.SaveButton.Location = new System.Drawing.Point(3, 119);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(42, 23);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ReadButton
            // 
            this.ReadButton.Location = new System.Drawing.Point(3, 90);
            this.ReadButton.Name = "ReadButton";
            this.ReadButton.Size = new System.Drawing.Size(42, 23);
            this.ReadButton.TabIndex = 5;
            this.ReadButton.Text = "Read";
            this.ReadButton.UseVisualStyleBackColor = true;
            this.ReadButton.Click += new System.EventHandler(this.ReadButton_Click);
            // 
            // ViewButton
            // 
            this.ViewButton.Location = new System.Drawing.Point(3, 148);
            this.ViewButton.Name = "ViewButton";
            this.ViewButton.Size = new System.Drawing.Size(42, 23);
            this.ViewButton.TabIndex = 6;
            this.ViewButton.Text = "View";
            this.ViewButton.UseVisualStyleBackColor = true;
            this.ViewButton.Click += new System.EventHandler(this.ViewButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(51, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 600);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 622);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ViewButton);
            this.Controls.Add(this.ReadButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.OpenPortBar);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.ButtonOpen);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button ButtonOpen;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.ProgressBar OpenPortBar;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button ReadButton;
        private System.Windows.Forms.Button ViewButton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

