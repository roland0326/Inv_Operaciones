namespace WinFormsApp1.Vistas
{
    partial class Frm_Principal
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
            this.Lab_Titulo = new System.Windows.Forms.Label();
            this.Datos_Analisis = new System.Windows.Forms.DataGridView();
            this.Btn_Met1 = new System.Windows.Forms.Button();
            this.Btn_Met5 = new System.Windows.Forms.Button();
            this.Btn_Met6 = new System.Windows.Forms.Button();
            this.Btn_Met4 = new System.Windows.Forms.Button();
            this.Btn_Met3 = new System.Windows.Forms.Button();
            this.Btn_Met2 = new System.Windows.Forms.Button();
            this.Txt_Consola = new System.Windows.Forms.TextBox();
            this.Lab_Consola = new System.Windows.Forms.Label();
            this.Lab_alternativa = new System.Windows.Forms.Label();
            this.Txt_Alternativa = new System.Windows.Forms.TextBox();
            this.Txt_Alternativo2 = new System.Windows.Forms.TextBox();
            this.Lab_Alternativo2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Analisis)).BeginInit();
            this.SuspendLayout();
            // 
            // Lab_Titulo
            // 
            this.Lab_Titulo.AutoSize = true;
            this.Lab_Titulo.Location = new System.Drawing.Point(320, 9);
            this.Lab_Titulo.Name = "Lab_Titulo";
            this.Lab_Titulo.Size = new System.Drawing.Size(160, 15);
            this.Lab_Titulo.TabIndex = 0;
            this.Lab_Titulo.Text = "Investigacion de operaciones";
            // 
            // Datos_Analisis
            // 
            this.Datos_Analisis.AllowUserToAddRows = false;
            this.Datos_Analisis.AllowUserToDeleteRows = false;
            this.Datos_Analisis.BackgroundColor = System.Drawing.Color.White;
            this.Datos_Analisis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Datos_Analisis.Location = new System.Drawing.Point(12, 32);
            this.Datos_Analisis.Name = "Datos_Analisis";
            this.Datos_Analisis.RowHeadersWidth = 51;
            this.Datos_Analisis.RowTemplate.Height = 25;
            this.Datos_Analisis.Size = new System.Drawing.Size(776, 150);
            this.Datos_Analisis.TabIndex = 1;
            // 
            // Btn_Met1
            // 
            this.Btn_Met1.Location = new System.Drawing.Point(12, 224);
            this.Btn_Met1.Name = "Btn_Met1";
            this.Btn_Met1.Size = new System.Drawing.Size(86, 23);
            this.Btn_Met1.TabIndex = 2;
            this.Btn_Met1.Text = "Met Laplace";
            this.Btn_Met1.UseVisualStyleBackColor = true;
            this.Btn_Met1.Click += new System.EventHandler(this.Btn_Met1_Click);
            // 
            // Btn_Met5
            // 
            this.Btn_Met5.Location = new System.Drawing.Point(410, 224);
            this.Btn_Met5.Name = "Btn_Met5";
            this.Btn_Met5.Size = new System.Drawing.Size(90, 23);
            this.Btn_Met5.TabIndex = 3;
            this.Btn_Met5.Text = "<--Desiciones";
            this.Btn_Met5.UseVisualStyleBackColor = true;
            this.Btn_Met5.Click += new System.EventHandler(this.Btn_Met5_Click);
            // 
            // Btn_Met6
            // 
            this.Btn_Met6.Location = new System.Drawing.Point(506, 224);
            this.Btn_Met6.Name = "Btn_Met6";
            this.Btn_Met6.Size = new System.Drawing.Size(133, 23);
            this.Btn_Met6.TabIndex = 4;
            this.Btn_Met6.Text = "Met Arrepentimiento";
            this.Btn_Met6.UseVisualStyleBackColor = true;
            this.Btn_Met6.Click += new System.EventHandler(this.Btn_Met6_Click);
            // 
            // Btn_Met4
            // 
            this.Btn_Met4.Location = new System.Drawing.Point(307, 224);
            this.Btn_Met4.Name = "Btn_Met4";
            this.Btn_Met4.Size = new System.Drawing.Size(95, 23);
            this.Btn_Met4.TabIndex = 6;
            this.Btn_Met4.Text = "Met Hurwicz";
            this.Btn_Met4.UseVisualStyleBackColor = true;
            this.Btn_Met4.Click += new System.EventHandler(this.Btn_Met4_Click);
            // 
            // Btn_Met3
            // 
            this.Btn_Met3.Location = new System.Drawing.Point(204, 224);
            this.Btn_Met3.Name = "Btn_Met3";
            this.Btn_Met3.Size = new System.Drawing.Size(97, 23);
            this.Btn_Met3.TabIndex = 7;
            this.Btn_Met3.Text = "Met Pesimista";
            this.Btn_Met3.UseVisualStyleBackColor = true;
            this.Btn_Met3.Click += new System.EventHandler(this.Btn_Met3_Click);
            // 
            // Btn_Met2
            // 
            this.Btn_Met2.Location = new System.Drawing.Point(104, 224);
            this.Btn_Met2.Name = "Btn_Met2";
            this.Btn_Met2.Size = new System.Drawing.Size(94, 23);
            this.Btn_Met2.TabIndex = 8;
            this.Btn_Met2.Text = "Met Optimista";
            this.Btn_Met2.UseVisualStyleBackColor = true;
            this.Btn_Met2.Click += new System.EventHandler(this.Btn_Met2_Click);
            // 
            // Txt_Consola
            // 
            this.Txt_Consola.Location = new System.Drawing.Point(12, 276);
            this.Txt_Consola.Multiline = true;
            this.Txt_Consola.Name = "Txt_Consola";
            this.Txt_Consola.ReadOnly = true;
            this.Txt_Consola.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Txt_Consola.Size = new System.Drawing.Size(776, 162);
            this.Txt_Consola.TabIndex = 10;
            // 
            // Lab_Consola
            // 
            this.Lab_Consola.AutoSize = true;
            this.Lab_Consola.Location = new System.Drawing.Point(351, 254);
            this.Lab_Consola.Name = "Lab_Consola";
            this.Lab_Consola.Size = new System.Drawing.Size(99, 15);
            this.Lab_Consola.TabIndex = 11;
            this.Lab_Consola.Text = "Consola de salida";
            // 
            // Lab_alternativa
            // 
            this.Lab_alternativa.AutoSize = true;
            this.Lab_alternativa.Location = new System.Drawing.Point(12, 194);
            this.Lab_alternativa.Name = "Lab_alternativa";
            this.Lab_alternativa.Size = new System.Drawing.Size(101, 15);
            this.Lab_alternativa.TabIndex = 12;
            this.Lab_alternativa.Text = "Valor alternativo 1";
            // 
            // Txt_Alternativa
            // 
            this.Txt_Alternativa.Location = new System.Drawing.Point(128, 192);
            this.Txt_Alternativa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Txt_Alternativa.Name = "Txt_Alternativa";
            this.Txt_Alternativa.Size = new System.Drawing.Size(148, 23);
            this.Txt_Alternativa.TabIndex = 13;
            // 
            // Txt_Alternativo2
            // 
            this.Txt_Alternativo2.Location = new System.Drawing.Point(410, 192);
            this.Txt_Alternativo2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Txt_Alternativo2.Name = "Txt_Alternativo2";
            this.Txt_Alternativo2.Size = new System.Drawing.Size(148, 23);
            this.Txt_Alternativo2.TabIndex = 15;
            // 
            // Lab_Alternativo2
            // 
            this.Lab_Alternativo2.AutoSize = true;
            this.Lab_Alternativo2.Location = new System.Drawing.Point(291, 194);
            this.Lab_Alternativo2.Name = "Lab_Alternativo2";
            this.Lab_Alternativo2.Size = new System.Drawing.Size(101, 15);
            this.Lab_Alternativo2.TabIndex = 14;
            this.Lab_Alternativo2.Text = "Valor alternativo 2";
            // 
            // Frm_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Txt_Alternativo2);
            this.Controls.Add(this.Lab_Alternativo2);
            this.Controls.Add(this.Txt_Alternativa);
            this.Controls.Add(this.Lab_alternativa);
            this.Controls.Add(this.Lab_Consola);
            this.Controls.Add(this.Txt_Consola);
            this.Controls.Add(this.Btn_Met2);
            this.Controls.Add(this.Btn_Met3);
            this.Controls.Add(this.Btn_Met4);
            this.Controls.Add(this.Btn_Met6);
            this.Controls.Add(this.Btn_Met5);
            this.Controls.Add(this.Btn_Met1);
            this.Controls.Add(this.Datos_Analisis);
            this.Controls.Add(this.Lab_Titulo);
            this.Name = "Frm_Principal";
            this.Text = "Frm_Principal";
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Analisis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label Lab_Titulo;
        private DataGridView Datos_Analisis;
        private Button Btn_Met1;
        private Button Btn_Met5;
        private Button Btn_Met6;
        private Button Btn_Met4;
        private Button Btn_Met3;
        private Button Btn_Met2;
        private TextBox Txt_Consola;
        private Label Lab_Consola;
        private Label Lab_alternativa;
        private TextBox Txt_Alternativa;
        private TextBox Txt_Alternativo2;
        private Label Lab_Alternativo2;
    }
}