using SistemaDeNumeracao.Controls.Interface;
using System.Runtime.CompilerServices;

namespace SistemaDeNumeracao.Controls
{
    internal class CustomLabelModel : Label, ILabel, IFusionControls
    {
        // Implementação da interface ITextBox
        public new string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        int IFusionControls.TextLength => throw new NotImplementedException();
        int IFusionControls.SelectionStart { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        int IFusionControls.SelectionLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
