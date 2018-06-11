using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Inertia
{
    class Program
    {
        public static Game LevelDowload(List<string> matrix)
        {
            int x = 1;
            int y = 1;
            int treasures = 0;
            Element[,] map = new Element[matrix.Count, matrix[0].Length];
            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    switch (matrix[i][j])
                    {
                        case '#':
                            map[i, j] = new Wall(j, i);
                            break;
                        case '%':
                            map[i, j] = new Trap(j, i);
                            break;
                        case '$':
                            map[i, j] = new Treasure(j, i);
                            treasures++;
                            break;
                        case '.':
                            map[i, j] = new StopPoint(j, i);
                            break;
                        case '&':
                            map[i, j] = new Ground(j, i);
                            x = j;
                            y = i;
                            break;
                        default:
                            map[i, j] = new Ground(j, i);
                            break;
                    }
                }
            }

            return new Game(map, new Hero(x, y), treasures);
        }

        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MenuForm menu = new MenuForm();
            while (menu.DialogResult != DialogResult.No)
            {
                menu.ShowDialog();
                if (menu.DialogResult == DialogResult.Yes)
                {
                    LevelsForm level = new LevelsForm();
                    level.ShowDialog();
                    if (level.DialogResult == DialogResult.Yes)
                    {
                        Game obj = JsonConvert.DeserializeObject<Game>(File.ReadAllText($"../../Levels/{level.Tag}.json"), new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.Auto,
                            NullValueHandling = NullValueHandling.Ignore,
                        });

                        GameForm game = new GameForm(obj);
                        game.ShowDialog();
                    }
                }
            }
        }
    }
}