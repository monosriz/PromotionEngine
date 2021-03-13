1)Language - C#

2) Architectural Framework  - Domain-Driven-Design 

3) Design Pattern - Dependency Injection,Singleton

4) Open api specification - Swagger

5) Used  LINQ for Data Operation

6) Unit Test - xUnit Test Project Template


7)appsettings.json - Product and Promotion configuration information has been stored

a) You can change a product price or add new product
b) You can change the existing promotion offer or you can add a new production type.


8) To Get the Result need to call a API

URL -/api/promotion/totalcost  
HTTP Verb - POST
Body (JSON-Sample Data)

[
{
    "id":"A",
    "Quantity":3

},
{
    "id":"B",
    "Quantity":5

},
{
    "id":"C",
    "Quantity":1

},
{
    "id":"D",
    "Quantity":1

}


]



