using System.Linq;

namespace RefactoringToPatterns.CommandPattern
{
    public class MarsRover
    {
        private int _x;
        private int _y;
        public char Direction;
        public const string AvailableDirections = "NESW";
        public readonly string[] Obstacles;
        private bool _obstacleFound;
        private readonly RotateRightCommand _rotateRightCommand;
        private readonly RotateLeftCommand _rotateLeftCommand;

        public MarsRover(int x, int y, char direction, string[] obstacles)
        {
            _x = x;
            _y = y;
            Direction = direction;
            Obstacles = obstacles;
            _rotateRightCommand = new RotateRightCommand(this);
            _rotateLeftCommand = new RotateLeftCommand(this);
        }
        
        public string GetState()
        {
            return !_obstacleFound ? $"{_x}:{_y}:{Direction}" : $"O:{_x}:{_y}:{Direction}";
        }

        public void Execute(string commands)
        {
            foreach(char command in commands)
            {
                if (command == 'M')
                {
                    switch (Direction)
                    {
                        case 'E':
                            MoveEast();
                            break;
                        case 'S':
                            MoveSouth();
                            break;
                        case 'W':
                            MoveWest();
                            break;
                        case 'N':
                            MoveNorth();
                            break;
                    }
                }
                else if(command == 'L')
                {
                    _rotateLeftCommand.RotateLeft();
                } else if (command == 'R')
                {
                    _rotateRightCommand.RotateRight();
                }
            }
        }

        private void MoveNorth()
        {
            _obstacleFound = Obstacles.Contains($"{_x}:{_y - 1}");
            // check if rover reached plateau limit or found an obstacle
            _y = _y > 0 && !_obstacleFound ? _y -= 1 : _y;
        }

        private void MoveWest()
        {
            _obstacleFound = Obstacles.Contains($"{_x - 1}:{_y}");
            // check if rover reached plateau limit or found an obstacle
            _x = _x > 0 && !_obstacleFound ? _x -= 1 : _x;
        }

        private void MoveSouth()
        {
            _obstacleFound = Obstacles.Contains($"{_x}:{_y + 1}");
            // check if rover reached plateau limit or found an obstacle
            _y = _y < 9 && !_obstacleFound ? _y += 1 : _y;
        }

        private void MoveEast()
        {
            _obstacleFound = Obstacles.Contains($"{_x + 1}:{_y}");
            // check if rover reached plateau limit or found an obstacle
            _x = _x < 9 && !_obstacleFound ? _x += 1 : _x;
        }
    }
}