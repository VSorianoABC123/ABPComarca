namespace PruebaABPComarca
{
    partial class Preguntas
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
            this.buttonCrear = new System.Windows.Forms.Button();
            this.buttonEditar = new System.Windows.Forms.Button();
            this.buttonBorrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCrear
            // 
            this.buttonCrear.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonCrear.Font = new System.Drawing.Font("Verdana", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCrear.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonCrear.Location = new System.Drawing.Point(624, 122);
            this.buttonCrear.Name = "buttonCrear";
            this.buttonCrear.Size = new System.Drawing.Size(116, 39);
            this.buttonCrear.TabIndex = 0;
            this.buttonCrear.Text = "CREAR";
            this.buttonCrear.UseVisualStyleBackColor = false;
            this.buttonCrear.Click += new System.EventHandler(this.buttonCrear_Click);
            // 
            // buttonEditar
            // 
            this.buttonEditar.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonEditar.Font = new System.Drawing.Font("Verdana", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditar.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonEditar.Location = new System.Drawing.Point(624, 219);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(116, 39);
            this.buttonEditar.TabIndex = 1;
            this.buttonEditar.Text = "EDITAR";
            this.buttonEditar.UseVisualStyleBackColor = false;
            this.buttonEditar.Click += new System.EventHandler(this.buttonEditar_Click);
            // 
            // buttonBorrar
            // 
            this.buttonBorrar.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonBorrar.Font = new System.Drawing.Font("Verdana", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBorrar.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonBorrar.Location = new System.Drawing.Point(624, 318);
            this.buttonBorrar.Name = "buttonBorrar";
            this.buttonBorrar.Size = new System.Drawing.Size(116, 39);
            this.buttonBorrar.TabIndex = 3;
            this.buttonBorrar.Text = "BORRAR";
            this.buttonBorrar.UseVisualStyleBackColor = false;
            this.buttonBorrar.Click += new System.EventHandler(this.buttonBorrar_Click);
            // 
            // Preguntas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonBorrar);
            this.Controls.Add(this.buttonEditar);
            this.Controls.Add(this.buttonCrear);
            this.Name = "Preguntas";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCrear;
        private System.Windows.Forms.Button buttonEditar;
        private System.Windows.Forms.Button buttonBorrar;
    }
}