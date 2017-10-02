namespace RSSFeedMaker
{
    partial class WindowMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MenuStrip_Main = new System.Windows.Forms.MenuStrip();
            this.MenuStripItem_File = new System.Windows.Forms.ToolStripMenuItem();
            this.DropDownMenuItem_New = new System.Windows.Forms.ToolStripMenuItem();
            this.DropDownMenuItem_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.DropDownMenuItem_Load = new System.Windows.Forms.ToolStripMenuItem();
            this.DropDownMenuItem_Quit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStripItem_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.DropDownMenuItem_NewLine = new System.Windows.Forms.ToolStripMenuItem();
            this.DropDownMenuItem_DeleteLine = new System.Windows.Forms.ToolStripMenuItem();
            this.DropDownMenuItem_FeedInformation = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGrid_RSSFeed = new System.Windows.Forms.DataGridView();
            this.Column_Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Link = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DropDownMenuItem_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_RSSFeed)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuStrip_Main
            // 
            this.MenuStrip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripItem_File,
            this.MenuStripItem_Edit});
            this.MenuStrip_Main.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.MenuStrip_Main.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip_Main.Name = "MenuStrip_Main";
            this.MenuStrip_Main.Padding = new System.Windows.Forms.Padding(0);
            this.MenuStrip_Main.Size = new System.Drawing.Size(784, 19);
            this.MenuStrip_Main.TabIndex = 0;
            this.MenuStrip_Main.Text = "MenuStripMain";
            // 
            // MenuStripItem_File
            // 
            this.MenuStripItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DropDownMenuItem_New,
            this.DropDownMenuItem_Save,
            this.DropDownMenuItem_SaveAs,
            this.DropDownMenuItem_Load,
            this.DropDownMenuItem_Quit});
            this.MenuStripItem_File.Name = "MenuStripItem_File";
            this.MenuStripItem_File.Size = new System.Drawing.Size(46, 19);
            this.MenuStripItem_File.Text = "Datei";
            // 
            // DropDownMenuItem_New
            // 
            this.DropDownMenuItem_New.Name = "DropDownMenuItem_New";
            this.DropDownMenuItem_New.Size = new System.Drawing.Size(152, 22);
            this.DropDownMenuItem_New.Text = "Neu";
            // 
            // DropDownMenuItem_Save
            // 
            this.DropDownMenuItem_Save.Name = "DropDownMenuItem_Save";
            this.DropDownMenuItem_Save.Size = new System.Drawing.Size(152, 22);
            this.DropDownMenuItem_Save.Text = "Speichern";
            // 
            // DropDownMenuItem_Load
            // 
            this.DropDownMenuItem_Load.Name = "DropDownMenuItem_Load";
            this.DropDownMenuItem_Load.Size = new System.Drawing.Size(152, 22);
            this.DropDownMenuItem_Load.Text = "Laden";
            // 
            // DropDownMenuItem_Quit
            // 
            this.DropDownMenuItem_Quit.Name = "DropDownMenuItem_Quit";
            this.DropDownMenuItem_Quit.Size = new System.Drawing.Size(152, 22);
            this.DropDownMenuItem_Quit.Text = "Beenden";
            // 
            // MenuStripItem_Edit
            // 
            this.MenuStripItem_Edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DropDownMenuItem_NewLine,
            this.DropDownMenuItem_DeleteLine,
            this.DropDownMenuItem_FeedInformation});
            this.MenuStripItem_Edit.Name = "MenuStripItem_Edit";
            this.MenuStripItem_Edit.Size = new System.Drawing.Size(75, 19);
            this.MenuStripItem_Edit.Text = "Bearbeiten";
            // 
            // DropDownMenuItem_NewLine
            // 
            this.DropDownMenuItem_NewLine.Name = "DropDownMenuItem_NewLine";
            this.DropDownMenuItem_NewLine.Size = new System.Drawing.Size(162, 22);
            this.DropDownMenuItem_NewLine.Text = "Neue Zeile";
            // 
            // DropDownMenuItem_DeleteLine
            // 
            this.DropDownMenuItem_DeleteLine.Name = "DropDownMenuItem_DeleteLine";
            this.DropDownMenuItem_DeleteLine.Size = new System.Drawing.Size(162, 22);
            this.DropDownMenuItem_DeleteLine.Text = "Entferne Zeile";
            // 
            // DropDownMenuItem_FeedInformation
            // 
            this.DropDownMenuItem_FeedInformation.Name = "DropDownMenuItem_FeedInformation";
            this.DropDownMenuItem_FeedInformation.Size = new System.Drawing.Size(162, 22);
            this.DropDownMenuItem_FeedInformation.Text = "Feedinformation";
            // 
            // dataGrid_RSSFeed
            // 
            this.dataGrid_RSSFeed.AllowUserToResizeRows = false;
            this.dataGrid_RSSFeed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_RSSFeed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Title,
            this.Column_Link,
            this.Column_Description});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid_RSSFeed.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid_RSSFeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid_RSSFeed.Location = new System.Drawing.Point(0, 19);
            this.dataGrid_RSSFeed.Name = "dataGrid_RSSFeed";
            this.dataGrid_RSSFeed.Size = new System.Drawing.Size(784, 543);
            this.dataGrid_RSSFeed.TabIndex = 1;
            // 
            // Column_Title
            // 
            this.Column_Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_Title.HeaderText = "Titel";
            this.Column_Title.Name = "Column_Title";
            // 
            // Column_Link
            // 
            this.Column_Link.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_Link.HeaderText = "Link";
            this.Column_Link.Name = "Column_Link";
            // 
            // Column_Description
            // 
            this.Column_Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_Description.HeaderText = "Beschreibung";
            this.Column_Description.Name = "Column_Description";
            // 
            // DropDownMenuItem_SaveAs
            // 
            this.DropDownMenuItem_SaveAs.Name = "DropDownMenuItem_SaveAs";
            this.DropDownMenuItem_SaveAs.Size = new System.Drawing.Size(152, 22);
            this.DropDownMenuItem_SaveAs.Text = "Speichern als";
            // 
            // WindowMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.dataGrid_RSSFeed);
            this.Controls.Add(this.MenuStrip_Main);
            this.MainMenuStrip = this.MenuStrip_Main;
            this.Name = "WindowMain";
            this.Text = "RSSFeed Designer";
            this.MenuStrip_Main.ResumeLayout(false);
            this.MenuStrip_Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_RSSFeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip_Main;
        private System.Windows.Forms.ToolStripMenuItem MenuStripItem_File;
        private System.Windows.Forms.ToolStripMenuItem MenuStripItem_Edit;
        private System.Windows.Forms.DataGridView dataGrid_RSSFeed;
        private System.Windows.Forms.ToolStripMenuItem DropDownMenuItem_New;
        private System.Windows.Forms.ToolStripMenuItem DropDownMenuItem_Save;
        private System.Windows.Forms.ToolStripMenuItem DropDownMenuItem_SaveAs;
        private System.Windows.Forms.ToolStripMenuItem DropDownMenuItem_Load;
        private System.Windows.Forms.ToolStripMenuItem DropDownMenuItem_Quit;
        private System.Windows.Forms.ToolStripMenuItem DropDownMenuItem_NewLine;
        private System.Windows.Forms.ToolStripMenuItem DropDownMenuItem_DeleteLine;
        private System.Windows.Forms.ToolStripMenuItem DropDownMenuItem_FeedInformation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Link;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Description;
        

    }
}