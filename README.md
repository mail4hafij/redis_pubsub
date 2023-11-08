# Redis pubsub
Usually redis is used as caching service but it can also be used for publish and subscribe. Checkout this repo https://github.com/mail4hafij/redis_cache_dotnet_core if you are interested how to cache using redis.

There are two projects in this solution. Run the subscriber project first and then run the publisher.
But first, setup a redis on docker as follows. 

### Redis on docker

https://redis.io/docs/getting-started/install-stack/docker/

redis/redis-stack - contains both Redis Stack server and RedisInsight. 
This container is best for local development because you can use the 
embedded RedisInsight to visualize your data.


``` docker run -d --name redis-stack -p 6379:6379 -p 8001:8001 redis/redis-stack:latest ```

The docker run command above also exposes RedisInsight on port 8001. 
You can use RedisInsight by pointing your browser to localhost:8001.


Enjoy!
