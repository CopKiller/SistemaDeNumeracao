using SistemaDeNumeracao.Controls.Interface;
using System.Text;

namespace SistemaDeNumeracao.Controls
{
    public enum ControlsType
    {
        None = 0,
        ControlTextBinary = 1,
        ControlTextDecimal = 2,
        CustomTextOctal = 3,
        CustomTextHexadecimal = 4,
    }
    public class LogicControl
    {
        #region Construtor
        internal DictionaryWrapper<ControlsType, IFusionControls> controlsDictionary = new();
        public LogicControl()
        {
            // Ativa o binário por padrão.
            controlActive = ControlsType.ControlTextBinary;
        }
        internal void SetAssignEvents()
        {
            // Binário
            controlsDictionary.GetItem(ControlsType.ControlTextBinary).TextChanged += txtBin_Change;
            controlsDictionary.GetItem(ControlsType.ControlTextBinary).KeyDown += txtBin_KeyDown;
            controlsDictionary.GetItem(ControlsType.ControlTextBinary).Enter += SetControlActive;
            controlsDictionary.GetItem(ControlsType.ControlTextBinary).Leave += UnSetControlActive;

            // Decimal
            controlsDictionary.GetItem(ControlsType.ControlTextDecimal).TextChanged += txtDec_Change;
            controlsDictionary.GetItem(ControlsType.ControlTextDecimal).Enter += SetControlActive;
            controlsDictionary.GetItem(ControlsType.ControlTextDecimal).Leave += UnSetControlActive;
        }

        #endregion

        #region Binário
        // Adicionado esta abordagem, por conta de não estar apagando o caractere de espaço, pois o tratamento
        // dentro do método de processamento de formato binário, retira todos os espaços e quebra de linha no início
        // do algarítmo, foi adaptado também para apagar quebras de linha apenas no binário é necessário!
        bool txtBin_BackSpace = false;
        public void txtBin_Change(object sender, EventArgs e)
        {
            var controlElement = controlsDictionary.GetItem(ControlsType.ControlTextBinary);
            var text = controlElement.Text;

            // Remova o manipulador de eventos temporariamente
            controlElement.TextChanged -= txtBin_Change;

            // Verifique se o controle atual está ativo.
            if (controlActive == ControlsType.ControlTextBinary)
            {
                if (txtBin_BackSpace)
                {
                    txtBin_BackSpace = false;
                }
                else
                {
                    UpdateValues();
                }

                controlElement.SelectionStart = controlElement.TextLength;
            }


            // Acione o manipulador de eventos.
            controlsDictionary.GetItem(ControlsType.ControlTextBinary).TextChanged += txtBin_Change;
        }
        public void txtBin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                var controlElement = controlsDictionary.GetItem(ControlsType.ControlTextBinary);
                var sstring = controlElement.Text;

                if (controlElement.SelectionLength == 0 && controlElement.SelectionStart > 0)
                {
                    int positionBeforeBackspace = controlElement.SelectionStart - 1;

                    if (controlElement.Text[positionBeforeBackspace] == ' ' ||
                        positionBeforeBackspace >= Environment.NewLine.Length &&
                         controlElement.Text.Substring(positionBeforeBackspace + 1 - Environment.NewLine.Length, Environment.NewLine.Length) == Environment.NewLine)
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
        private string FormatBinaryToLayout(string txtBin)
        {
            // Limites de caracteres por linha e caracteres para adicionar uma quebra de linha
            int characterLimit = 8;
            int characterToSpace = 4;

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

            return novoTexto.ToString();
        }
        #endregion

        #region Decimal
        public void txtDec_Change(object sender, EventArgs e)
        {

            var controlElement = controlsDictionary.GetItem(ControlsType.ControlTextDecimal);

            // Desative o manipulador de eventos temporariamente.
            controlElement.TextChanged -= txtDec_Change;

            if (controlActive == ControlsType.ControlTextDecimal)
                UpdateValues();

            // Ative o manipulador de eventos.
            controlElement.TextChanged += txtDec_Change;
        }
        #endregion

        #region AtivacaoControles

        public ControlsType controlActive;
        public void SetControlActive(object sender, EventArgs e)
        {
            var tipo = sender.GetType();

            if (tipo == null) { return; }

            if (tipo == typeof(CustomTextBoxModel))
            {
                var textBox = (CustomTextBoxModel)sender;

                for (int i = 1; i <= Enum.GetValues(typeof(ControlsType)).Length; i++)
                {
                    var controlName = Enum.GetName(typeof(ControlsType), i);

                    if (textBox.Name == controlName)
                    {
                        controlActive = (ControlsType)i;
                        return;
                    }
                }
            }
        }

        public void UnSetControlActive(object sender, EventArgs e)
        {
            controlActive = ControlsType.None;
        }
        #endregion

        #region AtualizacaoDados
        public void UpdateValues()
        {
            var controlElement = controlsDictionary.GetItem(controlActive);

            switch (controlActive)
            {
                case ControlsType.None: break;
                case ControlsType.ControlTextBinary:
                    var txtBin = controlElement.Text.Replace(" ", "").Replace(Environment.NewLine, "");

                    if (string.IsNullOrWhiteSpace(txtBin))
                    {
                        controlsDictionary.GetItem(ControlsType.ControlTextDecimal).Text = "";
                        controlsDictionary.GetItem(ControlsType.CustomTextOctal).Text = "";
                        controlsDictionary.GetItem(ControlsType.CustomTextHexadecimal).Text = "";
                        return;
                    }
                    if (IsBin(txtBin))
                    {
                        int valorDecimal = Convert.ToInt32(txtBin, 2);

                        controlElement.Text = FormatBinaryToLayout(txtBin);
                        controlsDictionary.GetItem(ControlsType.ControlTextDecimal).Text = valorDecimal.ToString();
                        controlsDictionary.GetItem(ControlsType.CustomTextOctal).Text = Convert.ToString(valorDecimal, 8);
                        controlsDictionary.GetItem(ControlsType.CustomTextHexadecimal).Text = Convert.ToString(valorDecimal, 16).ToUpper();
                        controlElement.SelectionStart = controlElement.TextLength;
                    }
                    else
                    {
                        controlsDictionary.GetItem(ControlsType.ControlTextDecimal).Text = "Invalido";
                        controlsDictionary.GetItem(ControlsType.CustomTextOctal).Text = "Invalido";
                        controlsDictionary.GetItem(ControlsType.CustomTextHexadecimal).Text = "Invalido";
                    }
                    break;
                case ControlsType.ControlTextDecimal:
                    if (int.TryParse(controlElement.Text, out int txtDec))
                    {
                        controlsDictionary.GetItem(ControlsType.ControlTextBinary).Text = FormatBinaryToLayout(Convert.ToString(txtDec, 2));
                        controlElement.Text = Convert.ToString(txtDec, 10);
                        controlsDictionary.GetItem(ControlsType.CustomTextOctal).Text = Convert.ToString(txtDec, 8);
                        controlsDictionary.GetItem(ControlsType.CustomTextHexadecimal).Text = txtDec >= 0
                            ? Convert.ToString(txtDec, 16).ToUpper()
                            : "-" + Convert.ToString(Math.Abs(txtDec), 16).ToUpper();
                    }
                    else
                    {
                        controlsDictionary.GetItem(ControlsType.ControlTextBinary).Text = "Invalido";
                        controlsDictionary.GetItem(ControlsType.CustomTextOctal).Text = "Invalido";
                        controlsDictionary.GetItem(ControlsType.CustomTextHexadecimal).Text = "Invalido";
                    }

                    break;
                case ControlsType.CustomTextOctal: break;
                case ControlsType.CustomTextHexadecimal: break;

                default: break;
            }
        }
        #endregion
    }
}
