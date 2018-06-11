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
    public partial class GameOverForm : Form
    {
        public GameOverForm(int score)
        {
            InitializeComponent();
            labelScore.Text = $"Your score: {score}";
        }

        private void GameOverForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonAgain_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
