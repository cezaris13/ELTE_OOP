using System;

public class Gopher : Prey
{
    private static readonly Lazy<Gopher> lazy = new Lazy<Gopher>(() => new Gopher());

    public static Gopher Instance { get { return lazy.Value; } }

    private Gopher() : base(4, 200, 40, 2, 2) { }
}
