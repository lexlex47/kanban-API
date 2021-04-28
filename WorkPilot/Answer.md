## Part 1

### Middleware

Middleware is software that provides common services and capabilities to applications outside of what’s offered by the operating system. Data management, application services, messaging, authentication, and API management are all commonly handled by middleware.

Provide convenient, out-of-the-box service interaction and computing capabilities for the development of upper-level application software, shorten the development cycle; shield the differences in the underlying runtime; save the application's own system resources, and reduce operating costs.

For example:
`Retailer` <-- `Distributor` --> `Factory`
Distributor can be seen as a Middleware which can be replaced by anytime.

### Dependency Injection

Its essential purpose is to decouple, maintain loose coupling between software components, and bring flexibility to design and development.

For example:
```
class Player{  
    Weapon weapon;  

    Player(){  
        this.weapon = new Sword();  
    }  

    public void attack() {
        weapon.attack();
    }
} 
```
with Dependency Injection:
```
class Player{  
    Weapon weapon;  

    Player(Weapon weapon){  
        this.weapon = weapon;  

    }  

    public void attack() {
        weapon.attack();
    }

    public void setWeapon(Weapon weapon){  
        this.weapon = weapon;  
    }  
} 
```

### SignalR

ASP.NET SignalR is a library for ASP.NET developers that simplifies the process of adding real-time web functionality to applications. Real-time web functionality is the ability to have server code push content to connected clients instantly as it becomes available, rather than having the server wait for a client to request new data.

### Integration Test

is defined as a type of testing where software modules are integrated logically and tested as a group. A typical software project consists of multiple software modules, coded by different programmers. The purpose of this level of testing is to expose defects in the interaction between these software modules when they are integrated.

Integration Testing focuses on checking data communication amongst the modules.

### Unit Test

Unit testing is a software testing method by which individual units of source code—sets of one or more computer program modules together with associated control data, usage procedures, and operating procedures—are tested to determine whether they are fit for use.

Unit testing is a verification behavior-testing and verifying the correctness of each function in the program, to provide support for future development;

Unit testing is a design behavior-writing unit tests will allow us to observe and think from the caller, especially considering testing first, so that the program can be designed to be easy to call and testable, and to reduce the coupling in the software, It can also enable developers to produce pre-tests during coding, reducing program defects to a minimum;

Unit testing is the act of writing documentation-it is the best document to show how a function or class is used; 

Unit testing is regressive-automated unit testing helps with regression testing.

***

## Part 2

### A customer is experiencing a bug and that no one else in the team is experiencing. What steps would you take to identify the problem and fix it?

1.  To make it sure that the bug originated from, whether it was a user's operation error, or a code error, etc.
2.  Try to reproduce the error and record the operation process and current application environment.
3.  To test and then locate piece of code caused the bug: front-end, back-end, database or api, etc., and communicate with relevant colleagues.
4.  Start to prepare for repair, set timeline, backup version, set up test environment.
5.  First building the happy path, focus on the input and output, code first to write the database, and finally to the front-end.
6.  Test, if the bug still there, repeat the stpe 3-5.
7.  Create branch after repair, and submit push, wait for others to review and merge.


### There is a library or API that you need to integrate with but it has no or very bad documentation. How do you figure out how it works?

1.  Try use tools for quick test, such as Postman and Google.
2.  Try to find a working example.
3.  Make a breakpoint to write down the parameters of the call, and after a single step, write down the return value.
4.  When debugging, dynamically modify the incoming parameters, observe the return value and execution effect, and guess the meaning of the parameters.
5.  Use written by yourself to get the function works, pass in the parameters you noted before, and see if the return value is the same after the call, and see the effect is the same or not.
6.  Use the development version to connect to the api to avoid security issues.
7.  Get and analyze error messages.
8.  Well documents and notes.

***

