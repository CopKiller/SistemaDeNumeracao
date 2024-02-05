using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeNumeracao.Logic.Decimal
{
    internal class DecimalClass
    {
        private LogicControl logicControl;

        public DecimalClass(LogicControl logicControl)
        {
            this.logicControl = logicControl;
        }

        private void SetControlActive()
        {
            logicControl.controlActive = ControlsType.ControlTextBinary;
        }
        private ControlsType GetControlActive()
        {
            return logicControl.controlActive;
        }
        public bool isDecimal(string value)
        {
            return int.TryParse(value, out _);
        }

        public void ControlTextDecimal_Change(object sender, EventArgs e)
        {

            var controlElement = logicControl.controls.GetItem(ControlsType.ControlTextDecimal);

            // Desative o manipulador de eventos temporariamente.
            controlElement.TextChanged -= ControlTextDecimal_Change;

            if (GetControlActive() == ControlsType.ControlTextDecimal)
                logicControl.UpdateValues();

            // Ative o manipulador de eventos.
            controlElement.TextChanged += ControlTextDecimal_Change;
        }
    }
}
