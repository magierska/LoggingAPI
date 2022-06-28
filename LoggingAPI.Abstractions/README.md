# LoggingAPI.Abstractions

Class library, which contains any interfaces or classes for which there might be a need for an implementation switch later.

> Let's consider scenario in which a decision comes to the team, that they should move from using PostgresDB to other DB. They can create new Class Library resembling [LoggingAPI.PostgresDB](../LoggingAPI.PostgresDb/LoggingAPI.PostgresDb.csproj) with repository implementing [ILogMessageDbRepository](ILogMessageDbRepository.cs). Then just switch the dependency injection.