# ShortUrl

Pre-requisites
Docker running with linux container

Build and execute
Clone the project 
git clone 
At the root folder execute
docker-compose up -d

Web app url: http://localhost:9000

Api to shorten url: 

POST http://localhost:8000/shorten
Accept : application/json
{
"longurl":"https://yourlongurl/test"
}

Response
Status code: 200 OK
http://localhost:8000/shorturl

Api to redirect short url to original url

GET http://localhost:8000/shorturl

Response
Status Code: 302
Location: https://yourlongurl/test



