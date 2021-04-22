namespace Module4
{
    using System;
    using FsCheck;
    using FsCheck.NUnit;
    using System.Linq;
    using System.Collections.Generic;

    [NUnit.Framework.TestFixture]
    public class DequeTest
    {
        [Property]
        public Property Should_Expose_Stack_Push_Like_Operation(int[] input)
        {
            var dq = new Deque<int>();

            Func<bool> property = () => {
                var acc = input.Aggregate<int, bool>(true, (acc, i) =>
                {
                    dq.EnqueueHead(i);
                    return dq.Head.Value == i;
                });

                Console.WriteLine(string.Join(',', dq.ToArray()));
                Console.WriteLine($"Head={dq.Head.Value} - input.Last={input.Last()}");

                return acc && dq.Count == input.Length;
            };

            return property.When(input.Length > 0);
        }

        [Property]
        public Property Should_Expose_Stack_Pop_Like_Operation(List<int> input)
        {
            var dq = new Deque<int>();

            Func<bool> property = () => {

                // fill-in dq
                input.ForEach(i => dq.EnqueueHead(i));
                var filledUpSucceeded = dq.Count == input.Count;

                // checking last-in-input head-in-dq
                var acc = input.Reverse<int>().Aggregate(true, (acc, i) =>
                {
                    return dq.DequeHead() == i;
                });

                return filledUpSucceeded && acc && dq.Count == 0;
            };

            return property.When(input.Count > 0);
        }

        [Property]
        public Property Should_Expose_Queue_QueueUp_Like_Operation(int[] input)
        {
            var dq = new Deque<int>();

            Func<bool> property = () => {
                var acc = input.Aggregate<int, bool>(true, (acc, i) =>
                {
                    dq.EnqueueTail(i);
                    return dq.Tail.Value == i;
                });

                Console.WriteLine(string.Join(',', dq.ToArray()));
                Console.WriteLine($"Tail={dq.Head.Value} - input.First={input.First()}");

                return acc && dq.Count == input.Length;
            };

            return property.When(input.Length > 0);
        }


        [Property]
        public Property Should_Expose_Queue_Dequeue_Like_Operation(List<int> input)
        {
            var dq = new Deque<int>();

            Func<bool> property = () => {

                // fill-in dq
                // adding to head so first-in-input will be tail-in-dq
                input.ForEach(i => dq.EnqueueHead(i));
                var filledUpSucceeded = dq.Count == input.Count;

                // checking first-in-input should be tail-in-dq
                var acc = input.Aggregate(true, (acc, i) =>
                {
                    return dq.DequeTail() == i;
                });

                return filledUpSucceeded && acc && dq.Count == 0;
            };

            return property.When(input.Count > 0);
        }

    }
}
