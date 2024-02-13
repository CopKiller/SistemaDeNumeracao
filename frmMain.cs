
using Microsoft.VisualBasic.Logging;
using SistemaDeNumeracao.Controls.Interface;
using SistemaDeNumeracao.Logic;
using System.Text;

namespace SistemaDeNumeracao
{
    public partial class frmMain : Form
    {
        private readonly LogicControl controller;

        public frmMain()
        {
            InitializeComponent();

            controller = new LogicControl();

            InitializeLogicControl();
        }

        private void InitializeLogicControl()
        {
            controller.controls.AddItem(ControlsType.ControlTextBinary, ControlTextBinary);
            controller.controls.AddItem(ControlsType.ControlTextDecimal, ControlTextDecimal);
            controller.controls.AddItem(ControlsType.ControlTextOctal, ControlTextOctal);
            controller.controls.AddItem(ControlsType.ControlTextHexadecimal, ControlTextHexadecimal);
            controller.controls.AddItem(ControlsType.ControlLabelBit, ControlLabelBit);
            controller.controls.AddItem(ControlsType.ControlLabelByte, ControlLabelByte);

            controller.SetAssignEvents();
        }
    }
}
