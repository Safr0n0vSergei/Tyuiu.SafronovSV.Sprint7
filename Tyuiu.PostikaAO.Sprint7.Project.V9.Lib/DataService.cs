using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Tyuiu.SafronovSV.Sprint7.Project.V9.Lib
{
    public class DataService
    {
        string pathImg = $@"{Directory.GetCurrentDirectory()}\img\";
        string pathData = $@"{Directory.GetCurrentDirectory()}\FilmsData.csv";
        public void AddFilm(string[] values)
        {
            bool isFirst = false;
            if (!File.Exists(pathData))
            {
                Directory.CreateDirectory(pathImg);
                isFirst = true;
            }
            string[] temp = values[0].Split('\\');
            string fileName = temp[temp.Length - 1];

            temp = fileName.Split('.');

            string fileFormat = '.' + temp[temp.Length - 1];
            fileName = temp[0];

            string copyTo = pathImg + fileName + fileFormat;
            string copyFrom = values[0];

            int additionNum = 0;
            string endFileName = fileName + fileFormat;
            while (File.Exists(copyTo))
            {
                additionNum++;
                endFileName = fileName + additionNum + fileFormat;
                copyTo = pathImg + endFileName;
            }
            File.Copy(copyFrom, copyTo);
            values[0] = endFileName;


            string finalLine = string.Join(";", values);

            if (isFirst)
            {
                File.AppendAllText(pathData, finalLine, Encoding.Unicode);
            }
            else
            {
                File.AppendAllText(pathData, Environment.NewLine + finalLine, Encoding.Unicode);
            }
        }

        public int GetFilmCount()
        {
            int result = 0;
            if (File.Exists(pathData))
            {
                using (StreamReader rd = new StreamReader(pathData))
                {
                    while (rd.ReadLine() != null)
                    {
                        result++;
                    }
                }
                return result;
            }
            return result;
        }

        public string[] GetNecessaryFilmInfo(int lineNum)
        {
            string line = File.ReadLines(pathData).Skip(lineNum).First();
            string[] result = line.Split(';');

            return result;
        }

        public string[] GetNecessaryTypeInfo(int typeNum)
        {
            string[] lines = File.ReadAllLines(pathData);
            string[] result = new string[lines.Length];

            for (int i = 0; i < result.Length; i++)
            {
                string filmName = lines[i].Split(';')[typeNum];
                result[i] = filmName;
            }

            return result;
        }

        public void DeleteFilm(int deletedLine)
        {
            string fileContent = File.ReadAllText(pathData);
            fileContent = fileContent.Replace('\n', '\r');
            string[] lines = fileContent.Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);


            string[] resultLines = new string[lines.Length - 1];
            for (int i = 0; i < lines.Length; i++)
            {
                if (i == deletedLine) continue;
                if (i < deletedLine)
                {
                    resultLines[i] = lines[i];
                }
                else
                {
                    resultLines[i - 1] = lines[i];
                }
            }


            File.Delete(pathData);
            if (resultLines.Length == 0) return;
            File.AppendAllText(pathData, string.Join(Environment.NewLine, resultLines),Encoding.Unicode);
        }


        public int[] GetGenreStatistics()
        {
            int[] result = new int[7];
            int filmCount = GetFilmCount();

            for (int i = 0; i < filmCount; i++)
            {
                int genreType = int.Parse(GetNecessaryFilmInfo(i)[3]);

                result[genreType] += 1;
            }

            return result;
        }


        public void ClearUnusedImages()
        {
            if (Directory.Exists(pathImg))
            {
                string[] directory = Directory.GetFiles(pathImg);
                foreach (string item in directory)
                {
                    try
                    {
                        File.Delete(item);
                    }
                    catch
                    {
                        // игнорируем используемые в данный момент файлы
                    }
                }
            }
        }
    }
}
