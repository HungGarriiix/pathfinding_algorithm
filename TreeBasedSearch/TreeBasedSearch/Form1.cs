using TreeBasedSearch.Codes;

namespace TreeBasedSearch
{
    public partial class Form1 : Form
    {
        Map map;
        MapInTableLayoutPanel tlp_ui;
        PathFinder pf;

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

        private void btnDFS_Click(object sender, EventArgs e)
        {
            if (map != null)
            {
                pf = new DFS(map, tlp_ui);
                pf.Search();
            }
        }

        private void btnBFS_Click(object sender, EventArgs e)
        {
            if (map != null)
            {
                pf = new BFS(map, tlp_ui);
                pf.Search();
            }
        }

        private void btnGBFS_Click(object sender, EventArgs e)
        {
            if (map != null)
            {
                pf = new GBFS(map, tlp_ui);
                pf.Search();
            }
        }
    }
}