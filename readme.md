# ☕✨ Coffee Sky API

API built with .NET implementing a CRUD for Coffee Products + NASA APOD integration.

## About the project (API .NET com CRUD de Products + integração NASA).
This project is a RESTful API developed in .NET that manages coffee shop purchases (CRUD operations for products) and enriches
them with data retrieved from the NASA Astronomy Picture of the Day (APOD) API.

The idea is that every time a coffee purchase is recorded, the system also stores the astronomical image and description of that day. 
This transforms a simple coffee purchase into an emotional memory, connecting the experience with the cosmos.

## Endpoints

### 📌 GET /products
Retrieves all registered coffees with their information and linked NASA data.

**Answer example:**
```json
[
  {
    "id": "123e4567-e89b-12d3-a456-426614174000",
    "name": "Morning Brew",
    "purchaseDate": "2025-08-27",
    "nasaData": {
      "title": "Beautiful Galaxy",
      "description": "A spiral galaxy 50 million light years away...",
      "imageUrl": "https://apod.nasa.gov/apod/astropix.html"
    }
  }
]
Returning a 200 Status Code

```
### 🔹 POST /products
Creates a new coffee purchase record.

Example Request:
```json
[
    {
     "name": "Cappuccino",
     "purchaseDate": "2025-08-25"
    }
]
Returning a 200 Status Code

```
### 🔹 PUT /products/{id}

Updates an existing coffee purchase record.

Example Request:
```json
[
    {
     "name": "Cappuccino Deluxe",
     "purchaseDate": "2025-08-25"
    }
]

Returning a 200 Status Code
```

### 🔹 DELETE /products/{id}

Removes a coffee purchase from the database.
    with a 200 Status Code, if product is removed successfully.
##

🌌 NASA Integration 

External API used: https://api.nasa.gov/planetary/apod (No_key in this example)

Each time a product (coffee) is created, the API fetches the corresponding APOD data for that date.

The NASA image, title, and description are stored along with the product data.

    ⚠️ API Key

By default, this project uses the NASA public key:

"NASA": {
  "ApiKey": "DEMO_KEY"
}

🔑 If you want to use your own key (to avoid request limits), create one at https://api.nasa.gov
 and replace the value in appsettings.json.
    
    ⚠️ Possible Errors

400 Bad Request → Invalid data in the request body.

404 Not Found → Coffee product not found.

502 Bad Gateway → Error when communicating with NASA API.

    🛠️ Technologies

C# / ASP.NET Core

Entity Framework Core

SQL Server 

NASA APOD API

    🚀 How to run

Clone the project

Update your appsettings.json with your database connection string and NASA API key

Run the migrations

Start the project with:

dotnet run


The API will run on https://localhost:5001.