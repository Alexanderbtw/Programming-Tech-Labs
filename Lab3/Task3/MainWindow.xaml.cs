using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Task3.Entities;
using Task3.Entities.Decorators;
using Task3.Infrastructure;

namespace Task3;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = new CarViewModel(new CarDecorator(new Car(), FileLogger<Car>.GetInstance("Logs", out _)));
        Playground.Focus();
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        ((CarViewModel)DataContext).SetState(CarState.Nitro);
    }

    private void CarHandling(object sender, KeyEventArgs e)
    {
        switch (e.Key)
        {
            case Key.W:
                ((CarViewModel)DataContext).SetState(CarState.MoveForward);
                break;
            case Key.A:
                ((CarViewModel)DataContext).SetState(CarState.TurnLeft);
                break;
            case Key.D:
                ((CarViewModel)DataContext).SetState(CarState.TurnRight);
                break;
            case Key.Space:
                ((CarViewModel)DataContext).SetState(CarState.Stop);
                break;
            case Key.LeftShift:
                ((CarViewModel)DataContext).SetState(CarState.Nitro);
                break;
            default:
                break;
        }
    }
}