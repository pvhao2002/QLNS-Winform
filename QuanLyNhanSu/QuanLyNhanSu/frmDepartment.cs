using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanSu
{
    public partial class frmDepartment : Form
    {
        bool isAdd = false;
        public frmDepartment()
        {
            InitializeComponent();
        }
        private void loadData()
        {
            dgvDept.DataSource = DepartmentBUS.Instance.getAll()
                .Select(d => new
                {
                    d.id,
                    d.departmentName,
                    d.manager.fullNamePosition,
                    d.description,
                }).ToList();

            cboManager.DataSource = EmployeeBUS.Instance.getEmployeeCanBeManager();
            cboManager.DisplayMember = "fullNamePosition";
            cboManager.ValueMember = "id";
        }

        private void dgvDept_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvDept.CurrentCell.RowIndex;
            txtId.Text = dgvDept.Rows[r].Cells[0].Value.ToString();
            txtName.Text = dgvDept.Rows[r].Cells[1].Value.ToString();
            txtDescription.Text = dgvDept.Rows[r].Cells[3].Value.ToString();


            btnEdit.Enabled = true;
            btnDelete.Enabled = true;

            btnSave.Enabled = false;
        }

        private void disableButton()
        {
            btnAdd.Enabled = true;

            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
        }

        private void enableButton()
        {
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

            btnSave.Enabled = true;
        }

        private void frmDepartment_Load(object sender, EventArgs e)
        {
            disableButton();
            disableTextbox();
            loadData();
            dgvDept.Columns[0].HeaderText = "Mã phòng ban";
            dgvDept.Columns[1].HeaderText = "Tên phòng ban";
            dgvDept.Columns[2].HeaderText = "Người quản lý";
            dgvDept.Columns[3].HeaderText = "Mô tả";

            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAdd = true;
            enableButton();
            resetTextbox();
            enableTextbox();

            txtName.Focus();
        }

        private void resetTextbox()
        {
            txtId.ResetText();
            txtName.ResetText();
            txtDescription.ResetText();
            cboManager.ResetText();
        }

        private void enableTextbox()
        {
            txtName.Enabled = true;
            txtDescription.Enabled = true;
            cboManager.Enabled = true;
        }


        private void disableTextbox()
        {
            txtName.Enabled = false;
            txtDescription.Enabled = false;
            cboManager.Enabled = false;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            isAdd = false;
            enableButton();
            enableTextbox();

            cboManager.Enabled = true;

            txtName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textBoxIsEmpty())
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                return;
            }
            try
            {
                var dept = new Department
                {
                    id = string.IsNullOrEmpty(txtId.Text.Trim()) ? 0 : Convert.ToInt32(txtId.Text.Trim()),
                    departmentName = txtName.Text.Trim(),
                    managerId = (cboManager.SelectedItem as Employee) == null ? -1 : Convert.ToInt32(cboManager.SelectedValue),
                    description = txtDescription.Text.Trim(),
                };
                if (isAdd)
                {
                    DepartmentBUS.Instance.add(dept);
                    loadData();
                    MessageBox.Show("Thêm thành công");
                }
                else
                {
                    if (dgvDept.SelectedRows.Count > 0)
                    {
                        DepartmentBUS.Instance.removeMangerByDid(Convert.ToInt32(txtId.Text));
                        DepartmentBUS.Instance.update(dept); loadData();
                        MessageBox.Show("Cập nhật thành công");
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn phòng ban");
                    }
                }
                btnReload_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private bool textBoxIsEmpty()
        {
            return string.IsNullOrEmpty(txtName.Text.Trim()) &&
                string.IsNullOrEmpty(txtDescription.Text.Trim());
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            disableButton();
            loadData();
            resetTextbox();
            disableTextbox();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDept.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DepartmentBUS.Instance.delete(Convert.ToInt32(txtId.Text));
                    DepartmentBUS.Instance.removeMangerByDid(Convert.ToInt32(txtId.Text));
                    btnReload_Click(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa");
            }
        }
    }
}
