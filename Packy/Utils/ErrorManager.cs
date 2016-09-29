using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Packy.Utils
{
    public static class ErrorManager
    {

        public static void PromptMsg(this Exception exception)
        {
            if (exception != null)
            {
                MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
