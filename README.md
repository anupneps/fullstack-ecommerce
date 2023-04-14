# Fullstack Project

![TypeScript](https://img.shields.io/badge/TypeScript-v.4-green)
![SASS](https://img.shields.io/badge/SASS-v.4-hotpink)
![React](https://img.shields.io/badge/React-v.18-blue)
![Redux toolkit](https://img.shields.io/badge/Redux-v.1.9-brown)
![.NET Core](https://img.shields.io/badge/.NET%20Core-v.7-purple)
![EF Core](https://img.shields.io/badge/EF%20Core-v.7-cyan)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-v.14-drakblue)

* Frontend: SASS, TypeScript, React, Redux Toolkit
* Backend: ASP .NET Core, Entity Framework Core, PostgreSQL

## Demo
- Frontend: https://hilarious-pasca-58c602.netlify.app
- Backend Api (Swagger) : https://orderlyonclick.azurewebsites.net/swagger/index.html
- For Api Usage : https://orderlyonclick.azurewebsites.net/api/v1/{products/users/categories}

## Introduction 
This ecommerce application namely Orderly is a fullstack project which has been developed using modern frontend technologies such as react and redux. The backend implementation is done using Asp.Net Core and Entity Framework having PostgreSQL as a database. The backend API is being hosted at Azure cloud services.  

## Frontend

## Features Implemented 
1. Public Pages : Homepage, Categories, Cart, Login/SignUp
2. Private Pages : Profile and Admin
    - Profile page only visible by the loged in user 
    - Admin tab appears once admin has log in 
3. Search products from input bar and filter products by price and ascending order with buttons in categories page
4. Search products from different categories in categories page
5. Able to signup and login to the webpage until you refresh the page
6. All the cart functionality can be performed (add, remove, increase/decrease quantity)
7. Once you click on product image, it will redirect to single product page and and it has addToCart button for everyone and  Edit and Delete buttons for admins. 
8. Theme change has been implemented (MUI example)
9. Unit test has been done for cart and product 
10. CRUD operation on products

## Things to do
1. User persistance
2. More UI features and styling
3. Image upload using Cloudinary
4. react-toastify for notifications

## Instruction to start the project

Clone the project

- https://github.com/anupneps/fullstack-ecommerce

Go to the project directory

- cd frontend

### `npm install`

Install all the dependencies

### `npm start`

Runs the app in the development mode.\
Open [http://localhost:3000](http://localhost:3000) to view it in the browser.

The page will reload if you make edits.\
You will also see any lint errors in the console.

### `npm test`

Launches the test runner in the interactive watch mode

### `npm run build`

Builds the app for production to the `build` folder.\
It correctly bundles React in production mode and optimizes the build for the best performance.

## Backend

## Features Implemented 
1. CRUD operation on products, categories for all and on users only for admin 
2. Also custom api route to get products from each category
3. Authentication and Autorization
4. Deployed to Cloud
5. Api endpoints with query params and pagination
6. Modular and flexible architecture implementing database-repo-service-controller layers

## Things to do
1. Add more authorization policies
2. Add middlewares and more custom exception handlers
3. Add other custom routes

## Instruction to start the project

In the project directory, you can run:

## Run Locally
Clone the project

- https://github.com/anupneps/fullstack-ecommerce

Go to the project directory

- cd backend

Install dependecies

- dotnet run

Configure Appsetting file add the following information
```
{
  "AllowedHosts": "*",
  "Jwt": {
    "Token": "XXXXXXXX"
  },
  "ConnectionStrings": {
    "DefaultConnection": "XXXX"
  }
}

```


