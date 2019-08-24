namespace TheLongDarkItemMarker.Forms
{
    partial class CreateMarkerForm
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
            this.labelMarkerName = new System.Windows.Forms.Label();
            this.textBoxMarkerName = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAddMarker = new System.Windows.Forms.Button();
            this.errorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelMarkerName
            // 
            this.labelMarkerName.AutoSize = true;
            this.labelMarkerName.Location = new System.Drawing.Point(25, 97);
            this.labelMarkerName.Name = "labelMarkerName";
            this.labelMarkerName.Size = new System.Drawing.Size(89, 13);
            this.labelMarkerName.TabIndex = 0;
            this.labelMarkerName.Text = "Name (1-20 char)";
            // 
            // textBoxMarkerName
            // 
            this.textBoxMarkerName.Location = new System.Drawing.Point(120, 94);
            this.textBoxMarkerName.Name = "textBoxMarkerName";
            this.textBoxMarkerName.Size = new System.Drawing.Size(177, 20);
            this.textBoxMarkerName.TabIndex = 1;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(159, 176);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 24;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonAddMarker
            // 
            this.buttonAddMarker.Location = new System.Drawing.Point(48, 176);
            this.buttonAddMarker.Name = "buttonAddMarker";
            this.buttonAddMarker.Size = new System.Drawing.Size(75, 23);
            this.buttonAddMarker.TabIndex = 23;
            this.buttonAddMarker.Text = "Add marker";
            this.buttonAddMarker.UseVisualStyleBackColor = true;
            this.buttonAddMarker.Click += new System.EventHandler(this.buttonAddMarker_Click);
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(117, 40);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(54, 13);
            this.errorLabel.TabIndex = 25;
            this.errorLabel.Text = "Error label";
            // 
            // CreateMarkerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(309, 211);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAddMarker);
            this.Controls.Add(this.textBoxMarkerName);
            this.Controls.Add(this.labelMarkerName);
            this.Name = "CreateMarkerForm";
            this.Text = "CreateMarkerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMarkerName;
        private System.Windows.Forms.TextBox textBoxMarkerName;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAddMarker;
        private System.Windows.Forms.Label errorLabel;
    }
}