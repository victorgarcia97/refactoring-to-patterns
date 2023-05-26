using System.Collections.Generic;

namespace RefactoringToPatterns.CommandPattern
{
    public class MarsRover
    {
        public int X;
        public int Y;
        public char Direction;
        public const string AvailableDirections = "NESW";
        public readonly string[] Obstacles;
        public bool ObstacleFound;
        private readonly Dictionary<char, ICommand> movements = new Dictionary<char, ICommand>();
        private readonly Dictionary<char, ICommand> rotations = new Dictionary<char, ICommand>();

        public MarsRover(int x, int y, char direction, string[] obstacles)
        {
            X = x;
            Y = y;
            Direction = direction;
            Obstacles = obstacles;
            movements.Add('E', new MoveEastCommand(this));
            movements.Add('S', new MoveSouthCommand(this));
            movements.Add('W', new MoveWestCommand(this));
            movements.Add('N', new MoveNorthCommand(this));
            rotations.Add('L', new RotateLeftCommand(this));
            rotations.Add('R', new RotateRightCommand(this));
        }
        
        public string GetState()
        {
            return !ObstacleFound ? $"{X}:{Y}:{Direction}" : $"O:{X}:{Y}:{Direction}";
        }

        public void Execute(string commands)
        {
            foreach(char command in commands)
            {
                if (command == 'M')
                {
                    var move = movements[Direction];
                    move.Execute();
                }
                else if(command == 'L')
                {
                    rotations[command].Execute();
                } else if (command == 'R')
                {
                    rotations[command].Execute();
                }
            }
        }
    }
}