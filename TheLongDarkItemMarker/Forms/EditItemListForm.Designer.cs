using System.Diagnostics.CodeAnalysis;

namespace TheLongDarkItemMarker.Forms
{
    partial class EditItemListForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        [ExcludeFromCodeCoverage]
        private void InitializeComponent()
        {
            this.panelItems = new System.Windows.Forms.Panel();
            this.buttonAddItem = new System.Windows.Forms.Button();
            this.labelItems = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonEditSelectedItem = new System.Windows.Forms.Button();
            this.buttonRemoveSelectedItems = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelItems
            // 
            this.panelItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelItems.Location = new System.Drawing.Point(12, 47);
            this.panelItems.Name = "panelItems";
            this.panelItems.Size = new System.Drawing.Size(470, 716);
            this.panelItems.TabIndex = 0;
            // 
            // buttonAddItem
            // 
            this.buttonAddItem.Location = new System.Drawing.Point(488, 47);
            this.buttonAddItem.Name = "buttonAddItem";
            this.buttonAddItem.Size = new System.Drawing.Size(110, 23);
            this.buttonAddItem.TabIndex = 1;
            this.buttonAddItem.Text = "Add item";
            this.buttonAddItem.UseVisualStyleBackColor = true;
            this.buttonAddItem.Click += new System.EventHandler(this.AddItemClick);
            // 
            // labelItems
            // 
            this.labelItems.AutoSize = true;
            this.labelItems.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItems.Location = new System.Drawing.Point(12, 25);
            this.labelItems.Name = "labelItems";
            this.labelItems.Size = new System.Drawing.Size(45, 19);
            this.labelItems.TabIndex = 2;
            this.labelItems.Text = "Items:";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(85, 785);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.SaveClick);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(258, 785);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.CancelClick);
            // 
            // buttonEditSelectedItem
            // 
            this.buttonEditSelectedItem.Location = new System.Drawing.Point(488, 77);
            this.buttonEditSelectedItem.Name = "buttonEditSelectedItem";
            this.buttonEditSelectedItem.Size = new System.Drawing.Size(110, 23);
            this.buttonEditSelectedItem.TabIndex = 5;
            this.buttonEditSelectedItem.Text = "Edit selected item";
            this.buttonEditSelectedItem.UseVisualStyleBackColor = true;
            this.buttonEditSelectedItem.Click += new System.EventHandler(this.EditSelectedItemClick);
            // 
            // buttonRemoveSelectedItems
            // 
            this.buttonRemoveSelectedItems.Location = new System.Drawing.Point(488, 153);
            this.buttonRemoveSelectedItems.Name = "buttonRemoveSelectedItems";
            this.buttonRemoveSelectedItems.Size = new System.Drawing.Size(110, 37);
            this.buttonRemoveSelectedItems.TabIndex = 6;
            this.buttonRemoveSelectedItems.Text = "Remove selected items";
            this.buttonRemoveSelectedItems.UseVisualStyleBackColor = true;
            this.buttonRemoveSelectedItems.Click += new System.EventHandler(this.RemoveSelectedItemsClick);
            // 
            // EditItemListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 820);
            this.Controls.Add(this.buttonRemoveSelectedItems);
            this.Controls.Add(this.buttonEditSelectedItem);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelItems);
            this.Controls.Add(this.buttonAddItem);
            this.Controls.Add(this.panelItems);
            this.Name = "EditItemListForm";
            this.Text = "EditItemListForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelItems;
        private System.Windows.Forms.Button buttonAddItem;
        private System.Windows.Forms.Label labelItems;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonEditSelectedItem;
        private System.Windows.Forms.Button buttonRemoveSelectedItems;
    }
}