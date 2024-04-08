using Task3.Infrastructure;
using Task3.Interfaces;

namespace Task3.Entities.Decorators;

public class CarDecorator : IStatement<CarState>
{
    private IStatement<CarState> _car { get; }
    private ILogger _logger { get; }
    public CarDecorator(IStatement<CarState> car, ILogger logger)
    {
        _car = car;
        _logger = logger;
        _logger.Log("Car created");
    }

    public CarState State
    {
        get => _car.State;
        set
        {
            _logger.Log($"Changing state from {State} to {value}");
            _car.State = value;
        }
    }
}