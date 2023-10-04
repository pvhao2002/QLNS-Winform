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
    public partial class frmContract : Form
    {
        bool isAdd = false;
        List<Contract> contracts;
        public frmContract()
        {
            InitializeComponent();
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

        private void disableTextbox()
        {
            txtother.Enabled = false;
            txtsalary.Enabled = false;
            txttype.Enabled = false;
            cboEmp.Enabled = false;
            dtpedate.Enabled = false;
            dtpsdate.Enabled = false;
            rdf.Enabled = false;
            rdt.Enabled = false;
        }

        private void enableTextbox()
        {
            txtother.Enabled = true;
            txtsalary.Enabled = true;
            txttype.Enabled = true;
            cboEmp.Enabled = true;
            dtpedate.Enabled = rdt.Checked;
            dtpsdate.Enabled = true;
            rdf.Enabled = true;
            rdt.Enabled = true;
        }
        private void frmContract_Load(object sender, EventArgs e)
        {
            loadData();
            disableButton();
            disableTextbox();
            dgvContract.Columns[0].HeaderText = "Mã hợp đồng";
            dgvContract.Columns[1].HeaderText = "Loại hợp đồng";
            dgvContract.Columns[2].HeaderText = "Nhân viên";
            dgvContract.Columns[3].HeaderText = "Ngày bắt đầu";
            dgvContract.Columns[4].HeaderText = "Ngày kết thúc";
            dgvContract.Columns[5].HeaderText = "Lương";
            dgvContract.Columns[6].HeaderText = "Mục khác";
        }
        private void loadData()
        {
            contracts = ContractBUS.Instance.getAll();
            dgvContract.DataSource = contracts
                                            .Select(d => new
                                            {
                                                d.id,
                                                d.contractType,
                                                d.employee.fullNamePosition,
                                                d.startDate,
                                                d.endDate,
                                                d.salary,
                                                d.otherItem
                                            }).ToList();

            cboEmp.DataSource = EmployeeBUS.Instance.GetAll();
            cboEmp.DisplayMember = "fullNamePosition";
            cboEmp.ValueMember = "id";
        }
        private void dgvContract_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1 && e.RowIndex < contracts.Count)
            {
                var item = contracts[e.RowIndex];
                txtid.Text = item.id.ToString();
                txtother.Text = item.otherItem.ToString();
                txtsalary.Text = item.salary.ToString();
                txttype.Text = item.contractType.ToString();
                dtpedate.Value = item.endDate ?? DateTime.Now;
                dtpsdate.Value = item.startDate;


                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
                btnSave.Enabled = true;
            }
        }

        private void clearTextbox()
        {
            txtid.ResetText();
            txtother.ResetText();
            txtsalary.ResetText();
            txttype.ResetText();
            rdf.Checked = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAdd = true;
            enableTextbox();
            clearTextbox();
            enableButton();
            txttype.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            isAdd = false;
            enableTextbox();
            enableButton();
            txttype.Focus();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            loadData();
            disableButton();
            disableTextbox();
            clearTextbox();
        }

        private bool isValidSalary()
        {
            return decimal.TryParse(txtsalary.Text, out _);
        }
        private bool isEmptyTextbox()
        {
            return string.IsNullOrEmpty(txtother.Text.Trim())
                && string.IsNullOrEmpty(txtsalary.Text.Trim())
                && string.IsNullOrEmpty(txttype.Text.Trim());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvContract.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ContractBUS.Instance.delete(Convert.ToInt32(txtid.Text));
                    btnReload_Click(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hợp đồng để xóa");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isEmptyTextbox())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                txttype.Focus();
                return;
            }

            if (!isValidSalary())
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng số");
                txtsalary.Focus();
                return;
            }
            try
            {
                var item = new Contract
                {
                    id = string.IsNullOrEmpty(txtid.Text) ? (int?)null : Convert.ToInt32(txtid.Text),
                    contractType = txttype.Text.Trim(),
                    salary = Convert.ToDecimal(txtsalary.Text.Trim()),
                    startDate = dtpsdate.Value,
                    endDate = rdf.Checked ? (DateTime?)null : dtpedate.Value,
                    otherItem = txtother.Text.Trim(),
                    employeeId = cboEmp.SelectedItem == null ? (int?)null : Convert.ToInt32(cboEmp.SelectedValue),
                };
                if (isAdd)
                {
                    ContractBUS.Instance.add(item);
                    MessageBox.Show("Thêm thành công!");
                }
                else
                {
                    if (dgvContract.SelectedRows.Count > 0)
                    {
                        ContractBUS.Instance.update(item);
                        MessageBox.Show("Sửa thông tin thành công");
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn hợp đồng để chỉnh sửa");
                    }
                }
                btnReload_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void rdt_CheckedChanged(object sender, EventArgs e)
        {
            dtpedate.Enabled = rdt.Checked;
        }
    }
}
