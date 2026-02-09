# Explicit Interfaces for Clean Code
This example is about implementing the Factory Method design pattern creating plugins, to demonstrate how to use Explicit Interfaces to avoid the use of Reflection in our code, for purpose of huge improvements in performance.

## Simple Code using Explicit Interface to avoid using Reflection
```sh
public interface IProcessor
{
    void Process();
}

public class OrderProcessor : IProcessor
{
    void IProcessor.Process()
    {
        Console.WriteLine("Processing order");
    }
}
// Common reflection anti-pattern
if (obj.GetType().GetMethod("Process") != null)
{
    obj.GetType().GetMethod("Process")!.Invoke(obj, null);
}

// Reflection-free replacement
if (obj is IProcessor processor)
{
    processor.Process();
}
```

## When to Use Explicit Interfaces
1.To resolve name/signature conflicts when implementing multiple interfaces

2.To hide interface members from the public API of the concrete class

3. To enforce programming against the interface (not concrete class)

## Alternative ways
Default interface methods (C# 8+) or static abstract members (C# 11+) can solve the problem cleaner.