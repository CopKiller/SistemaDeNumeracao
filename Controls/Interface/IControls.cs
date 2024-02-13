using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeNumeracao.Controls.Interface
{
    internal interface IControls
    {
        string Text { get; set; }
        event EventHandler TextChanged;
        event KeyEventHandler KeyDown;
        event EventHandler Enter;
        event EventHandler Leave;
    }
}
