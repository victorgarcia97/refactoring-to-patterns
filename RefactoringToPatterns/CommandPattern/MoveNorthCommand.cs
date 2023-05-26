using System.Linq;

namespace RefactoringToPatterns.CommandPattern
{
    public class MoveNorthCommand: ICommand
    {
        private MarsRover _marsRover;

        public MoveNorthCommand(MarsRover marsRover)
        {
            _marsRover = marsRover;
        }

        public void Execute()
        {
            _marsRover.ObstacleFound = _marsRover.Obstacles.Contains($"{_marsRover.X}:{_marsRover.Y - 1}");
            // check if rover reached plateau limit or found an obstacle
            _marsRover.Y = _marsRover.Y > 0 && !_marsRover.ObstacleFound ? _marsRover.Y -= 1 : _marsRover.Y;
        }
    }
}