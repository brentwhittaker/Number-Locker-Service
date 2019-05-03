# Number-Locker-Service

Features:
Api gateway with Service Bus
Message broker for async processing
Command pattern for Commands + Events
Loosley coupled microservices
Generated Api ui with swaggerui. 
Go to http://localhost:<port number>/swagger/index.html

Tech:
Asp.netcore
RabbitMq
MongoDb
Hangfire.Mongo

Tools:
Git Bash for Windows
vscode
vs community edition
Robomongo

Resources:
Udemy.com .NETCORE Microservices

Notes:
Only implemented direct messaging, should be refactored to use message exchange for maintainability.
If you encounter the 'connection is not private' browser error message, please proceed to localhost(unsafe) to view swagger page.
