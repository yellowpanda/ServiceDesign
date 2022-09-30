# Service design

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

