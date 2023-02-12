# FlightsManager

## The Task

I was offered a task to create a system of managing flights from one point all 
over the world to other point all over the world. This system should consist of
sign up, sign in, log out functionality and of course opportunity of making flight
tickets reservations for each of flights in the database.

## System Description

This systems offers its users opportunity of sign up, sign in, log out of their own profiles.
Also, it offers opportunity of viewing all possible flights of the database, making tickets 
reservations for them, editing of their own reservations and recceiving brief information 
emails after making reservation.

## Database

![db_diagram](https://user-images.githubusercontent.com/47276102/218316902-436c58b5-42f6-4443-b6ee-5b512311c99f.PNG)

## Neede to Start the System

1. Visual Studio
2. .Net Core Web extension for Vissual Studio
3. Microsoft SQL Server 

## Functionalities and descriptions

1. Sign Up
  
  1.1. Filing up personal information
    * username
    * paswsword
    * re-entered password
    * email
    * name
    * family
    * pin (personal idenity number)
    * full addres - country, living area, destricted area, street, number, floor, apartment
    * phone number
   1.2. Sending information to the server
   1.3. Procceeding information by the server
   1.4. If the information is correctly filled up => registration, 
        if not => message from the server to the user
  
2. Sign In
  
  2.1. Filling up personal information
    * username 
    * password
   2.2. Sending information to the server
   2.3. Procceeding information by the server
   2.4. If the information is correctly filled up and there is no user with the same personal 
        information => logging in, if not => message from the server to the user
        
3. Log out

Pressing button Log out, deleting the user id from the server session and redirecting to the 
Login page.

4. Flights View

Viewing all flights from the database brief information (start point, end point, flying date 
and landing date) in multi page view with opportunity of filtering them.

5. Definite Flight View

Viewing full information about definite flight.

6. Making Reservation

   6.1. Filling information about how many people will be on the flight, their full personal
        information about flight ticket confirmation
   6.2. Sending information to the server
   6.3. Procceeding information by the server
   6.4. If the information is correctly filled up => making reservation and sending emails to 
        the passagers, if not => message from the server to the user

7. Sending Email for Reservation
8. Editing Reservation
9. Changing User Role

## User Roles and active functionality

General functionality permission - sign up, sign in, log out

1. Admin - chanign user role, viewing all employees, hiring / fireing employees, 
            adding flights, editing flights information, deleting flights from 
            the database, deleting reservations, all passager functionalities 
            
2. Passager - making reservations, editing reservations, deleting their own tickets 
              reservations
              
3. Employee (e.x. Pilot)

## System Components (Folders)

1. Models - entities from which is created the database
2. Views - connection with the web pages
3. Controllers - connection  between Models andd Views classes
4. Migrations - migrations of C# classes and database tables
5. Properties - system properties description
6. Utils - helper classes such as password hashing in the database 
   with SHA-256 
7. wwwroot - pages design

## Used Technologies

1. MVC
2. .Net Core Web programming
3. SQL Database with Microsoft SQL Server
