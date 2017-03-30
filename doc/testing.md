#Testing
Note to reader:  This document is a sequel to unitTesting.md (also included in the doc folder).

###How Are We Testing the Code?
>The basic idea behind **_Unit Testing_** is that each "Unit" of code, be it a Class or a Method, is written such that is it test-able.

>Our goal is, therefore, to do just that; we will write tests for each unit of code.  
A 'unit', in this case, refers to any method within one of Project's classes.

###What Should The Reader Expect?
>Upon completion of this project, the reader should expect to see the following:
*  For each Project within the Solution, there exists a Test Project with the following naming convention.  Eg, WebCrawler.Web == WebCrawler.WebTests
*  For each Test Project, there exists a number of folders; each of these folders corresponds to a non-testing folder with the same name.  Eg, WebCrawler.WebTests.Controllers == WebCrawler.Web.Controllers 
*  For each of the folders, there exists at least one test class that mirrors a non-test class.  Eg, WebCrawler.WebTests.Controllers.HomeControllerTests.cs == WebCrawler.Web.Controllers.HomeControllers.cs 
*  For each test class, there exists at least one Test Method for each method from a non-test class. (generally speaking, but not always)
> Eg, Index() == IndexTest()
*  The format of each test will primarily follow the "A,A,A" method of organization:

>>>[TestMethod]  
>>>public void MethodNameFollowedByTheWordTestAndOrDescription()  
>>>{  

>>>//Arrange  
   
>>>//Act  
  
>>>//Assert  
  
>>>}  

*  Also expect to see a document named TestResults.md in this directory.  It will discuss what you think it will discuss.

###Conclusion
As a final note to reader, there may be exceptions to all the above cases.  If the reader encounters a deviation from the above expectations, there will/should be a note or comment inside the testing classes that address the issue.