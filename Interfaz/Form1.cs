using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer timer;
        private Random random;
        private int columnCount;
        private int[] columns;

        public Form1()
        {
            InitializeComponent();
            // Configurar estilo del formulario
            //FormBorderStyle = FormBorderStyle.None;
            DoubleBuffered = true;
            Label label = new Label
            {
                Text = "Message Encrypter/Decrypter",
                ForeColor = Color.Cyan,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 20),
                Dock = DockStyle.Top,
                Height = Height / 8
            };
            Controls.Add(label);
            // Configurar animación de letras lloviendo
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 200; // Ajusta la velocidad de la animación
            timer.Tick += Timer_Tick;

            random = new Random();
            columnCount = Width / 10; // Ajusta el número de columnas de letras
            columns = new int[columnCount];

            timer.Start();
            // Agregar botones centrados vertical y horizontalmente
            Button button1 = new Button
            {
                Text = "Encriptar",
                ForeColor = Color.Cyan,
                BackColor = Color.Black,
                Font = new Font("Arial", 12),
                Size = new Size(150, 50),
                Location = new Point((Width / 2) - 200, (Height - 50) / 2)
            };
            button1.Click += Button1_Click;
            Controls.Add(button1);

            Button button2 = new Button
            {
                Text = "Desencriptar",
                ForeColor = Color.Cyan,
                BackColor = Color.Black,
                Font = new Font("Arial", 12),
                Size = new Size(150, 50),
                Location = new Point((Width / 2) + 50, (Height - 50) / 2),
            };
            button2.Click += Button2_Click;
            Controls.Add(button2);
            // Agregar controles personalizados en los bordes
            Controls.Add(new CustomBorderControl(Color.Cyan, DockStyle.Left));
            Controls.Add(new CustomBorderControl(Color.Cyan, DockStyle.Right));
            // Agregar el texto centrado horizontalmente

        }
        private void Button1_Click(object sender, EventArgs e)
        {
            // Lógica que se ejecuta cuando se hace clic en el botón 1
            Encrypt encriptarForm = new Encrypt();
            this.Hide();
            encriptarForm.ShowDialog();
            this.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // Lógica que se ejecuta cuando se hace clic en el botón 2
            Desencriptar desencriptarForm = new Desencriptar();
            this.Hide();
            desencriptarForm.ShowDialog();
            this.Show();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (var brush = new SolidBrush(Color.Cyan))
            {
                for (int i = 0; i < columnCount; i++)
                {
                    if (columns[i] == 0 || random.Next(10) == 0)
                    {
                        columns[i] = random.Next(Height / 10);
                    }

                    for (int j = 0; j < columns[i]; j++)
                    {
                        int y = j * 10;
                        char letter = (char)random.Next(33, 127); // Rango de caracteres ASCII imprimibles
                        e.Graphics.DrawString(letter.ToString(), Font, brush, i * 10, y);
                    }

                    columns[i]--;
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

public class CustomBorderControl : Panel
{
    public CustomBorderControl(Color liquidColor, DockStyle dockStyle)
    {
        Dock = dockStyle;
        Width = 10;

        // Estilo visual del control de borde
        BackColor = Color.Transparent;
        BorderStyle = BorderStyle.FixedSingle;
        Padding = new Padding(2);
        Margin = new Padding(0);
        ControlPaint.DrawBorder(this.CreateGraphics(), ClientRectangle,
                                Color.Black, 2, ButtonBorderStyle.Solid,
                                Color.Black, 2, ButtonBorderStyle.Solid,
                                Color.Black, 2, ButtonBorderStyle.Solid,
                                Color.Black, 2, ButtonBorderStyle.Solid);

        // Configurar líquido azul
        Panel liquid = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = liquidColor,
            BorderStyle = BorderStyle.None,
            Padding = new Padding(2)
        };
        Controls.Add(liquid);
    }
}
