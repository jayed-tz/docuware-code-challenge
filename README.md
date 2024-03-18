# Implementation of Docuware technical challenge

This project contains the implementation of the technical task for the interview process at Docuware.
The project uses the latest .net version 8.

## Installation and run

Restore the depepndencies using NuGet. Run the project.

The API is available at:
`https://localhost:7150`

OpenAPI support has been enabled, the swagger documentation can be found at: `https://localhost:7150/swagger/index.html`

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
    "Description": "Quaterly meet up",
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
A few things were assumed during the development of the project:
1. User registration is not necessary for the prototype
2. The Event DTO (`EventRequest`) contains a property for the duration, it seemed user friendly. However, the DB model `Event` contains the computed EndTime.

## Improvements
The implementation was kept simple with potential enhancement and improvement areas on:
1. Retrieve key from a suitable service (AWS Secrets manager, Azure Key Vault)
2. It was coded on the master branch for simplicity, a proper branch convention would be ideal
3. 
