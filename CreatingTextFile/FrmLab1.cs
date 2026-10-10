namespace CreatingTextFile
{
    public partial class FrmLab1 : Form
    {
        FrmFileName File;
        public FrmLab1()
        {
            InitializeComponent();
            File = new FrmFileName();
            File.ShowDialog();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            File.ShowDialog();
            String getInput = txtInput.Text;

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, FrmFileName.SetFileName)))
            {
                outputFile.WriteLine(getInput);
                Console.WriteLine(getInput);
            }
            Close();
        }
    }
}
