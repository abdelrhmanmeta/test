using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MaterialSkin.Controls;
using MaterialSkin.Animations;
using MaterialSkin;
using System.Linq;
namespace ExeToBin
{
    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void materialCheckBox1_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (materialCheckBox1.Checked)
                {
                    //convert to base64
                    byte[] buffer = File.ReadAllBytes(textBox1.Text);
                    string base64Encoded = Convert.ToBase64String(buffer);
                    richTextBox1.Text = base64Encoded;
                    materialLabel1.Text = "BASE64";
                }
                else
                {
                    //convert to bytes
                    byte[] buffer = File.ReadAllBytes(textBox1.Text);
                    richTextBox1.Text = BitConverter.ToString(buffer);
                    materialLabel1.Text = "BINARY";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Select A File First!", "Conversion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Select an Exe",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "exe",
             //   Filter = "exe files (*.exe)|*.exe",
             //   FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                byte[] buffer = File.ReadAllBytes(textBox1.Text);
                string base64Encoded = Convert.ToBase64String(buffer);
                richTextBox1.Text = base64Encoded;
                materialLabel1.Text = "BASE64";
                MessageBox.Show("Your File Has Been Loaded!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string Temp = "";
                System.Text.StringBuilder txtBuilder = new System.Text.StringBuilder();
                foreach (byte Character in System.Text.ASCIIEncoding.ASCII.GetBytes(richTextBox1.Text))
                {
                    txtBuilder.Append(Convert.ToString(Character, 2).PadLeft(8, '0'));
                    txtBuilder.Append(" ");
                }
                Temp = txtBuilder.ToString().Substring(0, txtBuilder.ToString().Length - 0);
                richTextBox2.Text = Temp;
            }
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.Text);
            MessageBox.Show("Base64 Data Copied!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void materialLabel3_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox2.Text);
            MessageBox.Show("Binary Data Copied!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void materialRaisedButton4_Click(object sender, EventArgs e)
        {
            public static Image BinaryToImage(System.Data.Linq.Binary binaryData)
{
    if (binaryData == null) return null;

    byte[] buffer = binaryData.ToArray();
    MemoryStream memStream = new MemoryStream();
    memStream.Write(buffer, 0, buffer.Length);
    return Image.FromStream(memStream);
}
        }
            
        }
    

