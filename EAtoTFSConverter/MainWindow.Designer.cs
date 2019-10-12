namespace EAtoTFSConverter
{
    partial class MainWindow
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
            this.btn_load_EA_XML = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_load_EA_XML
            // 
            this.btn_load_EA_XML.Location = new System.Drawing.Point(12, 12);
            this.btn_load_EA_XML.Name = "btn_load_EA_XML";
            this.btn_load_EA_XML.Size = new System.Drawing.Size(154, 23);
            this.btn_load_EA_XML.TabIndex = 0;
            this.btn_load_EA_XML.Text = "Wczytaj XML z EA";
            this.btn_load_EA_XML.UseVisualStyleBackColor = true;
            this.btn_load_EA_XML.Click += new System.EventHandler(this.Btn_load_EA_XML_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 641);
            this.Controls.Add(this.btn_load_EA_XML);
            this.Name = "MainWindow";
            this.Text = "EAtoTFSConverter";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_load_EA_XML;
    }
}

