using System.Diagnostics.CodeAnalysis;

namespace TheLongDarkItemMarker.Views
{
    partial class ItemView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        [ExcludeFromCodeCoverage]
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        [ExcludeFromCodeCoverage]
        private void InitializeComponent()
        {
            this.pictureBoxItem = new System.Windows.Forms.PictureBox();
            this.panelFields = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItem)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxItem
            // 
            this.pictureBoxItem.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pictureBoxItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxItem.Location = new System.Drawing.Point(13, 12);
            this.pictureBoxItem.Name = "pictureBoxItem";
            this.pictureBoxItem.Size = new System.Drawing.Size(100, 100);
            this.pictureBoxItem.TabIndex = 0;
            this.pictureBoxItem.TabStop = false;
            // 
            // panelFields
            // 
            this.panelFields.Location = new System.Drawing.Point(135, 12);
            this.panelFields.Name = "panelFields";
            this.panelFields.Size = new System.Drawing.Size(150, 100);
            this.panelFields.TabIndex = 1;
            // 
            // ItemView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelFields);
            this.Controls.Add(this.pictureBoxItem);
            this.Name = "ItemView";
            this.Size = new System.Drawing.Size(400, 129);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxItem;
        private System.Windows.Forms.Panel panelFields;
    }
}
