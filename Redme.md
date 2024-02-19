# Technical Task - Backend Engineer

I created two services connected by RabbitMQ 
The PixelService returns a 1x1 transparent image and sends the user information via RabbitMq to the StorageService.
Both services use DDD Arquitecture and are completly detached.
I wanted to keep everything as simple as possible.
Any doubts or suggestions you may contact me.

## Content

    ├───PixelService
    │   ├───PixelService.API
    │   ├───PixelService.Application
    │   ├───PixelService.Domain
    │   ├───PixelService.Infrastructure
    │   └───PixelService.Tests
    └───StorageService
        ├───StorageService.Application
        ├───StorageService.Domain
        ├───StorageService.Infrastructure
        ├───StorageService.Messaging
        └───StorageService.Tests
