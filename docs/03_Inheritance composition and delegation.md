# Inheritance, composition and delegation

Inheritance, composition and delegation are technics that allow classes to extend their behaviours, over a shared set of instruction.

## Inheritance

A class can inherit another one. Inheritance is a hierarchical relationship between the «parent» (called *base* class) and the «child» (called *derived* or *sub* class).

Multi level inheritance is also possible, when three or more classes compose an inheritance chain.

Some language allows multiple inheritance, where an object can be derived from two different and unrelated classes (C is derived from unrelated classes A and B). C# and Java don't.

The derived object will inherit the behaviour of the base class and can access all the `public`, `internal` and `protected` fields and methods.

If a field or method is marked as `virtual` in the base object, the derived one can `override` the behaviour and re-define the operations performed.

### Single inheritance

:::mermaid
flowchart TB
A --> B
:::

In this case `B` is derived from `A` (and `A` is the base class of `B`).

### Multilevel inheritance

:::mermaid
flowchart TB
A --> B --> C
:::

### C# corner

In C#, a class can be inherited using the `: BaseClass` when the class is created, for example:

```csharp
class Rectangle { // the base class
    // ...
}

class Square : Rectangle { // the derived class
    // ...
}
```

### When to use inheritance?

Inheritance is very powerful when the derived class is a particular case of the base one.

An ever green example is the `square`, that is a particular case of the `rectangle`.

## Composition

The composition is an alternative way that allows to extend the behaviour of a class, creating an instance of a «inherited» object.

In this case, there's not a direct hierarchical inheritance: the «derived» object simply use an instance of the «base» object.

To fully benefit and implement composition pattern, interfaces and polymorphism must be used.

### When to use Composition?

Very useful if:

* two classes are unrelated
* we want to hide the attributes and methods of the «base» object from the external classes.

There's a doctrine «composition over inheritance» that stands and explain why it's preferable to use an «has-a» relationship instead of inheritance («is-a»). For example this gives higher flexibility and it's more close to the business-domain behaviour.

## Delegation

Delegation is a principle in which a member (property or method) of an object (or an object itself) is passed as argument to another object (or method).

In this way, the receiver will execute the code of the delegate in the original context (i.e. the sender one) and the behavior is shared across more classes and methods.

```csharp
class Rectangle {
    public double Side1 { get; set; }
    public double Side2 { get; set; }
    public double Area() => Side1 * Side2;
    public double Perimeter() => 2 * Side1 + 2 * Side2;
}

class Square {
    Rectangle rectangle;
    public double Side { get => rectangle.Side1; set => rectangle.Side1 = rectangle.Side2 = value; }
    public Square(Rectangle rectangle) {
        this.rectangle = rectangle;
    }
    public double Area() => rectangle.Area();
    public double Perimeter() => rectangle.Perimeter();
}

// Usage
var rectangle = new Rectangle();
var square = new Square(rectangle);
// In this way I'm delegating the calculous to the rectangle object and I'm making explicit the dependency between Square and Rectangle (Square depends on Rectangle)
```

Delegation can be applied also using a single method:

```csharp

public class Multiplication {
    public double Multiplicate(double value1, double value2) => value1 * value2;
}
public delegate double Multiplier(double value1, double value2);

public class Rectangle {
    public double Side1 { get; set; }
    public double Side2 { get; set; }

    Multiplier multiplier;
    public Rectangle(Multiplier multiplier) {
        this.multiplier = multiplier;
    }

    public double Area() => multiplier(Side1, Side2);
    public double Perimeter() => multiplier(2, Side1) + multiplier(2, Side2);
}

// Usage
var multiplication = new Multiplication();
var rectangle = new Rectangle(multiplication.Multiplicate);
```

> Note: not to be confused with forwarding, in which the object/method is not passed as argument, but instantiated inside the class.
