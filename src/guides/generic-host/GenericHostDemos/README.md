# Generic Host use cases

These projects contains demos for the [Use cases for generic host](../../../../docs/guides/generic-host-use-cases.md) guide.

## ConsoleAppWithGenericHost project

This app is a console app that shows how to make use of the generic host to provide dependency injection, logging and configuration via appsettings.

### How to run - ConsoleAppWithGenericHost

* Open the `GenericHostDemos.slnx` which can be found at `src/guides/generic-host/GenericHostDemos`.
* From Visual Studio, set the `ConsoleAppWithGenericHost` project as the Startup Project.
* Run the project.

### ConsoleAppWithGenericHost2 project

This app is a console app that shows how to make use of the generic host to provide dependency injection, logging and configuration via appsettings.

**It also shows** how to start and stop the host in case you need any functionality that is tied to those host operations.

### How to run - ConsoleAppWithGenericHost2

* Open the `GenericHostDemos.slnx` which can be found at `src/guides/generic-host/GenericHostDemos`.
* From Visual Studio, set the `ConsoleAppWithGenericHost2` project as the Startup Project.
* Run the project.

## AWSLambdaWithGenericHost project

This app is an AWS Lambda created with the template for an empty function. The template was modified to make use of the generic host to provide dependency injection, logging and configuration via appsettings.

### How to run - AWSLambdaWithGenericHost

* Open the `GenericHostDemos.slnx` which can be found at `src/guides/generic-host/GenericHostDemos`.
* From Visual Studio, set the `AWSLambdaWithGenericHost` project as the Startup Project.
* Run the project.

## AWSLambdaWithGenericHost2 project

This app is an AWS Lambda created with the template for an empty function. The template was modified to make use of the generic host to provide dependency injection, logging and configuration via appsettings.

**It also shows** how to start and stop the host in case you need any functionality that is tied to those host operations.

### How to run - AWSLambdaWithGenericHost2

* Open the `GenericHostDemos.slnx` which can be found at `src/guides/generic-host/GenericHostDemos`.
* From Visual Studio, set the `AWSLambdaWithGenericHost2` project as the Startup Project.
* Run the project.

## Notes

* For the configuration values to be loaded from the appsettings.json file, the appsettings.json file properties must be configured to have the `Build Action` set to `Content` and the `Copy to Output Directory` to `Copy if newer`.