using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeNumeracao.Logic.Hexadecimal
{
    internal class HexadecimalClass
    {
        private LogicControl logicControl;

        public HexadecimalClass(LogicControl logicControl)
        {
            this.logicControl = logicControl;
        }

        private void SetControlActive()
        {
            logicControl.controlActive = ControlsType.ControlTextHexadecimal;
        }
        private ControlsType GetControlActive()
        {
            return logicControl.controlActive;
        }

        public bool isHexadecimal(string value)
        {
            return int.TryParse(value, System.Globalization.NumberStyles.HexNumber, null, out _);
        }

        public void ControlTextHexadecimal_Change(object sender, EventArgs e)
        {
            var controlElement = logicControl.controls.GetItem(ControlsType.ControlTextHexadecimal);

            // Desative o manipulador de eventos temporariamente.
            controlElement.TextChanged -= ControlTextHexadecimal_Change;

            if (GetControlActive() == ControlsType.ControlTextHexadecimal)
                logicControl.UpdateValues();

            // Ative o manipulador de eventos.
            controlElement.TextChanged += ControlTextHexadecimal_Change;
        }
    }
}
