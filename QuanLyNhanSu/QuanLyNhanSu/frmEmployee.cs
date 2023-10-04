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
    public partial class frmEmployee : Form
    {
        bool isAdd = false;
        List<Employee> employees;
        public frmEmployee()
        {
            InitializeComponent();
            loadData();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            disableButton();
            disableTextbox();

            cboDepartment.DataSource = DepartmentBUS.Instance.getAll();
            cboDepartment.DisplayMember = "departmentName";
            cboDepartment.ValueMember = "id";
            dgvEmpl.Columns[0].HeaderText = "Mã nhân viên";
            dgvEmpl.Columns[1].HeaderText = "Họ và tên";
            dgvEmpl.Columns[2].HeaderText = "Địa chỉ";
            dgvEmpl.Columns[3].HeaderText = "Ngày sinh";
            dgvEmpl.Columns[4].HeaderText = "Giới tính";
            dgvEmpl.Columns[5].HeaderText = "Số điện thoại";
            dgvEmpl.Columns[6].HeaderText = "Chức vụ";
            dgvEmpl.Columns[7].HeaderText = "Phòng ban";
            //dgvEmpl.Columns[8].HeaderText = "Trạng thái";
        }
        private void loadData()
        {
            employees = EmployeeBUS.Instance.GetAll();

            dgvEmpl.DataSource = employees.Select(emp => new
            {
                emp.id,
                emp.fullName,
                emp.address,
                emp.birthday,
                emp.gender,
                emp.phone,
                emp.position,
                emp.department.departmentName,
            }).ToList();
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
            btnSave.Enabled = true;

            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void enableTextbox()
        {
            txtFullName.Enabled = true;
            txtAddress.Enabled = true;
            txtPhone.Enabled = true;
            txtPosition.Enabled = true;

            cboDepartment.Enabled = true;
            dtpBirthday.Enabled = true;
        }

        private void disableTextbox()
        {
            txtFullName.Enabled = false;
            txtAddress.Enabled = false;
            txtPhone.Enabled = false;
            txtPosition.Enabled = false;

            cboDepartment.Enabled = false;
            dtpBirthday.Enabled = false;
        }



        private void dgvEmpl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var emp = employees[e.RowIndex];
            txtID.Text = emp.id.ToString();
            txtAddress.Text = emp.address;
            txtFullName.Text = emp.fullName;
            txtPhone.Text = emp.phone;
            txtPosition.Text = emp.position;
            if (emp.gender.Equals("Nam")) rdNam.Checked = true;
            else rdNu.Checked = true;

            dtpBirthday.Value = emp.birthday ?? DateTime.Now;

            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            isAdd = false;
            enableButton();
            enableTextbox();
            txtFullName.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAdd = true;
            enableButton();
            enableTextbox();

            txtFullName.Focus();
        }
        private void clearTextbox()
        {
            txtAddress.ResetText();
            txtFullName.ResetText();
            txtID.ResetText();
            txtPhone.ResetText();
            txtPosition.ResetText();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            disableTextbox();
            disableButton();
            clearTextbox();
            loadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textBoxIsEmpty())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            try
            {
                var emp = new Employee
                {
                    id = string.IsNullOrEmpty(txtID.Text) ? 0 : Convert.ToInt32(txtID.Text),
                    fullName = txtFullName.Text.Trim(),
                    address = txtAddress.Text.Trim(),
                    birthday = dtpBirthday.Value,
                    gender = rdNam.Checked ? "Nam" : "Nữ",
                    phone = txtPhone.Text.Trim(),
                    departmentId = (cboDepartment.SelectedItem == null) ? -1 : Convert.ToInt32(cboDepartment.SelectedValue),
                    position = txtPosition.Text.Trim()
                };
                if (isAdd)
                {
                    EmployeeBUS.Instance.add(emp);
                    MessageBox.Show("Thêm nhân viên thành công");
                }
                else
                {
                    if (dgvEmpl.SelectedRows.Count > 0)
                    {
                        EmployeeBUS.Instance.update(emp);
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn nhân viên để sửa");
                    }
                }
                btnReload_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex}");
            }
        }

        private bool textBoxIsEmpty()
        {
            return string.IsNullOrEmpty(txtAddress.Text.Trim())
                && string.IsNullOrEmpty(txtFullName.Text.Trim())
                && string.IsNullOrEmpty(txtPhone.Text.Trim())
                && string.IsNullOrEmpty(txtPosition.Text.Trim());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmpl.SelectedRows.Count > 0)
            {
                if(MessageBox.Show("Bạn có chắc muốn xóa?","Xác nhận",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    EmployeeBUS.Instance.delete(Convert.ToInt32(txtID.Text));
                    DepartmentBUS.Instance.removeManager(Convert.ToInt32(txtID.Text));
                    ContractBUS.Instance.deleteByEmpId(Convert.ToInt32(txtID.Text));
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
