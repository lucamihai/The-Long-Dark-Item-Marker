using System.Diagnostics.CodeAnalysis;

namespace TheLongDarkItemMarker.Forms
{
    partial class EditMarkerForm
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
            this.errorLabel = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSaveMarker = new System.Windows.Forms.Button();
            this.textBoxMarkerName = new System.Windows.Forms.TextBox();
            this.labelMarkerName = new System.Windows.Forms.Label();
            this.buttonEditItemList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(110, 26);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(54, 13);
            this.errorLabel.TabIndex = 30;
            this.errorLabel.Text = "Error label";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(152, 162);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 29;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.CancelClick);
            // 
            // buttonSaveMarker
            // 
            this.buttonSaveMarker.Location = new System.Drawing.Point(41, 162);
            this.buttonSaveMarker.Name = "buttonSaveMarker";
            this.buttonSaveMarker.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveMarker.TabIndex = 28;
            this.buttonSaveMarker.Text = "Save marker";
            this.buttonSaveMarker.UseVisualStyleBackColor = true;
            this.buttonSaveMarker.Click += new System.EventHandler(this.SaveMarkerClick);
            // 
            // textBoxMarkerName
            // 
            this.textBoxMarkerName.Location = new System.Drawing.Point(113, 80);
            this.textBoxMarkerName.Name = "textBoxMarkerName";
            this.textBoxMarkerName.Size = new System.Drawing.Size(177, 20);
            this.textBoxMarkerName.TabIndex = 27;
            // 
            // labelMarkerName
            // 
            this.labelMarkerName.AutoSize = true;
            this.labelMarkerName.Location = new System.Drawing.Point(18, 83);
            this.labelMarkerName.Name = "labelMarkerName";
            this.labelMarkerName.Size = new System.Drawing.Size(89, 13);
            this.labelMarkerName.TabIndex = 26;
            this.labelMarkerName.Text = "Name (1-20 char)";
            // 
            // buttonEditItemList
            // 
            this.buttonEditItemList.Location = new System.Drawing.Point(113, 117);
            this.buttonEditItemList.Name = "buttonEditItemList";
            this.buttonEditItemList.Size = new System.Drawing.Size(75, 23);
            this.buttonEditItemList.TabIndex = 31;
            this.buttonEditItemList.Text = "Edit item list";
            this.buttonEditItemList.UseVisualStyleBackColor = true;
            this.buttonEditItemList.Click += new System.EventHandler(this.EditItemListClick);
            // 
            // EditMarkerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(309, 211);
            this.Controls.Add(this.buttonEditItemList);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSaveMarker);
            this.Controls.Add(this.textBoxMarkerName);
            this.Controls.Add(this.labelMarkerName);
            this.Name = "EditMarkerForm";
            this.Text = "EditMarkerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSaveMarker;
        private System.Windows.Forms.TextBox textBoxMarkerName;
        private System.Windows.Forms.Label labelMarkerName;
        private System.Windows.Forms.Button buttonEditItemList;
    }
}