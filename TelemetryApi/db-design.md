*********************************
Create MachineState Table Statement 
*********************************
CREATE TABLE [dbo].[MachineState](
	[MachineId] [nvarchar](450) not null  PRIMARY KEY,
	[TemperatureC] [float] NULL,
	[Status] [nvarchar](max) NULL,
	[LastErrorCode] [nvarchar](max) NULL,
	[TsUtc] [datetime2](7) NULL)

*********************************
Create Telemetry Table Statement 
*********************************

CREATE TABLE [dbo].[Telemetry](
	[Id] [bigint] IDENTITY(1,1) NOT NULL  PRIMARY KEY,
	[MachineId] [nvarchar](max) NOT NULL,
	[TemperatureC] [float] NULL,
	[Status] [nvarchar](max) NULL,
	[LastErrorCode] [nvarchar](max) NULL,
	[TsUtc] [datetime2](7) NULL,)


***Note***
there is MachineId foriegn key in Telementry Table in case any Data is cleared from Machinestate then it will raise conflits.

1- how you would query “all machines with their latest telemetry”

all latest data in stored in MachineState table,Data is only added to the data  MachineState table if it is not present , else it will update the data as per machineid

2-	how you would index the data.

index can be applied on machineid as it will unique id in the table, this will avoid scaning entire telemetry data to pick lastest data.
current implentation, telemetry data is only logs for future  dashbaord , trend analysis for common issue times, issues.