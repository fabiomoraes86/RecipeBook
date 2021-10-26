# Recipe Book Api

API (CRUD) of recipes, using Visual Studio

## Before starting
Make sure you:
 - Have Visual Studio or Visual Studio Code

 ## Optional
 - Have postman installed

## Starting
1. Clone the application to your local workspace
2. Start the application from Visual Studio or Visual Studio Code
3. Use routes via Swagger or via Postman

### Api Route
The API uses the path `https://localhost:5001` or `http://localhost:5000`

#### Recursos da API
For the definition of resources, an approach closer to RESTful was adopted.


## Ingredients

| Verb      | Resource                                          | Description                |
|-----------|:--------------------------------------------------|:---------------------------|
| `POST`    | `/v1/ingredient/add/{recipeId}`                   | Add ingredient             |
| `POST`    | `v1/ingredient/remove/{recipeId}/{ingredientId}`  | Remove ingredient          |


## Recipe Book

| Verb     | Resource                           | Description               |
|----------|:-----------------------------------|:--------------------------|
| `POST`   | `/v1/recipebook`                   | Add recipe                |
| `GET `   | `/v1/recipebook`                   | Get all recipes           |
| `GET `   | `v1/recipebook/2`                  | Get recipes by id         |
| `POST`   | `/v1/recipebook/remove/{recipeId}` | Remove recipe by id       |
| `PUT`    | `/v1/recipebook/update/{recipeID}` | Update recipe             |
