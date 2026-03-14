using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities (1, 5, 2). 
    // Dequeue until the queue is empty.
    // Expected Result: High (5), Medium (2), Low (1)
    // Defect(s) Found: The original code failed to look at the last item in the list 
    // (off-by-one) and failed to actually remove items from the queue.
    public void TestPriorityQueue_BasicPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 5);
        priorityQueue.Enqueue("Medium", 2);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same high priority (A:5, B:2, C:5).
    // Expected Result: A (5), C (5), B (2)
    // Defect(s) Found: The original code used ">=" which caused it to pick the 
    // LATEST item added for a priority tie (C) rather than the EARLIEST (A).
    public void TestPriorityQueue_TieFIFO()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("FirstHigh", 5);
        priorityQueue.Enqueue("MidLow", 2);
        priorityQueue.Enqueue("SecondHigh", 5);

        Assert.AreEqual("FirstHigh", priorityQueue.Dequeue());
        Assert.AreEqual("SecondHigh", priorityQueue.Dequeue());
        Assert.AreEqual("MidLow", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue several items and ensure the highest priority item 
    // is correctly identified when it is at the very end of the internal list.
    // Expected Result: EndItem (10)
    // Defect(s) Found: The loop range was "index < _queue.Count - 1", meaning 
    // the last item in the queue was ignored during the search.
    public void TestPriorityQueue_LastItemPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 10); // The last item

        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: (This test verifies the requirement for error handling is met).
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown for empty queue.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}
