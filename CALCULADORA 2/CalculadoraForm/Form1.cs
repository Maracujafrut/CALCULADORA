using System;
using System.Windows.Forms;

namespace CalculadoraForm
{
    public partial class Form1 : Form
    {
        private TextBox txtDisplay;
        private Button[] btnNumbers;
        private Button[] btnOperations;
        private Button btnEqual;
        private Button btnClear;
        private string currentOperation;
        private double firstNumber;

        public Form1()
        {
            InitializeComponent();
            InitializeCalculator();
        }

        private void InitializeCalculator()
        {
            // Criando os controles de interface
            this.Text = "Calculadora";
            this.Width = 400;
            this.Height = 500;

            txtDisplay = new TextBox
            {
                Location = new System.Drawing.Point(20, 20),
                Width = 340,
                Height = 40,
                ReadOnly = true,
                TextAlign = HorizontalAlignment.Right,
                Font = new System.Drawing.Font("Arial", 20)
            };
            this.Controls.Add(txtDisplay);

            // Criar os botões de números
            btnNumbers = new Button[10];
            int x = 20, y = 80;
            for (int i = 0; i < 10; i++)
            {
                btnNumbers[i] = new Button
                {
                    Text = i.ToString(),
                    Width = 80,
                    Height = 60,
                    Location = new System.Drawing.Point(x, y),
                    Font = new System.Drawing.Font("Arial", 14)
                };
                btnNumbers[i].Click += NumberButtonClick;
                this.Controls.Add(btnNumbers[i]);

                x += 90;
                if ((i + 1) % 3 == 0)
                {
                    x = 20;
                    y += 70;
                }
            }

            // Criar os botões de operação
            btnOperations = new Button[4];
            string[] operations = { "+", "-", "*", "/" };
            x = 290;
            y = 80;
            for (int i = 0; i < 4; i++)
            {
                btnOperations[i] = new Button
                {
                    Text = operations[i],
                    Width = 80,
                    Height = 60,
                    Location = new System.Drawing.Point(x, y),
                    Font = new System.Drawing.Font("Arial", 14)
                };
                btnOperations[i].Click += OperationButtonClick;
                this.Controls.Add(btnOperations[i]);

                y += 70;
            }

            // Botão de "=" para calcular
            btnEqual = new Button
            {
                Text = "=",
                Width = 80,
                Height = 60,
                Location = new System.Drawing.Point(290, y),
                Font = new System.Drawing.Font("Arial", 14)
            };
            btnEqual.Click += EqualButtonClick;
            this.Controls.Add(btnEqual);

            // Botão de "C" para limpar
            btnClear = new Button
            {
                Text = "C",
                Width = 80,
                Height = 60,
                Location = new System.Drawing.Point(20, y),
                Font = new System.Drawing.Font("Arial", 14)
            };
            btnClear.Click += ClearButtonClick;
            this.Controls.Add(btnClear);
        }

        // Função para o clique dos botões numéricos
        private void NumberButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            txtDisplay.Text += button.Text;
        }

        // Função para o clique dos botões de operação
        private void OperationButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentOperation = button.Text;
            firstNumber = double.Parse(txtDisplay.Text);
            txtDisplay.Clear();
        }

        // Função para o clique do botão "="
        private void EqualButtonClick(object sender, EventArgs e)
        {
            double secondNumber = double.Parse(txtDisplay.Text);
            double result = 0;

            switch (currentOperation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    if (secondNumber != 0)
                    {
                        result = firstNumber / secondNumber;
                    }
                    else
                    {
                        MessageBox.Show("Erro: Divisão por zero!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;
            }

            txtDisplay.Text = result.ToString();
        }

        // Função para limpar a tela
        private void ClearButtonClick(object sender, EventArgs e)
        {
            txtDisplay.Clear();
            firstNumber = 0;
            currentOperation = string.Empty;
        }
    }
}
