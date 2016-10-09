#Creational patterns 
---

## Singleton

+ The Singleton class is a class that is supposed to have only one (single) instance
	+ Singleton is **not** a global variable
+ Consequences of Singleton Use
	+ Default (not thread-safe) implementation should not be used in multi-threaded environments 
	+ Singletons are difficult to test
+ Be careful when you use multiple threads 


## Factories

### Simple Factory

+ Not a real pattern
+ Used quite often
+ Used to encapsulate object creation logic
	+ can hide complex object creation
	+ if you want to make specific class selection logic changes, you make them in one place
+ Usually implemented with Switch(@enum)

### Factory method

+  Objects are created by separate methods
+  Produces objects as normal factory

### Abstract factory

+ Abstraction in object creation
	+ create a family of related objects
+ Used in systems that are frequently changed

## Builder

### In short

+ Separates the construction of a complex object(logic) from its representation(data) so the same construction process can create different representations
	+ separation of logic(multistep) and data
	+ encapsulates the way an object is constructed 

### Solves 3 problems
+ Too many parameters
+ Order dependent
+ Different constructions


### Implementation

+ **Client**
	+ Uses the *Director* and *Concrete Builder* to produce product
+ **Director** 
	+ Puts the steps in the right order
+ **Builder** (interface)
	+ Defines the steps 
	+ Builder is used by Director
	+ Builder is implemented by *Concrete Builder*
+ **Concrete Builder** 
	+ Defines the implementation
+ **Product** 
	+ Product is produced by the *Concrete Builder*




## Prototype

Factory for cloning new instance from a prototype

+ Create new objects by copying prototype
+ Instead of using *"new"* keyword

**IClonable** interface acts as Prototype

## Fluent Interface

An implementation of an object-oriented API that aims to provide more readable code
	
+ reduce syntactical noise
+ more clearly express what the code does

Implemented by using method cascading

LINQ in .NET - using extension methods

## Lazy Initialization

Tactic for delaying the creation of an object, the calculation of a value, or some other expensive process until the first time it is needed

It is used in IoC containers

In .NET Lazy<T> (value holder)

## Object Pool

Avoid expensive acquisition and release of resources by recycling unused objects

+ Can offer a significant performance boost