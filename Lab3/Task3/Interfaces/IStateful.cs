namespace Task3.Interfaces;

public interface IStateful<T>
{
    T State { get; set; }
}