# CompositeMapper

Some say "Manual mappers are safer!"

Others say "Auto mappers are faster!"

We say...

![Why not both?](https://media1.tenor.com/images/067bb2e4df4aaa6d8c702eb9eabb0964/tenor.gif?itemid=11478682)


CompositeMapper is a very simple framework that allows you to use an automapper (like Mapster or AutoMapper) while also providing specific hard coded mappings, facilitated by a single abstraction so that your calling code doesn't have to care.

## Install

Nuget:  install-package Develorem.CompositeMapper

## How it works

You inject 'IMapper' and use it.
Under the covers it will first try to resolve through (dependency injection) a hard coded mapper of the types you are mapping.
If it can't find one, it will fall back to the configured auto mapper. 

## Two types of mappers

We call the fallback mappers 'AutoMappers' and they implement the IAutoMapper interface.
We call the hard coded mappers 'ExplicitMappers' and they inherit from the ExplicitMapper<TSource, TTarget> abstract class.

## Registering mappers

At the moment we only support Microsoft.Extensions.DependencyInjection as the IoC container (IServiceCollection and IServiceProvider). 
As such we take a nuget dependency on the Microsoft.Extensions.DependencyInjection.Abstractions nuget package.

You can use the extension method in the 'ServiceCollectionExtensions' static class to register your automapper, and pass it a list of assemblies to be scanned for explicit mappers.

```
services.RegisterCompositeAutoMapper<MapsterAutoMapper>(typeof(MyExplicitMap).Assembly);
```
