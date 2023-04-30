using System;

public class Hare : Prey
{
    private static readonly Lazy<Hare> lazy = new Lazy<Hare>(() => new Hare());

    public static Hare Instance { get { return lazy.Value; } }

    private Hare() : base(2, 100, 20, 1.5, 2) { }
}
