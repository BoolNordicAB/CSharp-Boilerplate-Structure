This project contains an solution that gives an example on how to structure
code in a .NET/C# codebase, to enable rather strict isolation of units during
unit testing, and enable the implementation and usage of mock logic that can
be used both during unit testing and development.


### Rationale

The point of this is to show a minimal example of a structure in a .NET solution
that enables:

- Separation of concerns,
- Testability; and
- Mockability


### Overview

The solution contains 5 basic C# projects that each fills a core role. In 
addition to these, there is one unit test project, one UI project and one UI 
test project. The core projects are:

- Common
- Models
- Logic.Interfaces
- Logic.Real
- Logic.Simulated

The (primary) dependency graph between these looks like:

```
                            +------------------+
                            |                  |
                            | Logic.Real       |
                            |                  |
                            +--------|---------+
                                     |
+--------+    +--------+    +--------v---------+
|        |    |        |    |                  |
| Common <----+ Models <----+ Logic.Interfaces |
|        |    |        |    |                  |
+--------+    +--------+    +--------^---------+
                                     |
                            +--------|---------+
                            |                  |
                            | Logic.Simulated  |
                            |                  |
                            +------------------+
```

N.B. the graph above depicts only the primary dependents. E.g. `Logic.Real` 
depends on `Logic.Interfaces`, because its primary purpose is to implement 
interfaces found in that project. However, to do that, it needs the models
defined in `Models`, and most likely elements that are found in the `Common`
project. Similarly, since some models might implement certain interfaces found
in `Common`, `Logic.Interfaces` have to have a dependency on `Common`. This is 
because the dependencies propagate down in the dependency chain.

In addition to the projects above, there are the following also:

- Test.Unit
- UI.Console
- UI.Console.Test

All of these depend on, at least, all of the core projects.
`Test.Unit` contains the unit tests for the logic found in the core projects.
In a big project, it might be reasonable to also create a `Test.Integration` 
project, to run automated integration tests. `UI.Console` is the actual 
application that a user consumes. Examples of other real world applications 
would be a `UI.API.Web` project and/or a `UI.Graphical.Web` project. The 
`UI.Console.Test` is a "Coded UI Test" project, that emulates a human user 
interacting with the application via normal [HIDs](https://en.wikipedia.org/wiki/Human_interface_device).


### More in-depth

Each of the above projects have a rather defined set of rules regarding what one
should put, and *not* to put in them, as follows:


Core
---

#### `Common`

This project should contain generic functionality, that is agnostic to the
solution's business requirements. Examples of this kind of functionality is:

- Extensions that operate on built-in types or own types defined in `Common`,
- Exception types that can be used in common situations;
- Interfaces that can be used in common situations;
- etc.


#### `Models`

All the Models used by the business logic should reside here. Examples include database models, integration models, etc.


#### `Logic.Interfaces`

Here, we put interfaces that define how we are able to interact with the
business logic. E.g. if we want to be able to authenticate users, we would
define a `IUserService` or something like that in this project, and then we
would implement that interface in `Logic.Real` and/or `Logic.Simulated`.


#### `Logic.Simulated`


#### `Logic.Real`


Core/test
---

#### `Test.Unit`


Application
---

#### `UI.Console`


#### `UI.Console.Test`
