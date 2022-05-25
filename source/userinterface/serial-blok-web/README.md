# Digital Service Portal

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 1.2.0.

## Enable HTTPS on localhost 

Install the root certificate, follow the guideline [here](https://docs.devops.buhlergroup.com/iot-environment-pki/certificate-management/) to install the root certificate for the testing environment.

## Development server

The dev server is available on [https://localhost:4200/](https://localhost:4200/)
and will automatically reload if you change any of the source files.

* `npm install` installs npm packages. use this before running `npm start` for the first time.

* `npm start` starts a HTTPS dev server. 
* `npm run start-prod` starts a HTTPS server running a production build. 
* `npm run start-uat` starts a HTTPS dev server using the `uat - proxy configuration`.
* `npm run start-demo` starts a HTTPS dev server using the `demo - proxy configuration`.
* `npm run start-systest` starts a HTTPS dev server using the `systest - proxy configuration`.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `-prod` flag for a production build.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via [Protractor](http://www.protractortest.org/).
Before running the tests make sure you are serving the app via `ng serve`.

## Further help

- To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI README](https://github.com/angular/angular-cli/blob/master/README.md).

- [Fix the '[WDS] Disconnected!' issue](docs/fixWdsDisconnectError.md)

## Commit/Push Rules

See the [repository guidelines](https://docs.devops.buhlergroup.com/iot-docs-guidelines/repository-guidelines/#format-of-the-commit-message).
