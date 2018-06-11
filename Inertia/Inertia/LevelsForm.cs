using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inertia
{
    public partial class LevelsForm : Form
    {
        public LevelsForm()
        {
            InitializeComponent();
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonLevel01_Click(object sender, EventArgs e)
        {
            Tag = "level01";
            Close();
        }

        private void buttonLevel02_Click(object sender, EventArgs e)
        {
            Tag = "level02";
            Close();
        }

        private void buttonLevel03_Click(object sender, EventArgs e)
        {
            Tag = "level03";
            Close();
        }
    }
}
