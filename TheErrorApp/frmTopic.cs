using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BLL;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace TheErrorApp
{
    
    public partial class frmTopic : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );
        public frmTopic()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }
        static string connString = "Data Source= localHost;Initial Catalog= ErrorAppDB;Integrated Security=True;";
        SqlConnection dbConn = new SqlConnection(connString);
        
        BusinessLogicLayer bll = new BusinessLogicLayer();
        DataAccessLayer dll = new DataAccessLayer();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Topics topics = new Topics();
            if (string.IsNullOrEmpty(txtTopic.Text))
            {
                errorProvider1.SetError(txtTopic, "Cannot add empty fields");
            }
            else {
                topics.TopicDescription = txtTopic.Text;
                

                int x = bll.InsertTopic(topics);

                if (x > 0)
                {
                    MessageBox.Show(" Added");
                }
                else
                {
                    MessageBox.Show(" Added");
                }
                Refresh();

                pnlNav.Height = btnAdd.Height;
                pnlNav.Top = btnAdd.Top;
                pnlNav.Left = btnAdd.Left;
                btnAdd.BackColor = Color.FromArgb(46, 51, 73);
            }
            
        }

        private void frmTopic_Load(object sender, EventArgs e)
        {

            dgvTopics.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


        }
        public void Refresh()
        {
            dgvTopics.DataSource = bll.GetTopics();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Topics topics = new Topics();

            if (string.IsNullOrEmpty(txtTopic.Text))
            {
                errorProvider1.SetError(txtTopic, "Cannot update empty field");
            }
            else {
                topics.TopicDescription = txtTopic.Text;

                topics.TopicID = int.Parse(dgvTopics.SelectedRows[0].Cells["TopicID"].Value.ToString());

                int x = bll.UpdateTopics(topics);

                if (x > 0)
                {
                    MessageBox.Show(" Topic Updated");
                }
                else
                {
                    MessageBox.Show(" Topic Updated");
                }
                Refresh();

                pnlNav.Height = btnUpdate.Height;
                pnlNav.Top = btnUpdate.Top;
                pnlNav.Left = btnUpdate.Left;
                btnUpdate.BackColor = Color.FromArgb(46, 51, 73);
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Topics topics = new Topics();
            topics.TopicID = int.Parse(dgvTopics.SelectedRows[0].Cells["TopicID"].Value.ToString());

            int x = bll.DeleteTopic(topics);

            if (x > 0)
            {
                MessageBox.Show(" Deleted");
            }
            else
            {
                MessageBox.Show(" Deleted");
            }

            pnlNav.Height = btnDelete.Height;
            pnlNav.Top = btnDelete.Top;
            pnlNav.Left = btnDelete.Left;
            btnDelete.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            dgvTopics.DataSource = bll.GetTopics();

            pnlNav.Height = btnView.Height;
            pnlNav.Top = btnView.Top;
            pnlNav.Left = btnView.Left;
            btnView.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmLecturerDash lecture = new frmLecturerDash();
            lecture.Show();
            this.Hide();

            pnlNav.Height = btnBack.Height;
            pnlNav.Top = btnBack.Top;
            pnlNav.Left = btnBack.Left;
            btnBack.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dgvTopics_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvTopics_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dgvTopics.Rows[e.RowIndex];

                txtTopic.Text = row.Cells[1].Value.ToString();
               
               

            }
            else
            {
                MessageBox.Show("Please click View");


            }
        }
    }
}
