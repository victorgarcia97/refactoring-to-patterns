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
        private readonly Dictionary<char, ICommand> _movements = new Dictionary<char, ICommand>();
        private readonly Dictionary<char, ICommand> _rotations = new Dictionary<char, ICommand>();

        public MarsRover(int x, int y, char direction, string[] obstacles)
        {
            X = x;
            Y = y;
            Direction = direction;
            Obstacles = obstacles;
            _movements.Add('E', new MoveEastCommand(this));
            _movements.Add('S', new MoveSouthCommand(this));
            _movements.Add('W', new MoveWestCommand(this));
            _movements.Add('N', new MoveNorthCommand(this));
            _rotations.Add('L', new RotateLeftCommand(this));
            _rotations.Add('R', new RotateRightCommand(this));
        }
        
        public string GetState()
        {
            return !ObstacleFound ? $"{X}:{Y}:{Direction}" : $"O:{X}:{Y}:{Direction}";
        }

        public void Execute(string commands)
        {
            foreach(var command in commands)
            {
                switch (command)
                {
                    case 'M':
                        _movements[Direction].Execute();
                        break;
                    case 'L':
                    case 'R':
                        _rotations[command].Execute();
                        break;
                }
            }
        }
    }
}