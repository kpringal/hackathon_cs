
namespace SpaceAllocationTool
{
    partial class ExistingOfficeDetailsForm
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
            this.dgvOfficeDetails = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOfficeDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOfficeDetails
            // 
            this.dgvOfficeDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOfficeDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOfficeDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOfficeDetails.Location = new System.Drawing.Point(14, 18);
            this.dgvOfficeDetails.Name = "dgvOfficeDetails";
            this.dgvOfficeDetails.RowTemplate.Height = 25;
            this.dgvOfficeDetails.Size = new System.Drawing.Size(771, 414);
            this.dgvOfficeDetails.TabIndex = 0;
            this.dgvOfficeDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOfficeDetails_CellClick);
            // 
            // ExistingOfficeDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvOfficeDetails);
            this.Name = "ExistingOfficeDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Office Details";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ExistingOfficeDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOfficeDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOfficeDetails;
    }
}