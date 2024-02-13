using SistemaDeNumeracao.Controls.Interface;
using System.Runtime.CompilerServices;

namespace SistemaDeNumeracao.Controls
{
    internal class CustomLabelModel : Label, ILabel
    {
        // Implementação da interface ITextBox
        public new string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }
    }
}
