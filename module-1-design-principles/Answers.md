Here are my Answers for module 1:

SalesReport.razor
-I don't think there is the need to instantiate the DB connection string in the load method. Breaks Single Responsibility.
-I also see that there is an emailer method that also does not need to be there SRP.

RegionSummary.razor
-I see that the connection string is hardcoded and that is Dependency Inversion - also think thats the case for SalesReport.razor.

LegacySalesDb.cs 
-The ISalesRepository is quite big so it could be voilating the Interface Segregation.

Sorry if I didn't catch all of them.