using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleMigration
{
    public partial class Main : Form
    {
        private string _cId;
        private string _cSec;
        private Config cfg =  new Config();
        private List<string> _mailList = new List<string>(); 
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            txt_pstPath.Text = cfg.PstPath;
            txt_GroupAddress.Text = cfg.GroupAddress;
            _cId = cfg.ClientId;
            _cSec = cfg.ClientSecret;
        }

        private void btn_GroupUpload_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(_cId)) || (string.IsNullOrWhiteSpace(_cSec)))
            {
                MessageBox.Show(@"The Client Id or the Client Secret is missing, Please add it then try again!",@"Missing API INFO!");
                ProcessApi();
            }
            else
            {
                GoogleGroup gg = new GoogleGroup
                {
                    GroupAddress = txt_GroupAddress.Text,
                    SetClientId = _cId,
                    SetClientSecret = _cSec
                };
                cfg.GroupAddress = txt_GroupAddress.Text;
                cfg.Save();
                gg.ProcessMail();
            }
        }

        private void readPst_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_GroupAddress.Text))
            {
                MessageBox.Show(@"Please set the Group Address", @"Missing Address!");
            }
            else
            {
                if (!File.Exists(txt_pstPath.Text)) return;
                PstReader pst = new PstReader {PstPath = txt_pstPath.Text, groupAddy = txt_GroupAddress.Text};
                _mailList = pst.LoadPst();
                var temp = 1;
            }
        }

        private void browse_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog findPstDialog = new OpenFileDialog
            {
                Title = @"Load PST File",
                InitialDirectory = Environment.GetEnvironmentVariable("USERPROFILE"),
                Filter = @"PST File (*.pst)|*.pst",
                FilterIndex = 1,
                RestoreDirectory = true
            };
            if (findPstDialog.ShowDialog() == DialogResult.OK)
            {
                txt_pstPath.Text = findPstDialog.FileName;
                cfg.PstPath = findPstDialog.FileName;
                cfg.Save();
            }
        }

        private void btn_SetClientId_Click(object sender, EventArgs e)
        {
            ProcessApi();
        }

        private void ProcessApi()
        {
            AddApiInfo aai = new AddApiInfo();
            aai.ShowDialog();
            _cId = aai.ClientId;
            _cSec = aai.ClientSecret;
            cfg.ClientId = _cId;
            cfg.ClientSecret = _cId;
            cfg.Save();
        }

        private void btn_Save_Config_Click(object sender, EventArgs e)
        {
            cfg.ClientId = _cId;
            cfg.ClientSecret = _cId;
            cfg.PstPath = txt_pstPath.Text;
            cfg.GroupAddress = txt_GroupAddress.Text;
            cfg.Save();
        }
    }
}
