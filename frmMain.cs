
using Microsoft.VisualBasic.Logging;
using System.Text;

namespace SistemaDeNumeracao
{
    public partial class frmMain : Form
    {
        private readonly Logic logic;

        protected Controls controlActive;

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
        }
    }
}
