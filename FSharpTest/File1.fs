//module File1
//
////#r "packages/FSharp.Data.2.2.5/lib/net40/FSharp.Data.dll"
////#r "bin/Debug/FSharp.Data.SQLProvider.dll"
//open System
//open System.Linq
//open FSharp.Data.Sql
//open FSharp.Data
//
//[<Literal>]
//let connString = @"Server=localhost;Database=postgres;User Id=postgres;Password=password"
//[<Literal>]
//let resPath = @"C:\Windows\Microsoft.NET\assembly\GAC_MSIL\Npgsql\v4.0_3.0.5.0__5d8b90d52f46fda7\"
//let dbVendor = Common.DatabaseProviderTypes.POSTGRESQL
//let indivAmount = 1000
//let useOptTypes  = true
//
//type sql = SqlDataProvider< 
//              ConnectionString = connString,
//              DatabaseVendor = Common.DatabaseProviderTypes.POSTGRESQL,
//              ResolutionPath = resPath,
//              IndividualsAmount = 1000,
//              UseOptionTypes = true >
//let ctx = sql.GetDataContext()
//
