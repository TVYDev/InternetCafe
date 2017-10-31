namespace InternetCafeClientProject
{
    partial class frmTopUp
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelTopup = new System.Windows.Forms.Button();
            this.btnConfirmTopUp = new System.Windows.Forms.Button();
            this.nudHours = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudHours)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(391, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter numbers of hours that you want to top up";
            // 
            // btnCancelTopup
            // 
            this.btnCancelTopup.BackgroundImage = global::InternetCafeClientProject.Properties.Resources._1489346321_Close;
            this.btnCancelTopup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancelTopup.Location = new System.Drawing.Point(215, 140);
            this.btnCancelTopup.Name = "btnCancelTopup";
            this.btnCancelTopup.Size = new System.Drawing.Size(70, 67);
            this.btnCancelTopup.TabIndex = 3;
            this.btnCancelTopup.UseVisualStyleBackColor = true;
            // 
            // btnConfirmTopUp
            // 
            this.btnConfirmTopUp.BackgroundImage = global::InternetCafeClientProject.Properties.Resources._1489346171_Checkmark;
            this.btnConfirmTopUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfirmTopUp.Location = new System.Drawing.Point(127, 140);
            this.btnConfirmTopUp.Name = "btnConfirmTopUp";
            this.btnConfirmTopUp.Size = new System.Drawing.Size(70, 67);
            this.btnConfirmTopUp.TabIndex = 2;
            this.btnConfirmTopUp.UseVisualStyleBackColor = true;
            // 
            // nudHours
            // 
            this.nudHours.Font = new System.Drawing.Font("Comic Sans MS", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudHours.Location = new System.Drawing.Point(164, 71);
            this.nudHours.Name = "nudHours";
            this.nudHours.Size = new System.Drawing.Size(93, 45);
            this.nudHours.TabIndex = 4;
            this.nudHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmTopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 219);
            this.Controls.Add(this.nudHours);
            this.Controls.Add(this.btnCancelTopup);
            this.Controls.Add(this.btnConfirmTopUp);
            this.Controls.Add(this.label1);
            this.Name = "frmTopUp";
            this.Text = "Top Up";
            ((System.ComponentModel.ISupportInitialize)(this.nudHours)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConfirmTopUp;
        private System.Windows.Forms.Button btnCancelTopup;
        private System.Windows.Forms.NumericUpDown nudHours;
    }
}