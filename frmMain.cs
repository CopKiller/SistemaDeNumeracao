
using Microsoft.VisualBasic.Logging;
using System.Text;

namespace SistemaDeNumeracao
{
    public partial class frmMain : Form
    {
        private readonly Logic logic;

        public frmMain()
        {
            InitializeComponent();

            logic = new Logic(this);

            SetAssignEvents();
        }

        private void SetAssignEvents()
        {
            // Binário
            txtBin.TextChanged += logic.txtBin_Change;
            txtBin.KeyDown += logic.txtBin_KeyDown;
            txtBin.Enter += logic.SetControlActive;
            txtBin.Leave += logic.UnSetControlActive;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
