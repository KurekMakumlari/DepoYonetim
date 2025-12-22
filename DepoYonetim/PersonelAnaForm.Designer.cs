namespace DepoYonetim
{
    partial class PersonelAnaForm
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
            this.label_ID = new System.Windows.Forms.Label();
            this.label_Ad = new System.Windows.Forms.Label();
            this.label_Soyad = new System.Windows.Forms.Label();
            this.label_Soyad_Out = new System.Windows.Forms.Label();
            this.label_Ad_Out = new System.Windows.Forms.Label();
            this.label_ID_Out = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_ID
            // 
            this.label_ID.AutoSize = true;
            this.label_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_ID.Location = new System.Drawing.Point(84, 36);
            this.label_ID.Name = "label_ID";
            this.label_ID.Size = new System.Drawing.Size(52, 29);
            this.label_ID.TabIndex = 0;
            this.label_ID.Text = "ID :";
            // 
            // label_Ad
            // 
            this.label_Ad.AutoSize = true;
            this.label_Ad.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_Ad.Location = new System.Drawing.Point(78, 85);
            this.label_Ad.Name = "label_Ad";
            this.label_Ad.Size = new System.Drawing.Size(58, 29);
            this.label_Ad.TabIndex = 1;
            this.label_Ad.Text = "Ad :";
            // 
            // label_Soyad
            // 
            this.label_Soyad.AutoSize = true;
            this.label_Soyad.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_Soyad.Location = new System.Drawing.Point(36, 141);
            this.label_Soyad.Name = "label_Soyad";
            this.label_Soyad.Size = new System.Drawing.Size(100, 29);
            this.label_Soyad.TabIndex = 2;
            this.label_Soyad.Text = "Soyad :";
            // 
            // label_Soyad_Out
            // 
            this.label_Soyad_Out.AutoSize = true;
            this.label_Soyad_Out.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_Soyad_Out.Location = new System.Drawing.Point(146, 141);
            this.label_Soyad_Out.Name = "label_Soyad_Out";
            this.label_Soyad_Out.Size = new System.Drawing.Size(69, 29);
            this.label_Soyad_Out.TabIndex = 5;
            this.label_Soyad_Out.Text = "____";
            // 
            // label_Ad_Out
            // 
            this.label_Ad_Out.AutoSize = true;
            this.label_Ad_Out.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_Ad_Out.Location = new System.Drawing.Point(146, 85);
            this.label_Ad_Out.Name = "label_Ad_Out";
            this.label_Ad_Out.Size = new System.Drawing.Size(69, 29);
            this.label_Ad_Out.TabIndex = 4;
            this.label_Ad_Out.Text = "____";
            // 
            // label_ID_Out
            // 
            this.label_ID_Out.AutoSize = true;
            this.label_ID_Out.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_ID_Out.Location = new System.Drawing.Point(146, 36);
            this.label_ID_Out.Name = "label_ID_Out";
            this.label_ID_Out.Size = new System.Drawing.Size(69, 29);
            this.label_ID_Out.TabIndex = 3;
            this.label_ID_Out.Text = "____";
            // 
            // PersonelAnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label_Soyad_Out);
            this.Controls.Add(this.label_Ad_Out);
            this.Controls.Add(this.label_ID_Out);
            this.Controls.Add(this.label_Soyad);
            this.Controls.Add(this.label_Ad);
            this.Controls.Add(this.label_ID);
            this.Name = "PersonelAnaForm";
            this.Text = "PersonelAnaForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_ID;
        private System.Windows.Forms.Label label_Ad;
        private System.Windows.Forms.Label label_Soyad;
        private System.Windows.Forms.Label label_Soyad_Out;
        private System.Windows.Forms.Label label_Ad_Out;
        private System.Windows.Forms.Label label_ID_Out;
    }
}