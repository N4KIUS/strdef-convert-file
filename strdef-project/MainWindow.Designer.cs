namespace strdef_project
{
    partial class MainWindow
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
            this.bin2txt = new System.Windows.Forms.Button();
            this.txt2bin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bin2txt
            // 
            this.bin2txt.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.bin2txt.Location = new System.Drawing.Point(12, 12);
            this.bin2txt.Name = "bin2txt";
            this.bin2txt.Size = new System.Drawing.Size(113, 36);
            this.bin2txt.TabIndex = 0;
            this.bin2txt.Text = "*.bin   >   *.txt";
            this.bin2txt.UseVisualStyleBackColor = true;
            this.bin2txt.Click += new System.EventHandler(this.bin2txt_Click);
            // 
            // txt2bin
            // 
            this.txt2bin.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt2bin.Location = new System.Drawing.Point(147, 12);
            this.txt2bin.Name = "txt2bin";
            this.txt2bin.Size = new System.Drawing.Size(112, 36);
            this.txt2bin.TabIndex = 1;
            this.txt2bin.Text = "*.txt    >   *.bin";
            this.txt2bin.UseVisualStyleBackColor = true;
            this.txt2bin.Click += new System.EventHandler(this.txt2bin_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 60);
            this.Controls.Add(this.txt2bin);
            this.Controls.Add(this.bin2txt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "strdef 1.0";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bin2txt;
        private System.Windows.Forms.Button txt2bin;
    }
}

