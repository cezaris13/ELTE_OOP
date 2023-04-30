using System;

public class Lemming : Prey
{
    private static readonly Lazy<Lemming> lazy = new Lazy<Lemming>(() => new Lemming());

    public static Lemming Instance { get { return lazy.Value; } }

    private Lemming() : base(2, 200, 30, 2, 4) { }
}
