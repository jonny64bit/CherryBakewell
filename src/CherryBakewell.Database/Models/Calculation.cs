using CherryBakewell.Database.Interfaces;

namespace CherryBakewell.Database.Models;

public enum Operator
{
    Add = 0,
    Minus = 1,
    Multiply = 2,
    Divide = 3,
}

public class Calculation : IOrdered
{
    public int Id { get; set; }
    public double InputA { get; set; }
    public double InputB { get; set; }
    public Operator Operator { get; set; }
    public double Answer { get; set; }
    public int Order { get; set; }
}