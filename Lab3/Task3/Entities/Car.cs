using Task3.Interfaces;

namespace Task3.Entities;

public class Car : IStateful<CarState>
{
    public CarState State { get; set; }

    public Car()
    {
        State = CarState.Stop;
    }
}

public enum CarState
{
    Stop,
    TurnLeft,
    TurnRight,
    MoveForward,
    Nitro
}