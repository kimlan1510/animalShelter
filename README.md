# Animal Shelter

#### A program that allows users to input animals into a mock shelter database. 6/6/17

#### By **Marilyn Carlin and Kimlan Nguyen**

## Description

A website created with C# and HTML where a user can enter animals into a shelter database, and remove them from the database once they've been rehomed.


### Specs
| Spec | Input | Output |
| :-------------     | :------------- | :------------- |
| **User can add animal types to shelter DB** | add cat | Cat |
| **User can add individual animals to DB** | "Olive", female, 6/6/17, domestic shorthair  | Name: "Olive" Gender: female Admitted: 6/6/17 Breed: domestic shorthair |
| **User can query animals in DB by type or breed**| Query: all cats | Cats: "Abigail, Olive, Zephyr" |
| **User can query animals in DB by date of admittance**| Query: animals by admittance | Animals: Juniper (6/1/17), Zephyr (6/3/17), Olive (6/6/17) |
| **User can delete animals from DB once they've been rehomed** | Delete: Zephyr | "Zephyr has been rehomed!" |

## Setup/Installation Requirements

1. To run this program, you must have a C# compiler. I use [Mono](http://www.mono-project.com).
2. Install the [Nancy](http://nancyfx.org/) framework to use the view engine. Follow the link for installation instructions.
3. Clone this repository.
4. Open the command line--I use PowerShell--and navigate into the repository. Use the command "dnx kestrel" to start the server.
5. On your browser, navigate to "localhost:5004" and enjoy!

## Known Bugs
* No known bugs at this time.

## Technologies Used
* C#
  * Nancy framework
  * Razor View Engine
  * ASP.NET Kestrel HTTP server
  * xUnit

* HTML

## Support and contact details

_Email no one with any questions, comments, or concerns._

### License

*{This software is licensed under the MIT license}*

Copyright (c) 2017 **_{Marilyn Carlin, Kimlan Nguyen}_**
