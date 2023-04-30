using System;

public class Fox : Predator
{
    private static readonly Lazy<Fox> lazy = new Lazy<Fox>(() => new Fox());

    public static Fox Instance { get { return lazy.Value; } }

    private Fox() : base(3, 4) { }
}
