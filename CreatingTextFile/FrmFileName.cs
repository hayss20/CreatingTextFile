using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CreatingTextFile
{
    public partial class FrmFileName : Form
    {
        public static string SetFileName { get; private set; }
        public FrmFileName()
        {
            InitializeComponent();
        }
        private void btnOkay_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFileName.Text))
            {
                MessageBox.Show("Please enter a file name.");
                return;
            }
            SetFileName = txtFileName.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
            Close();
        }
    }
}
