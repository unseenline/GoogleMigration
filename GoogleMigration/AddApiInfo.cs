using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleMigration
{
    public partial class AddApiInfo : Form
    {
        public string ClientSecret { get; set; }
        public string ClientId { get; set; }
        public AddApiInfo(string tcId,string tcSec)
        {
            InitializeComponent();
            txt_ClientId.Text = tcId;
            txt_ClientSecret.Text = tcSec;
        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(txt_ClientSecret.Text)) || (string.IsNullOrWhiteSpace(txt_ClientId.Text)))
            {
                MessageBox.Show(@"Please Insert the Client Key and the Client Secret", @"No Data");
            }
            else
            {
                ClientId = txt_ClientId.Text;
                ClientSecret = txt_ClientSecret.Text;
                DialogResult = DialogResult.OK;
                Close();
            }

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
