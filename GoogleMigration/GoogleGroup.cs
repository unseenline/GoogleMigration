using System;
using System.IO;
using System.Text;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.GroupsMigration.v1;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;

namespace GoogleMigration
{
    public class GoogleGroup
    {
        public string MsgBody { get; set; }
        public string GroupAddress { get; set; }
        public string SetClientId { get; set; }
        public string SetClientSecret { get; set; }

        private UserCredential SetAuth()
        {
            var scopes = new string[] {"https://www.googleapis.com/auth/apps.groups.migration"};
            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets {ClientId = SetClientId, ClientSecret = SetClientSecret}
                ,scopes
                ,Environment.UserName
                ,CancellationToken.None
                ,new FileDataStore("Google.Migration")
                ).Result;
            return credential;
        }

        public void ProcessMail()
        {
            var bytes = ASCIIEncoding.ASCII.GetBytes(MsgBody);
            var messageStream = new MemoryStream(bytes);
            var service = new GroupsMigrationService(new BaseClientService.Initializer
            {
                HttpClientInitializer = SetAuth(),
                ApplicationName = "Google Groups Migration"
            });

            var request = service.Archive.Insert(GroupAddress, messageStream, "message/rfc822");

            IUploadProgress uploadStatus = request.Upload();

            if (uploadStatus.Exception != null)
            {
                Console.WriteLine(uploadStatus.Exception.ToString());
            }
        }
    }
}
