Invoke-WebRequest -Uri http://localhost:7210/api/Auctions/1

Invoke-WebRequest -Uri http://localhost:5033/Auctions -Method POST -Body '{"Title":"Boat"}' -Headers @{"Content-Type" = "application/json"}