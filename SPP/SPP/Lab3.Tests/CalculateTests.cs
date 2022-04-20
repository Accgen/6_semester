using System;
using NUnit.Framework;

namespace Lab3.Tests;

public class CalculateTests
{
    public Calculate Calculate;
    [SetUp]
    public void Setup()
    {
        Calculate = new Calculate();
    }

    [Test]
    public void SumShouldPass()
    {
        //acr
        var number1 = 10;
        var number2 = 5;
        var expected = 15;
        var numbers = new[] {number1, number2 };
        
        //action
        var actual = Calculate.Sum(numbers);
        
        //assert
        Assert.AreEqual(actual, expected);
    }
    
    [Test]
    public void SumShouldFail()
    {
        //acr
        var numbers = new[] { int.MaxValue, int.MaxValue };
        
        //action
        
        //assert
        Assert.Throws<OverflowException>(() => Calculate.Sum(numbers));
    }
    
    [Test]
    public void KeepShouldThrowException()
    {
        //acr
        string source1 = null;
        string source2 = null;
        
        //action
        
        //assert
        Assert.Throws<ArgumentNullException>(() => Calculate.Keep(source1, source2));
    }
    
    [Test]
    public void KeepShouldReturnNull()
    {
        //acr
        string source1 = null;
        string source2 = "c";
        string expected = null;
        
        //action
        var actual = Calculate.Keep(source1, source2);
        
        //assert
        Assert.AreEqual(expected, actual);
    }
    
    [Test]
    public void KeepShouldReturnStringEmpty()
    {
        //acr
        var source1 = "";
        var source2 = "c";
        
        var source11 = "с";
        string source22 = null;

        var source111 = "с";
        string source222 = "";
        string expected = "";

        //action
        var actual = Calculate.Keep(source1, source2);
        var actual1 = Calculate.Keep(source11, source22);
        var actual2 = Calculate.Keep(source111, source222);
        
        //assert
        Assert.AreEqual(expected, actual);
        Assert.AreEqual(expected, actual1);
        Assert.AreEqual(expected, actual2);
    }
    
    [Test]
    public void KeepShouldReturnResult()
    {
        //acr
        var source1 = "hello";
        var source2 = "hl";
        string expected = "hll";
        
        var source11 = "hello";
        string source22 = "le";
        string expected1 = "ell";

        //action
        var actual = Calculate.Keep(source1, source2);
        var actual1 = Calculate.Keep(source11, source22);
        
        //assert
        Assert.AreEqual(expected, actual);
        Assert.AreEqual(expected1, actual1);
    }
}