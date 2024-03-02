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
    public partial class FormAddFilm : Form
    {
        public FormAddFilm()
        {
            InitializeComponent();
        }
        DataService ds = new DataService();
        private void buttonAdd_PAO_Click(object sender, EventArgs e)
        {
            string[] values = new string[10];

            if(pathImage != "" && comboBoxGenre_PAO.SelectedIndex>-1 && !string.IsNullOrEmpty(textBoxName_PAO.Text)&& !string.IsNullOrEmpty(textBoxName_PAO.Text) && !string.IsNullOrEmpty(textBoxScreenwriter_PAO.Text)&& !string.IsNullOrEmpty(textBoxDirector_PAO.Text) && !string.IsNullOrEmpty(textBoxRole_PAO.Text) && !string.IsNullOrEmpty(textBoxRating_PAO.Text) && !string.IsNullOrEmpty(textBoxYear_PAO.Text) && !string.IsNullOrEmpty(textBoxDescription_PAO.Text))
            {
                values[0] = pathImage;
                values[1] = textBoxName_PAO.Text;
                values[2] = textBoxYear_PAO.Text;
                values[3] = comboBoxGenre_PAO.SelectedIndex.ToString();
                values[4] = textBoxDirector_PAO.Text;
                values[5] = textBoxScreenwriter_PAO.Text;
                values[6] = textBoxCountry_PAO.Text;
                values[7] = textBoxRating_PAO.Text;
                values[8] = textBoxRole_PAO.Text;
                values[9] = textBoxDescription_PAO.Text;

                ds.AddFilm(values);

                this.Close();
            }
            else
            {
                MessageBox.Show("Заполните все поля!!!","Ошибка");
            }
        }
        string pathImage = "";
        private void pictureBox1_Click(object sender, EventArgs e)
        {
           if (openFileDialogImage_PAO.ShowDialog() == DialogResult.OK)
            {
                pathImage = openFileDialogImage_PAO.FileName;
                pictureBoxPreview_PAO.Image = Image.FromFile(pathImage);
            }
           
        }

        private void comboBoxGenre_PAO_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
