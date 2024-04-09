using System.ComponentModel;
using System.Runtime.CompilerServices;
using Task3.Interfaces;

namespace Task3.Entities;

public sealed class CarViewModel(IStateful<CarState> car) : INotifyPropertyChanged
{
    public string State => Enum.GetName(car.State)!;

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void SetState(CarState state)
    {
        if (car.State == state) return;
        car.State = state;
        OnPropertyChanged(nameof(car.State));
    }
}