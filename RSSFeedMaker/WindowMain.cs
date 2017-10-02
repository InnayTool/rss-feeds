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
        string FilePath;
        public WindowMain()
        {
            InitializeComponent();
            VirtualFile = new YB.VirtualRSSXmlFile();
            FilePath = "";


            this.dataGrid_RSSFeed.CellEndEdit +=new DataGridViewCellEventHandler(this.SynchronizeToVirtualRSSXmlFile);
            this.dataGrid_RSSFeed.Sorted += new EventHandler(this.SynchronizeToVirtualRSSXmlFile);
            this.FormClosing += new FormClosingEventHandler(this.CloseWindow);
            this.DropDownMenuItem_Quit.Click += new EventHandler(this.QuitProgram);
            this.DropDownMenuItem_New.Click += new EventHandler(this.CreateNewProject);
            this.DropDownMenuItem_Load.Click +=new EventHandler(this.LoadProject);
            this.DropDownMenuItem_Save.Click += new EventHandler(this.SaveProject);
            this.DropDownMenuItem_SaveAs.Click += new EventHandler(this.SaveAsProject);

            this.DropDownMenuItem_FeedInformation.Click +=new EventHandler(this.FeedInformation);
            this.DropDownMenuItem_NewLine.Click += new EventHandler(this.AddNewLine);
            this.DropDownMenuItem_DeleteLine.Click += new EventHandler(this.DeleteRows);
            
        }
        private void CloseWindow(object sender, FormClosingEventArgs EventArguments)
        {
            EventArguments.Cancel = true;
            QuitProgram(sender, EventArguments);
        }
        private void QuitProgram(object sender, EventArgs EventArguments)
        {
            DialogResult ResultMessageBox = System.Windows.Forms.MessageBox.Show(
                "Sollen die Änderungen gespeichert werden bevor das Programm geschlossen wird?",
                "RSSFeedDesigner",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);
                
            switch (ResultMessageBox)
            {
                case DialogResult.Cancel:
                    break;
                case DialogResult.Yes:
                    SaveProject(sender, EventArguments);
                    System.Environment.Exit(0);
                    break;
                case DialogResult.No:
                    System.Environment.Exit(0);
                    break;
            }
        }
        private void CreateNewProject(object sender, EventArgs EventArguments)
        {
            DialogResult ResultMessageBox = System.Windows.Forms.MessageBox.Show(
                "Sollen die Änderungen gespeichert werden bevor ein neues Projekt erstellt wird?",
                "RSSFeedDesigner",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            switch (ResultMessageBox)
            {
                case DialogResult.Cancel:
                    break;
                case DialogResult.Yes:
                    SaveProject(sender, EventArguments);
                    goto case DialogResult.No;
                    break;
                case DialogResult.No:
                    VirtualFile = new YB.VirtualRSSXmlFile();
                    dataGrid_RSSFeed.SelectAll();
                    DeleteRows(sender, EventArguments);
                    break;
            }
            
        }
        private void LoadProject(object sender, EventArgs EventArguments)
        {
            DialogResult ResultMessageBox = System.Windows.Forms.MessageBox.Show(
               "Sollen die Änderungen gespeichert werden bevor ein anderes Projekt geladen wird?",
               "RSSFeedDesigner",
               MessageBoxButtons.YesNoCancel,
               MessageBoxIcon.Question);

            switch (ResultMessageBox)
            {
                case DialogResult.Cancel:
                    break;
                case DialogResult.Yes:
                    SaveProject(sender, EventArguments);
                    goto case DialogResult.No;
                    break;
                case DialogResult.No:
                    VirtualFile = new YB.VirtualRSSXmlFile();
                    dataGrid_RSSFeed.SelectAll();
                    DeleteRows(sender, EventArguments);
                    System.Windows.Forms.OpenFileDialog LoadDialog = new OpenFileDialog();
                    LoadDialog.CheckFileExists = true;
                    DialogResult ResultSaveDialog = LoadDialog.ShowDialog();
                    switch (ResultSaveDialog)
                    {
                        case System.Windows.Forms.DialogResult.OK:
                            string FilePath = LoadDialog.FileName;
                            VirtualFile = YB.VirtualRSSXmlFile.Load(FilePath);
                            break;
                    }
                    foreach (YB.VirtualRSSXmlFile.item Item in VirtualFile.ItemList)
                    {
                        AddNewLine(sender, EventArguments);
                        this.dataGrid_RSSFeed[0, (dataGrid_RSSFeed.Rows.Count - 2)].Value = Item.Title;
                        this.dataGrid_RSSFeed[1, (dataGrid_RSSFeed.Rows.Count - 2)].Value = Item.Link;
                        this.dataGrid_RSSFeed[2, (dataGrid_RSSFeed.Rows.Count - 2)].Value = Item.Description;
                    }
                    
                    break;
            }
        }
        private void SaveProject(object sender, EventArgs EventArguments)
        {
            SynchronizeToVirtualRSSXmlFile(sender, EventArguments);
            VirtualFile.WriteToFile(FilePath);

        }
        private void SaveAsProject(object sender, EventArgs EventArguments)
        {
            SynchronizeToVirtualRSSXmlFile(sender, EventArguments);
            System.Windows.Forms.SaveFileDialog SaveDialog = new SaveFileDialog();
            DialogResult ResultSaveDialog = SaveDialog.ShowDialog();
            
            if (ResultSaveDialog == System.Windows.Forms.DialogResult.OK)
            {
                VirtualFile.WriteToFile(SaveDialog.FileName);
                System.Windows.Forms.MessageBox.Show(SaveDialog.FileName);
            }
        }
        private void SynchronizeToVirtualRSSXmlFile(object sender, EventArgs EventArguments)
        {
            for (int i = 0; i < (this.dataGrid_RSSFeed.Rows.Count-1); i++)
            {
                if (i < VirtualFile.ItemList.Count)
                {

                    VirtualFile.ItemList[i].Title = (string)dataGrid_RSSFeed.Rows[i].Cells[0].Value;
                    VirtualFile.ItemList[i].Link = (string)dataGrid_RSSFeed.Rows[i].Cells[1].Value;
                    VirtualFile.ItemList[i].Description = (string)dataGrid_RSSFeed.Rows[i].Cells[2].Value;
                }
                else
                {
                    VirtualFile.AddItem();
                    VirtualFile.ItemList[i].Title = (string)dataGrid_RSSFeed.Rows[i].Cells[0].Value;
                    VirtualFile.ItemList[i].Link = (string)dataGrid_RSSFeed.Rows[i].Cells[1].Value;
                    VirtualFile.ItemList[i].Description = (string)dataGrid_RSSFeed.Rows[i].Cells[2].Value;
                }
            }
            VirtualFile.Generator = "RSSFeedDesigner";

        }

        private void FeedInformation(object sender, EventArgs EventArguments) //TODO:
        {
            WindowFeedInformation FeedInformation = new WindowFeedInformation();
            FeedInformation.Set_StringField_DescriptionRSSFile(VirtualFile.Description);
            FeedInformation.Set_StringField_TitleRSSFile(VirtualFile.Title);
            FeedInformation.Set_StringField_LinkRSSFile(VirtualFile.Link);
            FeedInformation.Set_StringField_LanguageRSSFile(VirtualFile.Language);
            FeedInformation.Set_StringField_GeneratorRSSFile(VirtualFile.Generator);
            Application.EnableVisualStyles();
            DialogResult ResultFeedInformation = FeedInformation.ShowDialog();
            if (ResultFeedInformation == DialogResult.OK)
            {
                if (FeedInformation.Get_CheckBox_SetPublicationDate())
                {
                    //TODO:
                }
                VirtualFile.Title = FeedInformation.Get_StringField_TitleRSSFile();
                VirtualFile.Link = FeedInformation.Get_StringField_LinkRSSFile();
                VirtualFile.Description = FeedInformation.Get_StringField_DescriptionRSSFile();
                VirtualFile.Language = FeedInformation.Get_StringField_LanguageRSSFile();
                VirtualFile.Generator = FeedInformation.Get_StringField_GeneratorRSSFile();
            }
        }
        private void DeleteRows(object sender, EventArgs EventArguments)
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
        private void AddNewLine(object sender, EventArgs EventArguments)
        {
            this.dataGrid_RSSFeed.RowCount++;
        }

    }
}
