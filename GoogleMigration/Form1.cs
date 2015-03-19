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
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.GroupsMigration.v1;
using Google.Apis.Upload;
using Google.Apis.Util.Store;

namespace GoogleMigration
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private UserCredential GetAuth(){
        var scopes = new string[] {"https://www.googleapis.com/auth/apps.groups.migration"};
            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets { ClientId = "Add Client ID Here"
                    , ClientSecret = "Add Client Secret Here" }
                ,scopes
                ,Environment.UserName
                ,CancellationToken.None
                ,new FileDataStore("Google.Migration")
                ).Result;
            return credential;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var body =
@"Date: 16 Jul 07 10:12 GMT
From: samplesender@example.com
To: test@test.com
Subject: Test Subject
Message-Id: <1fdsfb345@acme.com>


This is the body of the migrated email message. 


";

            var bytes = ASCIIEncoding.ASCII.GetBytes(body);
            var messageStream = new MemoryStream(bytes);
            var service = new GroupsMigrationService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = GetAuth(),
                ApplicationName = "group migration application"
            });

            var request = service.Archive.Insert("group@yourdomain.com", messageStream, "message/rfc822");

            IUploadProgress uploadStatus = request.Upload();

            if (uploadStatus.Exception != null)
            {
                Console.WriteLine(uploadStatus.Exception.ToString());
            }
        }

        private void readPst_btn_Click(object sender, EventArgs e)
        {
            PstReader pst = new PstReader {PstPath = @"C:\temp\Testing.pst"};
            pst.LoadPst();
        }




    }
}
