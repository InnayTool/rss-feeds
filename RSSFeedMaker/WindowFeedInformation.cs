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
    public partial class WindowFeedInformation : Form
    {
        public WindowFeedInformation()
        {
            InitializeComponent();
        }
        internal string Get_StringField_TitleRSSFile()
        {
            return StringField_TitleRSSFile.Text;
        }
        internal string Get_StringField_LinkRSSFile()
        {
            return StringField_LinkRSSFile.Text;
        }
        internal string Get_StringField_DescriptionRSSFile()
        {
            return StringField_DescriptionRSSFile.Text;
        }
        internal string Get_StringField_LanguageRSSFile()
        {
            return StringField_LanguageRSSFile.Text;
        }
        internal string Get_StringField_GeneratorRSSFile()
        {
            return StringField_GeneratorRSSFile.Text;
        }
        internal bool Get_CheckBox_SetPublicationDate()
        {
            return CheckBox_PublicationDateSet.Checked;
        }

        internal void Set_StringField_TitleRSSFile(string Title)
        {
            StringField_TitleRSSFile.Text = Title;
        }
        internal void Set_StringField_LinkRSSFile(string Link)
        {
            StringField_LinkRSSFile.Text = Link;
        }
        internal void Set_StringField_DescriptionRSSFile(string Description)
        {
            StringField_DescriptionRSSFile.Text = Description;
        }
        internal void Set_StringField_LanguageRSSFile(string Language)
        {
            StringField_LanguageRSSFile.Text = Language;
        }
        internal void Set_StringField_GeneratorRSSFile(string Generator)
        {
            StringField_GeneratorRSSFile.Text = Generator;
        }
        internal void Set_CheckBox_SetPublicationDate(bool Checked)
        {
            CheckBox_PublicationDateSet.Checked = Checked;
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
