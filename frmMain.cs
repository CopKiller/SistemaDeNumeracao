
using Microsoft.VisualBasic.Logging;
using SistemaDeNumeracao.Controles;
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
            controller.AddControlToDictionary(Controles.Controls.txtBin, txtBin);
            controller.AddControlToDictionary(Controles.Controls.txtDec, txtDec);
            controller.AddControlToDictionary(Controles.Controls.txtOct, txtOct);
            controller.AddControlToDictionary(Controles.Controls.txtHex, txtHex);

            controller.SetAssignEvents();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
