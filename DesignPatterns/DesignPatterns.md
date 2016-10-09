#Design Patterns
###### General and reusable solutions to common problems in software design
---

+ What design patterns are?
	+	General, repeatable and reusable solution to a common problem in software design
	+ What do patterns deal with?
		+ Application and system design
		+ Abstraction and code structure
		+ Relationships between classes or other collaborators
	+ Can speed up the development process by providing tested, proven development paradigms

+ Elements of design patterns
	+ Name
		+ how we talk about the DP
		+ aslo known as
	+ Problem
		+ the problem that the DP solves
		+ intent
		+ motivation
	+ Solution
		+ sample code
		+ structure
		+ how it solves the problem   
	+ Consequences
		+  for example do we have speed up or speed down of the code performance?
		+  esier understainding of the code
		+  result 
		+  tradeoffs

+ Benefits of DP
	+ Improves system and application design
	+ DP enable large-scale reuse of software architecture
	+ Can speed up production in team

+ When to use patterns?
	+ When we want to provide a solution to recurring problems
	+ Do not user patterns when not required - overdesign is evil 
	+ Be careful for the **Golden Hammer Rule**

+ Drawbacks of design patterns
	+ patterns do not lead to a direct code reuse
	+ teams may suffer from pattern overload
	+ use patterns if you understand them well 

+ Types of patterns
	+ **Creational patterns** - deal with initializing and configuring classes and objects
	+ **Structural patterns** - describe ways to assemble objects to implement a new functionality
	+ **Behavioral patterns** - deal with dynamic iterations among societies of classes and objects
	+ how to distribute responsibility

### Creational patterns

+ Deal with  **object creation mechanisms**

+ Trying to create objects in a manner **suitable to the situation**

+ **List of creational patterns**:
	+ Singleton
	+ Simple factory
	+ Factory method
	+ Abstract factory
	+ Builder
	+ Prototype
	+ Fluent interface
	+ Object pool
	+ Lazy initialization 

### Structural patterns

+ Ease the design by identifying a simple way to realize relationships between entities

+ **List of structural patterns**:
	+ Facade
	+ Composite
	+ Flyweight
	+ Proxy
	+ Decorator
	+ Adapter
	+ Bridge 

### Behavioral patterns

+ Concerned with **communication** (interaction) **between the objects**

+ **List of behavioral patterns**:
	+ Chain or responsibilities
	+ Iterator
	+ Command
	+ Template method
	+ Strategy
	+ Observer
	+ Mediator
	+ Memento
	+ State
	+ Interpreter
	+ Visitor

### Concurrency patterns

+ **Active object**
+ **Double checked locking** pattern
+ **Monitoring object**
	+ an object can be safely used by many threds
+ **Read-Write Lock** pattern
+ **Thread Pool** pattern
	+ a number of threads are created to perform a number of tasks