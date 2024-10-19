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
            try
            {
                IMapParse text = new TextFileParse();
                map = text.ParseMap(tbxFilePath.Text);
                tlp_ui = new MapInTableLayoutPanel(map, tlpMap);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnDFS_Click(object sender, EventArgs e)
        {
            if (map != null)
            {
                pf = new DFS(map, tlp_ui);
                pf.Search();
            }
            else
                AlertNoMapLoaded();
        }

        private void btnBFS_Click(object sender, EventArgs e)
        {
            if (map != null)
            {
                pf = new BFS(map, tlp_ui);
                pf.Search();
            }
            else
                AlertNoMapLoaded();
        }

        private void btnGBFS_Click(object sender, EventArgs e)
        {
            if (map != null)
            {
                pf = new GBFS(map, tlp_ui);
                pf.Search();
            }
            else
                AlertNoMapLoaded();
        }

        private void btnAS_Click(object sender, EventArgs e)
        {
            if (map != null)
            {
                pf = new AS(map, tlp_ui);
                pf.Search();
            }
            else
                AlertNoMapLoaded();
        }

        private void btnCUS2_Click(object sender, EventArgs e)
        {
            if (map != null)
            {
                pf = new CUS2(map, tlp_ui);
                pf.Search();
            }
            else
                AlertNoMapLoaded();
        }

        private void btnFindMap_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt",
                Title = "Open Map File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                tbxFilePath.Text = openFileDialog.FileName;
        }

        private void AlertNoMapLoaded()
        {
            MessageBox.Show("No map loaded yet!");
        }
    }
}