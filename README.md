# PROJECT TIMETABLE WITH ASP.NET CORE 3.1 FROM LUCAS
## Link about project
- http://www.lucasitstore.tk/
- https://docs.microsoft.com/en-us/ef/core/get-started/install/
- https://www.learnentityframeworkcore.com/configuration/fluent-api

## Group trao đổi
- Học lập trình ASP.NET MVC 5
- Góc IT - Cùng học lập trình

## ANOTHERS
- Crystal report

## Lesion 1 - Introduce ASP.NET MVC core source
Technologies
- ASP.NET CORE 3.1
- Entity framework core 3.1
- SQL 2019 v18.6
- C# 8.0

Required skill
- HTML & CSS
- Javascript basic
- C# basic
- SQL sever basic

## Lesion 2 - setup development enviroment
- SDK
- SQL
- Visual studio
- Git client
- Nodejs

Bonnus: 
- Git extensions for Visual studio
- SQL sever management tool

## Lesion 3 - create solution and source code repository
- models
- views
- controllers
- appseting
- root
- program
- startup
- dependencies
- properties

## Lesion 4 - create solution structure
Git flow
master -> develop -> feature/solution_folder -> create pull request to develop -> bugfix/fix_error_start -> create pull request to develop

Solution structure
- *N layer (data, business, presentation) data driven design
- DDD (domain driven design)

WebApplication: Request pipeline
## Lesion 5 - design function

## Lesion 6 - design database

## Lesion 7 - create entity class and setup EF core
CÓ 2 CÁCH CẤU HÌNH KIỂU DỮ LIỆU GIÚP MIGRATION DATABASE
- altribute configuration (chỉ ra thẳng) 
-- Data Annotations Attributes (https://www.learnentityframeworkcore.com/configuration/data-annotation-attributes)
- *fluent API configuration (tách riêng ra)

Design database
- table: work

Install EF (Entity Framework) core 
- .NET Core CLI v3.1.9: Microsoft.EntityFrameworkCore.SqlServer
- Get the .NET Core CLI tools v3.1.9: Microsoft.EntityFrameworkCore.Design
- Get the Package Manager Console tools v3.1.9: Microsoft.EntityFrameworkCore.Tools

## Lesion 8 - Cấu hình entity với Fluent API | configure entity with Fluent API
- ORM: Object Relational Mapping (quản lý các object, table thông qua class)
-- https://viblo.asia/p/object-relational-mapping-djeZ1PQ3KWz
- Có 2 cách: ghi đè hoặc tách ra các class riêng (Separate Configuration Classes)

## Lesion 9 - Migration database
- Microsoft.Extensions.Configuration.FileExtensions 3.1.9
- Microsoft.Extensions.Configuration.Json 3.1.9
- Lệnh thêm: Add-Migration _name_
- Thực thi: update-database

## Lesion 10 - data seeding tạo (data mẫu)
- tạo data mồi cho data mẫu (data trống) clear code
- Model seed data (https://docs.microsoft.com/en-us/ef/core/modeling/data-seeding)
- tạo dataseeding -> migration lại -> update-database 

## Lesion 11 - Add ASP.NET Identity tables
- ASP.NET Core Identity là gì? (https://tedu.com.vn/kien-thuc/cai-dat-va-su-dung-aspnet-identity-core-va-identity-server-4-trong-ung-dung-aspnet-core-270.html)
- Identity library: IdentityDbContext
- File > New > Project -> ASP.NET Core Web Application -> Web Application -> Authentication -> Individual user account -> OK
- tables is: AppUser, AppRole, AppUserClaims, AppRoleClaims, AppUserRoles, AppUserLogins, AppUserTokens

## Lesion 12 - create application layer structure (tầng application = sevice)
- Logic: feature/sevice_layer -> create modul catalog/ system/
- Keyword: SOLID -> Dependence inverse -> dependence Injection pattern; View model; SOLID Principles
- tất cả phương thức của 1 class được định nghĩa qua interface

## Lesion 13 - create search and paging method
## Lesion 14 - update product method
## Lesion 15 - thêm bảng hình ảnh (nope)
## Lesion 16 - thêm phương thức quản lý hình ảnh (nope)
- Adding: Microsoft.AspNetCore.Hosting & Microsoft.Extensions.Hosting & Microsoft.AspNetCore.Hosting.Abstractions
- edit project file -> delete 2 reference -> <frameworkReference Include="Microsoft.AspNetCore.App" /> 
## Lesion 17 - create web api BackendApi
- BackendApi -> delete view -> set startup project -> create controller 
-> config connectionstring: appsettings.Development.json 
-> config connectionstring in startup: ConfigureServices -> add reference 
-> 
## Lesion 18 - add Swagger to web api
- Install Swagger: Swashbuckle.AspNetCore 
## Lesion 19 - create restful api for work
## Lesion 20 - Image
## Lesion 21 - login
- by web api and jwwt (not save section like MVC it just return jwwt)
- done register, login admin
## Lesion 22 - Add Authorization to Swagger
- AddSwaggerGen: AddSecurityDefinition, AddSecurityRequirement
- JWT config
- services.AddControllers();
## lesion 23 - Fluent validator viewmodel of WebApi 
- validation 2 cách: [Required(ErrorMessage = "UserName is required")] fix cứng khó thay đổi điều kiện
- https://docs.fluentvalidation.net/en/latest/aspnet.html
## Lesion 24 - create admin app & add template
- https://startbootstrap.com/previews/sb-admin-2
## Lesion 25 - create Login page and integrate backend API
- Login with web api (not use identity on app mvc core)
- https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-5.0
## Lesion 26 - Cookie Authentication without ASP.NET Identity
- cookie authenticcation without asp.net core identity
- https://docs.microsoft.com/en-us/aspnet/core/security/authentication/cookie?view=aspnetcore-5.0
## Lesion 27 - get list user
- 