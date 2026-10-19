public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var hash = new Dictionary<int, int>();
        
        for(int i = 0; i < nums.Length; i++)
        {
            var n = nums[i];
            if(!hash.ContainsKey(n))
                hash[n] = i;
                
            var delta = target - n;

            if(hash.TryGetValue(delta, out var v2) && i != v2)
                return new []{v2, i};
        }

        return null;
    }
}
