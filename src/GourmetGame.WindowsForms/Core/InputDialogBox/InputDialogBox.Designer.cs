namespace GourmetGame.WindowsForms
{
    partial class InputDialogBox
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
            lblCaption = new Label();
            txtUserInput = new TextBox();
            btnOK = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // lblCaption
            // 
            lblCaption.Anchor = AnchorStyles.None;
            lblCaption.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCaption.Location = new Point(12, 9);
            lblCaption.Name = "lblCaption";
            lblCaption.Size = new Size(351, 24);
            lblCaption.TabIndex = 0;
            lblCaption.Text = "Caption";
            lblCaption.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtUserInput
            // 
            txtUserInput.Location = new Point(34, 47);
            txtUserInput.Name = "txtUserInput";
            txtUserInput.Size = new Size(295, 23);
            txtUserInput.TabIndex = 1;
            // 
            // btnOK
            // 
            btnOK.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnOK.Location = new Point(97, 85);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 2;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCancelar.Location = new Point(178, 85);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // InputDialogBox
            // 
            AcceptButton = btnOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(375, 121);
            Controls.Add(btnCancelar);
            Controls.Add(btnOK);
            Controls.Add(txtUserInput);
            Controls.Add(lblCaption);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "InputDialogBox";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "InputDialogBox";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCaption;
        private TextBox txtUserInput;
        private Button btnOK;
        private Button btnCancelar;
    }
}