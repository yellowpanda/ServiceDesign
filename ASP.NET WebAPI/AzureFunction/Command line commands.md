Invoke-WebRequest -Uri http://localhost:7210/api/Auctions/1

Invoke-WebRequest -Uri http://localhost:7210/api/Auctions -Method POST -Body '{"Title":"House"}'