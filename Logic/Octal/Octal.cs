using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeNumeracao.Logic.Octal
{
    internal class OctalClass
    {
        private LogicControl logicControl;

        public OctalClass(LogicControl logicControl)
        {
            this.logicControl = logicControl;
        }

        private void SetControlActive()
        {
            logicControl.controlActive = ControlsType.ControlTextOctal;
        }
        private ControlsType GetControlActive()
        {
            return logicControl.controlActive;
        }

        public void ControlTextOctal_Change(object sender, EventArgs e)
        {
            var controlElement = logicControl.controls.GetItem(ControlsType.ControlTextOctal);

            // Desative o manipulador de eventos temporariamente.
            controlElement.TextChanged -= ControlTextOctal_Change;

            if (GetControlActive() == ControlsType.ControlTextOctal)
                logicControl.UpdateValues();

            // Ative o manipulador de eventos.
            controlElement.TextChanged += ControlTextOctal_Change;
        }
    }
}
