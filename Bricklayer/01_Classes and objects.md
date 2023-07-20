# Classes and objects

The **class** is a definition for the data format and available procedures for a given type or group of object; may also contain data and procedures (known as class methods) themselves.

The **object** is the instance of a class.

The purpose of a class is to *encapsulate* (i.e. isolate) an entity and consider it as a separated and isolated block.

There are many kind of classes, each of those explained by a well-defined design pattern.

## Example

A bank account could be a good class: it has data, it has operations that could be made on it.

Let's define it as `BankAccount` and `Operation`:

```csharp
class BankAccount {
    public decimal AccountBalance { get; set; }
    public decimal AvailableBalance { get; set; }
    public List<Operation> Operations { get; set; }
    public string Owner { get; set; }

    public void OutTransfer(decimal amount) {
        // code...
    }
    
    public void InTransfer(decimal amount) {
        // code...
    }
}

class Operation {
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
}
```

This is the `class` definition and represent a generic bank account.

Everyone has is own bank account:

```csharp
var myBankAccount = new BankAccount();
var yourBankAccount = new BankAccount();
```

And what's happening to my account, will not affect yours and viceversa!

```csharp
var myBankAccount = new BankAccount();
var yourBankAccount = new BankAccount();

yourBankAccount.OutTransfer(100);

myBankAccount.InTransfer(500);
```

Classes and objects will allow this kind of interaction, handling the data of each object separately.

This reduces (a lot!) possible unwanted interactions.
