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

```csharp
internal interface IHasTransferability {
    void InTransfer(decimal amount);
    void OutTransfer(decimal amount);
}

internal interface IIsResettable {
    void Reset();
}

internal interface IHasOperation {
    List<Operation> Operations { get; set; }
}


class Operation {
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public string? Description { get; set; }
}

class BankAccount : IHasTransferability, IIsResettable, IHasOperation
{
    public decimal AccountBalance { get; set; }
    public decimal AvailableBalance { get; set; }
    public string Owner { get; set; }
    public List<Operation> Operations { get; set; }

    public void InTransfer(decimal amount)
    {
        // code here...
    }

    public void OutTransfer(decimal amount)
    {
        // code here...
    }

    public void Reset()
    {
        // code here...
    }
}
```

### What if... Composition + Delegation + Interface??

```csharp
internal interface IHasTransferability {
    decimal AvailableBalance { get; set; }
    void InTransfer(decimal amount);
    void OutTransfer(decimal amount);
}

class MoneyTransfer : IHasTransferability {
    public decimal AvailableBalance { get; set; }
    public void InTransfer(decimal amount)
    {
        // code here...
    }

    public void OutTransfer(decimal amount)
    {
        // code here...
    }
}

internal interface IIsResettable {
    void Reset();
}

internal interface IHasOperation {
    List<Operation> Operations { get; set; }
}


class Operation {
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public string? Description { get; set; }
}

class BankAccount : IHasTransferability, IIsResettable, IHasOperation
{
    public decimal AccountBalance { get; set; }
    public decimal AvailableBalance { get; set; }
    public string Owner { get; set; }
    public List<Operation> Operations { get; set; }

    private IHasTransferability moneyTransfer;
    public BankAccount(IHasTransferability moneyTransfer) {
        this.moneyTransfer = moneyTransfer;
    }

    public void InTransfer(decimal amount) => moneyTransfer.InTransfer(amount);

    public void OutTransfer(decimal amount) => moneyTransfer.OutTransfer(amount);

    public void Reset() => moneyTransfer.OutTransfer(AvailableBalance);
}
```

Does this sound familiar? Take a look at [Dependency inversion principle](https://en.wikipedia.org/wiki/Dependency_inversion_principle).

## Implementing polymorphism

Interfaces are at their best when polymorphism is applied.

Consider the following `BankAccount` and `PayPalAccount` classes

```csharp
internal interface IHasTransferability {
    void InTransfer(decimal amount);
    void OutTransfer(decimal amount);
}

class BankAccount: IHasTransferability {
    // ...
}

class PayPalAccount: IHasTransferability {
    // ...
}
```

As both implements `IHasTransferability` interface, both will surely have `InTransfer` and `OutTransfer` methods.

Let's suppose we want to setup a payment system, that move money from a bank account OR a PayPal account, to another bank account OR PayPal account.

Without polymorphism we should write something similar to this

```csharp
void NewTransfer(decimal amount, Object sourceAccount, Object destinationAccount) {
    if (sourceAccount is BankAccount src) {
        src.OutTransfer(amount);
    }
    else if (sourceAccount is PayPalAccount src) {
        src.OutTransfer(amount);
    }
    if (destinationAccount is BankAccount) {
        dst.InTransfer(amount);
    }
    else if (destinationAccount is PayPalAccount) {
        dst.InTransfer(amount);
    }
}
```

With polymorphism, we will write this

```csharp
void NewTransfer(decimal amount, IHasTransferability sourceAccount, IHasTransferability destinationAccount) {
    sourceAccount.OutTransfer(amount);
    destinationAccount.InTransfer(amount);
}
```

It is not important which is the real implementation of the `sourceAccount` and of the `destinationAccount`: for our functionality, we only need that source and destination account contains the `OutTransfer` and `InTransfer` methods. And this is ensured from interface implementation on the classes!

In this way, `sourceAccount` and `destinationAccount` could be any object with a source class that is implementing the `IHasTransferability` interface.
