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
            this.cb_chooseProject = new System.Windows.Forms.ComboBox();
            this.label_chooseProject = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_load_EA_XML
            // 
            this.btn_load_EA_XML.Location = new System.Drawing.Point(261, 12);
            this.btn_load_EA_XML.Name = "btn_load_EA_XML";
            this.btn_load_EA_XML.Size = new System.Drawing.Size(154, 23);
            this.btn_load_EA_XML.TabIndex = 0;
            this.btn_load_EA_XML.Text = "Wczytaj XML z EA";
            this.btn_load_EA_XML.UseVisualStyleBackColor = true;
            this.btn_load_EA_XML.Click += new System.EventHandler(this.Btn_load_EA_XML_Click);
            // 
            // cb_chooseProject
            // 
            this.cb_chooseProject.FormattingEnabled = true;
            this.cb_chooseProject.Location = new System.Drawing.Point(101, 12);
            this.cb_chooseProject.Name = "cb_chooseProject";
            this.cb_chooseProject.Size = new System.Drawing.Size(154, 21);
            this.cb_chooseProject.TabIndex = 1;
            this.cb_chooseProject.SelectedIndexChanged += new System.EventHandler(this.cb_chooseProject_OnChanged);
            // 
            // label_chooseProject
            // 
            this.label_chooseProject.AutoSize = true;
            this.label_chooseProject.Location = new System.Drawing.Point(12, 16);
            this.label_chooseProject.Name = "label_chooseProject";
            this.label_chooseProject.Size = new System.Drawing.Size(83, 13);
            this.label_chooseProject.TabIndex = 2;
            this.label_chooseProject.Text = "Wybierz projekt:";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 641);
            this.Controls.Add(this.label_chooseProject);
            this.Controls.Add(this.cb_chooseProject);
            this.Controls.Add(this.btn_load_EA_XML);
            this.Name = "MainWindow";
            this.Text = "EAtoTFSConverter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_load_EA_XML;
        private System.Windows.Forms.ComboBox cb_chooseProject;
        private System.Windows.Forms.Label label_chooseProject;
    }
}

