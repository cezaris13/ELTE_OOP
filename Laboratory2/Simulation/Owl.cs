using System;

public class Owl : Predator
{
    private static readonly Lazy<Owl> lazy = new Lazy<Owl>(() => new Owl());

    public static Owl Instance { get { return lazy.Value; } }

    private Owl() : base(1, 4) { }
}
