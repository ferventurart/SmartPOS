using Ardalis.SmartEnum;

namespace SmartPOS.Products.Domain.Products;

public sealed class UnitOfMeasure : SmartEnum<UnitOfMeasure>
{
    public static readonly UnitOfMeasure Kg = new UnitOfMeasure(nameof(Kg), 1);
    public static readonly UnitOfMeasure Gr = new UnitOfMeasure(nameof(Gr), 2);
    public static readonly UnitOfMeasure Lb = new UnitOfMeasure(nameof(Lb), 3);
    public static readonly UnitOfMeasure Ml = new UnitOfMeasure(nameof(Ml), 4);
    public static readonly UnitOfMeasure Mt = new UnitOfMeasure(nameof(Mt), 5);
    public static readonly UnitOfMeasure Oz = new UnitOfMeasure(nameof(Oz), 6);
    public static readonly UnitOfMeasure Gal = new UnitOfMeasure(nameof(Gal), 7);
    public static readonly UnitOfMeasure Doz = new UnitOfMeasure(nameof(Doz), 8);
    public static readonly UnitOfMeasure Pce = new UnitOfMeasure(nameof(Pce), 9);
    public static readonly UnitOfMeasure Bag = new UnitOfMeasure(nameof(Bag), 10);
    public static readonly UnitOfMeasure Pt = new UnitOfMeasure(nameof(Pt), 11);
    public static readonly UnitOfMeasure Cup = new UnitOfMeasure(nameof(Cup), 12);
    private UnitOfMeasure(string name, int value) : base(name, value)
    {
    }
}