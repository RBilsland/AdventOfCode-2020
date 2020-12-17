using System.Collections.Generic;

namespace Day17b
{
    public class HyperCube
    {
        public Position Position { get; set; } = new Position() { X = 0, Y = 0, Z = 0, W = 0 };
        public bool State { get; set; } = false;
        public List<HyperCube> HyperCubes { get; set; } = new List<HyperCube>();
        private bool NextState { get; set; } = false;

        public void CalculateNextState()
        {
            int activeNeighbourCount = HyperCubes
                .CountActive(Neighbours.Adjustments, this.Position.X, this.Position.Y, this.Position.Z, this.Position.W);

            this.NextState = this.State == true ? activeNeighbourCount >= 2 && activeNeighbourCount <= 3 : activeNeighbourCount == 3;
        }

        public void UpdateState() =>
            this.State = this.NextState;
    }
}
