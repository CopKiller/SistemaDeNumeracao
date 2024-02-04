using SistemaDeNumeracao.Controls.Interface;
using System.Runtime.CompilerServices;

namespace SistemaDeNumeracao.Controls
{
    internal class CustomTextBoxModel : TextBox, ITextBox, IFusionControls
    {
        // Implementação da interface ITextBox
        public new int SelectionStart { get { return base.SelectionStart; } set { base.SelectionStart = value; } }
        public new int SelectionLength { get { return base.SelectionLength; } set { base.SelectionLength = value; } }
        public new string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        // Implementação do evento TextChanged
        public new event EventHandler TextChanged
        {
            add { base.TextChanged += value; }
            remove { base.TextChanged -= value; }
        }
        // Implementação do evento KeyDown
        public new event KeyEventHandler KeyDown
        {
            add { base.KeyDown += value; }
            remove { base.KeyDown -= value; }
        }
        // Implementação do evento Enter
        public new event EventHandler Enter
        {
            add { base.Enter += value; }
            remove { base.Enter -= value; }
        }
        // Implementação do evento Leave
        public new event EventHandler Leave
        {
            add { base.Leave += value; }
            remove { base.Leave -= value; }
        }
    }
}
