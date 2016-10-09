# Behavioral Patterns

Behavioral Patterns are concerned with communication (interaction) between the objects

+ either with the assignment of responsibilities between objects
+ or encapsulation behavior in an object and delegating requests to it

Behavioral Patterns increase flexibility in carrying out cross-classes communication

## Chain of responsibilities

Allows you to pass a request to from an object to the next until the request is fulfilled

Simplifies object interactions 

+ each sender keeps a single reference to the next

### How it's done

+ Sender is aware of only one receiver 
+ Each receiver is aware of the next receiver
+ Receivers process or send to the next
+ The sender does not know who received the message
+ The first receiver to handle the message terminates the chain
+ The order of the list matters

## Iterator

Access to the elements of a complex object without revealing its actual presentation

Various ways of data structure traversing

+ Hides traversing details
+ Interchangeable traversing algorithms

## Template method

Defines the base of an algorithm in a method, leaving some implementation to its sub-classes


### When to use

+ two or more classes should follow the same common algorithm or workflow
+ the workflow never changes

## Strategy pattern

### Main purpose

+ Encapsulates a family of related algorithms

+ Let the algorithm vary and evolve separate from the class using it
+ Allow a class to maintain a single purpose
+ Separate the calculation from the delivery of its results

### Plus

+ Easier to be written for individual concrete strategies
+ Strategies may be mocked when testing the context class
+ Adding a new strategies does not modify anything

## Command 

An object that encapsulates all the information needed to call a method at a later time

Decouples clients that execute the command from the details and dependencies of the command logic

+ can log requests
+ can queue commands for later execution
+ can validate requests
+ support for undoable operation

## Observer

Also known as Publish-Subscribe

Defines a one-to-many dependency between different objects

+ When one object changes state, all its dependents (observers) are notified and updated
+ Separates the subject and the observer

### When to use

+ When one object is dependent on another
+ When changing one object requires changes in many others
+ When changes to an object should notify others without any knowledge of them

## Mediator

Simplifies communication between classes

+ using one centralized component (The Mediator)

Define an object that encapsulates how a set of objects interact with each other

Promotes loose coupling by keeping objects from referring to each other explicitly

A good example is :

+ The air traffic control center which plays the role of the mediator for all the aircrafts

### Implementation

 + *Colleagues* – components that communicate with each other (sharing same base type)
	+ Have knowledge of the Mediator component
+ *Mediator(s)* – the centralized component that manages communication between colleagues
	+ Abstract so that different mediators can exists

### Advantages

+ Hides all coordination between colleagues
	+ Separation of concerns
+ Decouples colleagues
+ One-to-many relationship is preferred to many-to-many fashion

### Disadvantages

+ The Mediator can become very large (fat) and very complicated as more logic is handled or as more type of colleagues are handled

## Memento

Capture and restore an object's internal state

+ Promote undo or rollback to full object state

### Implementation

+ Originator is the object whose state is being tracked as well is responsible for saving/restoring
+ The Caretaker performs operations on the Originator and is containing all states
+ The Memento is a value object that contains one state of the Originator (contains the data)

## Visitor

Represent an operation to be performed on the elements of an object structure

Lets us define a new operation to a class without change the elements of the class

### Implementation

**Visitor** declares a Visit operation for each class of ConcreteElement

**Element** defines an Accept operation that takes a visitor as an argument

## State

Alter an object's behavior when its state changes

+ Allows an object to have different behavior based on its internal state
+ Allows separation of concerns
+ Encapsulates the logic of each state
+ Easy to add new states

### Implementation

States are hidden (internal), the client uses only context

+ The context gets its behavior by delegation the operation to the current state
+ Context acts as a proxy to the states    
 
## Interpreter

A way to include language (formal grammar) elements in a program

+ define a representation for the grammar

Limiter area where it can be applied

## Specification (Rules) Pattern

Combines different rules (and/or/not)

+ When we have complex and growing (frequently changing) business logic

Examples

+ Gamification
+ Customer discount calculations / credit rating
+ Complex search