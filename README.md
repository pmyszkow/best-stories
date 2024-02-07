# Introduction 
Repository contains source code of a best-stories app

# best-stories
Application is implemented as Hacker News facade RESTful API for the purposes of fetching top N best stories

## Architecture & technology
Solution following **DDD** and **Hexagonal** architectural style implemented using **.Net Core 5.0** together with async programming pattern.

## Usage

Curl: *curl -X GET "https://{host}:{port}/api/v1/Stories/.json?top={numberOfTopStories}" -H  "accept: application/json"*
Request URL: *https://{host}:{port}/api/v1/Stories/.json?top={numberOfTopStories}*

For more details please refer to Swagger UI after sucessful build in debug mode.
https://{host}:{port}/swagger/index.html

Or generate client using spec:
https://{host}:{port}/swagger/v1/swagger.json
