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
            if (currentDirectionPosition != 0)
            {
                _marsRover.Direction = MarsRover.AvailableDirections[currentDirectionPosition - 1];
            }
            else
            {
                _marsRover.Direction = MarsRover.AvailableDirections[3];
            }
        }
    }
}