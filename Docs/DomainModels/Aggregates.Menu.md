# Domain Models

## Menu

```csharp 
class Menu {
    Menu Create();
    void AddDinner(Dinner dinner);
    void RemoveDinner(Dinner dinner);
    void UpdateSection(MenuSection section);
}
```

```js
{
    id: "0000-00000-000000-000000",
    name: "zehir zembelek menu",
    description: "bir isirikta dunya yanacak",
    avarageRating: 4.9,
    sections: [
        {
            id: "0000-00000-000000-000000",
            name: "Tadimliklar",
            description: "baslangic",
            items: [
                id: "0000-00000-000000-000000",
                name: "Ali usta cig kofte",
                description: "zehir zembelek aci",
                price: 5.99 
            ]
        }
    ],
    CreatedAt: "2024-01-01T00:000.0000000Z",
    UpdatedAt: "2024-01-01T00:000.0000000Z",
    hostId:"0000-00000-000000-000000",
    dinnerIds: [
        "0000-00000-000000-000000"
    ],
    menuReviewIds:[
        "0000-00000-000000-000000"
    ],

}
```