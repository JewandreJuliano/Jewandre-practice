Here are my Answers for module 1:

SalesReport.razor
-I don't think there is the need to instantiate the DB connection string in the load method. Breaks Single Responsibility.
-I also see that there is an emailer method that also does not need to be there SRP.

RegionSummary.razor
-I see that the connection string is hardcoded and that is Dependency Inversion - also think thats the case for SalesReport.razor.

LegacySalesDb.cs 
-The ISalesRepository is quite big so it could be voilating the Interface Segregation.

Sorry if I didn't catch all of them.

public class ArchivedSalesDb : LegacySalesDb - this class inherits from a class that uses an interface - seems like its not abiding to the parent child relationship.

0.15m I see that this value is not set as a constant that can be called by many other methods that might need to use it.

The EmailSender never gets used as it was being done in the SalesReport Page.

We could extend the EmailSender to become a MessengerService that handles SMS and Emails?

The seperation of concerns in the ,td> on Slaes report needs to be optimized where those are split into classes of their own to handle the calculations(maybe one classs with different methods inside?)