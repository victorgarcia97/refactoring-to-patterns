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
            if (currentDirectionPosition != 3)
            {
                _marsRover.Direction = MarsRover.AvailableDirections[currentDirectionPosition + 1];
            }
            else
            {
                _marsRover.Direction = MarsRover.AvailableDirections[0];
            }
        }
    }
}