namespace TheLongDarkItemMarker.Views
{
    partial class AddItemView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAddSelectedItem = new System.Windows.Forms.Button();
            this.labelSelectItem = new System.Windows.Forms.Label();
            this.panelItems = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(276, 747);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonAddSelectedItem
            // 
            this.buttonAddSelectedItem.Location = new System.Drawing.Point(106, 747);
            this.buttonAddSelectedItem.Name = "buttonAddSelectedItem";
            this.buttonAddSelectedItem.Size = new System.Drawing.Size(107, 23);
            this.buttonAddSelectedItem.TabIndex = 6;
            this.buttonAddSelectedItem.Text = "Add selected item";
            this.buttonAddSelectedItem.UseVisualStyleBackColor = true;
            this.buttonAddSelectedItem.Click += new System.EventHandler(this.AddSelectedItemClick);
            // 
            // labelSelectItem
            // 
            this.labelSelectItem.AutoSize = true;
            this.labelSelectItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectItem.Location = new System.Drawing.Point(18, 3);
            this.labelSelectItem.Name = "labelSelectItem";
            this.labelSelectItem.Size = new System.Drawing.Size(93, 19);
            this.labelSelectItem.TabIndex = 5;
            this.labelSelectItem.Text = "Select an item";
            // 
            // panelItems
            // 
            this.panelItems.Location = new System.Drawing.Point(18, 25);
            this.panelItems.Name = "panelItems";
            this.panelItems.Size = new System.Drawing.Size(470, 716);
            this.panelItems.TabIndex = 4;
            // 
            // AddItemView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAddSelectedItem);
            this.Controls.Add(this.labelSelectItem);
            this.Controls.Add(this.panelItems);
            this.Name = "AddItemView";
            this.Size = new System.Drawing.Size(506, 835);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAddSelectedItem;
        private System.Windows.Forms.Label labelSelectItem;
        private System.Windows.Forms.Panel panelItems;
    }
}
