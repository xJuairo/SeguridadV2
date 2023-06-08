
using System.Drawing;

namespace Interfaz
{
    partial class Encrypt
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Encrypt));
            this.inputbox = new System.Windows.Forms.TextBox();
            this.outputbox = new System.Windows.Forms.TextBox();
            this.stepsbox = new System.Windows.Forms.TextBox();
            this.grabar = new System.Windows.Forms.Button();
            this.Encriptbtn = new System.Windows.Forms.Button();
            this.Guardar = new System.Windows.Forms.Button();
            this.recordingTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // inputbox
            // 
            this.inputbox.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.inputbox.ForeColor = System.Drawing.Color.Cyan;
            this.inputbox.Font = new Font("Arial", 15);
            this.inputbox.Location = new System.Drawing.Point(12, 75);
            this.inputbox.Multiline = true;
            this.inputbox.Name = "inputbox";
            this.inputbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.inputbox.Size = new System.Drawing.Size(355, 177);
            this.inputbox.TabIndex = 1;
            this.inputbox.TextChanged += new System.EventHandler(this.inputbox_TextChanged);
            // 
            // outputbox
            // 
            this.outputbox.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.outputbox.ForeColor = System.Drawing.Color.Cyan;
            this.outputbox.Font = new Font("Arial", 15);
            this.outputbox.Location = new System.Drawing.Point(399, 75);
            this.outputbox.Multiline = true;
            this.outputbox.Name = "outputbox";
            this.outputbox.ReadOnly = true;
            this.outputbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputbox.Size = new System.Drawing.Size(355, 177);
            this.outputbox.TabIndex = 2;
            // 
            // stepsbox
            // 
            this.stepsbox.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.stepsbox.ForeColor = System.Drawing.Color.Cyan;
            this.stepsbox.Font = new Font("Arial", 15);
            this.stepsbox.Location = new System.Drawing.Point(12, 261);
            this.stepsbox.Multiline = true;
            this.stepsbox.Name = "stepsbox";
            this.stepsbox.ReadOnly = true;
            this.stepsbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.stepsbox.Size = new System.Drawing.Size(355, 177);
            this.stepsbox.TabIndex = 3;
            // 
            // grabar
            // 
            this.grabar.Location = new System.Drawing.Point(399, 272);
            this.grabar.Name = "grabar";
            this.grabar.Size = new System.Drawing.Size(133, 39);
            this.grabar.TabIndex = 9;
            this.grabar.Text = "Grabar voz";
            this.grabar.UseVisualStyleBackColor = true;
            this.grabar.Click += new System.EventHandler(this.grabar_Click);
            // 
            // recordingTimer
            // 
            this.recordingTimer.Interval = 5000;
            this.recordingTimer.Tick += new System.EventHandler(this.recordingTimer_Tick);
            // 
            // Encriptbtn
            // 
            this.Encriptbtn.Location = new System.Drawing.Point(621, 272);
            this.Encriptbtn.Name = "Encriptbtn";
            this.Encriptbtn.Size = new System.Drawing.Size(133, 39);
            this.Encriptbtn.TabIndex = 10;
            this.Encriptbtn.Text = "Encriptar mensaje";
            this.Encriptbtn.UseVisualStyleBackColor = true;
            this.Encriptbtn.Click += new System.EventHandler(this.Encriptbtn_Click);
            // 
            // Guardar
            // 
            this.Guardar.Location = new System.Drawing.Point(511, 336);
            this.Guardar.Name = "Guardar";
            this.Guardar.Size = new System.Drawing.Size(133, 39);
            this.Guardar.TabIndex = 11;
            this.Guardar.Text = "Guardar";
            this.Guardar.UseVisualStyleBackColor = true;
            this.Guardar.Click += new System.EventHandler(this.Guardar_Click);
            // 
            // Encrypt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Guardar);
            this.Controls.Add(this.Encriptbtn);
            this.Controls.Add(this.grabar);
            this.Controls.Add(this.stepsbox);
            this.Controls.Add(this.outputbox);
            this.Controls.Add(this.inputbox);
            this.Name = "Encrypt";
            this.Text = "Encriptar";
            this.Load += new System.EventHandler(this.Encrypt_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputbox;
        private System.Windows.Forms.TextBox outputbox;
        private System.Windows.Forms.TextBox stepsbox;
        private System.Windows.Forms.Button grabar;
        private System.Windows.Forms.Button Encriptbtn;
        private System.Windows.Forms.Button Guardar;
        private System.Windows.Forms.Timer recordingTimer;
    }
}