using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisKNNClassifier
{
    class KNNClassifier
    {
        private Random rand;
        public Dataset data { get; private set; }
        public void Fit(Dataset dat)
        {
            this.rand = new Random();
            this.data = dat;
        }

        public string[] Predict(double[,] dat)
        {
            List<string> predictions = new List<string>();

            for(int i = 0; i < dat.GetLength(0); i++)
            {
                string label = this.Closest(GetArrayFromIndex(dat, i));
                predictions.Add(label);
            }

            return predictions.ToArray();
        }

        /// <summary>
        /// Simple way to get 1D array from 2D with an index, since putting one index in 2D array DOESN'T return 1D one...
        /// </summary>
        /// <param name="dat"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private double[] GetArrayFromIndex(double[,] dat, int index)
        {
            double[] data = new double[dat.GetLength(1)];

            for(int i = 0; i < dat.GetLength(1); i++)
            {
                data[i] = dat[index, i];
            }

            return data;
        }
        private string Closest(double[] row)
        {
            double best_dist = Euclidean(row, GetArrayFromIndex(data.X_data, 0));
            int best_index = 0;

            for(int i = 0; i < data.X_data.GetLength(0); i++)
            {
                double dist = Euclidean(row, GetArrayFromIndex(data.X_data, i));
                if(dist < best_dist)
                {
                    best_dist = dist;
                    best_index = i;
                }
            }

            return this.data.Y_data[best_index];
        }

        private double Euclidean(double[] a, double[] b)
        {
            double[] cross_product = new double[a.Length];
            double sum = 0;
            for (int i = 0; i < cross_product.Length; i++)
            {
                cross_product[i] = (a[i] - b[i]) * (a[i] - b[i]);
                sum += cross_product[i];
            }

            return Math.Sqrt(sum);
        }
    }
}
