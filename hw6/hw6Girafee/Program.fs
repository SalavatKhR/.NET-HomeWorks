module Giraffe.App

open System
open System.IO
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Cors.Infrastructure
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Http
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging
open Microsoft.Extensions.DependencyInjection
open Giraffe
open hw5
open hw5.Parser
open hw5.Calculator

[<CLIMutable>]
type Values =
    {
        arg1: string
        operation: string
        arg2:string
    }
    

let calculatorHttpHandler : HttpHandler =
    fun next ctx ->
        let values = ctx.TryBindQueryString<Values>()
        match values with
        | Ok v ->
            let args = [|$"{v.arg1}";$"{v.operation}";$"{v.arg2}"|]
            let result = result{
             let parsedArg1, parsedOp, parsedArg2 = TryParseArguments [|args.[0]; args.[1]; args.[2]|]
             let! val1 = parsedArg1
             let! op = parsedOp
             let! val2 = parsedArg2
             let calculated = Calculate val1 op val2
             return calculated
            } 
            match  result  with
            | Success res -> (setStatusCode 200 >=> json (res)) next ctx
            | Failure exp -> (setStatusCode 400 >=> json (exp)) next ctx
        | Error e ->
            (setStatusCode 400 >=> json e) next ctx




let webApp =
    choose [
        GET >=>
            choose [
                route "/calculate" >=> calculatorHttpHandler
            ]
        setStatusCode 404 >=> text "Not Found" ]
    
type Startup() =
    member __.ConfigureServices (services : IServiceCollection) =
        services.AddGiraffe() |> ignore

    member __.Configure (app : IApplicationBuilder)
                        (env : IHostEnvironment)
                        (loggerFactory : ILoggerFactory) =
        app.UseGiraffe webApp

[<EntryPoint>]
let main _ =
    Host.CreateDefaultBuilder()
        .ConfigureWebHostDefaults(
            fun webHostBuilder ->
                webHostBuilder
                    .UseStartup<Startup>()
                    |> ignore)
        .Build()
        .Run()
    0