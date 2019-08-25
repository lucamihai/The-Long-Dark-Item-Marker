using System.Diagnostics.CodeAnalysis;

namespace TheLongDarkItemMarker.Forms
{
    partial class AddItemForm
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
            this.panelItems = new System.Windows.Forms.Panel();
            this.labelSelectItem = new System.Windows.Forms.Label();
            this.buttonAddSelectedItem = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelItems
            // 
            this.panelItems.AutoScroll = true;
            this.panelItems.Location = new System.Drawing.Point(12, 30);
            this.panelItems.Name = "panelItems";
            this.panelItems.Size = new System.Drawing.Size(420, 572);
            this.panelItems.TabIndex = 0;
            // 
            // labelSelectItem
            // 
            this.labelSelectItem.AutoSize = true;
            this.labelSelectItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectItem.Location = new System.Drawing.Point(12, 8);
            this.labelSelectItem.Name = "labelSelectItem";
            this.labelSelectItem.Size = new System.Drawing.Size(93, 19);
            this.labelSelectItem.TabIndex = 1;
            this.labelSelectItem.Text = "Select an item";
            // 
            // buttonAddSelectedItem
            // 
            this.buttonAddSelectedItem.Location = new System.Drawing.Point(80, 607);
            this.buttonAddSelectedItem.Name = "buttonAddSelectedItem";
            this.buttonAddSelectedItem.Size = new System.Drawing.Size(107, 23);
            this.buttonAddSelectedItem.TabIndex = 2;
            this.buttonAddSelectedItem.Text = "Add selected item";
            this.buttonAddSelectedItem.UseVisualStyleBackColor = true;
            this.buttonAddSelectedItem.Click += new System.EventHandler(this.AddSelectedItemClick);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(250, 607);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.CancelClick);
            // 
            // AddItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(463, 642);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAddSelectedItem);
            this.Controls.Add(this.labelSelectItem);
            this.Controls.Add(this.panelItems);
            this.Name = "AddItemForm";
            this.Text = "AddItemForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelItems;
        private System.Windows.Forms.Label labelSelectItem;
        private System.Windows.Forms.Button buttonAddSelectedItem;
        private System.Windows.Forms.Button buttonCancel;
    }
}