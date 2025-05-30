using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptron
{
    public class Perceptron
    {
        private double[] weights;
        private double learningRate = 0.1;
        private List<Tuple<double[], int>> trainingData;

        public Perceptron(int inputSize)
        {
            weights = new double[inputSize + 1]; // +1 for bias
            InitializeWeights();
            trainingData = new List<Tuple<double[], int>>();
        }

        private void InitializeWeights()
        {
            Random rand = new Random();
            weights = Enumerable.Range(0, weights.Length)
                                .Select(i => rand.NextDouble() * 2 - 1)
                                .ToArray(); // Random weights between -1 and 1
        }

        public int Predict(double[] inputs)
        {
            double sum = weights[0]; // Bias
            for (int i = 0; i < weights.Length - 1; i++)
            {
                sum += inputs[i] * weights[i + 1];
            }
            return Activation(sum);
        }

        private int Activation(double sum) => sum >= 0 ? 1 : -1; // Simple activation function

        public void Train(int epochs, List<Tuple<double[], int>> trainingSet, Action<int> epochCallback)
        {
            for (int epoch = 0; epoch < epochs; epoch++)
            {
                int correctCount = 0;

                foreach (var data in trainingSet)
                {
                    double[] inputs = data.Item1;
                    int target = data.Item2;
                    int guess = Predict(inputs);

                    if (target != guess)
                    {
                        int error = target - guess;

                        weights[0] += learningRate * error;

                        for (int i = 0; i < weights.Length - 1; i++)
                        {
                            weights[i + 1] += learningRate * error * inputs[i];
                        }
                    }
                    else
                    {
                        correctCount++;
                    }
                }

                double accuracy = (double)correctCount / trainingSet.Count;

                epochCallback?.Invoke(epoch);

                if (accuracy == 1.0)
                {
                    TrainingCompleted?.Invoke(this, EventArgs.Empty);
                    break;
                }
            }
        }

        public void AddTrainingData(double[] inputs, int label) => trainingData.Add(new Tuple<double[], int>(inputs, label));

        public double[] GetWeights() => weights;

        public List<Tuple<double[], int>> GetTrainingData() => trainingData;

        public event EventHandler TrainingCompleted;
    }
}
