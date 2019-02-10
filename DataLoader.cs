using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IrisKNNClassifier
{
    class DataLoader
    {
        private string path;
        public DataLoader(string path)
        {
            this.path = path;
        }

        public Dataset LoadData()
        {
            if(File.Exists(this.path))
            {
                string[] data = File.ReadAllLines(this.path);
                int NumberOfParams = data[0].Split(';').Length;

                double[,] X_data = new double[data.Length-1, NumberOfParams - 1];
                string[] Y_data = new string[data.Length-1];

                for (int i = 1; i < data.Length; i++)
                {
                    string[] line = data[i].Split(';');
                    for(int j = 0; j < NumberOfParams-1; j++)
                    {
                        string dat = line[j];
                        X_data[i-1, j] = Double.Parse(dat);
                    }

                    Y_data[i-1] = line[NumberOfParams - 1];
                }

                return new Dataset(X_data, Y_data);
            }
            else
            {
                return null;
            }
        }
    }
}
