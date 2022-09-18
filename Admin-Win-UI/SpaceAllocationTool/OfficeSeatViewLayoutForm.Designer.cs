
namespace SpaceAllocationTool
{
    partial class OfficeSeatViewLayoutForm
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
            this.dtpAllocationTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpAllocationFrom = new System.Windows.Forms.DateTimePicker();
            this.lblStartPeriod = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.dgvUserOfficeFloorSeatAllocationDetails = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserOfficeFloorSeatAllocationDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpAllocationTo
            // 
            this.dtpAllocationTo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpAllocationTo.Location = new System.Drawing.Point(424, 17);
            this.dtpAllocationTo.Name = "dtpAllocationTo";
            this.dtpAllocationTo.Size = new System.Drawing.Size(162, 25);
            this.dtpAllocationTo.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(328, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 19);
            this.label3.TabIndex = 14;
            this.label3.Text = "Allocation To :";
            // 
            // dtpAllocationFrom
            // 
            this.dtpAllocationFrom.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpAllocationFrom.Location = new System.Drawing.Point(125, 17);
            this.dtpAllocationFrom.Name = "dtpAllocationFrom";
            this.dtpAllocationFrom.Size = new System.Drawing.Size(162, 25);
            this.dtpAllocationFrom.TabIndex = 13;
            // 
            // lblStartPeriod
            // 
            this.lblStartPeriod.AutoSize = true;
            this.lblStartPeriod.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStartPeriod.Location = new System.Drawing.Point(6, 19);
            this.lblStartPeriod.Name = "lblStartPeriod";
            this.lblStartPeriod.Size = new System.Drawing.Size(112, 19);
            this.lblStartPeriod.TabIndex = 12;
            this.lblStartPeriod.Text = "Allocation From :";
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(619, 16);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(174, 25);
            this.btnView.TabIndex = 16;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // dgvUserOfficeFloorSeatAllocationDetails
            // 
            this.dgvUserOfficeFloorSeatAllocationDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUserOfficeFloorSeatAllocationDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUserOfficeFloorSeatAllocationDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserOfficeFloorSeatAllocationDetails.Location = new System.Drawing.Point(6, 48);
            this.dgvUserOfficeFloorSeatAllocationDetails.Name = "dgvUserOfficeFloorSeatAllocationDetails";
            this.dgvUserOfficeFloorSeatAllocationDetails.RowTemplate.Height = 25;
            this.dgvUserOfficeFloorSeatAllocationDetails.Size = new System.Drawing.Size(787, 447);
            this.dgvUserOfficeFloorSeatAllocationDetails.TabIndex = 17;
            // 
            // OfficeSeatViewLayoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 507);
            this.Controls.Add(this.dgvUserOfficeFloorSeatAllocationDetails);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.dtpAllocationTo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpAllocationFrom);
            this.Controls.Add(this.lblStartPeriod);
            this.Name = "OfficeSeatViewLayoutForm";
            this.Text = "Office Seat Allocation View";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OfficeSeatViewLayoutForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserOfficeFloorSeatAllocationDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpAllocationTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpAllocationFrom;
        private System.Windows.Forms.Label lblStartPeriod;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.DataGridView dgvUserOfficeFloorSeatAllocationDetails;
    }
}