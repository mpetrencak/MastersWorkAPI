In this folder is solution for backend

In folder Diplomka.IdentityServer is solution for Identity server

In folder FE is solution for frontend where is also React project
In React in folder public is folder PublishedWasm where is published latest version of FE project.
Also in folder public is folder _framework that is copied from PublishedWasm...


HOW TO START PROJECTS

Run all 3 .sln files (MinimalApi, DP.Frontend, Diplomka.IdentityServer)
and start them directly in visual studio

In folder FE open DP.Rect in VS Code and in terminal start React project using "yarn start". You will need Node.Js for this.

Then you will need correctly set up urls ports for every project. Every project have appsetting.json where are defined Urls.

MinimalApi have port 40000
DP.Frontend have port 40001
Diplomka.IdentityServer have port 40100
React have port 3000

For .NET project is possible to setup port in lauchsettings.json

Port 3000 should be default but in case for changig the port read this:
https://stackoverflow.com/questions/40714583/how-to-specify-a-port-to-run-a-create-react-app-based-project
