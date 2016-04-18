# PrimeReliableActors-FabricAzure
This project is an example of how to calculate prime lists using actors per calculation and OWIN self hosting web server to expose the actors. 
Also one of it's purposes is to do some performance analysis. 

It wasn't easy to find an easy project to follow along the examples of https://github.com/Azure-Samples/service-fabric-dotnet-getting-started
so I hope this will show a simple task without the unnescesary overhead of the previous samples. 

An important bottom line - there's no way of communicating (starting, using methods) with a Actor class, although there are examples of doing
so locally, using the CreateProxy method. Remotly we need to use a web server (OWIN) in order to expose our actors. 



