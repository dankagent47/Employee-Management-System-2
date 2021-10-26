
namespace Employee_Management_System
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAllEmps = new System.Windows.Forms.Button();
            this.btnSpecificEmps = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAddChangeEmps = new System.Windows.Forms.Button();
            this.btnDeleteEmps = new System.Windows.Forms.Button();
            this.gridEmployees = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAllEmps
            // 
            this.btnAllEmps.Location = new System.Drawing.Point(12, 36);
            this.btnAllEmps.Name = "btnAllEmps";
            this.btnAllEmps.Size = new System.Drawing.Size(228, 29);
            this.btnAllEmps.TabIndex = 1;
            this.btnAllEmps.Text = "Show All Employees";
            this.btnAllEmps.UseVisualStyleBackColor = true;
            // 
            // btnSpecificEmps
            // 
            this.btnSpecificEmps.Location = new System.Drawing.Point(262, 36);
            this.btnSpecificEmps.Name = "btnSpecificEmps";
            this.btnSpecificEmps.Size = new System.Drawing.Size(244, 29);
            this.btnSpecificEmps.TabIndex = 2;
            this.btnSpecificEmps.Text = "Find Specific Employees";
            this.btnSpecificEmps.UseVisualStyleBackColor = true;
            this.btnSpecificEmps.Click += new System.EventHandler(this.btnSpecificEmps_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1039, 48);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(355, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee Management System";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAddChangeEmps);
            this.panel2.Controls.Add(this.btnDeleteEmps);
            this.panel2.Controls.Add(this.btnSpecificEmps);
            this.panel2.Controls.Add(this.btnAllEmps);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 539);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1039, 86);
            this.panel2.TabIndex = 4;
            // 
            // btnAddChangeEmps
            // 
            this.btnAddChangeEmps.Location = new System.Drawing.Point(530, 36);
            this.btnAddChangeEmps.Name = "btnAddChangeEmps";
            this.btnAddChangeEmps.Size = new System.Drawing.Size(258, 29);
            this.btnAddChangeEmps.TabIndex = 5;
            this.btnAddChangeEmps.Text = "Add/Change Employee";
            this.btnAddChangeEmps.UseVisualStyleBackColor = true;
            this.btnAddChangeEmps.Click += new System.EventHandler(this.btnAddChangeEmps_Click);
            // 
            // btnDeleteEmps
            // 
            this.btnDeleteEmps.Location = new System.Drawing.Point(813, 36);
            this.btnDeleteEmps.Name = "btnDeleteEmps";
            this.btnDeleteEmps.Size = new System.Drawing.Size(198, 29);
            this.btnDeleteEmps.TabIndex = 4;
            this.btnDeleteEmps.Text = "Delete Employee";
            this.btnDeleteEmps.UseVisualStyleBackColor = true;
            this.btnDeleteEmps.Click += new System.EventHandler(this.btnDeleteEmps_Click);
            // 
            // gridEmployees
            // 
            this.gridEmployees.AllowUserToAddRows = false;
            this.gridEmployees.AllowUserToDeleteRows = false;
            this.gridEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEmployees.Location = new System.Drawing.Point(0, 54);
            this.gridEmployees.Name = "gridEmployees";
            this.gridEmployees.ReadOnly = true;
            this.gridEmployees.RowHeadersWidth = 51;
            this.gridEmployees.RowTemplate.Height = 29;
            this.gridEmployees.Size = new System.Drawing.Size(1039, 494);
            this.gridEmployees.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 625);
            this.Controls.Add(this.gridEmployees);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEmployees)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAllEmps;
        private System.Windows.Forms.Button btnSpecificEmps;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView gridEmployees;
        private System.Windows.Forms.Button btnAddChangeEmps;
        private System.Windows.Forms.Button btnDeleteEmps;
    }
}

