﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.Configuration;
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
                var listEnumerator = _mailList.GetEnumerator();
                //gg.MsgBody = "Date: 17 Feb 2015 17:00\r\nFrom: derper@q5systems.com\r\nTo: temp_test@q5systems.com\r\nSubject: Test Subject5\r\nMessage-Id: <1fdfdvslkjhgffdfesxsafgdb345>\r\n\r\n\r\nSo many more tests!!!.";
                //gg.MsgBody = "Date: 17 Mar 2015 17:00 \r\nFrom: noreply@q5iata.com\r\nTo: temp_test@q5systems.com\r\nSubject: Automated Login Check passed\r\nMessage-Id: <000000001D65EBB777C7DF46B36D844CF90715EF24002000> \r\n\r\n______________________________________________________________________\r\nThis email has been scanned by the Boundary Defense for Email Security System. For more information please visit http://www.apptix.com/email-security/antispam-virus\r\n______________________________________________________________________";
                /*string msg = @"Date: 16 Jul 07 10:12
From: samplesender@example.com
To: temp_test@q5systems.com
Subject: Test Subject
Message-Id: <1fdsfb345@acme.com>


This is the body of the migrated email message. ";
                gg.ProcessMail(); */
                for (var i = 0; listEnumerator.MoveNext(); i++)
                {
                    string msg = listEnumerator.Current; // Get current item.
                    gg.MsgBody = msg;
                    Console.WriteLine(@"Currently at index {0}", i);
                    gg.ProcessMail(); 
                    //Console.WriteLine("At index {0}, item is {1}", i, currentItem); // Do as you wish with i and  currentItem
                }
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
            AddApiInfo aai = new AddApiInfo(_cId, _cSec);
            aai.ShowDialog();
            if (aai.DialogResult == DialogResult.OK)
            {
                _cId = aai.ClientId;
                _cSec = aai.ClientSecret;
                cfg.ClientId = _cId;
                cfg.ClientSecret = _cSec;
                cfg.Save();
            }
        }

        private void btn_Save_Config_Click(object sender, EventArgs e)
        {
            cfg.ClientId = _cId;
            cfg.ClientSecret = _cSec;
            cfg.PstPath = txt_pstPath.Text;
            cfg.GroupAddress = txt_GroupAddress.Text;
            cfg.Save();
        }
    }
}
