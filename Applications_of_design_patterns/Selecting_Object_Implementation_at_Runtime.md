# Design Patterns for Selecting Object Implementations at Runtime

## Problem Statement

* Code uses a particular object type but only needs to know the interface, not the concrete implementation

* Concrete implementation may need to be chosen dynamically at runtime based on conditions

* **Example**: Audio player app that works on both Windows and Linux, which have different audio architectures

## Suitable Design Patterns

### 1. Factory Method

* A method in a Creator object that returns an object implementing a particular interface
* Several variations of Creator, each returning a specific implementation based on conditions
* Benefits: Single responsibility principle, easy to extend, facilitates unit testing

```plantuml
@startuml
abstract class Creator {
  + {abstract} factoryMethod() : Product
  + someOperation() : void
}

class ConcreteCreator extends Creator {
  + factoryMethod() : Product
}

interface Product {
  + {abstract} operation() : void
}

class ConcreteProduct implements Product {
  + operation() : void
}

Creator --> Product : Creates
ConcreteCreator --> ConcreteProduct : Creates
Client -> Creator : Uses
@enduml

```
### 2. Abstract Factory

* Uses multiple factory methods in Creator to create a family of related objects
* Example: App plays both audio and video on Windows and Linux
* Separate methods for each interface, with Windows and Linux-specific versions
* Implements interface or extends abstract class, with concrete implementations creating relevant output objects

```plantuml
@startuml
interface AbstractFactory {
  + {abstract} createProductA() : AbstractProductA
  + {abstract} createProductB() : AbstractProductB
}

class ConcreteFactory1 implements AbstractFactory {
  + createProductA() : AbstractProductA
  + createProductB() : AbstractProductB
}

class ConcreteFactory2 implements AbstractFactory {
  + createProductA() : AbstractProductA
  + createProductB() : AbstractProductB
}

interface AbstractProductA {
  + {abstract} operationA() : void
}

class ProductA1 implements AbstractProductA {
  + operationA() : void
}

class ProductA2 implements AbstractProductA {
  + operationA() : void
}

interface AbstractProductB {
  + {abstract} operationB() : void
}

class ProductB1 implements AbstractProductB {
  + operationB() : void
}

class ProductB2 implements AbstractProductB {
  + operationB() : void
}

AbstractFactory --> AbstractProductA : Creates
AbstractFactory --> AbstractProductB : Creates
ConcreteFactory1 --> ProductA1 : Creates
ConcreteFactory1 --> ProductB1 : Creates
ConcreteFactory2 --> ProductA2 : Creates
ConcreteFactory2 --> ProductB2 : Creates
Client -> AbstractFactory : Uses
@enduml

```

### 3. Builder

* Similar to Factory Method but builds the object step by step
* Single concrete implementation (shell object) with parameters/dependencies injected based on conditions
* Two main components:
  * Builder: Class with methods to modify object before returning
  * Director: Class with methods that accept Builder, call its methods with parameters, return finished object
* Used to gradually build complex objects and provide different representations
* Benefits: Single responsibility principle, facilitates unit testing, no need for class variations, adjusts properties through conditional logic, code reuse

```plantuml
@startuml
class Director {
  + construct() : void
}

abstract class Builder {
  + {abstract} buildPart1() : void
  + {abstract} buildPart2() : void
  + {abstract} buildPart3() : void
  + {abstract} getProduct() : Product
}

class ConcreteBuilder extends Builder {
  - product : Product
  + buildPart1() : void
  + buildPart2() : void
  + buildPart3() : void
  + getProduct() : Product
}

class Product {
  + listParts() : void
}

Director o-> Builder : Uses
ConcreteBuilder --> Product : Creates
Client -> Director : Uses
Client -> ConcreteBuilder : Uses
@enduml
```