using System.Diagnostics.CodeAnalysis;

namespace TheLongDarkItemMarker.Views
{
    partial class MarkerView
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
            this.textBoxMarkerName = new System.Windows.Forms.TextBox();
            this.panelItems = new System.Windows.Forms.Panel();
            this.labelItems = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxMarkerName
            // 
            this.textBoxMarkerName.Location = new System.Drawing.Point(11, 13);
            this.textBoxMarkerName.Name = "textBoxMarkerName";
            this.textBoxMarkerName.ReadOnly = true;
            this.textBoxMarkerName.Size = new System.Drawing.Size(227, 20);
            this.textBoxMarkerName.TabIndex = 0;
            // 
            // panelItems
            // 
            this.panelItems.AutoScroll = true;
            this.panelItems.Location = new System.Drawing.Point(11, 60);
            this.panelItems.Name = "panelItems";
            this.panelItems.Size = new System.Drawing.Size(420, 424);
            this.panelItems.TabIndex = 1;
            // 
            // labelItems
            // 
            this.labelItems.AutoSize = true;
            this.labelItems.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItems.Location = new System.Drawing.Point(11, 41);
            this.labelItems.Name = "labelItems";
            this.labelItems.Size = new System.Drawing.Size(124, 19);
            this.labelItems.TabIndex = 2;
            this.labelItems.Text = "Items that are here:";
            // 
            // MarkerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelItems);
            this.Controls.Add(this.panelItems);
            this.Controls.Add(this.textBoxMarkerName);
            this.Name = "MarkerView";
            this.Size = new System.Drawing.Size(435, 500);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxMarkerName;
        private System.Windows.Forms.Panel panelItems;
        private System.Windows.Forms.Label labelItems;
    }
}
