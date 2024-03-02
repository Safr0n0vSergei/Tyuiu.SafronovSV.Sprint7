using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tyuiu.SafronovSV.Sprint7.Project.V9.Lib;


namespace Tyuiu.SafronovSV.Sprint7.Project.V9
{
    public partial class FormStatistics : Form
    {
        DataService ds = new DataService();
        public FormStatistics()
        {
            InitializeComponent();
            ShowStatistics();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void ShowStatistics()
        {
            chartGenreStatistics_PAO.Series[0].Points.Clear();
            
            chartGenreStatistics_PAO.ChartAreas[0].AxisX.Title = "Жанры";
            chartGenreStatistics_PAO.ChartAreas[0].AxisY.Title = "Количество фильмов";

            string[] genres = { "Боевик", "Детектив", "Драма", "Исторический фильм", "Комедия", "Музыкальный фильм", "Трейлер" };
            int[] genreStats = ds.GetGenreStatistics();

            for (int i = 0; i < genres.Length; i++)
            {
                chartGenreStatistics_PAO.Series[0].Points.AddXY(genres[i], genreStats[i]);
            }

        }
    }
}
