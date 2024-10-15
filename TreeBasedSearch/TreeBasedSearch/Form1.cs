using TreeBasedSearch.Codes;

namespace TreeBasedSearch
{
    public partial class Form1 : Form
    {
        Map map;
        MapInTableLayoutPanel tlp_ui;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerateMap_Click(object sender, EventArgs e)
        {
            IMapParse text = new TextFileParse();
            map = text.ParseMap(tbxFilePath.Text);
            tlp_ui = new MapInTableLayoutPanel(map, tlpMap);

        }
    }
}