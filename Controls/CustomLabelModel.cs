using SistemaDeNumeracao.Controls.Interface;
using System.Runtime.CompilerServices;

namespace SistemaDeNumeracao.Controls
{
    internal class CustomLabelModel : Label, ILabel, IControls
    {
        // Implementação da interface ITextBox
        public new string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        int IControls.TextLength => throw new NotImplementedException();
        int IControls.SelectionStart { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        int IControls.SelectionLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
