using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VietNamNet.AddOn.Tracker.Process
{
    public partial class frmMainForm : Form
    {
       

        public frmMainForm()
        {
            InitializeComponent();
        }

       
        private void cmdSurvey_Click(object sender, EventArgs e)
        {
            frmSurveyProcess s = new frmSurveyProcess();
            s.Show();
        }

        private void cmdComment_Click(object sender, EventArgs e)
        {
            frmCommentProcess s = new frmCommentProcess();
            s.Show();
        }

        private void frmMainForm_Load(object sender, EventArgs e)
        {

        }

     
    }
}