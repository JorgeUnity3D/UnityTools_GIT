using System;

[Flags]
public enum PlatformsMask
{
    Standalone = 1 << 0,
    iOS = 1 << 1,
    Android = 1 << 2,
    WebGL = 2 << 3,
}