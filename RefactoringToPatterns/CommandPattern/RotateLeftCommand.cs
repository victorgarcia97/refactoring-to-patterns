namespace RefactoringToPatterns.CommandPattern
{
    public class RotateLeftCommand: ICommand
    {
        private MarsRover _marsRover;

        public RotateLeftCommand(MarsRover marsRover)
        {
            _marsRover = marsRover;
        }

        public void Execute()
        {
            // get new direction
            var currentDirectionPosition = MarsRover.AvailableDirections.IndexOf(_marsRover.Direction);
            _marsRover.Direction = currentDirectionPosition != 0 ? MarsRover.AvailableDirections[currentDirectionPosition - 1] : MarsRover.AvailableDirections[3];
        }
    }
}