# Exercises - Part 2 - ASP.NET Core MVC + Entity Framework + NUnit

## NUnit - Roman number converter
Make an application that converts numbers to there Roman notation:

![Valid Roman number conversion](images/RomanNumber_ValidConversion.png)

You can type a number in an input field and click on the *Convert* button. This results in the equivalent Roman number being shown. 

Roman numbers must be in the range from 1 to 3999. If a number out of range is converted an error message is shown:

![Valid Roman number conversion](images/RomanNumber_OutOfRange.png)

The *Controller* action methods are already implemented (*Home, Index*). The matching view is also already implemented.
What you need to do is to implement the *Convert* method of the *RomanNumberConverter* in the *Models* folder and write the necessary unit tests that verifies the implementation of the *Convert* method. 

Complete the *RomanNumberConverterTests* class (in the test project) by implementing the following tests:

* Convert_ValueIsNotBetweenOneAnd3999_ShouldThrowArgumentException
     * It is only possible to covert numbers between 1 and 3999. When the number to convert is out of bounds, an *ArgumentException* with the message *"Out of Roman range (1-3999)"* should be thrown. 
     * Define some test cases (2 or more). At least one test case for a value that is too small and at least one test case for a value that is too big.
* Convert_ValidValue_ShouldReturnRomanNumberEquivalent
     * Define some test castes (4 or more) to test a valid conversion. 
     * You can use the following (recursive) algorithm to implement the conversion:
          * If *number >= 1000* the result is *M* followed by the conversion of *number - 1000*. 
          * If *number >= 900* the result is *CM* followed by the conversion of *number - 900*. 
          * If *number >= 500* the result is *D* followed by the conversion of *number - 500*. 
          * If *number >= 400* the result is *CD* followed by the conversion of *number - 400*. 
          * If *number >= 100* the result is *C* followed by the conversion of *number - 100*. 
          * If *number >= 90* the result is *XC* followed by the conversion of *number - 90*. 
          * If *number >= 50* the result is *L* followed by the conversion of *number - 50*. 
          * If *number >= 40* the result is *XL* followed by the conversion of *number - 40*. 
          * If *number >= 10* the result is *X* followed by the conversion of *number - 10*. 
          * If *number >= 9* the result is *IX* followed by the conversion of *number - 9*. 
          * If *number >= 5* the result is *V* followed by the conversion of *number - 5*. 
          * If *number >= 4* the result is *IV* followed by the conversion of *number - 4*. 
          * If *number >= 1* the result is *I* followed by the conversion of *number - 1*.

Write the test first and then try to make it green by altering the production code.
Use a setup method.

