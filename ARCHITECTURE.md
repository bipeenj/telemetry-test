Part D – Architecture / Concept Questions

1.Azure IoT Hub / Events

Azure function with "Data Receiver" role for IoT event hubs which gets triggered because its subscribed for events ; Azure function has system assigned managed identity so we can authenticate against our api resource. Similarly our API is registered under app regosteration with system assigned identity and access database with DefaultAzureCredential so our access from one resource to other is secured. I this way database is updated with values from devices. We will use SignalR to push updates as we recieve Post api call from azure function so UI update in real time.

2.Unity + Hardware + Telemetry
The machines run a Unity application that controls motors and payment devices. Unity must send telemetry and events to IoT Hub.
How would you structure the Unity side?
Explain how you would:
I think we should use IOT edge for distributed approach so we seperate hardwar control layer for devices from telemetry. IOT edge can handle device errors and their software updates along with publishing events to IOT event hubs so that azure functions and eventually our api end points can be called to update databases.

3.Deployment to Azure App Service
You need to deploy your .NET API and Vue front-end to Azure:
Briefly outline:
If we want more control for no of pods/containers we can deploy webapi  as container but scaling needs to be done by ourselves for deploying as appservice we can configure it for scaling using azure portal. 
For UI currently its served as static file along with api but we can host it as seperate app service along with user logins against some resource(API/APPservice) registered using appregistration in azure. So that we can use role of the user and filter api return values based on user autorization.
