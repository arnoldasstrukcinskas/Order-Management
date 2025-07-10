# Order Management API
## Table of Contents
- [About](#about)
- [Features](#features)
- [Tech Stack](#tech-stack)
- [Installation](#installation)
- [Launching](#launching)
## About
This API is created for handling and processing customers orders, stores information about orders in the database. Additionaly in the system can generate discounts and apply a discount according to it's rules.
Additionally API can generate report of all or specified products.
## Features
- Create/get/delete products.
- Create/update/delete discounts
- Create/get/delete orders.
- Get reports of all or each discounted products.
## Tech Stack
| Technology | Purpose |
|------------|---------|
| ASP.NET Core 8.0 | Web API Framework |
| C# 12 | Programming language |
| Swagger | API documentation |
| PostgreSQL | Database |
| Pg Admin | Database ,amage,emt UI |
| Docker | Components containerization |

## Installation
1. Whole project is containerized and created using containers so firstly you need to install docker engine:
Link: https://docs.docker.com/engine/install/
2. For this API to work, you need to dowload three images: Asp.net, postgresql and pgadmin

### ASP.net Image
```bash
  docker run -d p 5000:5000  mcr.microsoft.com/dotnet/aspnet:latest
```

### PostgreSQL database Image
Login
UserName: example
Password: login
```bash
 docker run -d p 5432:5432  postgres:latest
```

### PgAdmin
Login
User: example@gmail.com
Password: admin
```bash
  docker run -d p 5050:80  elestio/pgadmin:latest
```
#### !!! To see any information in pgAdmin you have to conect to database.
Right-click on Servers -> Register -> server
#### Login:
**General:**
- Name: example(You can choose by yuorself)

**Connection:**
- Host name/address: ordermanagement.database
- Port: 5432
- username: arnoldas
- Password: admin
## Downloading project
For project to launch firstly need to download project or clone it from repository.
#### 1. Download
- Go to this repository: https://github.com/arnoldasstrukcinskas/Order-Management
- Then press green button Code and and Download Zip.
- Unpack zip file
- Move to [Launching](#launching)
#### 2. Clone(If you have git)
- Open Terminal and go to directory you want to clone project(add your own directory)
  ```bash
  cd D:\example
  ```
- In terminal use this command:
  ```bash
  git clone https://github.com/arnoldasstrukcinskas/Order-Management.git
  ```
- Move to [Launching](#launching)
## Launching
#### 1. Go to project directory(this is example directory)
```bash
cd "D:\Download\Order Management API\Order Management"
```
#### 2. Build project(with logs)
```bash
docker-compose build
```
#### 3. Launch project(with logs)
```bash
docker-compose up
```
#### 3. Launch project(without logs)
```bash
docker-compose up -d
```
#### 4. Stop project(without logs)
```bash
ctrl + c
```
### Links:
- Link to swagger: https://localhost:5001/swagger
- Link to PgAdmin: http://localhost:5050
