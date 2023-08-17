namespace AlgorithsPractise.LeetcodeBlind75
{
    public class IsSubtree
    {
        public NodeLR FirstTree { get; set; }
        public NodeLR SecondTree { get; set; }

        public bool IsSubtreeEh(NodeLR first, NodeLR second)
        {
            if (first == null && second == null)
            {
                return true;
            }

            if(first == null || second == null)
            {
                return false;
            }

            if (first.Value == second.Value)
            {
                var lef = IsSubtreeEh(first.Left, second.Left);
                if (!lef)
                {
                    return false;
                }
                var rig = IsSubtreeEh(first.Right, second.Right);
                if (lef && rig)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                var isSubtreeLeft = IsSubtreeEh(first.Left, second);
                if (isSubtreeLeft)
                {
                    return true;
                }
                var isSubtreeRight = IsSubtreeEh(first.Right, second);

                if (isSubtreeRight)
                {
                    return true;
                }
                return false;
            }

        }

    }
}