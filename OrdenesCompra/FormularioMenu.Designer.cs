namespace OrdenesCompra
{
    partial class FormularioMenu
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
            this.button1 = new System.Windows.Forms.Button();
            this.veroc = new System.Windows.Forms.Button();
            this.ingre = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.button1.Location = new System.Drawing.Point(333, 475);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(295, 63);
            this.button1.TabIndex = 0;
            this.button1.Text = "Cerrar sesión";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // veroc
            // 
            this.veroc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.veroc.Location = new System.Drawing.Point(333, 300);
            this.veroc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.veroc.Name = "veroc";
            this.veroc.Size = new System.Drawing.Size(295, 63);
            this.veroc.TabIndex = 1;
            this.veroc.Text = "Revisar órden de compra";
            this.veroc.UseVisualStyleBackColor = true;
            this.veroc.Click += new System.EventHandler(this.button2_Click);
            // 
            // ingre
            // 
            this.ingre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.ingre.Location = new System.Drawing.Point(333, 233);
            this.ingre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ingre.Name = "ingre";
            this.ingre.Size = new System.Drawing.Size(295, 63);
            this.ingre.TabIndex = 2;
            this.ingre.Text = "Ingresar órden de compra";
            this.ingre.UseVisualStyleBackColor = true;
            this.ingre.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.label1.Location = new System.Drawing.Point(251, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(464, 76);
            this.label1.TabIndex = 3;
            this.label1.Text = "Menú principal";
            // 
            // FormularioMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 661);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ingre);
            this.Controls.Add(this.veroc);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormularioMenu";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormularioMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button veroc;
        private System.Windows.Forms.Button ingre;
        private System.Windows.Forms.Label label1;
    }
}