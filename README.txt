#DEWY DECIMAL SYSTEM
The Dewy Decimal System is an ASP.NET web application that is used to train library users 
and novice librarians in the use of the Dewy Decimal Classification System. My application 
trains users to order books in ascending order by their call number, find call numbers and
correctly replace a book.

##Getting Sarted
The instructions listed below will guide you on how to install and run the appliation

##What things you need to install the software and how to install them:

Any of the latest MS Visual Studio e.g. v.16.1.0 (2019)
A device with dual core processing and at least 4GB's of RAM e.g. Acer Aspire
MSSQL Server for running the database

###Installing

*Setting up the enviroment

**CLASS LIBRARY 
-There is a class library used by the name DD_ClassLibrary. Ensure that this is included in the program.
-Make sure that the file path that is being used by the class library matches the location of the file 
in memory when being read.

**DATABASE
-Begin with creating a databse named DB_USER in MSSQL
-After creating the database, open the TBL_CREATES_DEWYDECIMAL from the root folder containg this README. Create a new 
 table named TBL_USER.
-Open Ms Viual Studio.

**VS PROJECT
-Click on the 'Open project or solution' option and open the DewyDecimalSystem project.
-Ensure that the project references the DD_ClassLibrary.
-Add a new connection to the visual studio project and connect to DB_USER database.
-Once you have successfuly loaded up the enviroment, click on the Server Explorer and select to run on either Firefox 
 or Google Chrome. Firefox is the preferred option.
-After selecting your preferred browser option, click on run. Ensure that the Default.aspx page loads first.

*Navigating the website

-When you have successfully launched the application, the homepage will come up.
-The options will appear. Select the option to Find a Book.
-You will be lead to the Find.aspx page where you can start the matching.
**For testing purposes the application outputs the list correct answers everytime you click on 'Next' 
  onto the output console. Use this to select the correct answer.
-The play game option leads to the FindGame.aspx page.

**Finding Game
-You will be expected to match the values the same way as before but you can only get three wrong
-you can exit the game by clicking on the 'Stop Game' button.
-When your last chance is done, enter your name and click proceed.
 The button will lead you to the scoreboard where only the top 10 scores will be displayed in order.
-You can exit the window to return to the Find.aspx page by clicking on finish.

To test this program:

-Select the wrong value to check if accepts the incorrect value
-click on next without selecting a value


## Built With

* [Dropwizard](http://www.dropwizard.io/1.0.2/docs/) - The web framework used
* [Maven](https://maven.apache.org/) - Dependency Management
* [ROME](https://rometools.github.io/rome/) - Used to generate RSS Feeds

##Authors
**Koketso Baruti**

##Acknowledgements

* Youtube tutors
* Microsoft ASP.NET Forums
* StackOverflow
* Mr Rudoloh Holzhousen