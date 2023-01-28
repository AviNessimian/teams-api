# Assessment

##### [Go To Client App](https://github.com/AviNessimian/teams-client "Client Side")

Please see the attached database in the [docs](/docs/domainData).
You can use the mongorestore tool to import it to mongodb.

Mongo Database reference:
- DB: domainData
- User: domainReader
- Password: reader
- Auth mechanism: SCRAM-SHA-1

### collections
3 collections:
   * domainA
   * domainB
   * domainC

with the same schema
   - SubjectId field (String),
   - Timepoint field (Double), 
   - NumericValue field (Double)

## Instructions: 

1. Server-side C# Web API application (.net core):


   A. Create a C# data type to represent the scehma of the domainA, domainB, domainC collections. Name it "DomainValue".


   B. Create a C# data type to represent a schema with the fields:
       Timepoint field (Double), 
       AverageValue field (Double)
       *The schema represents the Average of Numeric values per time point, so name the data type accordingly.


   C. Implement a data access layer to retrieve or query data from a given collection in the database. 
      The data access layer should generalize the read access to the 3 collections and provide a uniform read access implementation for all of them, 
      as if there were N amount of tables with the same schema.


   D. Create a business layer:
       -Consume and use the data access layer.

       -Create an implementation to retrieve a list of all domains (collection names).

       -Create an implementation to retrieve the documents of a domain by domain name (collection name). 
        * Use the data type of #A for the results.
        * Consider limiting the retrieved documents to a given range.
       
       -Create an implementation to calculate the average of the numeric values, grouped by timepoint, for a given domain name (collection name).
        * Use the data type of #B for the results.


   E. Create a Web API:
       -Consume the business layer

       -Create a method to retrieve a list all domains

       -Create a method to retrieve the documents of a domain by domain name

       -Create a method to retrieve the average of the numeric values grouped by timepoint, for a given domain name




2. Client angular application 


   A. Create an angular application.


   B. The front page of the application should display a list of domain names. 
       Send a request to a running instance of the web api application to retrieve the list of domains.


   C. When a domain name is clicked (a default choice can be set), the client application should navigate to a domain-specific page.
       -In the domain-specific page, display a header with the name of the domain
       -Display a table with the documents of the domain collection. Send a request to a running instance of the web api application to retrieve the documents of a domain.
        *Consider paging of the documents in the table


   D. Under the rendered table, display a list of average values per time point. Send a request to a running instance of the web api application to retrieve the average values.



   ## Extra (Optional):
   A. Integrate plotly.js into the application (https://plot.ly/javascript/). You may use an angular component if you find one online.
   B. Display a plotly line chart below the list of average values.
       Use the same values of the list of average values per time point, where the x-axis values are set by the Timepoint field,
       and the y-axis values are set by the AverageValue field.
   








