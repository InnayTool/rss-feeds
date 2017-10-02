namespace RSSFeedMaker
{
    partial class WindowFeedInformation
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
            this.Button_OK = new System.Windows.Forms.Button();
            this.Button_Cancel = new System.Windows.Forms.Button();
            this.Text_Title = new System.Windows.Forms.Label();
            this.StringField_TitleRSSFile = new System.Windows.Forms.TextBox();
            this.StringField_LanguageRSSFile = new System.Windows.Forms.TextBox();
            this.StringField_DescriptionRSSFile = new System.Windows.Forms.TextBox();
            this.StringField_LinkRSSFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CheckBox_PublicationDateSet = new System.Windows.Forms.CheckBox();
            this.StringField_GeneratorRSSFile = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Button_OK
            // 
            this.Button_OK.Location = new System.Drawing.Point(180, 379);
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.Size = new System.Drawing.Size(73, 21);
            this.Button_OK.TabIndex = 0;
            this.Button_OK.Text = "OK";
            this.Button_OK.UseVisualStyleBackColor = true;
            this.Button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Button_Cancel.Location = new System.Drawing.Point(259, 379);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(73, 21);
            this.Button_Cancel.TabIndex = 1;
            this.Button_Cancel.Text = "Abbrechen";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            // 
            // Text_Title
            // 
            this.Text_Title.AutoSize = true;
            this.Text_Title.Location = new System.Drawing.Point(20, 25);
            this.Text_Title.Name = "Text_Title";
            this.Text_Title.Size = new System.Drawing.Size(101, 13);
            this.Text_Title.TabIndex = 2;
            this.Text_Title.Text = "Titel der RSS Datei:";
            // 
            // StringField_TitleRSSFile
            // 
            this.StringField_TitleRSSFile.Location = new System.Drawing.Point(20, 45);
            this.StringField_TitleRSSFile.Name = "StringField_TitleRSSFile";
            this.StringField_TitleRSSFile.Size = new System.Drawing.Size(300, 20);
            this.StringField_TitleRSSFile.TabIndex = 3;
            // 
            // StringField_LanguageRSSFile
            // 
            this.StringField_LanguageRSSFile.Location = new System.Drawing.Point(20, 225);
            this.StringField_LanguageRSSFile.Name = "StringField_LanguageRSSFile";
            this.StringField_LanguageRSSFile.Size = new System.Drawing.Size(300, 20);
            this.StringField_LanguageRSSFile.TabIndex = 4;
            // 
            // StringField_DescriptionRSSFile
            // 
            this.StringField_DescriptionRSSFile.Location = new System.Drawing.Point(20, 165);
            this.StringField_DescriptionRSSFile.Name = "StringField_DescriptionRSSFile";
            this.StringField_DescriptionRSSFile.Size = new System.Drawing.Size(300, 20);
            this.StringField_DescriptionRSSFile.TabIndex = 5;
            // 
            // StringField_LinkRSSFile
            // 
            this.StringField_LinkRSSFile.Location = new System.Drawing.Point(20, 105);
            this.StringField_LinkRSSFile.Name = "StringField_LinkRSSFile";
            this.StringField_LinkRSSFile.Size = new System.Drawing.Size(300, 20);
            this.StringField_LinkRSSFile.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Link:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Beschreibung:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Sprache:";
            // 
            // CheckBox_PublicationDateSet
            // 
            this.CheckBox_PublicationDateSet.AutoSize = true;
            this.CheckBox_PublicationDateSet.Location = new System.Drawing.Point(12, 327);
            this.CheckBox_PublicationDateSet.Name = "CheckBox_PublicationDateSet";
            this.CheckBox_PublicationDateSet.Size = new System.Drawing.Size(146, 17);
            this.CheckBox_PublicationDateSet.TabIndex = 10;
            this.CheckBox_PublicationDateSet.Text = "Publikationsdatum setzen";
            this.CheckBox_PublicationDateSet.UseVisualStyleBackColor = true;
            // 
            // StringField_GeneratorRSSFile
            // 
            this.StringField_GeneratorRSSFile.Location = new System.Drawing.Point(20, 285);
            this.StringField_GeneratorRSSFile.Name = "StringField_GeneratorRSSFile";
            this.StringField_GeneratorRSSFile.Size = new System.Drawing.Size(300, 20);
            this.StringField_GeneratorRSSFile.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Generator:";
            // 
            // WindowFeedInformation
            // 
            this.AcceptButton = this.Button_OK;
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Button_Cancel;
            this.ClientSize = new System.Drawing.Size(344, 412);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.StringField_GeneratorRSSFile);
            this.Controls.Add(this.CheckBox_PublicationDateSet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StringField_LinkRSSFile);
            this.Controls.Add(this.StringField_DescriptionRSSFile);
            this.Controls.Add(this.StringField_LanguageRSSFile);
            this.Controls.Add(this.StringField_TitleRSSFile);
            this.Controls.Add(this.Text_Title);
            this.Controls.Add(this.Button_Cancel);
            this.Controls.Add(this.Button_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(350, 440);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(350, 440);
            this.Name = "WindowFeedInformation";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WindowFeedInformation";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_OK;
        private System.Windows.Forms.Button Button_Cancel;
        private System.Windows.Forms.Label Text_Title;
        private System.Windows.Forms.TextBox StringField_TitleRSSFile;
        private System.Windows.Forms.TextBox StringField_LanguageRSSFile;
        private System.Windows.Forms.TextBox StringField_DescriptionRSSFile;
        private System.Windows.Forms.TextBox StringField_LinkRSSFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox CheckBox_PublicationDateSet;
        private System.Windows.Forms.TextBox StringField_GeneratorRSSFile;
        private System.Windows.Forms.Label label4;
    }
}