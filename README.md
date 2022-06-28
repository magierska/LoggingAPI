# LoggingAPI

API gathering logs from other applications into Postgres database.

### Decisions
- Message and application name fields are required on each element of the array when making the request.
- Log date is not required, because in most of the cases it could be pretty accurately deduced based on current time. And it is crucial to log any possible log message, even if received data is not complete.