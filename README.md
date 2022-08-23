# Introduction

This is my ToDoList application. It contains all the code to display a listing things I need to do.

The ToDoList consists of three parts.

## TodoDAL

Is the database backend. It contains the routines to get and push new data to and from the database.

## ToDoList

Is the ASP.Net Web Forms browser application that displays the data and contains forms to display and update the data. It retrieves its data from ``ToDoDAL``.

## ToDoListTest

Is the testing backend for the data routines. This is a console program that I use to create and test routines for data access. The code from here eventually makes its way in to ``ToDoList``.

# Getting Started

I have a list of tasks that need to be completed. See ToDoList\ToDo.txt.

# Future Tasks

Eventually I will need to update this application to add a REST API for data access.
