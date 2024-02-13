using SistemaDeNumeracao.Controls;
using SistemaDeNumeracao.Controls.Interface;
using SistemaDeNumeracao.Utils;
using SistemaDeNumeracao.Logic.Decimal;
using SistemaDeNumeracao.Logic.Octal;
using SistemaDeNumeracao.Logic.Hexadecimal;
using SistemaDeNumeracao.Logic.Binary;

namespace SistemaDeNumeracao.Logic
{
    public class LogicControl
    {
        public ControlsType controlActive;
        internal DictionaryWrapper<ControlsType, IControls> controls = new();

        internal BinaryClass Bin { get; set; }
        internal DecimalClass Dec { get; set; }
        internal OctalClass Oct { get; set; }
        internal HexadecimalClass Hex { get; set; }

        public LogicControl()
        {
            Bin = new BinaryClass(this);
            Dec = new DecimalClass(this);
            Oct = new OctalClass(this);
            Hex = new HexadecimalClass(this);
        }

        internal void SetAssignEvents()
        {
            // Binário
            controls.GetItem(ControlsType.ControlTextBinary).TextChanged += Bin.ControlTextBinary_Change;
            controls.GetItem(ControlsType.ControlTextBinary).KeyDown += Bin.ControlTextBinary_KeyDown;
            controls.GetItem(ControlsType.ControlTextBinary).Enter += SetControlActive;
            controls.GetItem(ControlsType.ControlTextBinary).Leave += UnSetControlActive;

            // Decimal
            controls.GetItem(ControlsType.ControlTextDecimal).TextChanged += Dec.ControlTextDecimal_Change;
            controls.GetItem(ControlsType.ControlTextDecimal).Enter += SetControlActive;
            controls.GetItem(ControlsType.ControlTextDecimal).Leave += UnSetControlActive;

            // Octal
            controls.GetItem(ControlsType.ControlTextOctal).TextChanged += Oct.ControlTextOctal_Change;
            controls.GetItem(ControlsType.ControlTextOctal).Enter += SetControlActive;
            controls.GetItem(ControlsType.ControlTextOctal).Leave += UnSetControlActive;

            // Hexadecimal
            controls.GetItem(ControlsType.ControlTextHexadecimal).TextChanged += Hex.ControlTextHexadecimal_Change;
            controls.GetItem(ControlsType.ControlTextHexadecimal).Enter += SetControlActive;
            controls.GetItem(ControlsType.ControlTextHexadecimal).Leave += UnSetControlActive;
        }

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


        private void ResetOthersBoxValues(ControlsType controlActive)
        {
            for (var i = 1; i < Enum.GetValues(typeof(ControlsType)).Length; i++)
            {
                var controlName = Enum.GetName(typeof(ControlsType), i);
                var controlType = controls.GetItem((ControlsType)i).GetType();
                if (controlType == typeof(CustomTextBoxModel))
                {
                    if (controlName != controlActive.ToString())
                    {
                        controls.GetItem((ControlsType)i).Text = "";
                    }
                }
                else //Labels
                {
                    if (controlName == Enum.GetName(typeof(ControlsType), ControlsType.ControlLabelBit))
                    {
                        controls.GetItem((ControlsType)i).Text = "Bits:";
                    }
                    else if (controlName == Enum.GetName(typeof(ControlsType), ControlsType.ControlLabelByte))
                    {
                        controls.GetItem((ControlsType)i).Text = "Bytes:";
                    }
                }
            }
        }

        private void SetBoxValues(int value)
        {

            for (var i = 1; i < Enum.GetValues(typeof(ControlsType)).Length; i++)
            {
                var controlElement = controls.GetItem((ControlsType)i);

                switch ((ControlsType)i)
                {
                    case ControlsType.ControlTextBinary:
                        controlElement.Text = Bin.FormatBinaryToLayout(Convert.ToString(value, 2));
                        break;
                    case ControlsType.ControlTextDecimal:
                        controlElement.Text = value.ToString();
                        break;
                    case ControlsType.ControlTextOctal:
                        controlElement.Text = Convert.ToString(value, 8);
                        break;
                    case ControlsType.ControlTextHexadecimal:
                        controlElement.Text = Convert.ToString(value, 16).ToUpper();
                        break;
                    case ControlsType.ControlLabelBit:
                        controls.GetItem(ControlsType.ControlLabelBit).Text = $"Bits: {Convert.ToString(value, 2).Length}";
                        break;
                    case ControlsType.ControlLabelByte:
                        controls.GetItem(ControlsType.ControlLabelByte).Text = $"Bytes: {(int)Math.Ceiling((double)Convert.ToString(value, 2).Length / 8)}";
                        break;
                    default:
                        break;
                }
            }
        }

        public void UpdateValues()
        {
            var controlElement = controls.GetItem(controlActive);


            if (controlElement != null)
            {
                var formatValue = controlElement.Text.Replace(" ", "").Replace(Environment.NewLine, "");
                if (string.IsNullOrWhiteSpace(formatValue))
                {
                    ResetOthersBoxValues(controlActive);
                    return;
                }
                if (Bin.IsBinary(formatValue) && controlActive == ControlsType.ControlTextBinary)
                {
                    SetBoxValues(Convert.ToInt32(formatValue, 2));
                }
                else if (Dec.isDecimal(formatValue) && (controlActive == ControlsType.ControlTextDecimal || controlActive == ControlsType.ControlTextOctal))
                {
                    SetBoxValues(Convert.ToInt32(formatValue));
                }
                else if (Hex.isHexadecimal(formatValue) && controlActive == ControlsType.ControlTextHexadecimal)
                {
                    SetBoxValues(Convert.ToInt32(formatValue, 16));
                }
                else
                {
                    ChangeValueOfOthersBoxes();
                }
            }
        }

        public void ChangeValueOfOthersBoxes()
        {
            // Buscar e alterar os valores do tipo int diferentes
            var dictionary = controls.GetItems();
            foreach (var control in dictionary)
            {
                if (control.Value.GetType() == typeof(CustomTextBoxModel))
                {
                    if (control.Key != controlActive)
                    {
                        control.Value.Text = "Invalido";
                    }
                }
            }
        }
    }
}
