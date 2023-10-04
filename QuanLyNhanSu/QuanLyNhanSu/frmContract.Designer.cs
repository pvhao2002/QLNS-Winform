namespace QuanLyNhanSu
{
    partial class frmContract
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtid = new System.Windows.Forms.TextBox();
            this.txttype = new System.Windows.Forms.TextBox();
            this.txtsalary = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpsdate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpedate = new System.Windows.Forms.DateTimePicker();
            this.rdt = new System.Windows.Forms.RadioButton();
            this.rdf = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.txtother = new System.Windows.Forms.RichTextBox();
            this.dgvContract = new System.Windows.Forms.DataGridView();
            this.cboEmp = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContract)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAdd);
            this.flowLayoutPanel1.Controls.Add(this.btnEdit);
            this.flowLayoutPanel1.Controls.Add(this.btnDelete);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Controls.Add(this.btnReload);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(15, 15);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1227, 59);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(33, 3);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 3, 100, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(117, 56);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Location = new System.Drawing.Point(280, 3);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(30, 3, 100, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(117, 56);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(527, 3);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(30, 3, 100, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(117, 56);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(774, 3);
            this.btnSave.Margin = new System.Windows.Forms.Padding(30, 3, 100, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 56);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReload
            // 
            this.btnReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReload.Location = new System.Drawing.Point(994, 3);
            this.btnReload.Margin = new System.Windows.Forms.Padding(3, 3, 100, 3);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(117, 56);
            this.btnReload.TabIndex = 4;
            this.btnReload.Text = "Làm mới";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvContract);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(15, 74);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(1227, 461);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cboEmp);
            this.panel2.Controls.Add(this.txtother);
            this.panel2.Controls.Add(this.rdf);
            this.panel2.Controls.Add(this.rdt);
            this.panel2.Controls.Add(this.dtpedate);
            this.panel2.Controls.Add(this.dtpsdate);
            this.panel2.Controls.Add(this.txtsalary);
            this.panel2.Controls.Add(this.txttype);
            this.panel2.Controls.Add(this.txtid);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(15, 535);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(1227, 267);
            this.panel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã hợp đồng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Loại hợp đồng:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nhân viên:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Lương:";
            // 
            // txtid
            // 
            this.txtid.Enabled = false;
            this.txtid.Location = new System.Drawing.Point(172, 16);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(481, 30);
            this.txtid.TabIndex = 11;
            // 
            // txttype
            // 
            this.txttype.Location = new System.Drawing.Point(172, 63);
            this.txttype.Name = "txttype";
            this.txttype.Size = new System.Drawing.Size(481, 30);
            this.txttype.TabIndex = 0;
            // 
            // txtsalary
            // 
            this.txtsalary.Location = new System.Drawing.Point(172, 157);
            this.txtsalary.Name = "txtsalary";
            this.txtsalary.Size = new System.Drawing.Size(481, 30);
            this.txtsalary.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Ngày bắt đầu:";
            // 
            // dtpsdate
            // 
            this.dtpsdate.Location = new System.Drawing.Point(172, 206);
            this.dtpsdate.Name = "dtpsdate";
            this.dtpsdate.Size = new System.Drawing.Size(481, 30);
            this.dtpsdate.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(677, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "Ngày kết thúc:";
            // 
            // dtpedate
            // 
            this.dtpedate.Location = new System.Drawing.Point(682, 52);
            this.dtpedate.Name = "dtpedate";
            this.dtpedate.Size = new System.Drawing.Size(481, 30);
            this.dtpedate.TabIndex = 5;
            // 
            // rdt
            // 
            this.rdt.AutoSize = true;
            this.rdt.Location = new System.Drawing.Point(820, 13);
            this.rdt.Name = "rdt";
            this.rdt.Size = new System.Drawing.Size(136, 29);
            this.rdt.TabIndex = 4;
            this.rdt.Text = "Đã xác định";
            this.rdt.UseVisualStyleBackColor = true;
            this.rdt.CheckedChanged += new System.EventHandler(this.rdt_CheckedChanged);
            // 
            // rdf
            // 
            this.rdf.AutoSize = true;
            this.rdf.Checked = true;
            this.rdf.Location = new System.Drawing.Point(1006, 14);
            this.rdf.Name = "rdf";
            this.rdf.Size = new System.Drawing.Size(159, 29);
            this.rdf.TabIndex = 4;
            this.rdf.TabStop = true;
            this.rdf.Text = "Chưa xác định";
            this.rdf.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(677, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 25);
            this.label7.TabIndex = 0;
            this.label7.Text = "Các khoản khác:";
            // 
            // txtother
            // 
            this.txtother.Location = new System.Drawing.Point(682, 129);
            this.txtother.Name = "txtother";
            this.txtother.Size = new System.Drawing.Size(532, 107);
            this.txtother.TabIndex = 6;
            this.txtother.Text = "";
            // 
            // dgvContract
            // 
            this.dgvContract.AllowUserToResizeColumns = false;
            this.dgvContract.AllowUserToResizeRows = false;
            this.dgvContract.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvContract.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvContract.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvContract.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContract.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvContract.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvContract.Location = new System.Drawing.Point(10, 10);
            this.dgvContract.MultiSelect = false;
            this.dgvContract.Name = "dgvContract";
            this.dgvContract.ReadOnly = true;
            this.dgvContract.RowHeadersWidth = 51;
            this.dgvContract.RowTemplate.Height = 24;
            this.dgvContract.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContract.Size = new System.Drawing.Size(1207, 441);
            this.dgvContract.TabIndex = 0;
            this.dgvContract.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContract_CellClick);
            // 
            // cboEmp
            // 
            this.cboEmp.FormattingEnabled = true;
            this.cboEmp.Location = new System.Drawing.Point(172, 109);
            this.cboEmp.Name = "cboEmp";
            this.cboEmp.Size = new System.Drawing.Size(481, 33);
            this.cboEmp.TabIndex = 1;
            // 
            // frmContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 817);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmContract";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.Text = "frmContract";
            this.Load += new System.EventHandler(this.frmContract_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContract)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtsalary;
        private System.Windows.Forms.TextBox txttype;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpsdate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpedate;
        private System.Windows.Forms.RadioButton rdt;
        private System.Windows.Forms.RadioButton rdf;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox txtother;
        private System.Windows.Forms.DataGridView dgvContract;
        private System.Windows.Forms.ComboBox cboEmp;
    }
}