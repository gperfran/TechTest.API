# TechTest.API

This sample demonstrates how to use the API as per the Mobile team coding challenge.

# Tech Stack
 .Net Core 3.1
 Swashbuckle.AspNetCore 5.0 (documentation)
 Database In Memory

    
# How to run the API?
Clone it on local machine
Open the solution on Visual Studio 2019
Run it with F5
Use postman and add the following URL as a POST https://localhost:5001/checkout

# Request parameter
Add the following JSON as a paramenter in the BODY (I have fixed the ProductId from the task description document)

{   
	"CustomerId": "8e4e8991-aaee-495b-9f24-52d5d0e509c5",
	"LoyaltyCard":"CTX0000001",   
	"TransactionDate":"03-Jan-2020",   
	"Basket": [     
		{     "ProductId":"PRD01",     "UnitPrice":"1.2",     "Quantity":"3"     },     
		{     "ProductId":"PRD02",     "UnitPrice":"2.0",     "Quantity":"2"     },     
		{     "ProductId":"PRD03",     "UnitPrice":"5.0",     "Quantity":"1"     }  
		] 
	
} 
