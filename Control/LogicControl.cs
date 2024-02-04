using SistemaDeNumeracao.Controles.Interface;
using System.Text;

namespace SistemaDeNumeracao.Controles
{
    public enum Controls
    {
        None = 0,
        txtBin = 1,
        txtDec = 2,
        txtOct = 3,
        txtHex = 4,
    }
    public class LogicControl
    {
        #region Construtor
        private DictionaryWrapper<Controls, Control> controlsDictionary = new Dictionary<Controls, object>();
        public LogicControl()
        {
            // Ativa o binário por padrão.
            controlActive = Controls.txtBin;
        }
        internal void AddControlToDictionary<T>(Controls key) where T : Control, new()
        {
            controlsDictionary.AddItem(key, new T());
        }
        internal void SetAssignEvents()
        {
            // Binário
            controlsDictionary.GetValueOrDefault(Controls.txtBin).TextChanged += txtBin_Change;
            controlsDictionary.GetValueOrDefault(Controls.txtBin).KeyDown += txtBin_KeyDown;
            controlsDictionary.GetValueOrDefault(Controls.txtBin).Enter += SetControlActive;
            controlsDictionary.GetValueOrDefault(Controls.txtBin).Leave += UnSetControlActive;

            // Decimal
            controlsDictionary.GetValueOrDefault(Controls.txtDec).TextChanged += txtDec_Change;
            controlsDictionary.GetValueOrDefault(Controls.txtDec).Enter += SetControlActive;
            controlsDictionary.GetValueOrDefault(Controls.txtDec).Leave += UnSetControlActive;
        }

        #endregion

        #region Binário
        // Adicionado esta abordagem, por conta de não estar apagando o caractere de espaço, pois o tratamento
        // dentro do método de processamento de formato binário, retira todos os espaços e quebra de linha no início
        // do algarítmo, foi adaptado também para apagar quebras de linha apenas no binário é necessário!
        bool txtBin_BackSpace = false;
        public void txtBin_Change(object sender, EventArgs e)
        {
            var text = ((TextBox)sender).Text;

            var controlElement = controlsDictionary.GetValueOrDefault(Controls.txtBin);

            // Remova o manipulador de eventos temporariamente
            controlElement.TextChanged -= txtBin_Change;

            // Verifique se o controle atual está ativo.
            if (controlActive == Controls.txtBin)
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
            controlsDictionary.GetValueOrDefault(Controls.txtBin).TextChanged += txtBin_Change;
        }
        public void txtBin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                var controlElement = controlsDictionary.GetValueOrDefault(Controls.txtBin);
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

            var controlElement = controlsDictionary.GetValueOrDefault(Controls.txtDec);

            // Desative o manipulador de eventos temporariamente.
            controlElement.TextChanged -= txtDec_Change;

            if (controlActive == Controls.txtDec)
                UpdateValues();

            // Ative o manipulador de eventos.
            controlElement.TextChanged += txtDec_Change;
        }
        #endregion

        #region AtivacaoControles

        public Controls controlActive;
        public void SetControlActive(object sender, EventArgs e)
        {
            var tipo = sender.GetType();

            if (tipo == null) { return; }

            if (tipo == typeof(CustomTextBoxModel))
            {
                var textBox = (CustomTextBoxModel)sender;

                for (int i = 1; i <= Enum.GetValues(typeof(Controls)).Length; i++)
                {
                    var controlName = Enum.GetName(typeof(Controls), i);

                    if (textBox.Name == controlName)
                    {
                        controlActive = (Controls)i;
                        return;
                    }
                }
            }
        }

        public void UnSetControlActive(object sender, EventArgs e)
        {
            controlActive = Controls.None;
        }
        #endregion

        #region AtualizacaoDados
        public void UpdateValues()
        {
            var controlElement = controlsDictionary.GetValueOrDefault(controlActive);

            switch (controlActive)
            {
                case Controls.None: break;
                case Controls.txtBin:
                    var txtBin = controlElement.Text.Replace(" ", "").Replace(Environment.NewLine, "");

                    if (string.IsNullOrWhiteSpace(txtBin))
                    {
                        controlsDictionary.GetValueOrDefault(Controls.txtDec).Text = "";
                        controlsDictionary.GetValueOrDefault(Controls.txtOct).Text = "";
                        controlsDictionary.GetValueOrDefault(Controls.txtHex).Text = "";
                        return;
                    }
                    if (IsBin(txtBin))
                    {
                        int valorDecimal = Convert.ToInt32(txtBin, 2);

                        controlElement.Text = FormatBinaryToLayout(txtBin);
                        controlsDictionary.GetValueOrDefault(Controls.txtDec).Text = valorDecimal.ToString();
                        controlsDictionary.GetValueOrDefault(Controls.txtOct).Text = Convert.ToString(valorDecimal, 8);
                        controlsDictionary.GetValueOrDefault(Controls.txtHex).Text = Convert.ToString(valorDecimal, 16).ToUpper();
                        controlElement.SelectionStart = controlElement.TextLength;
                    }
                    else
                    {
                        controlsDictionary.GetValueOrDefault(Controls.txtDec).Text = "Invalido";
                        controlsDictionary.GetValueOrDefault(Controls.txtOct).Text = "Invalido";
                        controlsDictionary.GetValueOrDefault(Controls.txtHex).Text = "Invalido";
                    }
                    break;
                case Controls.txtDec:
                    if (int.TryParse(controlElement.Text, out int txtDec))
                    {
                        controlsDictionary.GetValueOrDefault(Controls.txtBin).Text = FormatBinaryToLayout(Convert.ToString(txtDec, 2));
                        controlElement.Text = Convert.ToString(txtDec, 10);
                        controlsDictionary.GetValueOrDefault(Controls.txtOct).Text = Convert.ToString(txtDec, 8);
                        controlsDictionary.GetValueOrDefault(Controls.txtHex).Text = txtDec >= 0
                            ? Convert.ToString(txtDec, 16).ToUpper()
                            : "-" + Convert.ToString(Math.Abs(txtDec), 16).ToUpper();
                    }
                    else
                    {
                        controlsDictionary.GetValueOrDefault(Controls.txtBin).Text = "Invalido";
                        controlsDictionary.GetValueOrDefault(Controls.txtOct).Text = "Invalido";
                        controlsDictionary.GetValueOrDefault(Controls.txtHex).Text = "Invalido";
                    }

                    break;
                case Controls.txtOct: break;
                case Controls.txtHex: break;

                default: break;
            }
        }
        #endregion
    }
}
