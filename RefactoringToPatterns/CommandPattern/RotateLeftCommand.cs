namespace RefactoringToPatterns.CommandPattern
{
    public class RotateLeftCommand
    {
        private MarsRover _marsRover;

        public RotateLeftCommand(MarsRover marsRover)
        {
            _marsRover = marsRover;
        }

        public void RotateLeft()
        {
            // get new direction
            var currentDirectionPosition = MarsRover.AvailableDirections.IndexOf(_marsRover.Direction);
            _marsRover.Direction = currentDirectionPosition != 0 ? MarsRover.AvailableDirections[currentDirectionPosition - 1] : MarsRover.AvailableDirections[3];
        }
    }
}