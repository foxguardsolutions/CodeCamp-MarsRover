namespace MarsRover
{
    public abstract class Action : IAct
    {
        protected bool HasPositiveDirectionOfMovement { get; set; }

        public Action(bool hasPositiveDirectionOfMovement)
        {
            HasPositiveDirectionOfMovement = hasPositiveDirectionOfMovement;
        }

        public abstract Position Act(Position lastPosition);

        protected int GetAdjustmentValue(bool isPositiveAdjustment)
        {
            if (isPositiveAdjustment)
                return 1;
            return -1;
        }

        protected int AdjustModulo(int startingValue, int adjustmentValue, int modulus)
        {
            var sum = startingValue + adjustmentValue;
            while (sum < 0)
                sum += modulus;
            return sum % modulus;
        }
    }
}
