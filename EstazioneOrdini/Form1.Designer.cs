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
            SuspendLayout();
            // 
            // txtNumOrdine
            // 
            txtNumOrdine.Location = new Point(256, 83);
            txtNumOrdine.Name = "txtNumOrdine";
            txtNumOrdine.Size = new Size(142, 23);
            txtNumOrdine.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(151, 86);
            label1.Name = "label1";
            label1.Size = new Size(99, 15);
            label1.TabIndex = 1;
            label1.Text = "INSERIRE ORDINE";
            // 
            // btnExcel
            // 
            btnExcel.Location = new Point(404, 82);
            btnExcel.Name = "btnExcel";
            btnExcel.Size = new Size(75, 23);
            btnExcel.TabIndex = 2;
            btnExcel.Text = "EXCEL";
            btnExcel.UseVisualStyleBackColor = true;
            btnExcel.Click += btnExcel_Click;
            // 
            // lblFatto
            // 
            lblFatto.AutoSize = true;
            lblFatto.Location = new Point(498, 86);
            lblFatto.Name = "lblFatto";
            lblFatto.Size = new Size(39, 15);
            lblFatto.TabIndex = 3;
            lblFatto.Text = "FATTO";
            lblFatto.Visible = false;
            // 
            // lblErrore
            // 
            lblErrore.AutoSize = true;
            lblErrore.Location = new Point(498, 86);
            lblErrore.Name = "lblErrore";
            lblErrore.Size = new Size(131, 15);
            lblErrore.TabIndex = 4;
            lblErrore.Text = "ORDINE NON TROVATO";
            lblErrore.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblErrore);
            Controls.Add(lblFatto);
            Controls.Add(btnExcel);
            Controls.Add(label1);
            Controls.Add(txtNumOrdine);
            Name = "Form1";
            Text = "Form1";
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
    }
}