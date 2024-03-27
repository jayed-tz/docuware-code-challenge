# This is an implementation of a use case that is focused on .NET

The requirements are as follows:
1. There are two kinds of users
    a. An event creator who has to login
    b. An event participant, who can register for the event
2. The event creator
    a. Can create an event
    b. Can see all registrations for an event
3. The event participant
    a. Can see all events,
    b. Choose one event and fill the registration form for it
4. An event has the following fields
    a. Name
    b. Description
    c. Location
    d. Start time
    e. End time
5. A registration may have the following fields
    a. Name
    b. Phone number
    c. Email address

Optionally, add an angular application to serve a UI for the aspnet backend.



## Installation and run
The project uses the latest .net version 8.

Restore the dependencies using NuGet. Run the project.

The API is available at:
`https://localhost:7150`

OpenAPI support has been enabled, the swagger documentation can be found at: `https://localhost:7150/swagger/index.html`

> Replace the DB connection string with your own

### Identity
##### Retrieve a jwt token
`https://localhost:7150/identity/token` [POST]
```
curl --location 'https://localhost:7150/identity/token' \
--header 'Content-Type: application/json' \
--data-raw '{
    "username": "anakin@mail.com",
    "password": "strong-p@ss"
}'
```
### Events
##### retrieve all the events
`https://localhost:7150/events` [GET]
```
curl --location 'https://localhost:7150/events'
```
##### Create an event
`https://localhost:7150/events/create` [POST]
> Auth token is necessary
```
curl --location 'https://localhost:7150/events/create' \
--header 'Content-Type: application/json' \
--header 'Authorization: Bearer xxxxxxx' \
--data '{
    "Name": "Berlin Meet up",
    "Description": "Quarterly meet up",
    "Location": "Berlin",
    "StartTime": "04/19/2024 11:00 AM",
    "Duration": 120
}'
```
### Registrations
##### Register for an event
`https://localhost:7150/registrations/create` [POST]
```
curl --location 'https://localhost:7150/registrations/create' \
--header 'Content-Type: application/json' \
--data-raw '{
    "Email": "sith@mail.com",
    "Name": "Participant Darth Sidious",
    "Phone":"019333535",
    "EventId": "3c852193-c52c-4c11-a7c3-0583a888339c"
}'
```
##### Retrieve all the registrations of an event
`https://localhost:7150/registrations?eventid=xxx` [GET]
> Auth token is necessary
```
curl --location 'https://localhost:7150/registrations?eventid=xxx' \
--header 'Authorization: Bearer xxxxxxx'
```

## Assumptions
A couple of assumptions that were made during the development of the project:
1. User registration is not necessary for the prototype
2. The Event DTO (`EventRequest`) contains a property for the duration, it seemed user friendly. However, the DB model `Event` contains the computed EndTime.

## Improvements and limitations
The implementation was kept simple with potential enhancement and improvement areas on:
1. Retrieve key from a suitable service (AWS Secrets manager, Azure Key Vault etc.)
2. Use a Response DTO instead of the DB models
3. Connection string is hardcoded for now, a proper alternative is necessary
4. Everything was implemented under one project, separation is necessary for maintainability
5. Long lived token was used for development
6. No test has been added
7. No deployment pipeline has been added
8. No linting and coverage tools have been added
8. A proper error handling mechanism is essential. For now, the handling is kept simple and poor
9. The Angular project is bare minimum, that is not the focus of the implementation


##### There can be more assumptions and improvement scopes
