namespace CrackingTheCodingInterview
{
    public class SortStack
    {

        public void sort(Stack<int> s)
        {
            var s2 = new Stack<int>();
            while ((s.Count > 0))
            {
                var temp = s.Pop();
                while (!s2.Any() && s2.Peek() > temp)
                {
                    s.Push(s2.Pop());
                }
            }
        }
    }
}
