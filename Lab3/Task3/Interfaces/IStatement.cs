namespace Task3.Interfaces;

public interface IStatement<T>
{
    T State { get; set; }
}