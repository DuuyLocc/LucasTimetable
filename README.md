# PROJECT TIMETABLE WITH ASP.NET CORE 3.1 FROM LUCAS
## Link about project
- http://www.lucasitstore.tk/
- https://docs.microsoft.com/en-us/ef/core/get-started/install/
- https://www.learnentityframeworkcore.com/configuration/fluent-api

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
- *fluent API configuration (tách riêng ra)

Design database
- table: work

Install EF (Entity Framework) core 
- .NET Core CLI v3.1.9: Microsoft.EntityFrameworkCore.SqlServer
- Get the .NET Core CLI tools v3.1.9: Microsoft.EntityFrameworkCore.Design
- Get the Package Manager Console tools v3.1.9: Microsoft.EntityFrameworkCore.Tools

## Lesion 8 - Cấu hình entity với Fluent API | configure entity with Fluent API
- ORM: Object Relational Mapping (quản lý các object, table thông qua class)
- https://viblo.asia/p/object-relational-mapping-djeZ1PQ3KWz

## Lesion 9 - Migration database
- Microsoft.Extensions.Configuration.FileExtensions 3.1.9
- Microsoft.Extensions.Configuration.Json 3.1.9
- Lệnh thêm: Add-Migration _name_
- Thực thi: update-database

## Lesion 10 - Ddataa seeding tạo (data mẫu)