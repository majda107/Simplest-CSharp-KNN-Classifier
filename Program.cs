using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisKNNClassifier
{
    class Program
    {
        static void Main(string[] args)
        {
            DataLoader dataLoader = new DataLoader(@"C:\Users\Marián Trpkoš\source\repos\MachineLearning\IrisKNNClassifier\iris.csv");
            Dataset dataset = dataLoader.LoadData();

            // dividing data

            double[,] X_train = new double[dataset.X_data.GetLength(0) / 2, dataset.X_data.GetLength(1)];
            string[] Y_train = new string[dataset.Y_data.Length / 2];

            double[,] X_test = new double[dataset.X_data.GetLength(0) / 2, dataset.X_data.GetLength(1)];
            string[] Y_test = new string[dataset.Y_data.Length / 2];

            for (int i = 0; i < dataset.X_data.GetLength(0); i++)
            {
                if(i % 2 == 0)
                {
                    for(int j = 0; j < dataset.X_data.GetLength(1); j++)
                    {
                        X_train[i / 2, j] = dataset.X_data[i, j];
                    }
                    Y_train[i / 2] = dataset.Y_data[i];
                }
                else
                {
                    for (int j = 0; j < dataset.X_data.GetLength(1); j++)
                    {
                        X_test[i / 2, j] = dataset.X_data[i, j];
                    }
                    Y_test[i / 2] = dataset.Y_data[i];
                }
            }

            Dataset train = new Dataset(X_train, Y_train);
            Dataset test = new Dataset(X_test, Y_test);

            // end of data division

            var classifier = new KNNClassifier();
            classifier.Fit(train);

            string[] predictions = classifier.Predict(test.X_data);

            Console.WriteLine("SET   PREDICTED \n");
            for(int i = 0; i < predictions.Length; i++)
            {
                Console.WriteLine($"{test.Y_data[i]} : {predictions[i]}");
            }

            Console.ReadKey();
        }
    }
}
