﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projects
{
    public partial class Add_Member : Form
    {
        MySqlConnection c = new MySqlConnection("Server=localhost; database=villageFund_db; UID=root; Pwd=root;");
        MySqlCommand cmd = new MySqlCommand();
        
        public Add_Member()
        {
            InitializeComponent();
        }
        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Memumain main = new Memumain();
            main.Show();
        }

        private void ShowMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Show_Member shm = new Show_Member();
            shm.Show();
        }

        private void AddMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Member adm = new Add_Member();
            adm.Show();
        }

        private void ShowDepositeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Show_Deposit shd = new Show_Deposit();
            shd.Show();
        }

        private void AddDepositeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Deposite___withdraw dw = new Deposite___withdraw();
            dw.Show();
        }

        private void PaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Payment pay = new Payment();
            pay.Show();
        }

        private void AddLoanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Loan adl = new Add_Loan();
            adl.Show();
        }

        private void ShowLoan1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowDataAccout1 shda1 = new ShowDataAccout1();
            shda1.Show();
        }

        private void ShowLoan2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowDataAccout2 shda2 = new ShowDataAccout2();
            shda2.Show();
        }

        private void ShowDividendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Show_Interest shi = new Show_Interest();
            shi.Show();
        }

        private void Dividend1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dividend div = new Dividend();
            div.Show();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
         private void but_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (memberNoID.Text != null)
                {
                    DateTime time = DateTime.Now;
                    string time_started = time.ToString("hh:mm:ss dd-MM-yyyy");

                    cmd.CommandText = @"INSERT INTO member(memTitle,memName,memLastname,memNoID,memHouseNo,memVillage,memVillageNo,
                                                       memSubdistrict,memDistrict,memProvince,memPostalcode,memcomday,memcommonth,
                                                       memYear,memcomstatus,memtimestarted) 
                                    VALUES('" + this.com_num.SelectedItem
                                    + "','" + this.memberName.Text + "','" + this.memberLastname.Text + "','" + this.memberNoID.Text
                                    + "','" + this.memberHouseNo.Text + "','" + this.memberVillage.Text + "','" + this.memberVillageNo.Text
                                    + "','" + this.memberSubdistrict.Text + "','" + this.memberDistrict.Text + "','" + this.memberProvince.Text
                                    + "','" + this.memberPostalcode.Text + "','" + this.com_day.SelectedItem
                                    + "','" + this.com_month.SelectedItem + "','" + this.memberYear.Text
                                    + "','" + this.com_status.SelectedItem + "','" + time_started + "')";

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("insert");

                    loadData();
                    MessageBox.Show("yes");

                }
                else
                {
                    MessageBox.Show("No");
                }
                

                


                cmd.ExecuteNonQuery();
                MessageBox.Show("insert");

                loadData();
                MessageBox.Show("yes");
                
                }
                

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void but_delete_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "DELETE FROM member WHERE memNoID = '" + memberNoID.Text + "' ";
            cmd.ExecuteNonQuery();
            loadData();


            MessageBox.Show("delete");
        }

        private void Add_Member_Load(object sender, EventArgs e)
        {
            c.Open();
            cmd.Connection = c;
            loadData();
        }

        private void Add_Member_Unload(object sender, EventArgs e)
        {
            c.Close();
        }

        private void but_edit_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            string time_started = time.ToString("hh:mm:ss dd-MM-yyyy");

            

            cmd.CommandText = @"UPDATE member
                                SET memTitle = '" + this.com_num.SelectedItem + "',memName = '" + this.memberName.Text + "', memLastname = '" + this.memberLastname.Text
                                                 + "',memNoID = '" + this.memberNoID.Text + "',memHouseNo = '" + this.memberHouseNo.Text
                                                 + "',memVillage = '" + this.memberVillage.Text + "',memVillageNo = '" + this.memberVillageNo.Text
                                                 + "',memSubdistrict = '" + this.memberSubdistrict.Text + "',memDistrict = '" + this.memberDistrict.Text
                                                 + "',memProvince = '" + this.memberProvince.Text + "',memPostalcode = '" + this.memberPostalcode.Text
                                                 + "',memcomday = '" + this.com_day.SelectedItem + "',memcommonth = '" + this.com_month.SelectedItem
                                                 + "',memYear = '" + this.memberYear.Text + "',memPostalcode = '" + this.com_status.SelectedItem
                                                 + "',memtimestarted = '" + time_started
                          + "' WHERE memNoID = '" + memberNoID.Text + "' ";

            MessageBox.Show("edit");
            cmd.ExecuteNonQuery();
            MessageBox.Show("edit2");
            loadData();
        }

        private void Cleardata()
        {
            com_num.Text = "คำนำหน้า";
            memberName.Clear();
            memberLastname.Clear();
            memberNoID.Clear();

            memberHouseNo.Clear();
            memberVillage.Clear();
            memberVillageNo.Clear();
            memberSubdistrict.Clear();
            memberDistrict.Clear();
            memberProvince.Clear();
            memberPostalcode.Clear();
            com_day.Text = "วันที่";
            com_month.Text = "เดือน";
            memberYear.Clear();
            com_status.Text = "สถานะภาพ";
        }

        private void loadData()
        {
            MySqlDataReader Reader;
            cmd.CommandText = "SELECT * FROM member";
            Reader = cmd.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(Reader);

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = dataTable;
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            com_num.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells["memTitle"].Value.ToString();
            memberName.Text = dataGridView1.Rows[e.RowIndex].Cells["memName"].Value.ToString();
            memberLastname.Text = dataGridView1.Rows[e.RowIndex].Cells["memLastname"].Value.ToString();
            memberNoID.Text = dataGridView1.Rows[e.RowIndex].Cells["memNoID"].Value.ToString();

            memberHouseNo.Text = dataGridView1.Rows[e.RowIndex].Cells["memHouseNo"].Value.ToString();
            memberVillage.Text = dataGridView1.Rows[e.RowIndex].Cells["memVillage"].Value.ToString();
            memberVillageNo.Text = dataGridView1.Rows[e.RowIndex].Cells["memVillageNo"].Value.ToString();
            memberSubdistrict.Text = dataGridView1.Rows[e.RowIndex].Cells["memSubdistrict"].Value.ToString();
            memberDistrict.Text = dataGridView1.Rows[e.RowIndex].Cells["memDistrict"].Value.ToString();
            memberPostalcode.Text = dataGridView1.Rows[e.RowIndex].Cells["memPostalcode"].Value.ToString();
            com_day.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells["memcomday"].Value.ToString();
            com_month.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells["memcommonth"].Value.ToString();
            memberYear.Text = dataGridView1.Rows[e.RowIndex].Cells["memYear"].Value.ToString();
            com_status.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells["memcomstatus"].Value.ToString();
        }

        private void but_print_Click(object sender, EventArgs e)
        {
            this.Hide();
            Print print = new Print();
            print.Show();
        }


      
    
      
    }
}
