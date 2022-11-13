using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
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
            richTextBox1.Text = File.ReadAllText("history.txt");
            listBox2.Items.AddRange(File.ReadAllLines("savePages.txt")) ;
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

            if (listBox1.Items[index].ToString().Contains("https://") || listBox1.Items[index].ToString().Contains("http://"))
            {
                try
                {
                    Uri uri = new Uri(listBox1.Items[index].ToString());
                    webBrowser.Navigate(uri);
                }
                catch (Exception)
                {
                    Uri uri = new Uri("https://google.com");
                    webBrowser.Navigate(uri);

                }
            }
            else
            {
                try
                {
                    Uri uri = new Uri("https://google.com/search?q=" + listBox1.Items[index].ToString());
                    webBrowser.Navigate(uri);
                }
                catch
                {
                    Uri uri = new Uri("https://google.com/search?q=" + listBox1.Items[index].ToString());
                    webBrowser.Navigate(uri);
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Contains("https://") || textBox1.Text.Contains("http://"))
            {
                int index = listBox1.SelectedIndex;
                string pageName = textBox1.Text;
                try
                {
                    Uri uri = new Uri(pageName);
                    webBrowser.Navigate(uri);
                    listBox1.Items[index] = pageName;
                }
                catch (Exception)
                {
                    Uri uri = new Uri("https://google.com");
                    webBrowser.Navigate(uri);
                    MessageBox.Show("pain");
                }
                File.AppendAllText("history.txt", textBox1.Text + "\n");
                richTextBox1.Text = File.ReadAllText("history.txt");
            }
            else
            {
                try
                {
                    int index = listBox1.SelectedIndex;
                    string pageName = textBox1.Text;

                    Uri uri = new Uri("https://google.com/search?q=" + textBox1.Text);
                    listBox1.Items[listBox1.SelectedIndex] = pageName;
                    webBrowser.Navigate(uri);
                } 
                catch
                {
                    Uri uri = new Uri("https://google.com/search?q=" + textBox1.Text);
                    listBox1.Items.Add(textBox1.Text);
                    webBrowser.Navigate(uri);
                }
                File.AppendAllText("history.txt", textBox1.Text + "\n");
                richTextBox1.Text = File.ReadAllText("history.txt");
            }
            textBox1.Text = "";
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

        private void addToFavoritesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.AppendAllText("savePages.txt", listBox1.Items[listBox1.SelectedIndex].ToString() + "\n");
            listBox2.Items.Add(listBox1.Items[listBox1.SelectedIndex].ToString());
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listBox2.Items.RemoveAt(listBox2.SelectedIndex);
        }

        private void webBrowser_DocumentCompleted_1(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
      
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
