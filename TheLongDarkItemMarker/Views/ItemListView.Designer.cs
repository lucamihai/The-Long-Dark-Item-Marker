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
            this.comboBoxCategoryFilter = new System.Windows.Forms.ComboBox();
            this.textBoxFilterByName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            // comboBoxCategoryFilter
            // 
            this.comboBoxCategoryFilter.FormattingEnabled = true;
            this.comboBoxCategoryFilter.Location = new System.Drawing.Point(136, 30);
            this.comboBoxCategoryFilter.Name = "comboBoxCategoryFilter";
            this.comboBoxCategoryFilter.Size = new System.Drawing.Size(197, 21);
            this.comboBoxCategoryFilter.TabIndex = 2;
            this.comboBoxCategoryFilter.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCategoryFilter_SelectedIndexChanged);
            // 
            // textBoxFilterByName
            // 
            this.textBoxFilterByName.Location = new System.Drawing.Point(136, 5);
            this.textBoxFilterByName.Name = "textBoxFilterByName";
            this.textBoxFilterByName.Size = new System.Drawing.Size(197, 20);
            this.textBoxFilterByName.TabIndex = 3;
            this.textBoxFilterByName.TextChanged += new System.EventHandler(this.TextBoxFilterByNameTextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Filter by name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Filter by category:";
            // 
            // ItemListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxFilterByName);
            this.Controls.Add(this.comboBoxCategoryFilter);
            this.Controls.Add(this.panelItems);
            this.Name = "ItemListView";
            this.Size = new System.Drawing.Size(450, 645);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelItems;
        private System.Windows.Forms.ComboBox comboBoxCategoryFilter;
        private System.Windows.Forms.TextBox textBoxFilterByName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
