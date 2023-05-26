namespace RefactoringToPatterns.CommandPattern
{
    public class RotateRightCommand
    {
        private MarsRover _marsRover;

        public RotateRightCommand(MarsRover marsRover)
        {
            _marsRover = marsRover;
        }

        public void RotateRight()
        {
            // get new direction
            var currentDirectionPosition = MarsRover.AvailableDirections.IndexOf(_marsRover.Direction);
            _marsRover.Direction = currentDirectionPosition != 3 ? MarsRover.AvailableDirections[currentDirectionPosition + 1] : MarsRover.AvailableDirections[0];
        }
    }
}