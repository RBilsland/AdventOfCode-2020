using System.Collections.Generic;

namespace Day17a
{
    public class Cube
    {
        public Position Position { get; set; } = new Position() { X = 0, Y = 0, Z = 0 };
        public bool State { get; set; } = false;
        public List<Cube> Cubes { get; set; } = new List<Cube>();
        private bool NextState { get; set; } = false;

        public void CalculateNextState()
        {
            int activeNeighbourCount = Cubes
                .CountActive(Neighbours.Adjustments, this.Position.X, this.Position.Y, this.Position.Z);

            this.NextState = this.State == true ? activeNeighbourCount >= 2 && activeNeighbourCount <= 3 : activeNeighbourCount == 3;
        }

        public void UpdateState() =>
            this.State = this.NextState;
    }
}
