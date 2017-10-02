using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YB
{
    namespace XMessage
    {

        public class Box
        {
            readonly string program_name;
            readonly string autor;
            const int Ok = 1;
            const int Cancel = 2;
            const int Yes = 6;
            const int No = 7;
            public Box(string autor, string program_name)
            {
                this.program_name = program_name;
                this.autor = autor;

            }

            public void noavailable()
            {
                MessageBox.Show("Dieses Element ist in dieser Version nicht verfügbar!", program_name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            #region Error Requests

            public void Error()
            {
                MessageBox.Show("Ein nicht identifizierter Fehler ist aufgetreten!", program_name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            public void Error(int Errorcode)
            {
                MessageBox.Show("Errorcode" + Errorcode, program_name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion

            public byte Question(string sQuestion, byte buttoncode)
            {
                switch (buttoncode)
                {
                    case 1:
                        break;
                }
                return (byte)MessageBox.Show(sQuestion, program_name, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            }

            public void Request(string sAusgabe)
            {
                MessageBox.Show(sAusgabe, program_name, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            public void Succes()
            {
                MessageBox.Show("Erfolg!", program_name);
            }


        }
    }
}
