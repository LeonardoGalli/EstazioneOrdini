namespace EstazioneOrdini
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtNumOrdine = new TextBox();
            label1 = new Label();
            btnExcel = new Button();
            lblFatto = new Label();
            lblErrore = new Label();
            label2 = new Label();
            txtImmagini = new TextBox();
            btnImmagini = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            label3 = new Label();
            txtCartellaExcel = new TextBox();
            txtNomeFileExcel = new TextBox();
            label4 = new Label();
            btnCartella = new Button();
            lblCarica = new Label();
            SuspendLayout();
            // 
            // txtNumOrdine
            // 
            txtNumOrdine.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            txtNumOrdine.Location = new Point(282, 190);
            txtNumOrdine.Name = "txtNumOrdine";
            txtNumOrdine.Size = new Size(212, 34);
            txtNumOrdine.TabIndex = 0;
            txtNumOrdine.TextChanged += txtNumOrdine_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(48, 186);
            label1.Name = "label1";
            label1.Size = new Size(228, 37);
            label1.TabIndex = 1;
            label1.Text = "INSERIRE ORDINE";
            // 
            // btnExcel
            // 
            btnExcel.Location = new Point(500, 190);
            btnExcel.Name = "btnExcel";
            btnExcel.Size = new Size(92, 34);
            btnExcel.TabIndex = 2;
            btnExcel.Text = "CREA EXCEL";
            btnExcel.UseVisualStyleBackColor = true;
            btnExcel.Click += btnExcel_Click;
            // 
            // lblFatto
            // 
            lblFatto.AutoSize = true;
            lblFatto.Location = new Point(598, 190);
            lblFatto.Name = "lblFatto";
            lblFatto.Size = new Size(39, 15);
            lblFatto.TabIndex = 3;
            lblFatto.Text = "FATTO";
            lblFatto.Visible = false;
            // 
            // lblErrore
            // 
            lblErrore.AutoSize = true;
            lblErrore.Location = new Point(598, 208);
            lblErrore.Name = "lblErrore";
            lblErrore.Size = new Size(131, 15);
            lblErrore.TabIndex = 4;
            lblErrore.Text = "ORDINE NON TROVATO";
            lblErrore.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 370);
            label2.Name = "label2";
            label2.Size = new Size(120, 15);
            label2.TabIndex = 5;
            label2.Text = "CARTELLA IMMAGINI";
            // 
            // txtImmagini
            // 
            txtImmagini.Enabled = false;
            txtImmagini.Location = new Point(226, 367);
            txtImmagini.Name = "txtImmagini";
            txtImmagini.Size = new Size(176, 23);
            txtImmagini.TabIndex = 6;
            // 
            // btnImmagini
            // 
            btnImmagini.Location = new Point(417, 365);
            btnImmagini.Name = "btnImmagini";
            btnImmagini.Size = new Size(206, 23);
            btnImmagini.TabIndex = 7;
            btnImmagini.Text = "SELEZIONA CARTELLA IMMAGINI";
            btnImmagini.UseVisualStyleBackColor = true;
            btnImmagini.Click += btnImmagini_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 410);
            label3.Name = "label3";
            label3.Size = new Size(199, 15);
            label3.TabIndex = 8;
            label3.Text = "CARTELLA DOVE CREARE FILE EXCEL";
            // 
            // txtCartellaExcel
            // 
            txtCartellaExcel.Enabled = false;
            txtCartellaExcel.Location = new Point(226, 407);
            txtCartellaExcel.Name = "txtCartellaExcel";
            txtCartellaExcel.Size = new Size(176, 23);
            txtCartellaExcel.TabIndex = 9;
            // 
            // txtNomeFileExcel
            // 
            txtNomeFileExcel.Location = new Point(120, 12);
            txtNomeFileExcel.Name = "txtNomeFileExcel";
            txtNomeFileExcel.Size = new Size(176, 23);
            txtNomeFileExcel.TabIndex = 10;
            txtNomeFileExcel.Text = "Standard.xlsx";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 15);
            label4.Name = "label4";
            label4.Size = new Size(102, 15);
            label4.TabIndex = 11;
            label4.Text = "NOME FILE EXCEL";
            // 
            // btnCartella
            // 
            btnCartella.Location = new Point(417, 407);
            btnCartella.Name = "btnCartella";
            btnCartella.Size = new Size(206, 23);
            btnCartella.TabIndex = 12;
            btnCartella.Text = "SELEZIONA CARTELLA EXCEL";
            btnCartella.UseVisualStyleBackColor = true;
            btnCartella.Click += button1_Click;
            // 
            // lblCarica
            // 
            lblCarica.AutoSize = true;
            lblCarica.Location = new Point(313, 237);
            lblCarica.Name = "lblCarica";
            lblCarica.Size = new Size(145, 15);
            lblCarica.TabIndex = 13;
            lblCarica.Text = "CARICANDO...ATTENDERE";
            lblCarica.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblCarica);
            Controls.Add(btnCartella);
            Controls.Add(label4);
            Controls.Add(txtNomeFileExcel);
            Controls.Add(txtCartellaExcel);
            Controls.Add(label3);
            Controls.Add(btnImmagini);
            Controls.Add(txtImmagini);
            Controls.Add(label2);
            Controls.Add(lblErrore);
            Controls.Add(lblFatto);
            Controls.Add(btnExcel);
            Controls.Add(label1);
            Controls.Add(txtNumOrdine);
            Name = "Form1";
            Text = "ESPORTAZIONE";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNumOrdine;
        private Label label1;
        private Button btnExcel;
        private Label lblFatto;
        private Label lblErrore;
        private Label label2;
        private TextBox txtImmagini;
        private Button btnImmagini;
        private FolderBrowserDialog folderBrowserDialog1;
        private Label label3;
        private TextBox txtCartellaExcel;
        private TextBox txtNomeFileExcel;
        private Label label4;
        private Button btnCartella;
        private Label lblCarica;
    }
}