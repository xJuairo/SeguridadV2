using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class Desencriptar : Form
    {
        private System.Windows.Forms.Timer timer;
        private Random random;
        private int columnCount;
        private int[] columns;

        public Desencriptar()
        {
            InitializeComponent();
            // Configurar estilo del formulario
            //FormBorderStyle = FormBorderStyle.None;
            DoubleBuffered = true;
            Label label = new Label
            {
                Text = "Desencriptar mensaje",
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

            // Agregar controles personalizados en los bordes
            Controls.Add(new CustomBorderControl(Color.Cyan, DockStyle.Left));
            Controls.Add(new CustomBorderControl(Color.Cyan, DockStyle.Right));
            // Agregar el texto centrado horizontalmente
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            //Refresh();
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

        private void Abrir_archivo_Click(object sender, EventArgs e)
        {
            // Crear un OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt";
            openFileDialog.Title = "Seleccionar archivo encriptado para abrir";

            // Mostrar el cuadro de diálogo para seleccionar el archivo
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Leer el contenido del archivo seleccionado
                string contenidoArchivo = File.ReadAllText(openFileDialog.FileName);

                // Mostrar el contenido en el cuadro de texto deseado
                inputbox.Text = contenidoArchivo;
            }
        }

        private void Decryptbtn_Click(object sender, EventArgs e)
        {
            string pythonScript = "comparador.py";
            string archivoParametro1 = "audio.wav";
            string archivoParametro2 = "voice.wav";

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "WPy64-31090/python-3.10.9.amd64/python.exe";
            startInfo.Arguments = $"{pythonScript} {archivoParametro1} {archivoParametro2}";
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Console.WriteLine(output);

            inputbox.Text = output;

            string mensajeEncriptado = inputbox.Text;
            string mensaje;
            if (!string.IsNullOrEmpty(mensajeEncriptado))
            {
                mensaje = DesencriptarMensaje(mensajeEncriptado);
                outputbox.Text = mensaje;
                stepsbox.Text = GenerarPasosDesencriptacion(mensajeEncriptado);
            }
            else
            {
                MessageBox.Show("No hay mensaje encriptado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string DesencriptarMensaje(string mensajeEncriptado)
        {
            //// Permutación inversa
            //char[] caracteresDesencriptados = mensajeEncriptado.ToCharArray();
            //Random random = new Random();
            //for (int i = 1; i < caracteresDesencriptados.Length; i++)
            //{
            //    int j = random.Next(i);
            //    char temp = caracteresDesencriptados[i];
            //    caracteresDesencriptados[i] = caracteresDesencriptados[j];
            //    caracteresDesencriptados[j] = temp;
            //}
            //string mensajePermutado = new string(caracteresDesencriptados);

            // Sustitución inversa
            string mensajeDesencriptado = "";
            foreach (char c in mensajeEncriptado)
            {
                int asciiValue = (int)c;
                int decryptedAsciiValue = (asciiValue - 5 + 256) % 256; // Deshacer el desplazamiento y módulo 256
                char decryptedChar = (char)decryptedAsciiValue;
                mensajeDesencriptado += decryptedChar;
            }

            return mensajeDesencriptado;
        }
        private string GenerarPasosDesencriptacion(string mensaje)
        {
            string pasos = "";

            // Lógica para generar los pasos de encriptación
            // Puedes ajustar este algoritmo según tus necesidades

            // Sustitución
            pasos += "Mensaje extraido del archivo de audio correctamente\n";
            pasos += "Sustitución:\r\n";

            foreach (char c in mensaje)
            {
                int asciiValue = (int)c;
                int decryptedAsciiValue = (asciiValue - 5 + 256) % 256; // Deshacer el desplazamiento y módulo 256
                char decryptedChar = (char)decryptedAsciiValue;
                pasos += string.Format("Carácter '{0}' desencriptado como '{1}'\r\n", c, decryptedChar);
            }




            // Permutación
            //pasos += "\r\nPermutación:\r\n";
            //Random random = new Random();
            //char[] caracteresEncriptados = mensaje.ToCharArray();
            //for (int i = caracteresEncriptados.Length - 1; i > 0; i--)
            //{
            //    int j = random.Next(i + 1);
            //    char temp = caracteresEncriptados[i];
            //    caracteresEncriptados[i] = caracteresEncriptados[j];
            //    caracteresEncriptados[j] = temp;

            //    pasos += string.Format("Carácter '{0}' intercambiado con carácter '{1}'\r\n", caracteresEncriptados[i], caracteresEncriptados[j]);
            //}
            return pasos;

        }

        private void Decryptbtn_Click_1(object sender, EventArgs e)
        {
            string pythonScript = "comparador.py";
            string archivoParametro1 = "audio.wav";
            string archivoParametro2 = "voice.wav";

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "WPy64-31090/python-3.10.9.amd64/python.exe";
            startInfo.Arguments = $"{pythonScript} {archivoParametro1} {archivoParametro2}";
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Console.WriteLine(output);

            inputbox.Text = output;

            string mensajeEncriptado = inputbox.Text;
            string mensaje;
            if (!string.IsNullOrEmpty(mensajeEncriptado))
            {
                mensaje = DesencriptarMensaje(mensajeEncriptado);
                outputbox.Text = mensaje;
                stepsbox.Text = GenerarPasosDesencriptacion(mensajeEncriptado);
            }
            else
            {
                MessageBox.Show("No hay mensaje encriptado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
