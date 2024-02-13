using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeNumeracao.Controls.Interface
{
    internal interface ITextBox : IControls
    {
        int TextLength { get; }
        int SelectionStart { get; set; }
        int SelectionLength { get; set; }
    }
}
