using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Outlook;
namespace GoogleMigration
{
    public class PstReader
    {
        public string PstPath { get; set; }
        public void LoadPst()
        {
            try
            {
                string pstPath = PstPath;
                IEnumerable<MailItem> mailItems = ReadPst(pstPath);
                foreach (MailItem mailItem in mailItems)
                {
                    Console.WriteLine(mailItem.SenderName + " - " + mailItem.Subject);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
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
    }
}