using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Email;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Email
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private  async void sendmail()
        {
            var em = new EmailMessage();
            em.To.Add(new EmailRecipient("ahishth@microsoft.com"));
            em.Subject = "Hi";
            em.Body = "What a nice day";
           var file = await GetTextFile();
            em.Attachments.Add(new EmailAttachment(file.Name, file));
           await EmailManager.ShowComposeNewEmailAsync(em);
            }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            sendmail();
        }
        // Creates a text file and returns it
        private static async Task<StorageFile> GetTextFile()
        {
            var localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            var file = await localFolder.CreateFileAsync("ashish.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);
            await Windows.Storage.FileIO.WriteTextAsync(file, "This is a test File");
            return file;
        }
    }
}
