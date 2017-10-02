using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RSSFeedMaker
{
    public partial class WindowMain : Form
    {
        YB.VirtualRSSXmlFile VirtualFile;
        System.IO.FileInfo FilePath;
        public WindowMain()
        {
            InitializeComponent();
            VirtualFile = new YB.VirtualRSSXmlFile();
            FilePath = null;


            this.dataGrid_RSSFeed.CellEndEdit += new DataGridViewCellEventHandler(this.DataGrid_RSSFeed_CellEndEdit);
            this.dataGrid_RSSFeed.Sorted += new EventHandler(this.DataGrid_RSSFeed_Sorted);
            this.FormClosing += new FormClosingEventHandler(this.FormClosing_Click);
            this.DropDownMenuItem_Quit.Click += new EventHandler(this.DropDownMenuItem_Quit_Click);
            this.DropDownMenuItem_New.Click += new EventHandler(this.DropDownMenuItem_New_Click);
            this.DropDownMenuItem_Load.Click += new EventHandler(this.DropDownMenuItem_Load_Click);
            this.DropDownMenuItem_Save.Click += new EventHandler(this.DropDownMenuItem_Save_Click);
            this.DropDownMenuItem_SaveAs.Click += new EventHandler(this.DropDownMenuItem_SaveAs_Click);

            this.DropDownMenuItem_FeedInformation.Click += new EventHandler(this.DropDownMenuItem_FeedInformation_Click);
            this.DropDownMenuItem_NewLine.Click += new EventHandler(this.DropDownMenuItem_NewLine_Click);
            this.DropDownMenuItem_DeleteLine.Click += new EventHandler(this.DropDownMenuItem_DeleteLine_Click);

            this.DropDownMenuItem_Info.Click +=new EventHandler(this.DropDownMenuItem_Info_Click);
            
        }
        private void DataGrid_RSSFeed_CellEndEdit(object sender, EventArgs EventArguments)
        {
            SynchronizeToVirtualRSSXmlFile();
        }
        private void DataGrid_RSSFeed_Sorted(object sender, EventArgs EventArguments)
        {
            SynchronizeToVirtualRSSXmlFile();
        }
        private void FormClosing_Click(object sender, FormClosingEventArgs EventArguments)
        {
            EventArguments.Cancel = true;
            if (SaveBeforeQuestion() != 0)
            {
                System.Environment.Exit(0);
            }
        }
        private void DropDownMenuItem_Quit_Click(object sender, EventArgs EventArguments)
        {
            if (SaveBeforeQuestion() != 0)
            {
                System.Environment.Exit(0);
            }
        }
        private void DropDownMenuItem_New_Click(object sender, EventArgs EventArguments)
        {
            if (SaveBeforeQuestion() != 0)
            {
                CreateNewProject();
            }
        }
        private void DropDownMenuItem_Load_Click(object sender, EventArgs EventArguments)
        {
            if (SaveBeforeQuestion() != 0)
            {
                LoadProject(null);
            }
        }
        private void DropDownMenuItem_Save_Click(object sender, EventArgs EventArguments)
        {
            SaveProjectWithNewFilename(false);
        }
        private void DropDownMenuItem_SaveAs_Click(object sender, EventArgs EventArguments)
        {
            SaveProjectWithNewFilename(true);
        }
        private void DropDownMenuItem_FeedInformation_Click(object sender, EventArgs EventArguments)
        {
            FeedInformation();
        }
        private void DropDownMenuItem_NewLine_Click(object sender, EventArgs EventArguments)
        {
            AddNewLine();
        }
        private void DropDownMenuItem_DeleteLine_Click(object sender, EventArgs EventArguments)
        {
            DeleteRows();
        }
        private void DropDownMenuItem_Info_Click(object sender, EventArgs EventArguments)
        {
            ShowInfo();
        }


        private int SaveBeforeQuestion()
        {
            DialogResult ResultMessageBox = System.Windows.Forms.MessageBox.Show(
                "Sollen vorher die Änderungen gespeichert werden ?",
                "RSSFeedDesigner",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);
                
            switch (ResultMessageBox)
            {
                case DialogResult.Cancel:
                    return 0;
                case DialogResult.Yes:
                    SaveProjectWithNewFilename(false);
                    
                    return 1;
                case DialogResult.No:
                    
                    return 2;
                default:
                    return 3;
            }
        }
        private void CreateNewProject()
        {
            VirtualFile = new YB.VirtualRSSXmlFile();
            dataGrid_RSSFeed.SelectAll();
            DeleteRows();
        }
        internal void LoadProject(System.IO.FileInfo FilePath)
        {
            VirtualFile = new YB.VirtualRSSXmlFile();
            dataGrid_RSSFeed.SelectAll();
            DeleteRows();
            
            if (FilePath == null)
            {
                System.Windows.Forms.OpenFileDialog LoadDialog = new OpenFileDialog();
                LoadDialog.CheckFileExists = true;
                if (LoadDialog.ShowDialog() == DialogResult.OK)
                {
                    this.FilePath = new System.IO.FileInfo(LoadDialog.FileName);
                }
                else
                {
                    return;
                }
            }
            else
            {
                this.FilePath = FilePath;
            }
            VirtualFile = YB.VirtualRSSXmlFile.Load(this.FilePath.ToString());
            if (VirtualFile == null)
            {
                System.Windows.Forms.MessageBox.Show("Die Angegebene Datei kann nicht mit dem XmlLinQ-Modul gelesen werden!", "RSSFeed Designer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CreateNewProject();
            }
            else
            {
                foreach (YB.VirtualRSSXmlFile.item Item in VirtualFile.ItemList)
                {
                    AddNewLine();
                    this.dataGrid_RSSFeed[0, (dataGrid_RSSFeed.Rows.Count - 2)].Value = Item.Title;
                    this.dataGrid_RSSFeed[1, (dataGrid_RSSFeed.Rows.Count - 2)].Value = Item.Link;
                    this.dataGrid_RSSFeed[2, (dataGrid_RSSFeed.Rows.Count - 2)].Value = Item.Description;
                }
            }

            
        }
        private void SaveProjectWithNewFilename(bool SaveModeNewFileName)
        {
            SynchronizeToVirtualRSSXmlFile();
            if (VirtualFile.Title == "" | VirtualFile.Title == null)
            {
                FeedInformation();
            }
            if (SaveModeNewFileName | FilePath == null)
            {
                System.Windows.Forms.SaveFileDialog SaveDialog = new SaveFileDialog();
                DialogResult ResultSaveDialog = SaveDialog.ShowDialog();

                if (ResultSaveDialog == System.Windows.Forms.DialogResult.OK)
                {
                    FilePath = new System.IO.FileInfo(SaveDialog.FileName);
                }
                else
                {
                    return;
                }
            }
            VirtualFile.LastBuildDate = DateTime.Now.ToUniversalTime().ToString("r");
            VirtualFile.WriteToFile(FilePath.ToString());
        }
        
        private void SynchronizeToVirtualRSSXmlFile()
        {
            dataGrid_RSSFeed.EndEdit();
            for (int i = 0; i < (this.dataGrid_RSSFeed.Rows.Count-1); i++)
            {
                if (i < VirtualFile.ItemList.Count)
                {
                    if (VirtualFile.ItemList[i].Title != (string)dataGrid_RSSFeed.Rows[i].Cells[0].Value)
                    {
                        VirtualFile.ItemList[i].Title = (string)dataGrid_RSSFeed.Rows[i].Cells[0].Value;
                        VirtualFile.ItemList[i].PublicationDate = DateTime.Now.ToUniversalTime().ToString("r");
                    }
                    if (VirtualFile.ItemList[i].Link != (string)dataGrid_RSSFeed.Rows[i].Cells[1].Value)
                    {
                        VirtualFile.ItemList[i].Link = (string)dataGrid_RSSFeed.Rows[i].Cells[1].Value;
                        VirtualFile.ItemList[i].PublicationDate = DateTime.Now.ToUniversalTime().ToString("r");
                    }
                    if (VirtualFile.ItemList[i].Description != (string)dataGrid_RSSFeed.Rows[i].Cells[2].Value)
                    {
                        VirtualFile.ItemList[i].Description = (string)dataGrid_RSSFeed.Rows[i].Cells[2].Value;
                        VirtualFile.ItemList[i].PublicationDate = DateTime.Now.ToUniversalTime().ToString("r");
                    }
                }
                else
                {
                    VirtualFile.AddItem();
                    VirtualFile.ItemList[i].PublicationDate = DateTime.Now.ToUniversalTime().ToString("r");
                    VirtualFile.ItemList[i].Title = (string)dataGrid_RSSFeed.Rows[i].Cells[0].Value;
                    VirtualFile.ItemList[i].Link = (string)dataGrid_RSSFeed.Rows[i].Cells[1].Value;
                    VirtualFile.ItemList[i].Description = (string)dataGrid_RSSFeed.Rows[i].Cells[2].Value;
                }
            }
            if (VirtualFile.Generator == "" | VirtualFile.Generator == null)
            {
                VirtualFile.Generator = "RSSFeedDesigner";
            }

        }

        private void FeedInformation() //TODO:
        {
            WindowFeedInformation FeedInformation = new WindowFeedInformation();
            FeedInformation.Set_StringField_DescriptionRSSFile(VirtualFile.Description);
            FeedInformation.Set_StringField_TitleRSSFile(VirtualFile.Title);
            FeedInformation.Set_StringField_LinkRSSFile(VirtualFile.Link);
            FeedInformation.Set_StringField_LanguageRSSFile(VirtualFile.Language);
            FeedInformation.Set_StringField_GeneratorRSSFile(VirtualFile.Generator);
            Application.EnableVisualStyles();
            DialogResult ResultFeedInformation = FeedInformation.ShowDialog();
            if (ResultFeedInformation == DialogResult.Cancel)
            {
                if (FeedInformation.Get_CheckBox_SetPublicationDate())
                {
                    VirtualFile.PublicationDate = DateTime.Now.ToUniversalTime().ToString("r");
                }
                VirtualFile.Title = FeedInformation.Get_StringField_TitleRSSFile();
                VirtualFile.Link = FeedInformation.Get_StringField_LinkRSSFile();
                VirtualFile.Description = FeedInformation.Get_StringField_DescriptionRSSFile();
                VirtualFile.Language = FeedInformation.Get_StringField_LanguageRSSFile();
                VirtualFile.Generator = FeedInformation.Get_StringField_GeneratorRSSFile();
            }
        }
        private void DeleteRows()
        {
            foreach (DataGridViewCell Cell in this.dataGrid_RSSFeed.SelectedCells)
            {
                bool IsIn = false;
                foreach (DataGridViewRow Row in this.dataGrid_RSSFeed.SelectedRows)
                {
                    if (Row == Cell.OwningRow)
                    {
                        IsIn = true;
                        break;
                    }
                }
                if (!IsIn)
                {
                    Cell.OwningRow.Selected = true;
                }
            }
            foreach (DataGridViewRow Row in this.dataGrid_RSSFeed.SelectedRows)
            {
                if (Row.IsNewRow !=true)
                {
                    this.dataGrid_RSSFeed.Rows.Remove(Row);
                }
            }
        }
        private void AddNewLine()
        {
            this.dataGrid_RSSFeed.RowCount++;
        }

        private void ShowInfo()
        {
            char CopyChar = (char)169;
            MessageBox.Show("RSSFeedDesigner by Yannick Bungers\nCopyright" + CopyChar + " by 2011 proggytool Coop.","RSSFeedDesigner");
        }
    }
}
