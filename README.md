# ShortUrl

## Pre-requisites
Docker running with linux container

## Build and execute
1. Clone the project    
`git clone`    
2. At the root folder execute    
`docker-compose up -d`

## Accessible URLs
### Web app url:    
`http://localhost:9000`

### Api to shorten url: 

```
POST http://localhost:8000/shorten
Accept : application/json
{
"longurl":"https://yourlongurl/test"
}
```

#### Response    
```
Status code: 200 OK    
http://localhost:8000/shorturl
```

Api to redirect short url to original url

`GET http://localhost:8000/shorturl`

#### Response    
```
Status Code: 302    
Location: https://yourlongurl/test
```
