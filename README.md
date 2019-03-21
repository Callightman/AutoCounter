# AutoCounter
An automation for collecting printer counters and save with a rest api while listing the data on a react built web application
This git has 4 projects
1. Asp.Net Web Api
The windows service sends the counters collected via Post and it saves it to database using Entity Framework.
The react app gets the counters and customers via Get
2. Windows Service
Windows Service uses SnmpSharpNet to collect the counter data from the printers with snmp and post the counters and status(online-offline) of the printer
to web api. 
3. Config Tool
There are only 2 settings only. First is the txt file that keeps the ip addresses that is used by windows service and the customer Id.
4.React Ui
The User interface to view counters collected of the customers, search in customers, add customers etc.

You need to change the webconfig file with your own connection string.

The project is for learning purposes only
