namespace MLopoly {
    partial class BoardGUI {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.Monopoly = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Monopoly
            // 
            this.Monopoly.AutoSize = true;
            this.Monopoly.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Monopoly.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Monopoly.Location = new System.Drawing.Point(1185, 820);
            this.Monopoly.Name = "Monopoly";
            this.Monopoly.Size = new System.Drawing.Size(618, 147);
            this.Monopoly.TabIndex = 0;
            this.Monopoly.Text = "Monopoly";
            // 
            // BoardGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(2974, 1929);
            this.Controls.Add(this.Monopoly);
            this.Name = "BoardGUI";
            this.Text = "Monopoly Viewer";
            this.Load += new System.EventHandler(this.BoardGUI_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BoardGUI_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Monopoly;
    }
}