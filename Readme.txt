Tech Chanllege -Race Day

I have created this application using C# .NET Core 2.1 and Angular 5.

SDK for .NET core can be found here https://www.microsoft.com/net/download/dotnet-core/2.1

Technologies that I have used to solve this problem are:

1. Visual Studio - 2017
2. .NET Core 2.1
3. Angular 5
4. NodeJs (I have used latest version of NodeJs 8.11.3 and this can be found here https://nodejs.org/en/download/
5. XUnit for Unit testing. I have used TDD approach so solve from business layer to implement the model for API.
6. FluentAssertions to test the assertion in easy way.
7. Moq to mock API calls as same as Repository pattern.
8. Swagger UI for documenting the API and testing.
9. Newton.Json package for json deserialization.
10. Async programming to call API.


API Documentation.
The API is integrated with Swagger to provide the documentation and contract and easy way to make API call.
This page will give detail of the API and you can use Try It button to test the API call.
http://localhost:53981/swagger/index.html (consider as running on port 53981 and in localhost)

The name of two APIs
1.	/api/DemoRace/RaceSummary
2.	/api/DemoRace/CustomerBetsSummary
Web Site:
If you execute the application that this will show a web page with Race summary. There is much scope to improve the UI and add more styling but I have focused more in API development.

Unit Test:
Created basic unit testing with minimum records to complete the requirement. There is scope to improve and add more unit testing to test properly and also giving proper naming.

Special Consideration:
        To calculate the payout, I have used to formula as stake of all customers * odds. This may be incorrect but for simplicity I have used this formula.

    
