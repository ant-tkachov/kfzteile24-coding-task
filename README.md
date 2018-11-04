# kfzteile24 Coding Task

## Table of contents
1. [Solution Structure](#solution-structure)
    1. [kfzteile24.CodingTask.DataLayer](#data-layer)
    2. [kfzteile24.CodingTask.BusinessLayer](#business-layer)
    3. [kfzteile24.CodingTask.BusinessLayer.Tests](#business-layer-tests)
    4. [kfzteile24.CodingTask.Web](#web)
2. [Installation](#installation)
3. [Testing](#testing)
    1. [Run unit tests from command line](#unt-tests)
    2. [Run UI using Swagger](#swagger-tests)
4. [Further improvements](#further-improvements)

## Solution Structure <a name="solution-structure"></a>

The current implemented solution is overcomplicated by purpose. The task itself does not require such the solution. The same result can be achieved in a simpler way. This approache was chosen to demonstrate my vision to the structure of the solution and to mention a few crucial topics which could not be noticeable with a simple solution.

The provided solution contains the following projects:
* kfzteile24.CodingTask.DataLayer
* kfzteile24.CodingTask.BusinessLayer
* kfzteile24.CodingTask.Web
* kfzteile24.CodingTask.BusinessLayer.Tests

All the public methods have their comments. The private methods can have the comments, it depends on the complexity of the methods and the preferences of the team or developers. In the ideal case the all the methods have to be self-descriptive.

### kfzteile24.CodingTask.DataLayer <a name="data-layer"></a>

In the project there is an interface (`ICounterRepository`) which defines methods to get and put the value from/into a storage. The interface allows us to implement classes where we can provide functionality to use different types of storages.

The project contains implementation (`CounterMemoryRepository`) of functionality to use memory class which is sufficient for the task.

In the real world we usually work with databases. Just for the demo purposes there is class `CounterDbRepository` with no implemented methods. If needed the methods in the class can be implemented.

In the best case the Data Layer project should have no logic besides the logic to store and retrieve data.

### kfzteile24.CodingTask.BusinessLayer <a name="business-layer"></a>

The project contains all the logic. The interface `CounterService` defines necessary method to make the task done.

Using the interfaces allows us to use the Dependency Injection with all the benefits which we can have from it, for instance adding unit tests, replacing some parts of the functionality without touching the others.

The implementation provided in `CounterService`, hence there is `kfzteile24.CodingTask.BusinessLayer.Tests` which contains the test to cover the implemented logic.

The `CounterService` uses `ICounterReository` described above.

### kfzteile24.CodingTask.BusinessLayer.Tests <a name="business-layer-tests"></a>

The project contains the unit tests to test the implemented business logic. There is no UI in the current task, therefore there is no need to provide UI tests. Also, in the current solution no need to add unit tests for the Data Layer.

To create the tests the following third party libraries are used:
* xUnit
* NSubstitute

Some of the projects might require integration tests. The integration tests have their own pros and cons. In scope of this task the integration tests are not needed.

### kfzteile24.CodingTask.Web <a name="web"></a>

The project contains the controller `CounterController` with only two action methods. The method to get the current counter value is the HTTP GET method. The method to increase (in other words update) the counter values is the HTTP POST method.

The controller uses the `ICounterService` service described above.

There is no logic in the controller, therefore no unit tests needed.

## Installation <a name="installation"></a>

To run the application from the command line:

1. Clone the repository: git clone [https://github.com/ant-tkachov/kfzteile24-coding-task](https://github.com/ant-tkachov/kfzteile24-coding-task)
2. Open `Developer Command Prompt for VS 2017` and navigation to the folder where the `kfzteile24.CodingTask.sln` is located
3. Run: `dotnet restore`
4. Run: `dotnet run --project kfzteile24.CodingTask.Web`
![alt text](https://github.com/ant-tkachov/kfzteile24-coding-task/blob/master/Documentation/images/figure1.png "Figure 1: The application is up and running")
5. Open a browser, copy and paste URL: [http://localhost:5000/swagger](http://localhost:5000/swagger)
*Note*: in the provided description the assigned port number is 5000, in your case it can have another number.

## Testing <a name="testing"></a>

### Run unit tests from command line <a name="unt-tests"></a>

To run the tests from the command line:
1. Open `Developer Command Prompt for VS 2017` and navigation to the folder where the `kfzteile24.CodingTask.sln` is located
2. Run: `dotnet restore`
3. Run: `dotnet test kfzteile24.CodingTask.BusinessLayer.Tests`

As the result 2 tests passed:

![alt text](https://github.com/ant-tkachov/kfzteile24-coding-task/blob/master/Documentation/images/figure2.png "Figure 2: All tests passed")

### Run UI using Swagger <a name="swagger-tests"></a>

To perform the tests using Swagger UI:

1. Open `Developer Command Prompt for VS 2017` and navigation to the folder where the `kfzteile24.CodingTask.sln` is located
2. Run: `dotnet restore`
3. Run: `dotnet run --project kfzteile24.CodingTask.Web`
4. Open [http://localhost:5000/swagger/index.html?url=/swagger/v1/swagger.json#/Counter](http://localhost:5000/swagger/index.html?url=/swagger/v1/swagger.json#/Counter)
5. Use `/api/counter/current` and `/api/current/increment` in Swagger UI to perform the testing
![alt text](https://github.com/ant-tkachov/kfzteile24-coding-task/blob/master/Documentation/images/figure3.png "Figure 3: Response of /api/counter/current call")
![alt text](https://github.com/ant-tkachov/kfzteile24-coding-task/blob/master/Documentation/images/figure4.png "Figure 4: Response of /api/current/increment call")

## Further improvements <a name="further-improvements"></a>

There are tons of ways to improve the provided implementation.

For instance, I could introduce a `kfzteile24.CodingTask.Core` project where I would put custom exceptions or functionality related to custom logging. Or implement some database interactions to demonstrate my skills in this area.

Or, I could create UI using MVC with Razor view.

Or, I could implement an example which demonstrates how to use the provided API from the client side, for instance by using jQuery. Or, even provide a simple SPA application using Vue or Angular framework in a couple of jasmine to run UI tests. My knowledge allows me to do it.

Or, or, or…

Of course, there are also areas to improve my technical skills, there is always something to learn and try, and there are always new ideas, new challenges and new bright achievements, so let’s discuss them…
