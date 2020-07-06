for EF, use command:

dotnet ef migrations add InitialCreate --project Data --startup-project Migration

Project Data cannot target directly because it runs .Net Standard 2.0 and is not supported. Project Migration is .Net Core 3.1 and is supporeted by DotNetCliToolReference

Reference:
https://rajbos.github.io/blog/2020/04/23/EntityFramework-Core-NET-Standard-Migrations