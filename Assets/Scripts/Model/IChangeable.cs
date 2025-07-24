using System;

public interface IChangeable
{
    event Action Changed;
}
