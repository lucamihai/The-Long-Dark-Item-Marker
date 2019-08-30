using System.Diagnostics.CodeAnalysis;

namespace TheLongDarkItemMarker.Views
{
    partial class ItemListView
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
            this.panelItems = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelItems
            // 
            this.panelItems.AutoScroll = true;
            this.panelItems.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelItems.Location = new System.Drawing.Point(16, 60);
            this.panelItems.Name = "panelItems";
            this.panelItems.Size = new System.Drawing.Size(420, 575);
            this.panelItems.TabIndex = 1;
            // 
            // ItemListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.panelItems);
            this.Name = "ItemListView";
            this.Size = new System.Drawing.Size(450, 645);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelItems;
    }
}
