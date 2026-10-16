public class Solution {
    public bool hasDuplicate(int[] nums) {
        var hash = new HashSet<int>();
        
        var l = nums.Length;
        for(int i = 0; i < l; i++)
        {
            if(!hash.Add(nums[i]))
                return true;
        }

        return false;
    }
}