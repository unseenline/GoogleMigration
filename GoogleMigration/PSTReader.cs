using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Outlook;
using System.Net.Mail;
using MIMER.RFC822;
namespace GoogleMigration
{
    public class PstReader
    {
        public string PstPath { get; set; }
        public int MailItems { get; set; }
        public string groupAddy { get; set; }
        const int RtTo = (int)OlMailRecipientType.olTo;
        const int RtFrom = (int)OlMailRecipientType.olOriginator;
        const int RtCc = (int)OlMailRecipientType.olCC;
        public List<string> LoadPst()
        {
            List<string> rawMail = new List<string>();
            string pstPath = PstPath;
            try
            {
                IEnumerable<MailItem> mailItems = ReadPst(pstPath);
                foreach (MailItem mailItem in mailItems)
                {
                    rawMail.Add(CreateMail(mailItem));
                    //Console.Write(mailItem);
                    Console.WriteLine(mailItem.SenderName + @" - " + mailItem.Subject);
                }
                
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
            MailItems =rawMail.Count;
            return rawMail;
        }

        private static IEnumerable<MailItem> ReadPst(string pstFilePath)
        {
            string pstName="";
            List<MailItem> mailItems = new List<MailItem>();
            Application app = new Application();
            NameSpace outlookNs = app.GetNamespace("MAPI");
            // Add PST file (Outlook Data File) to Default Profile
            outlookNs.AddStore(pstFilePath);
            Stores stores = app.Session.Stores;
            foreach (Store store in stores)
            {
                if (store.FilePath != pstFilePath) continue;
                Folder folder = store.GetRootFolder() as Folder;
                if (folder != null) pstName = folder.Name;
            }

            //var contacts = outlookNs.AddressLists;//GetDefaultFolder(OlDefaultFolders.);
            //Console.WriteLine(contacts.ToString());
            MAPIFolder rootFolder = outlookNs.Stores[pstName].GetRootFolder();
            // Traverse through all folders in the PST file
            // TODO: This is not recursive, refactor
            Folders subFolders = rootFolder.Folders;
            foreach (Folder folder in subFolders)
            {
                Items items = folder.Items;
                foreach (object item in items)
                {
                    if (item is MailItem)
                    {
                        MailItem mailItem = item as MailItem;
                        mailItems.Add(mailItem);
                    }
                }
            }
            // Remove PST file from Default Profile
            outlookNs.RemoveStore(rootFolder);
            return mailItems;
        }

        private string CreateMail(MailItem mi)
        {

            string mDate = string.Format("{0} {1} {2} {3}:{4}", mi.SentOn.Date.Day.ToString("D2"), mi.SentOn.Date.ToString("MMM"), mi.SentOn.Date.Year, mi.SentOn.TimeOfDay.Hours.ToString("D2"), mi.SentOn.TimeOfDay.Minutes.ToString("D2"));
            string mSubject = mi.Subject;
            string mBody = mi.Body;
            string mId = mi.EntryID;
            string mFrom = mi.Sender.Address;

            string message = string.Format("Date: {0} \r\nFrom: {1} \r\nTo: {2} \r\nSubject: {3} \r\nMessage-Id: <{4}> \r\n{5}", mDate, mFrom, groupAddy, mSubject, mId, mBody);
            return message;
            //string toAdd = "", fromAdd = "", ccAdd = "";

            //MailAddress fromAddress = new MailAddress(mi.SenderEmailAddress, mi.SenderName);
            //MailMessage message = new MailMessage(groupAddy, mi.SenderEmailAddress);//toAdd, mi.Sender.Address,mi.Subject,mi.Body);
            // message.Sender = fromAddress;
            //message.Subject = mi.Subject;
            //message.Body = mi.Body;

            //message.To.Add();
            /*foreach (Recipient rec in mi.Recipients)
            {
                switch (rec.Type)
                {
                    case RtTo:
                    {
                        var temp = rec.Address;
                        //message.To.Add(rec.Address);
                    }break;
                    case RtCc:
                    {
                        var temp = rec.Address;
                        //message.CC.Add(rec.Address);
                    }break;
                }
            }*/
            //return message.ToString();
        }

    }
}