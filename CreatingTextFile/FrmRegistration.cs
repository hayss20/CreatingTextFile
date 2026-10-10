using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CreatingTextFile
{
    public partial class FrmRegistration : Form
    {
        FrmFileName File;
        public FrmRegistration()
        {
            InitializeComponent();
            File = new FrmFileName();
            File.ShowDialog();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            String getstuno = string.Empty;
            String getfname = string.Empty;
            String getlname = string.Empty;
            String getmi = string.Empty;
            int getage = 0;
            String birthday = string.Empty;
            String contactno = string.Empty;
            String program = string.Empty;
            String gender = string.Empty;

            try
            {
                getstuno = txtStuNo.Text;
                getfname = txtFirstName.Text;
                getlname = txtLastName.Text;
                getmi = txtMiddleName.Text;
                getage = int.Parse(txtAge.Text);    
                birthday = dtpBirthday.Text;
                contactno = txtContactNo.Text;
                program = cbProgram.Text;
                gender = cbGender.Text;

                if (!Regex.IsMatch(contactno, @"^09\d{9}$"))
                {
                    MessageBox.Show("Invalid Contact number!");
                    return;
                }
                if (!Regex.IsMatch(getstuno, @"^02000\d{6}$"))
                {
                    MessageBox.Show("Invalid student number!");
                    return;
                }
                if (String.IsNullOrWhiteSpace(txtFirstName.Text) || String.IsNullOrWhiteSpace(txtLastName.Text) || String.IsNullOrWhiteSpace(txtMiddleName.Text) || String.IsNullOrWhiteSpace(txtAge.Text) || String.IsNullOrWhiteSpace(txtContactNo.Text) || String.IsNullOrWhiteSpace(cbProgram.Text) || String.IsNullOrWhiteSpace(txtStuNo.Text))
                {
                    MessageBox.Show("Please fill in all fields");
                    return;
                }
                if (txtMiddleName.Text.Length > 2)
                {
                    MessageBox.Show("Invalid MI count");
                    return;
                }
                if (!Regex.IsMatch(getfname, @"^[a-zA-Z]+$") || !Regex.IsMatch(getlname, @"^[a-zA-Z]+$") || !Regex.IsMatch(getmi, @"^[a-zA-Z]+$"))
                {
                    MessageBox.Show("Invalid. Names can only be letters");
                    return;
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, FrmFileName.SetFileName)))
            {
                outputFile.WriteLine("Student no: " + getstuno);
                outputFile.WriteLine("Full name: " + getfname + " " + getmi + " " + getlname);
                outputFile.WriteLine("Program: " + program);
                outputFile.WriteLine("Gender: " + gender);
                outputFile.WriteLine("Age: " + getage);
                outputFile.WriteLine("Birthday: " + birthday);
                outputFile.WriteLine("Contact no: " + contactno);
            }
            MessageBox.Show("Registration successful! File saved in My Documents folder.");
        }
    }
}
