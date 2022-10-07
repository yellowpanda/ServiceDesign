# Good service design

A good service treats commands and queries differently.

A good service process command requests with the following steps:
1. Syntax validation. Do the request contain all required data.
2. Fetch data 
3. Domain validation. Do the request make sense in relation to other data.
4. Domain logic. Here we change state of the system.
5. Response generation.

A good service process query requests with the following steps:
1. Syntax validation. Do the request contain all required data.
2. Execute query.
3. Response generation.

A good service has a consistent model for:
- Handle configuration.
- Handles unhandled exceptions 
- Is divided by domain concepts (domain folders pattern)
- Value Objects 
- Filters, sorting and pagination


# Example

## Value objects
Use Nuget package [ValueOf](https://www.nuget.org/packages/ValueOf). 

Why use value obejcts see [Treating Primitive Obsession with ValueObjects | DDD in .NET](https://youtu.be/h4uldNA1JUE) .

See example in [Price.cs](./ASP.NET%20WebAPI/DomainLayer/Price.cs).

Entity Framework needs to be told about value object, like this:
```csharp
modelBuilder.Entity<Bid>().OwnsOne(x => x.Price);
``` 
See [UnitOfWork.cs](./ASP.NET%20WebAPI/Infrastructure/Persistence/UnitOfWork.cs).


# GraphQL
Every good service needs a consistent way of handling filters, sorting and pagination on queries. Why not use a common known query language like GraphQL.

How to implement GraphQL with a library called HotChocolate: [GraphQL API in .NET w/ Hot Chocolate](https://youtube.com/playlist?list=PLA8ZIAm2I03g9z705U3KWJjTv0Nccw9pj).

See [Query.cs](./ASP.NET%20WebAPI/Graphql/Query.cs) and [program.cs](./ASP.NET%20WebAPI/Graphql/program.cs).
