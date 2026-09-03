# PawLocator

PawLocator is an ASP.NET Core MVC application developed in C# for managing posts about lost pets and their status updates.

The application allows users to:
- create posts for lost pets;
- view post details;
- add updates to a post;
- delete posts and updates;
- add different types of updates such as LOST, FOUND and SEEN.

## Technologies

- C#
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- xUnit
- Git / GitHub

## Application Structure

The application follows a layered structure:

Controller -> Service -> Repository -> Entity Framework Core -> Database

The main entities are `Post` and `Update`.

There is a one-to-many relationship between them:

Post 1 -> N Updates

A post can contain multiple updates, while each update belongs to a single post.

When a post is deleted, its associated updates are also deleted using cascade delete.

## Design Patterns

The project uses two design patterns: **Strategy** and **Factory**.

### 1. Strategy Pattern

The Strategy Pattern is used for formatting update messages depending on the type of update.

The common interface is:

`IUpdateStrategy`

The available strategies are:

- `LostUpdateStrategy`
- `FoundUpdateStrategy`
- `SeenUpdateStrategy`

Each strategy implements its own version of the `FormatMessage` method.

For example:

`LostUpdateStrategy` formats a message as:

`🔴 LOST: <message>`

This allows the formatting behavior to vary without placing all the logic inside `UpdateService`.

### 2. Factory Pattern

The Factory Pattern is implemented through:

`IUpdateStrategyFactory`

and:

`UpdateStrategyFactory`

The factory is responsible for selecting and creating the appropriate strategy depending on the update type.

For example:

- `lost` -> `LostUpdateStrategy`
- `found` -> `FoundUpdateStrategy`
- `seen` -> `SeenUpdateStrategy`

The factory is used by `UpdateService` when a new update is created.

The flow is:

UpdateController
-> UpdateService
-> UpdateStrategyFactory
-> IUpdateStrategy
-> formatted update message
-> UpdateRepository
-> Database

Using the Factory together with the Strategy Pattern keeps the strategy creation logic separate from the business logic of the service.

## Unit Tests

The project contains unit tests implemented using xUnit.

The tests verify:

- the behavior of an update strategy;
- the correct strategy returned by `UpdateStrategyFactory`.

Test classes:

- `UpdateStrategyTests`
- `UpdateStrategyFactoryTests`

## Running the Application

1. Configure the SQL Server connection string in `appsettings.json`.
2. Apply the Entity Framework Core migrations.
3. Run the application.
4. Open the Posts page to create and manage posts.

## Running the Tests

The tests can be executed from Visual Studio Test Explorer or using:

```bash
dotnet test