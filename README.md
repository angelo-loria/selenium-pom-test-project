# selenium-pom-test-project
Angelo Loria 01/2017

This is a C#/Selenium project demostrating a page object model framework, running tests on http://store.demoqa.com/. 

# Test Classes
Test classes are located in the Tests folder. There are currently three test classes set up; each class contains tests for a different section of the website. These classes contain the actual tests, each of which is in its own TestMethod. These TestMethods call methods from the various Page classes. The Test classes also utilize methods located in the TestHelper class through inheritance. 

# Page Classes
These classes each represent a page on http://store.demoqa.com/, and contain the elements and methods that work with those elements. There is also a base page- the BaseNavigationMenuPage, which represents the navigation menu that is present on nearly every page of the site. Methods within these classes are utilized by the TestMethods. 

# App.config
The App.config file allows you to set the browser. Currently, Chromedriver is the only driver present, but this will be expanded upon in the future.
