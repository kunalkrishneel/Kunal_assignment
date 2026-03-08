---------------------------------------
1- How would you design the pipeline from IoT Hub to your API / database?

IoT Devices -> Azure IoT Hub -> Message Stream (Event Hub / Service Bus) -> Processing Layer (Azure Functions to trasnform, validate  ) ->Web API (busines logic, integrations)-> Database (timeseries)

another approach could be all in Azure
IoT Devices -> Azure IoT Hub -> Message Stream (Event Hub / Service Bus) -> Processing Layer Azure Functions to transform, validate  and insert to azure db - Azure SQL
and all reporting could be based of Powerbi /custom dashboard
use signalr for near realtime pooling 
---------------------------------------
2 - The machines run a Unity application that controls motors and payment devices. Unity must send telemetry and events to IoT Hub.
o	How would you structure the Unity side?
   
    implement separations in layers ,use clean architure 
        hardware- motor controller, sensor  controller
        network- bakcground jobs to auzre 
        domain - vending machine logic 
        telemetry - all logs 
        separate functions so hardware crash doesnt affect networking 


o	Explain how you would:
        Separate hardware control logic from networking/telemetry logic.           
        Ensure that errors in hardware (e.g., motor jam, payment error) are reliably sent as telemetry events.

        telemetry- needs to maintain online and offlines data , so telementry to store all data, maintain buffer, locally sqlite, cache, queue message
        networking-   to upload data to clould, send and  retry functionality
---------------------------------------
You need to deploy your .NET API and Vue front-end to Azure:
o	Briefly outline:
    How you would host the API (App Service or Container).
	How you would host the front-end (static site / separate App Service).
	How configuration (connection strings, IoT Hub connection, etc.) should be handled securely.

    Use App Service its simplest and most common, automatic scaling and has built-in CI/CD integration all connected thru AzureDevops, good for smaller  apis applications 
    Vue app can be hosted on Azure Static Web Apps, use azure blob storage for static hosting 
    configuration  and keys use Azure App Service configuration, Azure Key Vault,App Service accesses them using Managed Identity and have separate enviroments , dev staging, prod each stage with separate configurations, db , connections
    if container is required then docker 

    some use digital signed certs + smart card  to establish conenction- can came across this during a VAT monioring system
    
---------------------------------------