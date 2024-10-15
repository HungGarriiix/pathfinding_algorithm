using TreeBasedSearch.Codes;

namespace TreeBasedSearch
{
    public partial class Form1 : Form
    {
        Map map;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerateMap_Click(object sender, EventArgs e)
        {
            IMapParse text = new TextFileParse();
            map = text.ParseMap(tbxFilePath.Text);
            


        }
    }
}