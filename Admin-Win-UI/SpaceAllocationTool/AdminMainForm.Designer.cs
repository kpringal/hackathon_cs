
namespace SpaceAllocationTool
{
    partial class AdminMainForm
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
            this.btnGetOfficeDetails = new System.Windows.Forms.Button();
            this.btnCreateNewOfficeDetail = new System.Windows.Forms.Button();
            this.btnGetRequestDetails = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetOfficeDetails
            // 
            this.btnGetOfficeDetails.BackColor = System.Drawing.Color.Purple;
            this.btnGetOfficeDetails.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnGetOfficeDetails.ForeColor = System.Drawing.Color.White;
            this.btnGetOfficeDetails.Location = new System.Drawing.Point(0, 1);
            this.btnGetOfficeDetails.Name = "btnGetOfficeDetails";
            this.btnGetOfficeDetails.Size = new System.Drawing.Size(237, 63);
            this.btnGetOfficeDetails.TabIndex = 0;
            this.btnGetOfficeDetails.Text = "Get Existing Office Details";
            this.btnGetOfficeDetails.UseVisualStyleBackColor = false;
            this.btnGetOfficeDetails.Click += new System.EventHandler(this.btnGetOfficeDetails_Click);
            // 
            // btnCreateNewOfficeDetail
            // 
            this.btnCreateNewOfficeDetail.BackColor = System.Drawing.Color.DeepPink;
            this.btnCreateNewOfficeDetail.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCreateNewOfficeDetail.ForeColor = System.Drawing.Color.White;
            this.btnCreateNewOfficeDetail.Location = new System.Drawing.Point(233, 1);
            this.btnCreateNewOfficeDetail.Name = "btnCreateNewOfficeDetail";
            this.btnCreateNewOfficeDetail.Size = new System.Drawing.Size(237, 63);
            this.btnCreateNewOfficeDetail.TabIndex = 1;
            this.btnCreateNewOfficeDetail.Text = "Create New Office Detail";
            this.btnCreateNewOfficeDetail.UseVisualStyleBackColor = false;
            this.btnCreateNewOfficeDetail.Click += new System.EventHandler(this.btnCreateNewOfficeDetail_Click);
            // 
            // btnGetRequestDetails
            // 
            this.btnGetRequestDetails.BackColor = System.Drawing.Color.Indigo;
            this.btnGetRequestDetails.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnGetRequestDetails.ForeColor = System.Drawing.Color.White;
            this.btnGetRequestDetails.Location = new System.Drawing.Point(467, 1);
            this.btnGetRequestDetails.Name = "btnGetRequestDetails";
            this.btnGetRequestDetails.Size = new System.Drawing.Size(237, 63);
            this.btnGetRequestDetails.TabIndex = 2;
            this.btnGetRequestDetails.Text = "Get Request Details";
            this.btnGetRequestDetails.UseVisualStyleBackColor = false;
            this.btnGetRequestDetails.Click += new System.EventHandler(this.btnGetRequestDetails_Click);
            // 
            // AdminMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 63);
            this.Controls.Add(this.btnGetRequestDetails);
            this.Controls.Add(this.btnCreateNewOfficeDetail);
            this.Controls.Add(this.btnGetOfficeDetails);
            this.MaximizeBox = false;
            this.Name = "AdminMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetOfficeDetails;
        private System.Windows.Forms.Button btnCreateNewOfficeDetail;
        private System.Windows.Forms.Button btnGetRequestDetails;
    }
}