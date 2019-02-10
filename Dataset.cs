using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisKNNClassifier
{
    class Dataset
    {
        public double[,] X_data { get; private set; }
        public string[] Y_data { get; private set; }
        public Dataset(double[,] X_data, string[] Y_data)
        {
            this.X_data = X_data;
            this.Y_data = Y_data;
        }

        public void Print()
        {
            for(int i = 0; i < X_data.GetLength(0); i++)
            {
                string line = "";
                for(int j = 0; j < X_data.GetLength(1); j++)
                {
                    line += X_data[i, j];
                    line += ";";
                }
                line += Y_data[i];
                Console.WriteLine(line);
            }
        }
    }
}
