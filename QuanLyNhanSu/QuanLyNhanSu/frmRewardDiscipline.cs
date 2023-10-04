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
using static System.Net.Mime.MediaTypeNames;

namespace QuanLyNhanSu
{
    public partial class frmRewardDiscipline : Form
    {
        bool isAdd = false;
        List<RewardDiscipline> list;
        public frmRewardDiscipline()
        {
            InitializeComponent();
        }

        private void dgvReward_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < list.Count)
            {
                var item = list[e.RowIndex];
                txtId.Text = item.id.ToString();
                txtDesc.Text = item.description;
                dtpCreateAt.Value = item.createAt ?? DateTime.Now;

                var cboIndex = cboEmp.FindStringExact(item.employee.fullNamePosition);
                if (cboIndex > -1)
                {
                    cboEmp.SelectedIndex = cboIndex;
                }
                cboType.SelectedIndex = cboType.FindStringExact(item.type.ToString());

                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
                btnSave.Enabled = false;
            }
        }
        private void clearTextbox()
        {
            txtDesc.ResetText();
            txtId.ResetText();
        }

        private void disableTextbox()
        {
            txtDesc.Enabled = false;
            cboEmp.Enabled = false;
            cboType.Enabled = false;
            dtpCreateAt.Enabled = false;
        }
        private void enableTextbox()
        {
            txtDesc.Enabled = true;
            cboEmp.Enabled = true;
            cboType.Enabled = true;
            dtpCreateAt.Enabled = true;
        }
        private void enableButton()
        {
            btnAdd.Enabled = true;

            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
        }
        private void disableButton()
        {
            btnAdd.Enabled = false;

            btnDelete.Enabled = false;
            btnEdit.Enabled = false;

            btnSave.Enabled = true;
        }
        private void loadData()
        {
            cboEmp.DataSource = EmployeeBUS.Instance.GetAll();
            cboEmp.DisplayMember = "fullNamePosition";
            cboEmp.ValueMember = "id";

            list = RewardDisciplineBUS.Instance.getAll();
            dgvReward.DataSource = list
                .Select(d => new
                {
                    d.id,
                    d.employee.fullNamePosition,
                    d.type,
                    d.createAt,
                    d.description
                }).ToList();
        }
        private void frmRewardDiscipline_Load(object sender, EventArgs e)
        {
            enableButton();
            clearTextbox();
            disableTextbox();
            loadData();
            dgvReward.Columns[0].HeaderText = "Mã khen thưởng / kỷ luật";
            dgvReward.Columns[1].HeaderText = "Nhân viên";
            dgvReward.Columns[2].HeaderText = "Loại";
            dgvReward.Columns[3].HeaderText = "Ngày tạo";
            dgvReward.Columns[4].HeaderText = "Chi tiết";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAdd = true;
            enableTextbox();
            disableButton();
            clearTextbox();
            cboEmp.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            isAdd = false;
            enableTextbox();
            disableButton();
            cboEmp.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvReward.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    RewardDisciplineBUS.Instance.delete(Convert.ToInt32(txtId.Text));
                    btnReload_Click(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại khen thường / kỉ luật cần xóa");
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            enableButton();
            disableTextbox();
            clearTextbox();
            loadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDesc.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                txtDesc.Focus();
                return;
            }
            try
            {
                var item = new RewardDiscipline
                {
                    id = string.IsNullOrEmpty(txtId.Text.Trim()) ? (int?)null : Convert.ToInt32(txtId.Text.Trim()),
                    employeeId = cboEmp.SelectedItem == null ? (int?)null : Convert.ToInt32(cboEmp.SelectedValue),
                    createAt = dtpCreateAt.Value,
                    description = txtDesc.Text.Trim(),
                    type = cboType.Text
                };
                if (isAdd)
                {
                    RewardDisciplineBUS.Instance.add(item);
                    MessageBox.Show("Thêm thành công");
                }
                else
                {
                    if (dgvReward.SelectedRows.Count > 0)
                    {
                        RewardDisciplineBUS.Instance.update(item);
                        MessageBox.Show("Chỉnh sửa thành công");
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn loại khen thường / kỉ luật cần chỉnh sửa");
                    }
                }
                btnReload_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }
    }
}
