namespace Juego_del_Gato_IA2020
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnAceptar = new System.Windows.Forms.Button();
            this.rbVersus = new System.Windows.Forms.RadioButton();
            this.rbIA = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(232, 179);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.button1_Click);
            // 
            // rbVersus
            // 
            this.rbVersus.AutoSize = true;
            this.rbVersus.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.rbVersus.Image = ((System.Drawing.Image)(resources.GetObject("rbVersus.Image")));
            this.rbVersus.Location = new System.Drawing.Point(316, 41);
            this.rbVersus.Name = "rbVersus";
            this.rbVersus.Size = new System.Drawing.Size(160, 173);
            this.rbVersus.TabIndex = 2;
            this.rbVersus.TabStop = true;
            this.rbVersus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbVersus.UseVisualStyleBackColor = true;
            // 
            // rbIA
            // 
            this.rbIA.AutoSize = true;
            this.rbIA.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.rbIA.Image = ((System.Drawing.Image)(resources.GetObject("rbIA.Image")));
            this.rbIA.Location = new System.Drawing.Point(66, 41);
            this.rbIA.Name = "rbIA";
            this.rbIA.Size = new System.Drawing.Size(160, 173);
            this.rbIA.TabIndex = 1;
            this.rbIA.TabStop = true;
            this.rbIA.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(104, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 23);
            this.label3.TabIndex = 41;
            this.label3.Text = "Modo IA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(340, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 23);
            this.label1.TabIndex = 42;
            this.label1.Text = "Modo versus";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(528, 234);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rbVersus);
            this.Controls.Add(this.rbIA);
            this.Controls.Add(this.btnAceptar);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(544, 273);
            this.MinimumSize = new System.Drawing.Size(544, 273);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Juego del gato";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.RadioButton rbIA;
        private System.Windows.Forms.RadioButton rbVersus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}

