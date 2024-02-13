using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;
using System.Runtime.InteropServices;


namespace TheErrorApp
{
    public partial class frmSearchErrors : Form
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
        public frmSearchErrors()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }
        BusinessLogicLayer bll = new BusinessLogicLayer();
        DataTable dt = new DataTable();
        int studentID;
        private void frmSearchErrors_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt = frmLogin.dtInfo;
            studentID = int.Parse(dt.Rows[0]["UserID"].ToString());
            int errorID;

            cmbModules.DataSource = bll.GetModuleByStudent(studentID);
            cmbModules.DisplayMember = "ModuleDescription";
            cmbModules.ValueMember = "ModuleID";

            cmbMod.DataSource = bll.GetModuleByStudent(studentID);
            cmbMod.DisplayMember = "ModuleDescription";
            cmbMod.ValueMember = "ModuleID";

            cmbTopics.DataSource = bll.GetTopics();
            cmbTopics.ValueMember = "TopicID";
            cmbTopics.DisplayMember = "TopicDescription";

            cmbProgLang.DataSource = bll.GetProgLang();
            cmbProgLang.DisplayMember = "ProgLanguageDesc";
            cmbProgLang.ValueMember = "ProgLanguageID";

            cmbErrorStatus.DataSource = bll.GetErrorStatus(studentID);
            cmbErrorStatus.DisplayMember = "ErrorStatus";
            cmbErrorStatus.ValueMember = "ErrorID";

            dgvDispErrors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void cmbModules_SelectedIndexChanged(object sender, EventArgs e)
        {
            int moduleID;
            Int32.TryParse(cmbModules.SelectedValue.ToString(), out moduleID);
            dgvDispErrors.DataSource = bll.GetErrorByModule(moduleID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           



        }

        private void dgvDispErrors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmStudentDash dash = new frmStudentDash();
            dash.Show();
            this.Hide();

            pnlNav.Height = btnBack.Height;
            pnlNav.Top = btnBack.Top;
            pnlNav.Left = btnBack.Left;
            btnBack.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmbTopics_SelectedIndexChanged(object sender, EventArgs e)
        {
            int topicID;
            Int32.TryParse(cmbTopics.SelectedValue.ToString(), out topicID);
            dgvDispErrors.DataSource = bll.GetErrorByTopic(topicID);
        }

        private void cmbProgLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            int progLangID;
            Int32.TryParse(cmbProgLang.SelectedValue.ToString(), out progLangID);
            dgvDispErrors.DataSource = bll.GetErrorByProgLanguage(progLangID);
        }

        private void cmbMod_SelectedIndexChanged(object sender, EventArgs e)
        {
            int moduleID;
            Int32.TryParse(cmbMod.SelectedValue.ToString(), out moduleID);
            dgvDispErrors.DataSource = bll.GetTopicByModule(moduleID);
        }

        private void cmbErrorStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            int errorID;
            Int32.TryParse(cmbErrorStatus.SelectedValue.ToString(),out errorID);
            dgvDispErrors.DataSource = bll.ErrorStatus(errorID);

        }
    }
}
