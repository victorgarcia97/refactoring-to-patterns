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
        private readonly RotateRightCommand _rotateRightCommand;
        private readonly RotateLeftCommand _rotateLeftCommand;
        private readonly MoveNorthCommand _moveNorthCommand;
        private readonly MoveWestCommand _moveWestCommand;
        private readonly MoveSouthCommand _moveSouthCommand;
        private readonly MoveEastCommand _moveEastCommand;

        public MarsRover(int x, int y, char direction, string[] obstacles)
        {
            X = x;
            Y = y;
            Direction = direction;
            Obstacles = obstacles;
            _rotateRightCommand = new RotateRightCommand(this);
            _rotateLeftCommand = new RotateLeftCommand(this);
            _moveNorthCommand = new MoveNorthCommand(this);
            _moveWestCommand = new MoveWestCommand(this);
            _moveSouthCommand = new MoveSouthCommand(this);
            _moveEastCommand = new MoveEastCommand(this);
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
                    switch (Direction)
                    {
                        case 'E':
                            _moveEastCommand.MoveEast();
                            break;
                        case 'S':
                            _moveSouthCommand.MoveSouth();
                            break;
                        case 'W':
                            _moveWestCommand.MoveWest();
                            break;
                        case 'N':
                            _moveNorthCommand.MoveNorth();
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
    }
}