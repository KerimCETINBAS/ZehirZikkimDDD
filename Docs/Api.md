


## Auth

### Register

#### RegisterRequest 

```js
POST {{BASE}}/auth/register
```
```json
    {
        "firstName": "jhon",
        "lastName" : "doe",
        "email"    : "jdoe@example.com",
        "password" : "jdoe123"
```
#### RegisterResponse 

```json
 {
    "id": "d53c4d9a-zod23-35pdf-b920b44aa902",
    "firstName": "jhon",
    "lastName" : "doe",
    "email"    : "jdoe@exmaple.com",
    "token"    : "235s23-sldf135"

 }
```



### Login 

#### LoginRequest

```js
POST {{BASE}}/auth/login
```

```json
{
    "email"    : "jdoe@example.com",
    "password" : "jdoe123"
}
```