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
using VisioForge.Libs.NAudio.Wave;

namespace Interfaz
{
    public partial class Encrypt : Form
    {
        private System.Windows.Forms.Timer timer;
        private Random random;
        private int columnCount;
        private int[] columns;
        private WaveFileWriter writer;
        private WaveInEvent waveInEvent;
        private string outputPath;
        public Encrypt()
        {
            InitializeComponent();
            recordingTimer.Tick += recordingTimer_Tick;
            // Configurar estilo del formulario
            //FormBorderStyle = FormBorderStyle.None;
            DoubleBuffered = true;
            Label label = new Label
            {
                Text = "Encriptar mensaje",
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

        private void Encrypt_Load(object sender, EventArgs e)
        {

        }

        private void inputbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Encriptbtn_Click(object sender, EventArgs e)
        {
            string mensaje = inputbox.Text;
            string mensajeEncriptado = EncriptarMensaje(mensaje);
            outputbox.Text = mensajeEncriptado;
            stepsbox.Text = GenerarPasosEncriptacion(mensaje);

            string pythonScript = "script.py";
            string archivoParametro = "audio.wav";
            string cadenaParametro = mensaje;

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "WPy64-31090/python-3.10.9.amd64/python.exe";
            startInfo.Arguments = $"{pythonScript} {archivoParametro} \"{cadenaParametro}\"";
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Console.WriteLine(output);
        }
        private string EncriptarMensaje(string mensaje)
        {
            // Lógica para encriptar el mensaje
            // Puedes ajustar este algoritmo según tus necesidades

            // Sustitución
            string mensajeEncriptado = "";
            foreach (char c in mensaje)
            {
                int asciiValue = (int)c;
                int encryptedAsciiValue = (asciiValue + 5) % 256; // Desplazamiento y módulo 256 para mantenerlo en el rango ASCII
                char encryptedChar = (char)encryptedAsciiValue;
                mensajeEncriptado += encryptedChar;
            }

            //// Permutación
            //char[] caracteresEncriptados = mensajeEncriptado.ToCharArray();
            //Random random = new Random();
            //for (int i = caracteresEncriptados.Length - 1; i > 0; i--)
            //{
            //    int j = random.Next(i + 1);
            //    char temp = caracteresEncriptados[i];
            //    caracteresEncriptados[i] = caracteresEncriptados[j];
            //    caracteresEncriptados[j] = temp;
            //}
            //mensajeEncriptado = new string(caracteresEncriptados);

            return mensajeEncriptado;
        }

        private string GenerarPasosEncriptacion(string mensaje)
        {
            string pasos = "";

            // Lógica para generar los pasos de encriptación
            // Puedes ajustar este algoritmo según tus necesidades

            // Sustitución
            pasos += "Sustitución:\r\n";
            foreach (char c in mensaje)
            {
                int asciiValue = (int)c;
                int encryptedAsciiValue = (asciiValue + 5) % 256; // Desplazamiento y módulo 256 para mantenerlo en el rango ASCII
                char encryptedChar = (char)encryptedAsciiValue;
                pasos += string.Format("Carácter '{0}' encriptado como '{1}'\r\n", c, encryptedChar);
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
        private void GuardarMensajeEncriptado(string mensajeEncriptado)
        {
            // Ruta y nombre de archivo donde se guardará el mensaje encriptado
            string rutaArchivo = "mensaje_encriptado.txt";

            // Crear un objeto StreamWriter para escribir en el archivo
            using (StreamWriter writer = new StreamWriter(rutaArchivo))
            {
                // Escribir el mensaje encriptado en el archivo
                writer.Write(mensajeEncriptado);
            }

            // Mostrar un mensaje de éxito
            MessageBox.Show("El mensaje encriptado se ha guardado en el archivo " + rutaArchivo, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Ejecutar script de Python
            string rutaPython = "C:\\Users\\xjlop\\AppData\\Local\\Microsoft\\WindowsApps\\python.exe";
            string rutaScript = "";
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = rutaPython;
            startInfo.Arguments = rutaScript;
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;

            using (Process process = new Process())
            {
                process.StartInfo = startInfo;
                process.Start();

                string resultado = process.StandardOutput.ReadToEnd();
            }

        }
        private void WaveInEvent_DataAvailable(object sender, WaveInEventArgs e)
        {
            writer.Write(e.Buffer, 0, e.BytesRecorded);
        }

        private void recordingTimer_Tick(object sender, EventArgs e)
        {
            if (waveInEvent != null)
            {
                waveInEvent.StopRecording();
                waveInEvent.Dispose();
                waveInEvent = null;
                writer.Close();
                writer.Dispose();

                recordingTimer.Stop(); // Detener el temporizador

                grabar.Text = "Iniciar Grabación";

                MessageBox.Show($"La nota de voz se ha guardado en: {outputPath}");
            }
        }

        private void grabar_Click(object sender, EventArgs e)
        {
            if (waveInEvent == null) // Si no se está grabando
            {
                // Generar una ruta de archivo única para guardar la nota de voz
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                string fileName = $"audio.wav";
                outputPath = Path.Combine(Application.StartupPath, fileName);

                // Iniciar la grabación
                waveInEvent = new WaveInEvent();
                waveInEvent.DataAvailable += WaveInEvent_DataAvailable;
                waveInEvent.WaveFormat = new WaveFormat(44100, 1); // 44.1 kHz, mono
                writer = new WaveFileWriter(outputPath, waveInEvent.WaveFormat);

                recordingTimer.Start(); // Iniciar el temporizador de 5 segundos
                waveInEvent.StartRecording();

                grabar.Text = "Detener Grabación";
            }
            else // Si ya se está grabando, detener la grabación
            {
                waveInEvent.StopRecording();
                waveInEvent.Dispose();
                waveInEvent = null;
                writer.Close();
                writer.Dispose();

                recordingTimer.Stop(); // Detener el temporizador
                recordingTimer.Tick -= recordingTimer_Tick;
                grabar.Text = "Iniciar Grabación";

                MessageBox.Show($"La nota de voz se ha guardado en: {outputPath}");
            }
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            string mensajeEncriptado = outputbox.Text;
            // Verificar si el mensaje encriptado está vacío
            if (!string.IsNullOrEmpty(mensajeEncriptado))
            {
                GuardarMensajeEncriptado(mensajeEncriptado);
            }
            else
            {
                MessageBox.Show("No hay mensaje encriptado para guardar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
