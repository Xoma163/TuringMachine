namespace MT
{
    partial class ViewTrack
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
            this.richTextBoxTrack = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBoxTrack
            // 
            this.richTextBoxTrack.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxTrack.Location = new System.Drawing.Point(12, 12);
            this.richTextBoxTrack.Name = "richTextBoxTrack";
            this.richTextBoxTrack.ReadOnly = true;
            this.richTextBoxTrack.Size = new System.Drawing.Size(718, 237);
            this.richTextBoxTrack.TabIndex = 0;
            this.richTextBoxTrack.Text = "";
            this.richTextBoxTrack.WordWrap = false;
            // 
            // ViewTrack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 261);
            this.Controls.Add(this.richTextBoxTrack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewTrack";
            this.Text = "Трасса";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxTrack;
    }
}