using Core;
using Core.Settings;
using Infrastructure;
using Infrastructure.Log;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace Vk2._0
{
    public partial class Form1 : Form
    {
        ParserWorker _parserWorker;
        public static int[] Groups { get; set; }
        public static List<Dictionary<string, string>> Proxies = new List<Dictionary<string, string>>();

        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// загрузка списка групп для парсинга
        /// </summary>
        private void Upload_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string fileName = openFileDialog1.FileName;
            string[] stringGroups = File.ReadAllLines(fileName);
            Groups = new int[stringGroups.Length];
            int i = 0;
            foreach (string line in stringGroups)
            {
                try
                {
                    Groups[i++] = int.Parse(line.Substring(4));
                }
                catch
                {
                    MessageBox.Show("Incorrect groups data");
                    break;
                }
            }
        }
        /// <summary>
        /// Загрузка списка прокси http.
        /// </summary>
        private void Proxy_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string fileName = openFileDialog1.FileName;
            string[] stringProxies = File.ReadAllLines(fileName, Encoding.Default);
            
            foreach (var s in stringProxies)
            {
                try
                {
                    string[] proxy = s.Split(new[] { ':' });
                    Proxies.Add(new Dictionary<string, string>() { { $"host", $"{proxy[0]}" }, { $"port", $"{proxy[1]}" } });
                }
                catch
                {
                    MessageBox.Show("All works done!");
                }
            }
        }

        private void Parser_OnCompleted(object obj)
        {
            LoadData();
            MessageBox.Show("All works done!");
        }

        private async void Start_Click(object sender, EventArgs e)
        {
            if (Proxies == null)
            {
                MessageBox.Show("Load proxy");
                return;
            }
            else if (Groups == null)
            {
                MessageBox.Show("Load groups");
                return;
            }
            else
            {
                //это отдельный поток, чтобы форма не зависала
                await Task.Run(() =>
                {
                    _parserWorker = new ParserWorker(new UrlSettings(Groups, Proxies));
                    _parserWorker.OnCompleted += Parser_OnCompleted;
                    _parserWorker.Start();
                });
            }
            Logger.Flush();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            _parserWorker.Stop();
        }

        /// <summary>
        /// Вывод данных в форму
        /// </summary>
        private void LoadData()
        {
            var pa = _parserWorker.data;
            try
            {
                if (pa.Count > 0)
                {
                    dataGridView1.Rows.Add(pa.Count);

                    Parallel.For(0, pa.Count, i =>
                    {
                        dataGridView1.Rows[i].Cells[0].Value = pa[i].Date;
                        dataGridView1.Rows[i].Cells[1].Value = pa[i].Text;
                        dataGridView1.Rows[i].Cells[2].Value = pa[i].Likes;
                        dataGridView1.Rows[i].Cells[3].Value = pa[i].Link;

                    });
                }
                else
                {
                    dataGridView1.Rows[0].Cells[0].Value = "NOTHING";
                    dataGridView1.Rows[0].Cells[1].Value = "NOTHING";
                    dataGridView1.Rows[0].Cells[2].Value = "NOTHING";
                    dataGridView1.Rows[0].Cells[3].Value = "NOTHING";
                }
            }
            catch(Exception ex) 
            {
                Logger.WriteLog(ex.HResult, ex.Message);
            }

            
        }
    }
}