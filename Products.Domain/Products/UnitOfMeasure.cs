using Ardalis.SmartEnum;

namespace SmartPOS.Products.Domain.Products;

public sealed class UnitOfMeasure : SmartEnum<UnitOfMeasure>
{
    public static readonly UnitOfMeasure Kilogram = new UnitOfMeasure(nameof(Kilogram), 1);
    public static readonly UnitOfMeasure Gram = new UnitOfMeasure(nameof(Gram), 2);
    public static readonly UnitOfMeasure Pound = new UnitOfMeasure(nameof(Pound), 3);
    public static readonly UnitOfMeasure Milliliter = new UnitOfMeasure(nameof(Milliliter), 4);
    public static readonly UnitOfMeasure Meter = new UnitOfMeasure(nameof(Meter), 5);
    public static readonly UnitOfMeasure Ounce = new UnitOfMeasure(nameof(Ounce), 6);
    public static readonly UnitOfMeasure Gallon = new UnitOfMeasure(nameof(Gallon), 7);
    public static readonly UnitOfMeasure Dozen = new UnitOfMeasure(nameof(Dozen), 8);
    public static readonly UnitOfMeasure Piece = new UnitOfMeasure(nameof(Piece), 9);
    public static readonly UnitOfMeasure Bag = new UnitOfMeasure(nameof(Bag), 10);

    private UnitOfMeasure(string name, int value) : base(name, value)
    {
    }
}