#UnitTesting
###Our Plan
>The basic idea behind **_Unit Testing_** is that each "Unit" of code, be it a Class or a Method, is written such that is it test-able.

>Our goal is, therefore, to do just that; we will write tests for each unit of code.

###Potential Problems
* Writing test code is a new adventure, therefore, unforeseen problems may arise.
* Given the uncertainties with writing test code in general, and the uncertainties  
associated with testing new technologies, the goal of testing **_EVERY_** Unit  
of code may or may not be feasible.

###An Example
     Preliminary research suggests that Visual Studio has a fairly comprehensible testing
framework.  Here is a general example of a test on a given method.  
[The example below was borrowed from this link.](http://www.codeproject.com/Articles/763928/MVC-Unit-Testing-Unleashed)

>
 //Test Cases  
[TestMethod]  
public void TestForViewWithValue0()  
{  

>//     Arrange  
         TestingController t = new TestingController();

>    //Act  
    ViewResult r = t.GetView(0) as ViewResult;  

>    //Asert  
    Assert.AreEqual("View2", r.ViewName);  

>}  

>[TestMethod]  
public void TestForViewWithValueOtherThanZero()  
{  
    //Arrange  
    TestingController t = new TestingController();  

>    //Act  
    ViewResult r = t.GetView(1) as ViewResult;  

>    //Asert  
    Assert.AreEqual("View1", r.ViewName);  

>}  

The example below is a test code snippet relative to our current project.  

>HomeController home = new HomeController();
 var view = home.Index() as ViewResult;
 Assert.IsNotNull(view);
 Assert.IsInstanceOfType(view, typeof(ViewResult));


###Conclusion
Where do we go from here?  The next step is to research more on testing
for both an MVC project and a Python based console app.
It seems both Python and C# have an ample supply of libraries from which we
can use.  We know Ideally, the writing of code and writing of tests will go
hand in hand, one will compliment the other, so that when the non-testing code
is complete, the testing code is finished shortly thereafter.  
The main point is to write unit tests as the code is written.
