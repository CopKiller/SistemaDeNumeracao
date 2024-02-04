using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeNumeracao.Controls.Interface
{
    internal interface ITextBox
    {
        int TextLength { get; }
        int SelectionStart { get; set; }
        int SelectionLength { get; set; }
        string Text { get; set; }
        event EventHandler TextChanged;
        event KeyEventHandler KeyDown;
        event EventHandler Enter;
        event EventHandler Leave;
    }
}
