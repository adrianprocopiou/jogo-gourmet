namespace GourmetGame.WindowsForms
{
    partial class FrmPrincipal
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
            lblInicioJogo = new Label();
            btnInicioJogo = new Button();
            SuspendLayout();
            // 
            // lblInicioJogo
            // 
            lblInicioJogo.AutoSize = true;
            lblInicioJogo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblInicioJogo.Location = new Point(68, 24);
            lblInicioJogo.Name = "lblInicioJogo";
            lblInicioJogo.Size = new Size(172, 15);
            lblInicioJogo.TabIndex = 0;
            lblInicioJogo.Text = "Pense em um prato que gosta";
            // 
            // btnInicioJogo
            // 
            btnInicioJogo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnInicioJogo.Location = new Point(114, 55);
            btnInicioJogo.Name = "btnInicioJogo";
            btnInicioJogo.Size = new Size(75, 23);
            btnInicioJogo.TabIndex = 1;
            btnInicioJogo.Text = "OK";
            btnInicioJogo.UseVisualStyleBackColor = true;
            btnInicioJogo.Click += btnInicioJogo_ClickAsync;
            // 
            // FrmPrincipal
            // 
            AcceptButton = btnInicioJogo;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(313, 107);
            Controls.Add(btnInicioJogo);
            Controls.Add(lblInicioJogo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = " Jogo Gourmet";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblInicioJogo;
        private Button btnInicioJogo;
    }
}
