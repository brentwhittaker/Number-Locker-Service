## Number-Locker-Service

### Features:

- Api gateway with Service Bus

- Message broker for async processing

- Command pattern for Commands + Events

- Loosley coupled microservices

- Generated Api ui with swaggerui. Go to https://localhost:5001/swagger/index.html

### Tech:

- Asp.netcore

- RabbitMq

- MongoDb

- Hangfire.Mongo

### Tools:

- Git Bash for Windows

- vscode

- vs community edition

- Robomongo

### Notes:

Only implemented direct messaging, should be refactored to use message exchange (with fanout) for maintainability.

If you encounter the 'connection is not private' browser error message, please proceed to localhost(unsafe) to view swagger page.
