namespace Module4
{
    using System;
    using FsCheck;
    using FsCheck.NUnit;
    using System.Linq;

    [NUnit.Framework.TestFixture]
    public class QueueTest
    {
        [Property]
        public Property Size_Should_Increase_With_Every_New_Element_In_The_Queue(int[] src)
        {
            var queue = new Queue<int>();
            for (int i = 0; i < src.Length; i++)
            {
                queue.QueueUp(src[i]);
            }
            return (queue.Count == src.Length).ToProperty();
        }

        [Property]
        public Property Dequeueing_Should_Remove_First_Queued_Element(int[] src)
        {
            Func<bool> test = () => {
                var firstInSrc = src[0];
                var queue = new Queue<int>();
                for (int i = 0; i < src.Length; i++)
                {
                    queue.QueueUp(src[i]);
                }
                var dequeued = queue.Dequeue();
                return dequeued.Value == firstInSrc && queue.Count == src.Length - 1;
            };
            return test.When(src.Length > 0);
        }

        [Property]
        public Property QueueingUp_Should_Always_Add_New_Tail(int[] src)
        {
            Func<bool> test = () => {
                var firstInSrc = src[0];
                var queue = new Queue<int>();

                var alwaysAddedToTail = src.Aggregate<int, bool>(true, (acc, i) =>
                {
                    queue.QueueUp(i);
                    return queue.Tail.Value == i;
                });

                return alwaysAddedToTail && queue.Count == src.Length;
            };
            return test.When(src.Length > 0);
        }
    }
}
