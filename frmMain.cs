
using Microsoft.VisualBasic.Logging;
using SistemaDeNumeracao.Controls;
using SistemaDeNumeracao.Controls.Interface;
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
            controller.controlsDictionary.AddItem(ControlsType.ControlTextBinary, ControlTextBinary);
            controller.controlsDictionary.AddItem(ControlsType.ControlTextDecimal, ControlTextDecimal);
            controller.controlsDictionary.AddItem(ControlsType.CustomTextOctal, ControlTextOctal);
            controller.controlsDictionary.AddItem(ControlsType.CustomTextHexadecimal, ControlTextHexadecimal);

            controller.SetAssignEvents();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
