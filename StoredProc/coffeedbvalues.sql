USE CoffeeDB

INSERT INTO dbo.Coffee (CoffeeName, Description)
VALUES ('Double Americano', 'Dark af'), ('Sweet Latte', 'Diabetes'), ('Flat White', 'Milky')

INSERT INTO dbo.Locations(LocationName, Description)
VALUES ('Pantry 1', 'First Location')

INSERT INTO dbo.Ingredients(IngredientName, Stock, Description, LocationId)
VALUES ('CoffeeBeans', 15, NULL, 1), ('Sugar', 15, NULL, 1), ('Milk', 15, NULL, 1)

INSERT INTO dbo.Recipes(CoffeeId, IngredientId, Amount)
VALUES (1, 1, 3), (1, 2, 0), (1, 3, 0), (2, 1, 2), (2, 2, 5), (2, 2, 3), (3, 1, 2), (3, 2, 1), (3, 2, 4)