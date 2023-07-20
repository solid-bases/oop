# Data abstraction

Data abstraction is a design pattern.

Its purpose is to prevent misuse of the data contained in a class.

It is reached hiding the field containing the data and allowing a controlled access through methods.

Let's see an example on the `pattern` field of `GreyPattern` class:

```csharp
internal class GreyPattern
{
    public RowPattern[] pattern;
    // [...]
}
```

As the property is marked as `public`, external objects are allowed to see and manipulate it, including the changes of its data.

This can be potentially very dangerous and have to be avoided. Only the class should care about its data.

> *Is it really dangerous?*<br />
> A common problem that often rise in such situation is the object null reference exception.
> If the not-null condition is not verified at each usage of the field inside the class, and someone could change it from outside, soon or later you will surely run up against a `NullReferenceException`.

Data abstraction is our equipment to get rid of the potential problems:

```csharp
internal class GreyPattern
{
    private RowPattern[] pattern;
    internal RowPattern[] GetPattern() {
        return pattern;
    }
    internal void SetPattern(RowPattern[] value) {
        if (value == null) {
            pattern = new RowPattern[0];
            return;
        }
        pattern = value;
    }
    // [...]
}
```

In this case, the `pattern` field is now `private` and not visible from the other classes, but the `GetPattern` and `SetPattern` methods are `internal`, so they are visible to all the classes in the current `assembly`.

Now to set and get `pattern` data the methods must be used:

```csharp
var greyPattern = new GreyPattern();
var pattern = greyPattern.GetPattern();
greyPattern.SetPattern(pattern);
```

In this case, the `NullReferenceException` could never be thrown from external interaction, because if the `null` value is passed, it will be replaced with an empty array. This is only an example to show the makings of this pattern, any other kind of operation can be performed both in get and set methods.

## C# corner

In some OOP language, such us C#, there's a distinction between *fields* and *properties*.

This has been introduced because of a simplified way that the language has introduced to use data abstraction: the `get` and `set` keywords.

The previous code snippet can be declared in this way

```csharp
internal class GreyPattern
{
    private RowPattern[] pattern;
    internal RowPattern[] Pattern
    {
        get => pattern;
        set
        {
            if (value == null)
            {
                pattern = new RowPattern[0];
                return;
            }
            pattern = value;
        }
    }
    // [...]
}
```

The big difference will be in the usage, to set and get `pattern` data, the property must be used:

```csharp
var greyPattern = new GreyPattern();
var pattern = greyPattern.Pattern;
greyPattern.Pattern = pattern;
```

This have a limitation: could only be used with sync getter and setter. If we want to apply data abstraction with async operations, we have to use async methods.

## Should I always use it?

Short answer: **yes!**

### Long answer: *why?*

Data abstraction is costless (modern IDE will automatically generate it from fields) and, also if in many cases they will be not used (acting like a «proxy» for the field data), it will allow future evolutions without changing any external code.

### Example

Let's suppose that in the initial phase we don't think that null values will be a problem and we detect it only in a second moment.

If the initial implementation has been done with field and with external class that directly access it, we will have to perform one of those operation:

1. change the code in all the points that use the field to check the not-null value
2. introduce the getter and setter and refactor all the code that use the field

If we have used a «proxy property» we will have only to implement the check in the setter (or getter) that is way easier, faster and safe*!

### *Safe?

There are two important truth in software development:

1. each new or modified line of code is a potential bug
2. developer must always suppose that its code will change.

This mean that developer:

1. must ensure that the code can be enhanced with the strictly necessary edits
2. write a code that will ensure the non-propagation of possible bug when edits are made.

A simple way to remember it:

>e=mc²

but written in this way:

> **e**rrors = (**m**ore **c**ode)²


## Encapsulation

We have already implicitly explained what encapsulation is: the ability to prevent that external code to being concerned with the internal workings of an object.

In other words: external user will *use* a method like a «locked box» and cannot manipulate what's happening inside the object.

This is achieved through the usage of the access modifiers:

* `private`: visible only inside the current class
* `internal`: visible only from the current `assembly` classes
* `public`: visible to all the classes (also in different `assembly`)

There is also another modifier:

* `protected`: visible only to this and inherited classes

Inheritance will be explained in next step.
