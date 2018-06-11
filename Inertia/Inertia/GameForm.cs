using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inertia
{
    internal partial class GameForm : Form
    {
        private Game _level;
        private Game Level { get; set; }
        private Panel[,] Field { get; set; }
        private Panel Hero { get; set; }
        private Label Info { get; set; }
        private int ElementSize { get; set; }

        public GameForm(Game level)
        {
            InitializeComponent();
            Level = level;
        }

        private void GameField_Load(object sender, EventArgs e)
        {
            ElementSize = Math.Min((int)(Size.Height * 0.8) / Level.Map.GetLength(0), (int)(Size.Width * 0.8) / Level.Map.GetLength(1));
            Render();
            _level = (Game) Level.Clone();
            Level.Save("save");
        }

        private void Render()
        {
            Field = new Panel[Level.Map.GetLength(0), Level.Map.GetLength(1)];
            Hero = new Panel();
            Info = new Label();
            for (int i = 0; i < Field.GetLength(0); i++)
            {
                for (int j = 0; j < Field.GetLength(1); j++)
                {
                    Field[i, j] = new Panel();
                    Field[i, j].Parent = this;
                    Field[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    UpdatePanel(Level[i, j], true);
                }
            }

            Info.Parent = this;
            Info.Width = 200;
            UpdateInfo();

            Hero.Parent = this;
            Hero.BringToFront();
            Hero.BackgroundImageLayout = ImageLayout.Stretch;
            UpdateHero(true); 
        }

        private void UpdatePanel(Element element, bool updateImage = false)
        {
            Field[element.Y, element.X].Size = new Size(ElementSize, ElementSize);
            Field[element.Y, element.X].Location = new Point(element.X * ElementSize + (Size.Width - Field.GetLength(1) * ElementSize) / 2,
                element.Y * ElementSize + (Size.Height - Field.GetLength(0) * ElementSize) / 2);
            if (updateImage) Field[element.Y, element.X].BackgroundImage = Level[element.Y, element.X].GetShape();
        }

        private void UpdateHero(bool updateImage = false)
        {
            Hero.Size = new Size(ElementSize, ElementSize);
            Hero.Location = new Point(Level.Hero.X * ElementSize + (Size.Width - Field.GetLength(1) * ElementSize) / 2,
                Level.Hero.Y * ElementSize + (Size.Height - Field.GetLength(0) * ElementSize) / 2);
            if (updateImage) Hero.BackgroundImage = Level.Hero.GetShape();
        }

        private void UpdateInfo()
        {
            Info.Location = new Point((Size.Width - Field.GetLength(1) * ElementSize) / 2 + ElementSize,
                (Size.Height - (Field.GetLength(0) + 2) * ElementSize) / 2);
            Info.Text = $"Health: {Level.Health}  Score: {Level.Score}";
            if (Level.Health <= 0)
            {
                GameOver(Level.Score);
            }
            else if (Level.Treasures == 0)
                Victory(Level.Score, Level.Health);
            
        }

        private void GameOver(int score)
        {
            timerStep.Enabled = false;
            GameOverForm gameOverForm = new GameOverForm(score);
            gameOverForm.ShowDialog();
            if (gameOverForm.DialogResult == DialogResult.Yes)
            {
                Reload(_level);
            }
            else if (gameOverForm.DialogResult == DialogResult.No)
            {
                Close();
            }
        }

        private void Victory(int score, int health)
        {
            timerStep.Enabled = false;
            VictoryForm victoryForm = new VictoryForm(score, health);
            victoryForm.ShowDialog();
            Close();
        }

        private void StartMovingHero(Direction direction)
        {
            Level.Hero.Direction = direction;
            Level.Hero.Moving = true;
            timerStep.Enabled = true;
        }

        private void Reload(Game level)
        {
            Level = (Game)level.Clone();
            for (int i = 0; i < Field.GetLength(0); i++)
            {
                for (int j = 0; j < Field.GetLength(1); j++)
                {
                    Field[i, j].Dispose();
                }
            }
            Hero.Dispose();
            Info.Dispose();
            Render();
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!Level.Hero.Moving)
            {
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        StartMovingHero(Direction.Left);
                        break;
                    case Keys.Up:
                        StartMovingHero(Direction.Up);
                        break;
                    case Keys.Right:
                        StartMovingHero(Direction.Right);
                        break;
                    case Keys.Down:
                        StartMovingHero(Direction.Down);
                        break;
                    default:
                        break;
                }
            }
        }

        private void GameForm_SizeChanged(object sender, EventArgs e)
        {
            ElementSize = Math.Min((int)(Size.Height * 0.8) / Field.GetLength(0), (int)(Size.Width * 0.8) / Field.GetLength(1));
            for (int i = 0; i < Field.GetLength(0); i++)
            {
                for (int j = 0; j < Field.GetLength(1); j++)
                {
                    UpdatePanel(Level[i, j]);
                }
            }
            UpdateHero();
            UpdateInfo();
        }

        private void timerStep_Tick(object sender, EventArgs e)
        {
            Level.MoveHero(Level.Hero.Direction);
            timerStep.Enabled = Level.Hero.Moving;

            UpdatePanel(Level[(Hero.Location.Y - (Size.Height - Field.GetLength(0) * ElementSize) / 2) / ElementSize,
                (Hero.Location.X - (Size.Width - Field.GetLength(1) * ElementSize) / 2) / ElementSize], true);
            UpdateHero();
            UpdateInfo();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Level.Save("save");
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var level = Level.Open("save");
            if (level != null)
                Reload(level);
        }
    }
}
