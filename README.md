# selenium-pom-test-project
Angelo Loria 01/2017

This is a C#/Selenium project demostrating a page object model framework, running tests on http://store.demoqa.com/. 

# Test Classes
Test classes are located in the Tests folder. There are currently three test classes set up; each class contains tests for a different section of the website. These classes contain the actual tests, each of which is in its own TestMethod. These TestMethods call methods from the various Page classes. The Test classes also utilize methods located in the TestHelper class through inheritance. 

# Page Classes
These classes each represent a page on http://store.demoqa.com/, and contain the methods used by the test classes that manipulate elements on those pages. Elements are also encapsulated on each page. All of these pages use the BaseNavigationMenuPage, which represents the navigation menu that is present on nearly every page of the site. 

# Browser Selection
Browser selection is done through selecting a .runsettings file using the Test Settings menu, under Test -> Select Test Settings file. Currently the project supports Chrome and Edge browsers. 
