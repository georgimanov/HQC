# Structural Patterns

## Facade

An object that provides simplified interface to a larger body of code, such as class library

+ Makes a software easier to use, understand and more readable
+ Reduce dependencies of outside code
+ Wrap a poorly designed APIs in a better one

In .NET 

+ XmlSerializer
+ JSON serializer
+ File

## Composite

Composite Pattern allows to combine different types of objects in tree structure

Gives the possibility to treat the same individual objects or groups of objects

Used when

+ we have different objects and we want to treat them the same way
+ we want to present hierarchy of objects
	+ tree-like structure

## Flyweight

Use sharing to support large numbers of fine-grained objects efficiently

In .NET 

+ string.Intern();

## Proxy

An object representing another object

+ provide a placeholder for another object to control access to it
+ use an external level of indirection to support distributed, controlled or intelligent access
+ add a wrapper and delegation to protect the real component from undue complexity

### Remote proxy

+ local representative of remote object

### Virtual proxy

+ creates expensive objects on demand
+ EF

### Protection proxy

+ used to control access to an object, based on some authorization rules

## Decorator

Add functionality to existing objects at run-time

+ Wrapping original component
+ Alternative to inheritance (class explosion)
+ Support Open-Closed principle
	+ Flexible design, original object is unaware 

## Adapter

Converts the given class' interface into another class request by client

+ wraps an existing class with a new interface

Allows classes to work together when this is impossible due to incompatible interfaces

## Bridge

Used to divide the abstraction and its implementation (the are by default coupled)

+ that way both can be rewritten independently

Solves problems usually solved by inheritance

+ one abstraction uses another abstraction and they can be changed independently