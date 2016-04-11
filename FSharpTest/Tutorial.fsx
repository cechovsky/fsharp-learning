#r "packages/FSharp.Data.2.2.5/lib/net40/FSharp.Data.dll"
#r "packages/SQLProvider.0.0.11-alpha/lib/FSharp.Data.SQLProvider.dll"
open System
open System.Linq
open System.Data
open FSharp.Data.Sql
open FSharp.Data

[<Literal>]
let connString = @"Server=localhost;Database=postgres;User Id=postgres;Password=password"
[<Literal>]
let resPath = @"C:\\Development\\FSharpTest\\packages\\Npgsql.3.0.5\\lib\\net45"
let dbVendor = Common.DatabaseProviderTypes.POSTGRESQL
let indivAmount = 1000
let useOptTypes  = true

type sql = SqlDataProvider< 
              ConnectionString = connString,
              DatabaseVendor = Common.DatabaseProviderTypes.POSTGRESQL,
              ResolutionPath = resPath,
              IndividualsAmount = 1000,
              UseOptionTypes = true >
let ctx = sql.GetDataContext()

let query1 = query {
    for row in ctx.Public.DisplayNames do
    select row
}

let query2 = query {
    for row in ctx.Public.Affiliations do
    for pub in row.``public.publishers by id`` do
    //join pub in ctx.Public.Publishers on (pubId.PublisherKey = pub.Id)
    select (row.AffiliationKey, row.AffiliationType, pub.PublisherKey)
}


query1 |> Seq.iter (fun row -> printfn "%s %s" row.EntityType row.FullName.Value)
query2 |> Seq.iter (fun (a,b,c)-> printfn "%s %s %s" a b.Value c)

