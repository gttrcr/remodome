using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpdateManager
{
    public class Messaggi
    {
        private static readonly string BOXNAME = "Program Update Manager";

        public static DialogResult ShowError(string messaggio)
        {
            return MessageBox.Show(messaggio, BOXNAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult ShowWarning(string messaggio)
        {
            return MessageBox.Show(messaggio, BOXNAME, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}