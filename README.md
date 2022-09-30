# Service design

A good service:
- Handles unhandled exceptions 
- Performs syntax check on input data.
- Is divided by domain concepts (screaming architecture)
- has individual classes for each API method and domain handler.

Handle plumming in a consistent way
- Handle configuration.

# ASP.NET WebServices

## Handles unhandled exceptions

ASP.NET handles all unhandled exceptions and returns Internal Server Error (http response code 500). No thing to do here. 

