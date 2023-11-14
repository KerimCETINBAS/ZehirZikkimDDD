

# Menu

## Create menu

```js
POST /hosts/{hostId}/menus
```

#### Request Body
```json 

    {
        "name": "Yummy menu",
        "description": "A menu with yummy food",
        "sections": [
            {
                "name": "Appetizers",
                "description": "Starters",
                "items": [
                    {
                        "name": "Fried Pickles",
                        "description": "Deep fried pickles"
                    }
                ]
            }
        ]
    }
```

#### Success Response
```json
```

#### Fail Response
```json
```