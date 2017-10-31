namespace InternetCafe
{
    partial class frmHourPrice
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
            this.nudHourPrice = new System.Windows.Forms.NumericUpDown();
            this.dgvHourPriceHistory = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblInfoUpdatePrice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudHourPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHourPriceHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Price per 1 hour =";
            // 
            // nudHourPrice
            // 
            this.nudHourPrice.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudHourPrice.Location = new System.Drawing.Point(213, 29);
            this.nudHourPrice.Name = "nudHourPrice";
            this.nudHourPrice.Size = new System.Drawing.Size(162, 32);
            this.nudHourPrice.TabIndex = 1;
            this.nudHourPrice.ValueChanged += new System.EventHandler(this.nudHourPrice_ValueChanged);
            // 
            // dgvHourPriceHistory
            // 
            this.dgvHourPriceHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHourPriceHistory.Location = new System.Drawing.Point(30, 138);
            this.dgvHourPriceHistory.Name = "dgvHourPriceHistory";
            this.dgvHourPriceHistory.Size = new System.Drawing.Size(401, 182);
            this.dgvHourPriceHistory.TabIndex = 2;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(164, 76);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(132, 37);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(381, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Riels";
            // 
            // lblInfoUpdatePrice
            // 
            this.lblInfoUpdatePrice.AutoSize = true;
            this.lblInfoUpdatePrice.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoUpdatePrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblInfoUpdatePrice.Location = new System.Drawing.Point(133, 113);
            this.lblInfoUpdatePrice.Name = "lblInfoUpdatePrice";
            this.lblInfoUpdatePrice.Size = new System.Drawing.Size(196, 19);
            this.lblInfoUpdatePrice.TabIndex = 6;
            this.lblInfoUpdatePrice.Text = "Price is updated successfully";
            // 
            // frmHourPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 352);
            this.Controls.Add(this.lblInfoUpdatePrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dgvHourPriceHistory);
            this.Controls.Add(this.nudHourPrice);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHourPrice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmHourPrice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudHourPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHourPriceHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudHourPrice;
        private System.Windows.Forms.DataGridView dgvHourPriceHistory;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblInfoUpdatePrice;
    }
}