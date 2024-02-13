using SistemaDeNumeracao.Controls.Interface;
using SistemaDeNumeracao.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeNumeracao.Logic.Binary
{
    internal class BinaryClass
    {
        private LogicControl logicControl;

        public BinaryClass(LogicControl logicControl)
        {
            this.logicControl = logicControl;

            SetControlActive();
        }

        bool ControlTextBinary_BackSpace = false;

        private void SetControlActive()
        {
            logicControl.controlActive = ControlsType.ControlTextBinary;
        }
        private ControlsType GetControlActive()
        {
            return logicControl.controlActive;
        }
        public void ControlTextBinary_Change(object sender, EventArgs e)
        {
            var controlElement = logicControl.controls.GetItem(ControlsType.ControlTextBinary) as ITextBox;
            var text = controlElement.Text;

            // Remova o manipulador de eventos temporariamente
            controlElement.TextChanged -= ControlTextBinary_Change;

            // Verifique se o controle atual está ativo.
            if (GetControlActive() == ControlsType.ControlTextBinary)
            {
                if (ControlTextBinary_BackSpace)
                {
                    ControlTextBinary_BackSpace = false;
                }
                else
                {
                    logicControl.UpdateValues();
                }

                controlElement.SelectionStart = controlElement.TextLength;
            }


            // Acione o manipulador de eventos.
            logicControl.controls.GetItem(key: ControlsType.ControlTextBinary).TextChanged += ControlTextBinary_Change;
        }
        public void ControlTextBinary_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                var controlElement = (ITextBox)logicControl.controls.GetItem(ControlsType.ControlTextBinary);
                var sstring = controlElement.Text;

                if (controlElement.SelectionLength == 0 && controlElement.SelectionStart > 0)
                {
                    int positionBeforeBackspace = controlElement.SelectionStart - 1;

                    if (controlElement.Text[positionBeforeBackspace] == ' ' ||
                        positionBeforeBackspace >= Environment.NewLine.Length &&
                         controlElement.Text.Substring(positionBeforeBackspace + 1 - Environment.NewLine.Length, Environment.NewLine.Length) == Environment.NewLine)
                    {
                        // Pode prosseguir com a exclusão
                        ControlTextBinary_BackSpace = true;
                    }
                }
            }
        }
        public bool IsBinary(string bin)
        {
            return bin.All(c => c == '0' || c == '1');
        }
        public string FormatBinaryToLayout(string controlBinaryText)
        {
            // Limites de caracteres por linha e caracteres para adicionar uma quebra de linha
            int characterLimit = 8;
            int characterToSpace = 4;

            StringBuilder novoTexto = new StringBuilder();

            controlBinaryText = controlBinaryText.Replace(" ", "").Replace(Environment.NewLine, "");

            int charIndex = 0;
            foreach (char c in controlBinaryText)
            {
                novoTexto.Append(c);
                charIndex++;

                if (charIndex % characterToSpace == 0 && charIndex % characterLimit != 0)
                    novoTexto.Append(" ");

                if (charIndex % characterLimit == 0)
                    novoTexto.Append(Environment.NewLine);
            }

            return novoTexto.ToString();
        }
    }
}
