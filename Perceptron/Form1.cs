using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Perceptron
{
    public partial class Form1 : Form
    {
        private List<PointData> pointsList = new List<PointData>();
        private List<PointData> activationPointsList = new List<PointData>();
        private Color checkBoxColor = Color.Red;
        private Perceptron perceptron;
        private double[] separatingLineWeights;
        private System.Windows.Forms.Timer generationTimer;
        private int epochsCounter = 0;
        private int maxEpochs = 100;


        public Form1()
        {
            InitializeComponent();
            separatingLineWeights = new double[3];
            generationTimer = new System.Windows.Forms.Timer { Interval = 100 };
            generationTimer.Tick += GenerationTimer_Tick;
        }

        private void GenerationTimer_Tick(object sender, EventArgs e)
        {
            perceptron.Train(1, perceptron.GetTrainingData(), null);
            separatingLineWeights = perceptron.GetWeights();
            DrawSeparatingLine();
            UpdateEpochLabel(++epochsCounter);

            if (epochsCounter >= maxEpochs)
            {
                generationTimer.Stop();
            }
        }

        private void UpdateEpochLabel(int epoch)
        {
            if (genCounter.InvokeRequired)
            {
                genCounter.Invoke((MethodInvoker)(() => { genCounter.Text = epoch.ToString(); }));
            }
            else
            {
                genCounter.Text = epoch.ToString();
            }
        }

        private void ActivateButton_Click(object sender, EventArgs e)
        {
            perceptron = new Perceptron(2); // 2 входи (x та y координати)

            // Копіюємо точки до додаткового списку перед навчанням
            activationPointsList = new List<PointData>(pointsList);

            int epochs = 500; // Визначте кількість поколінь
            TrainPerceptron(epochs); // Початок навчання
        }

        private void plotArea_MouseDown(object sender, MouseEventArgs e)
        {
            plotArea_MouseClick(sender, e);
        }

        private void plotArea_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = e.X;
                int y = e.Y;
                DrawPoint(x, y, checkBoxColor); // Малювання точки

                // Додавання точки до персептрону при кліку на plotArea
                perceptron?.AddTrainingData(new double[] { x, y }, GetLabelForPoint(new Point(x, y)));
            }
            else if (e.Button == MouseButtons.Right)
            {
                int x = e.X;
                int y = e.Y;
                RemovePoint(x, y); // Видалення точки
            }
        }

        private void DrawSeparatingLine()
        {
            using (Graphics g = plotArea.CreateGraphics())
            {
                g.Clear(plotArea.BackColor);

                Pen pen = new Pen(Color.Green, 2);
                double x1 = 0;
                double y1 = (-separatingLineWeights[0] - separatingLineWeights[1] * x1) / separatingLineWeights[2];
                double x2 = plotArea.Width;
                double y2 = (-separatingLineWeights[0] - separatingLineWeights[1] * x2) / separatingLineWeights[2];

                // Перемалювання всіх точок з копії списку
                List<PointData> pointsCopy = new List<PointData>(pointsList);
                foreach (var point in pointsCopy)
                {
                    DrawPoint(point.X, point.Y, point.PointColor);
                }

                // Перемалювання всіх точок активації з копії списку
                List<PointData> activationPointsCopy = new List<PointData>(activationPointsList);
                foreach (var point in activationPointsCopy)
                {
                    DrawPoint(point.X, point.Y, point.PointColor);
                }
                g.DrawLine(pen, (float)x1, (float)y1, (float)x2, (float)y2);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //TrainPerceptron(); // Навчання персептрона при завантаженні форми
            //RedrawPoints(); // Перемалювання точок на полі
        }

        private void TrainPerceptron()
        {
            perceptron = new Perceptron(2);

            // Додавання точок зі списку до персептрона для навчання
            foreach (var point in pointsList)
            {
                perceptron.AddTrainingData(new double[] { point.X, point.Y }, GetLabelForPoint(new Point(point.X, point.Y)));
            }

            int epochs = 500;
            TrainPerceptronContinuously(epochs); // Змінено назву методу для уникнення зациклення
        }


        private void TrainPerceptron(int epochs)
        {
            // Персептрон створюється з визначеними розмірами вхідних даних (координати x та y)
            perceptron = new Perceptron(2);

            // Ітеруємося по всім точкам на полі і додаємо їх як навчальні дані для персептрона
            foreach (var point in pointsList)
            {
                perceptron.AddTrainingData(new double[] { point.X, point.Y }, GetLabelForPoint(new Point(point.X, point.Y)));
            }

            // Викликаємо метод для початку навчання персептрона
            TrainPerceptronContinuously(epochs);
        }

        private async void TrainPerceptronContinuously(int epochs)
        {
            int totalTrainingData = pointsList.Count; // Кількість точок для навчання

            for (int epoch = 0; epoch < epochs; epoch++)
            {
                int correctCount = 0; // Лічильник правильно класифікованих точок

                foreach (var point in pointsList)
                {
                    double[] inputs = new double[] { point.X, point.Y };
                    int target = GetLabelForPoint(new Point (point.X, point.Y));
                    int guess = perceptron.Predict(inputs);

                    if (target != guess)
                    {
                        int error = target - guess;

                        perceptron.AddTrainingData(inputs, target); // Додавання нових даних для навчання

                        // Навчання персептрона на нових даних
                        perceptron.Train(1, perceptron.GetTrainingData(), null);
                    }
                    else
                    {
                        correctCount++; // Збільшення лічильника правильних класифікацій
                    }
                }

                double accuracy = (double)correctCount / totalTrainingData;

                // Оновлення розділяючої лінії
                separatingLineWeights = perceptron.GetWeights();

                // Зупинка навчання, якщо досягнута 100% точність
                if (accuracy == 1.0)
                {
                    DrawSeparatingLine();
                    break;
                }

                await Task.Delay(100); // Затримка між ітераціями
            }
        }

        private int GetLabelForPoint(Point point)
        {
            // Параметри розділяючої лінії y = mx + c (зазвичай m = 1, c = 0 для простоти)
            double m = 1;
            double c = 0;

            // Якщо точка знаходиться нижче розділяючої лінії, повертаємо 1, інакше -1
            return point.Y < m * point.X + c ? 1 : -1;
        }

        private void RedrawPoints()
        {
            plotArea.Refresh();

            // Перемалювання всіх точок з урахуванням кольору
            foreach (var point in pointsList)
            {
                DrawPoint(point.X, point.Y, point.PointColor);
            }
        }

        private void DrawPoint(int x, int y, Color color)
        {
            using (Graphics g = plotArea.CreateGraphics())
            {
                g.FillEllipse(new SolidBrush(color), x, y, 5, 5);
            }

            // Додавання точки з відповідним кольором до списку для персептрона
            pointsList.Add(new PointData(x, y, color));
            perceptron?.AddTrainingData(new double[] { x, y }, GetLabelForPoint(new Point(x, y)));
        }

        private void RemovePoint(int x, int y)
        {
            // Пошук точки за координатами для видалення
            PointData pointToRemove = pointsList.FirstOrDefault(p => Math.Abs(p.X - x) <= 5 && Math.Abs(p.Y - y) <= 5);
            if (pointToRemove != null)
            {
                pointsList.Remove(pointToRemove);
                RedrawPoints();
                RemovePointFromPerceptron(pointToRemove.X, pointToRemove.Y);
            }
        }

        private void RemovePointFromPerceptron(int x, int y)
        {
            // Видалення точки з персептрону за координатами
            var data = perceptron?.GetTrainingData().FirstOrDefault(d => d.Item1[0] == x && d.Item1[1] == y);
            if (data != null)
            {
                perceptron?.GetTrainingData().Remove(data);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            int x, y;
            if (int.TryParse(xTextBox.Text, out x) && int.TryParse(yTextBox.Text, out y))
            {
                pointsList.Add(new PointData(x, y, checkBoxColor));
                DrawPoint(x, y, checkBoxColor);
            }
            else
            {
                MessageBox.Show("Некоректні координати!");
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            int x, y;
            if (int.TryParse(xTextBox.Text, out x) && int.TryParse(yTextBox.Text, out y))
            {
                RemovePoint(x, y);
            }
            else
            {
                MessageBox.Show("Некоректні координати!");
            }
        }

        private void colorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (colorBox.SelectedIndex == 0)
                checkBoxColor = Color.Red;
            else if (colorBox.SelectedIndex == 1)
                checkBoxColor = Color.Blue;
        }

    }
}
