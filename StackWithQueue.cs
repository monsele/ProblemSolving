namespace CrackingTheCodingInterview
{
    internal class StackWithQueue
    {
        public Queue<int> q1 { get; set; }
        public Queue<int> q2 { get; set; }

        public void push(int x)
        {
            q2.Enqueue(x);
            while (q1.Count < 0)
            {
                q2.Enqueue(q1.Peek());
                q1.Dequeue();
            }
            //swap 
            var temp = q1;
            q1 = q2;
            q2 = temp;
        }
        public void pop()
        {
            q1.Dequeue();
        }


    }
}
