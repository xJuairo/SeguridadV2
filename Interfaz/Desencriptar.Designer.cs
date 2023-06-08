
using System.Drawing;

namespace Interfaz
{
    partial class Desencriptar
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
            this.inputbox = new System.Windows.Forms.TextBox();
            this.outputbox = new System.Windows.Forms.TextBox();
            this.stepsbox = new System.Windows.Forms.TextBox();
            this.Abrir_archivo = new System.Windows.Forms.Button();
            this.Decryptbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // inputbox
            // 
            this.inputbox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.inputbox.Font = new System.Drawing.Font("Arial", 15);
            this.inputbox.ForeColor = System.Drawing.Color.Cyan;
            this.inputbox.Location = new System.Drawing.Point(24, 87);
            this.inputbox.Multiline = true;
            this.inputbox.Name = "inputbox";
            this.inputbox.ReadOnly = true;
            this.inputbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.inputbox.Size = new System.Drawing.Size(355, 177);
            this.inputbox.TabIndex = 9;
            // 
            // outputbox
            // 
            this.outputbox.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.outputbox.Font = new System.Drawing.Font("Arial", 15);
            this.outputbox.ForeColor = System.Drawing.Color.Cyan;
            this.outputbox.Location = new System.Drawing.Point(433, 87);
            this.outputbox.Multiline = true;
            this.outputbox.Name = "outputbox";
            this.outputbox.ReadOnly = true;
            this.outputbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputbox.Size = new System.Drawing.Size(355, 177);
            this.outputbox.TabIndex = 12;
            // 
            // stepsbox
            // 
            this.stepsbox.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.stepsbox.Font = new System.Drawing.Font("Arial", 15);
            this.stepsbox.ForeColor = System.Drawing.Color.Cyan;
            this.stepsbox.Location = new System.Drawing.Point(24, 290);
            this.stepsbox.Multiline = true;
            this.stepsbox.Name = "stepsbox";
            this.stepsbox.ReadOnly = true;
            this.stepsbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.stepsbox.Size = new System.Drawing.Size(355, 148);
            this.stepsbox.TabIndex = 13;
            // 
            // Abrir_archivo
            // 
            this.Abrir_archivo.Location = new System.Drawing.Point(546, 305);
            this.Abrir_archivo.Name = "Abrir_archivo";
            this.Abrir_archivo.Size = new System.Drawing.Size(133, 39);
            this.Abrir_archivo.TabIndex = 14;
            this.Abrir_archivo.Text = "Abrir Mensaje ";
            this.Abrir_archivo.UseVisualStyleBackColor = true;
            this.Abrir_archivo.Click += new System.EventHandler(this.Abrir_archivo_Click);
            // 
            // Decryptbtn
            // 
            this.Decryptbtn.Location = new System.Drawing.Point(546, 383);
            this.Decryptbtn.Name = "Decryptbtn";
            this.Decryptbtn.Size = new System.Drawing.Size(133, 39);
            this.Decryptbtn.TabIndex = 15;
            this.Decryptbtn.Text = "Desencriptar mensaje\r\n";
            this.Decryptbtn.UseVisualStyleBackColor = true;
            this.Decryptbtn.Click += new System.EventHandler(this.Decryptbtn_Click_1);
            // 
            // Desencriptar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Decryptbtn);
            this.Controls.Add(this.Abrir_archivo);
            this.Controls.Add(this.stepsbox);
            this.Controls.Add(this.outputbox);
            this.Controls.Add(this.inputbox);
            this.Name = "Desencriptar";
            this.Text = "Desencriptar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputbox;
        private System.Windows.Forms.TextBox outputbox;
        private System.Windows.Forms.TextBox stepsbox;
        private System.Windows.Forms.Button Abrir_archivo;
        private System.Windows.Forms.Button Decryptbtn;
    }
}