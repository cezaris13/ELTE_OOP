using System;

public class Wolf : Predator
{
    private static readonly Lazy<Wolf> lazy = new Lazy<Wolf>(() => new Wolf());

    public static Wolf Instance { get { return lazy.Value; } }

    private Wolf() : base(2, 4) { }
}
