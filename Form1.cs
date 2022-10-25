using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("New Tab");
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            try
            {
                Uri uri = new Uri("https://" + listBox1.Items[index].ToString() + ".com");
                textBox1.Text = "";
                webBrowser1.Navigate(uri);
            }
            catch (Exception)
            {
                Uri uri = new Uri("https://google.com");
                textBox1.Text = "";
                webBrowser1.Navigate(uri);
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            string pageName = textBox1.Text;
            try
            {
                Uri uri = new Uri(pageName);
                webBrowser1.Navigate(uri);

                listBox1.Items[listBox1.SelectedIndex] = pageName;
            }
            catch (Exception)
            {
                try
                {
                    Uri uri = new Uri(pageName); 
                    webBrowser1.Navigate(uri);
                    listBox1.Items[listBox1.SelectedIndex] = pageName;
                }
                catch
                {
                    Uri uri = new Uri("https://" + pageName + ".com");
                    webBrowser1.Navigate(uri);
                    if(listBox1.SelectedIndex == -1)
                    {
                        listBox1.Items.Add(pageName);
                        
                    }
                    else
                    {
                        listBox1.Items[listBox1.SelectedIndex] = pageName;
                    }
                    
                }
                
            }
        }

        private void navigateToPageName ()
        {
            string pageName = textBox1.Text;
            Uri uri = new Uri(pageName);
            webBrowser1.Navigate(uri);
            listBox1.Items[listBox1.SelectedIndex] = pageName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser.GoBack();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser.GoForward();
        }
    }
}
