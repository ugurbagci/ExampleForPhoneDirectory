using PhoneApplication.DAL.ORM.Context;
using PhoneApplication.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ProjectContext db = new ProjectContext();

       public void TextEraser()
        {
            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
                if (item is MaskedTextBox)
                {
                    item.Text = "";
                }
            }
            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
                if (item is MaskedTextBox)
                {
                    item.Text = "";
                }
            }
            foreach (Control item in groupBox3.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            foreach (Control  item in groupBox4.Controls)
            {
                if(item is TextBox)
                {
                    item.Text = "";
                }
            }

        }

        public void TakeList()
        {

            dataGridView1.DataSource = db.AppUsers.Where(x => x.Status == DAL.ORM.Enum.Status.Active || x.Status == DAL.ORM.Enum.Status.Update).ToList();
            dataGridView1.Refresh();
        }

        public void AddUser()
        {
            AppUser user = new AppUser();
            user.FirstName = txtAddFirst.Text;
            user.LastName = txtAddLast.Text;
            user.PhoneNumber = mkdAddPhone.Text;
            db.AppUsers.Add(user);
            TakeList();
            db.SaveChanges();
            TextEraser();
        }

        int id;
        public void UpdateUser()
        {
            id = int.Parse(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());
            AppUser user = db.AppUsers.Where(x => x.ID == id).FirstOrDefault();
            user.FirstName = txtUpdateFirst.Text;
            user.LastName = txtUpdateLast.Text;
            user.PhoneNumber = mkdUpdatePhone.Text;
            TakeList();
            db.SaveChanges();
            TextEraser();
        }

        public void DeleteUser()
        {
             int id1 = Convert.ToInt32(txtDeleteUser.Text);
            AppUser user = db.AppUsers.Where(x => x.ID == id1).FirstOrDefault();
            user.Status = DAL.ORM.Enum.Status.Delete;
            TakeList();
            db.SaveChanges();
            TextEraser();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TakeList();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddUser();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUpdateFirst.Text = dataGridView1.CurrentRow.Cells["FirstName"].Value.ToString();

            txtUpdateLast.Text = dataGridView1.CurrentRow.Cells["LastName"].Value.ToString();
            mkdUpdatePhone.Text = dataGridView1.CurrentRow.Cells["PhoneNumber"].Value.ToString();
            txtDeleteUser.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();

        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            UpdateUser();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteUser();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            int id2 = Convert.ToInt32(txtFindUser.Text);
            dataGridView1.DataSource = db.AppUsers.Where(x=> x.ID == id2).Select(y => new
            {
                y.FirstName,
                y.LastName,
                y.ID,
                y.PhoneNumber,
                y.Status
            }).ToList(); 

            TextEraser();
        }
    }
    
}
