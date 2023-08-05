# Clubinho do bebe
[![Build Status](https://api.travis-ci.com/isaacslima/ClubinhoDoBebe.svg?branch=main)](https://api.travis-ci.com/isaacslima/ClubinhoDoBebe)

## Table of Contents

- [Introduction](#introduction)
- [Technologies](#technologies)
- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [API Documentation](#api-documentation)
- [Contributing](#contributing)
- [License](#license)

## Introduction

Welcome to the Clubinho do Bebe! This project is designed to provide a simple and user-friendly system for managing products and clients for a rental business. The system allows you to perform CRUD operations for products and clients and register client's rental for a specific period.

## Technologies

The project is built using the following technologies:

- .NET 7
- Angular 15

## Features

The main features of the project include:

- CRUD functionality for managing products.
- CRUD functionality for managing clients.
- Rental system: Clients can rent products for a specified time period.

## Installation

To run this project locally, follow these steps:

1. Clone the repository:

git clone https://github.com/isaacslima/ClubinhoDoBebe.git
cd ClubinhoDoBebe

2. Backend setup:
   - Make sure you have <a href="https://dotnet.microsoft.com/en-us/download">.NET 7</a> installed.
   - From root folder restore dependencies:
```
dotnet restore
```
3. Frontend setup:
   - Make sure you have <a href="https://nodejs.org/en">Node.js</a> at least 14.21.3 (lts) or later.
   - Navigate to the frontend folder and install dependencies:
```
cd ClientApp
npm install
```

## Usage

1. Backend and front-end:
   - To start the backend server, run the following command from the root folder:
   - The front-end will start automatically because inside ClubinhoDoBebe.csproj has a itemgroup to start it.

dotnet run --project Presentation\ClubinhoDoBebe.csproj

3. Open your web browser and go to `http://localhost:44417` to access the application.

