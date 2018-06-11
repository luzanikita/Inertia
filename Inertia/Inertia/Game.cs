using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Inertia
{
    internal class Game : ICloneable
    {
        public Element[,] Map { get; set; }
        public Hero Hero { set; get; }
        public int Health { set; get; }
        public int Score { set; get; }
        public int Treasures { set; get; }


        public Game(Element[,] map, Hero hero, int treasures, int score = 0, int health = 3)
        {
            Health = health;
            Score = score;
            Treasures = treasures;
            Hero = new Hero(hero.X, hero.Y);
            Map = new Element[map.GetLength(0), map.GetLength(1)];
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Map[i, j] = (Element) map[i, j].Clone();
                }
            } 
        }

        public Element this[int row, int column]
        {
            set { Map[row, column] = value; }
            get { return Map[row, column]; }
        }

        public object Clone()
        {
            return new Game(Map, Hero, Treasures, Score, Health);
        }

        public void MoveHero(Direction direction)
        {
            Hero.Move();
            {
                switch (this[Hero.Y, Hero.X].Gist)
                {
                    case Gists.Wall:
                        Hero.Move(true);
                        Hero.Moving = false;
                        break;
                    case Gists.Trap:
                        Hero.Move(true);
                        Hero.Moving = false;
                        Health--;
                        break;
                    case Gists.Treasure:
                        Score += Health;
                        Treasures--;
                        this[Hero.Y, Hero.X] = new Ground(Hero.X, Hero.Y);
                        break;
                    case Gists.StopPoint:
                        Hero.Moving = false;
                        break;
                    case Gists.None:
                    default:
                        break;
                }
            }
        }    

        public void Save(string fileName)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new Newtonsoft.Json.Converters.JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            serializer.TypeNameHandling = TypeNameHandling.Auto;
            serializer.Formatting = Formatting.Indented;

            using (StreamWriter sw = new StreamWriter($"..//..//Saves//{fileName}.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, this);
            }
        }

        public Game Open(string fileName)
        {
            if (File.Exists($"../../Saves/{fileName}.json"))
            {
                Game obj = JsonConvert.DeserializeObject<Game>(File.ReadAllText($"../../Saves/{fileName}.json"), new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    NullValueHandling = NullValueHandling.Ignore,
                });

                return obj;
            }
            return null;
        }
    }
}