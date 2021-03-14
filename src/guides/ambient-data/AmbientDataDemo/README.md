# Ambient data

This project contains a demo app for the [Share data across the lifetime of an HTTP request](../../../../docs/guides/share-data-with-async-local.md) guide.

This app is an ASP.NET web api that shows how to use `AsyncLocal<T>` to share ambient data accross the lifetime of an HTTP Request.

## How to run

* Open the `AmbientDataDemo.sln` which can be found at `src/guides/ambient-data/AmbientDataDemo`.
* From Visual Studio, set the `AmbientDataDemo` project as the Startup Project.
* Run the project.
* The browser should open on the swagger page at https://localhost:5001/swagger/index.html.
* Execute the `/api/ambient/demo` endpoint by clicking on it, then on the *Try it Out* button and finally on the *Execute* button.
* Analyse the code to understand how ambient data is used across the HTTP request.