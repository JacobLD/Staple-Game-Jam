using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SampleTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void SampleTestSimplePasses()
    {
        // Use the Assert class to test conditions
        // Nothing will pass the test
    }

    [Test]
    public void TrueNotEqualFalse()
    {
        Assert.IsTrue(false!=true);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator SampleTestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
