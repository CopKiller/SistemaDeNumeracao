using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeNumeracao
{
    public enum Controls
    {
        txtBin = 1,
        txtDec = 2,
        txtOct = 3,
        txtHex = 4,
    }
    public class Logic
    {
        #region Construtor
        private frmMain formulario;
        public Logic(frmMain frm)
        {
            formulario = frm;
        }
        #endregion

        #region Binário
        // Adicionado esta abordagem, por conta de não estar apagando o caractere de espaço, pois o tratamento
        // dentro do método de processamento de formato binário, retira todos os espaços e quebra de linha no início
        // do algarítmo, foi adaptado também para apagar quebras de linha apenas no binário é necessário!
        bool txtBin_BackSpace = false;
        public void txtBin_Change(object sender, EventArgs e)
        {
            // Limites de caracteres por linha e caracteres para adicionar uma quebra de linha
            int characterLimit = 8;
            int characterToSpace = 4;

            // Remova os espaços em branco do texto
            var txtBin = formulario.txtBin.Text;

            // Verifique se há algo no campo binário
            if (string.IsNullOrWhiteSpace(txtBin))
            {
                // Lidar com o caso em que não há nada no campo binário
                UpdateValues();
                return;
            }

            // Remova o manipulador de eventos temporariamente
            formulario.txtBin.TextChanged -= txtBin_Change;

            if (txtBin_BackSpace)
            {
                txtBin_BackSpace = false;

                // Adicione o manipulador de eventos de volta
                formulario.txtBin.TextChanged += txtBin_Change;
                return;
            }

            StringBuilder novoTexto = new StringBuilder();

            txtBin = txtBin.Replace(" ", "").Replace(Environment.NewLine, "");

            int charIndex = 0;
            foreach (char c in txtBin)
            {
                novoTexto.Append(c);
                charIndex++;

                if (charIndex % characterToSpace == 0 && charIndex % characterLimit != 0)
                    novoTexto.Append(" ");

                if (charIndex % characterLimit == 0)
                    novoTexto.Append(Environment.NewLine);
            }

            formulario.txtBin.Text = string.Empty;
            formulario.txtBin.Text += novoTexto.ToString();

            formulario.txtBin.SelectionStart = novoTexto.Length;

            // Atualize os TextBoxes
            UpdateValues();

            // Adicione o manipulador de eventos de volta
            formulario.txtBin.TextChanged += txtBin_Change;
        }

        public void txtBin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                var sstring = formulario.txtBin.Text;

                if (formulario.txtBin.SelectionLength == 0 && formulario.txtBin.SelectionStart > 0)
                {
                    int positionBeforeBackspace = formulario.txtBin.SelectionStart - 1;

                    if (formulario.txtBin.Text[positionBeforeBackspace] == ' ' ||
                        (positionBeforeBackspace >= Environment.NewLine.Length &&
                         formulario.txtBin.Text.Substring(positionBeforeBackspace + 1 - Environment.NewLine.Length, Environment.NewLine.Length) == Environment.NewLine))
                    {
                        // Pode prosseguir com a exclusão
                        txtBin_BackSpace = true;
                    }
                }
            }
        }

        private bool IsBin(string bin)
        {
            return bin.All(c => c == '0' || c == '1');
        }
        #endregion


        public void UpdateValues()
        {
            var txtBin = formulario.txtBin.Text.Replace(" ", "").Replace(Environment.NewLine, "");

            if (string.IsNullOrWhiteSpace(txtBin))
            {
                formulario.txtDec.Text = "";
                formulario.txtOct.Text = "";
                formulario.txtHex.Text = "";
                return;
            }

            if (IsBin(txtBin))
            {
                int valorDecimal = Convert.ToInt32(txtBin, 2);

                formulario.txtDec.Text = valorDecimal.ToString();
                formulario.txtOct.Text = Convert.ToString(valorDecimal, 8);
                formulario.txtHex.Text = Convert.ToString(valorDecimal, 16).ToUpper();
            }
            else
            {
                formulario.txtDec.Text = "Invalido";
                formulario.txtOct.Text = "Invalido";
                formulario.txtHex.Text = "Invalido";
            }
        }
    }
}
