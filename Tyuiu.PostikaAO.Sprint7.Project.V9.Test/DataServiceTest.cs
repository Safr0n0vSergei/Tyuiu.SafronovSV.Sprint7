using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;


using Tyuiu.SafronovSV.Sprint7.Project.V9.Lib;
namespace Tyuiu.SafronovSV.Sprint7.Project.V9.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidFilmsData()
        {
            string path = $@"C:\Users\sralr\source\repos\Tyuiu.SafronovSV.Sprint7\Tyuiu.SafronovSV.Sprint7.Project.V9\bin\Debug\FilmsData.csv";

            FileInfo fileInfo = new FileInfo(path);
            bool fileExists = fileInfo.Exists;
            bool wait = true;
            Assert.AreEqual(wait, fileExists);
        }


        [TestMethod]
        public void ValidGenreCount()
        {
            DataService ds = new DataService();

            int[] wait = { 2, 1, 1, 2, 2, 0, 3 };
            int[] result = ds.GetGenreStatistics();
            CollectionAssert.Equals(wait, result);
        }
    }

}
