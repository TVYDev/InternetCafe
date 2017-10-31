using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InternetCafeClientProject
{
    public partial class frmTopUp : Form
    {
        public frmTopUp()
        {
            InitializeComponent();

            nudHours.Minimum = 1;
            nudHours.Maximum = 20;
            nudHours.Increment = 1;
        }
    }
}
