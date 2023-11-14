
# Auth

## Register User
```js
POST {{BASE}}/auth/register
```

#### Register Request
```json
    {
        "firstName": "jhon",
        "lastName" : "doe",
        "email"    : "jdoe@example.com",
        "password" : "jdoe123"
    }
```
#### Success Response

```json
 {
    "id": "d53c4d9a-zod23-35pdf-b920b44aa902",
    "firstName": "jhon",
    "lastName" : "doe",
    "email"    : "jdoe@exmaple.com",
    "token"    : "235s23-sldf135"
 }
```





## Login User

```js
POST {{BASE}}/auth/login
```

#### Reqeust body
```json
{
    "email"    : "jdoe@example.com",
    "password" : "jdoe123"
}
```