# HQC
High Quality Code - Exam and Lectures

#SOLID

Single Responsibility
- one class is responsible for only one thing

Open/Close 
- opened for extension
- closed for modification

Liskov Substitution Principle
- Is-A relation
- Animal "Cow is an/Dog is an/Cat isn an"
- Shape : Rectangle is a Shape; Square is a Shape (not a Rectangle? depends!)
- Implementation of the inheritance should be very close to the parent class; 

Interface Segregation
- clients shold not be forced to depend on method that they do not use
- small cohesive interfaces
- divide "fat" interfaces into smaller ones

Dependency Inversion
- the little the better
- High-level modules should not depend on low-level modules. Both should depend on abstractions.
- Abstractions should not depend on details. Details should depend on abstractions.
