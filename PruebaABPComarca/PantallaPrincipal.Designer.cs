namespace PruebaABPComarca
{
    partial class PantallaPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonPreguntas = new System.Windows.Forms.Button();
            this.buttonPersonajes = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPreguntas
            // 
            this.buttonPreguntas.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonPreguntas.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPreguntas.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonPreguntas.Location = new System.Drawing.Point(91, 153);
            this.buttonPreguntas.Name = "buttonPreguntas";
            this.buttonPreguntas.Size = new System.Drawing.Size(232, 138);
            this.buttonPreguntas.TabIndex = 0;
            this.buttonPreguntas.Text = "PREGUNTAS";
            this.buttonPreguntas.UseVisualStyleBackColor = false;
            this.buttonPreguntas.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonPersonajes
            // 
            this.buttonPersonajes.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonPersonajes.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPersonajes.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonPersonajes.Location = new System.Drawing.Point(462, 153);
            this.buttonPersonajes.Name = "buttonPersonajes";
            this.buttonPersonajes.Size = new System.Drawing.Size(232, 138);
            this.buttonPersonajes.TabIndex = 1;
            this.buttonPersonajes.Text = "PERSONAJES";
            this.buttonPersonajes.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PruebaABPComarca.Properties.Resources.OPCION_1;
            this.pictureBox1.Location = new System.Drawing.Point(339, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(106, 107);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonPersonajes);
            this.Controls.Add(this.buttonPreguntas);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPreguntas;
        private System.Windows.Forms.Button buttonPersonajes;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

