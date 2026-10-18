public class Solution {
    public bool IsAnagram(string s, string t) {
        var chars = new int[256];

        if(s.Length != t.Length)
            return false;

        foreach(var c in s)
        {
            chars[(byte)c]++;
        }

        foreach(var c in t)
        {
            chars[(byte)c]--;
            if(chars[(byte)c]<0)
                return false;
        }

        return true;
    }
}
