# Polymorphism

Polymorphism is «the condition of occurring in several different forms».

In OOP, polymorphism is the provisioning of a single `interface` to entities of different types.

## What is an interface

The interface is the shared boundary across which two or more separate components interact.

In OOP, an interface defines the operations that a class provide to other classes.

The interface itself does not contains any logic, but only the definition of the methods that a class implement.

It is widely used to separate the implementation of a functionality with its usage.

In C# they usually starts with `I`.

### Example

Given the `Rectangle` class

```csharp
class Rectangle {
    public double Side1 { get; set; }
    public double Side2 { get; set; }
    public double Area() => Side1 * Side2;
    public double Perimeter() => 2 * Side1 + 2 * Side2;
}
```

The interface of that class could be:

```csharp
interface IRectangle {
    double Area();
    double Perimeter();
}
```

And the class will be written in this way

```csharp
class Rectangle : IRectangle {
    public double Side1 { get; set; }
    public double Side2 { get; set; }
    public double Area() => Side1 * Side2;
    public double Perimeter() => 2 * Side1 + 2 * Side2;
}
```

In such situation, interface seems to be useless and the thought «I'm going to use directly the class» will be strong.

The advantages will come when:

* composition pattern will be used, and a class will implement many interfaces
* the polymorphism is applied.

## Composition pattern, this time with interface

As we introduced the interface, we could complete the explanation of the composition pattern:

![Status](https://img.shields.io/badge/Status-To%20be%20done-blue)

## Implementing polymorphism

![Status](https://img.shields.io/badge/Status-To%20be%20done-blue)
