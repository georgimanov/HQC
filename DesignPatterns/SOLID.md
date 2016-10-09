#SOLID Principles
---
##SRP – Single Responsibility Principle

> "The Single Responsibility Principle states that every object should have a single responsibility, and that responsibility should be entirely encapsulated by the class."
Wikipedia 

> "There should never be more than one reason for a class to change"
Robert C. "Uncle Bob" Martin

###Strong cohesion
+ Relation of responsibilities
+ Focused on the task

###Low coupling
+ Dependency on other modules
+ Relationship between modules

### Example

**Classic violations** - Objects that can print/draw themselves; Objects that can save/restore themselves;

**Classic solution** Separate printer; Separate saver (or memento)

**Solution** - Multiple small interfaces (ISP); Many small classes;
Distinct responsibilities

**Result** - Flexible design; Lower coupling; Higher cohesion


##OCP – Open/Closed Principle

>"The Open / Closed Principle states that software entities (classes, modules, functions, etc.) should be open for extension, but closed for modification."
Wikipedia 

### Hot to change the behavior without changing code?
+ Rely on abstractions, not implementations
+ Do not limit the variety of implementations
+ In **.NET**
	- Interfaces
	- Abstract Classes

###Open to Extension 
+ New behavior can be added in the future 

###Closed to Modification 
+ Changes to source or binary code are not required 

### Example

**Classic violations**
 
+ Each change requires re-testing (possible bugs); 
+ Cascading changes through modules;
	- when making changes requires changes in couple of places instead of one. (Also violation of separation of concerns) 
+ Logic depends on conditional statements
	- when adding new logic requires *"else if"*, also requires adding new tests for the new logic;

**Classic solution**

+ New classes (nothing depends on them yet);
	- new functionality should inherit interface or class or introduce new ones;
+ New classes (no legacy coupling)

###Three approaches to achieve OCP
+ Parameters
	- Pass delegates / callbacks	
+ Inheritance /  Template Method pattern
	- Child types override behavior of a base class. New class should not brake the logic. Be careful for class explosions.
	- *Template method* - leave a method abstract/virtual who can be implemented by child classes. 
+ Composition / Strategy pattern
	- Client code depends on abstraction 
	- "Plug in" model
### When to apply OCP?
+ Based on experience mostly. Don't rush into it. For example:
	- If module changes once, accept it
	- If it changes a second time, refactor for OCP
+ Note that no design can be closed against all changes

##LSP – Liskov Substitution Principle
>"The Liskov Substitution Principle states that Subtypes must be substitutable for their base types."
Agile Principles, Patterns, and Practices in C#

### Substitutability – child classes must not 
+ Remove base class behavior
	+ hide behavior or throw not implemented exception
+ Violate base class invariant(s)
	+ should not be changed

**Normal OOP inheritance** - IS-A relationship

+ For example if we have base class *Animal*:
	+ *Cat* **IS A**n *Animal*; 
	+ *Dog* **IS A**n *Animal*

**Liskov Substitution inheritance** - IS-SUBSTITUTABLE-FOR

+ We should ask the question - can the child class substitute the base class?
+ For example if I substitute *Cat* with *Dog* somewhere in my class will this brake my code? 

###The problem
+ Polymorphism break
	+ when we brake(the logic) of Polymorphism or we don't use it.
+ Client code expectations
+ "Fixing" by adding if-then – nightmare (OCP)

###Classic violations
+ Type checking for different methods
	+ *if else* should be escaped
	+ think a lot about the **IS A** and **AS** rule
+ Not implemented overridden methods
+ Virtual methods in constructor

###Solutions
+ "Tell, Don't Ask"
	- Don’t ask for types - don't ask if the class is a *Dog* or *Cat*, 
	- Tell the object what to do - simply call a method that it holds. 
+ Refactoring to base class
	- If lot's of the functionality is left to the base class (Common functionality) and some methods are not implemented in the inheritance maybe you should rethink the structure and introduce third class.

### Classic example for this priciple
+ base class **Shape**
+ child **Circle** and **Rectangle**
+ child of Rectangle is **Square**

+ when we try to calculate the Area pf the square we can use *Width * Height*
 there is a possibility to brake the logic and the **Square** should directly inherit the **Shape**. We should always consider the base class implementation




##ISP – Interface Segregation Principle
>"The Interface Segregation Principle states that Clients should not be forced to depend on methods they do not use."
Agile Principles, Patterns, and Practices in C#

+ Prefer small, cohesive interfaces
+ Divide "fat" interfaces into smaller ones. Having "fat" interfaces leads to:
	+ Classes having methods they do not need
	+ Increasing coupling
	+ Reduced flexibility
	+ Reduced maintainability

### Examples for classic violations
+ Unimplemented methods (also in LSP)
+ Use of only small portion of a class

### When to fix?
+ Once there is pain! Do not fix, if is not broken!
+ If the "fat" interface is yours, separate it to smaller ones
+ If the "fat" interface is not yours, use "Adapter" pattern

### Solutions
+ Small interfaces
+ Cohesive interfaces
+ Focused interfaces
+ Let the client define interfaces
+ Package interfaces with their implementation

##DIP – Dependency Inversion Principle
> "High-level modules should not depend on low-level modules. Both should depend on abstractions."

> "Abstractions should not depend on details. Details should depend on abstractions."
Agile Principles, Patterns, and Practices in C#

### What is dependency
+ When we rely on:
	+ Framework 
	+ Third Party Libraries 
	+ Database 
	+ File System 
	+ System Resources (Clock) 
	+ Configuration 
	+ The new Keyword 
	+ Static methods

+ How we should do it correctly
	+ Classes should declare what they need
	+ Constructors should require dependencies
	+ Hidden dependencies should be shown
	+ Dependencies should be abstractions

+ How to do it
	+ Dependency Injection
	+ The Hollywood principle "Don't call us, we'll call you!"

### Types of dependencies 
+ Constructor injection
	+ Dependencies – through constructors
	+ **Pros**
		+ Classes self document requirements
		+ Works well without container
		+ Always valid state
	+ **Cons**	
		+ Many parameters
		+ Some methods may not need everything

+ Property injection
	+ Dependencies – through setters
	+ **Pros**
		+ Can be changed anytime
		+ Very flexible
	+ **Cons**
		+ Possible invalid state
		+ Less intuitive

+ Parameter injection
	+ Dependencies – through method parameter
	+ **Pros**
		+ No change in rest of the class
		+ Very flexible
	+ **Cons**
		+ Many parameters
		+ Breaks method signature

### Classic violations
+ Using of the new keyword 
	+ when using *new* you get coupling to the class that you use.
+ Using static methods/properties coupling to static means that it's harder to test the code

+ **How to fix?**
	+ Default constructor
	+ Main method/starting point
	+ Inversion of Control container - **IoC containers**
		+ Responsible for object instantiation
		+ Initiated at application start-up
		+ Interfaces are registered into the container
		+ Dependencies on interfaces are resolved
		+ Examples – Autofac, Ninject and more