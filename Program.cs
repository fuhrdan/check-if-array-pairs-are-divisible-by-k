//*****************************************************************************
//** 1497. Check If Aarray Pairs Are Divisible by K   leetcode               **
//*****************************************************************************


bool canArrange(int* arr, int arrSize, int k) 
{
    int* mp = (int*)calloc(k, sizeof(int)); // Initialize array of size k to 0 (O(K))
    
    // Process each number in arr
    for(int i = 0; i < arrSize; i++) 
    {
        int rem = ((arr[i] % k) + k) % k; // Handling negative remainders
        mp[rem]++;
    }

    // Check if the number of elements with remainder 0 is even
    if (mp[0] % 2 != 0) 
    {
        free(mp); // Free allocated memory
        return false;
    }

    // Check for each remainder pair (rem, k - rem)
    for (int rem = 1; rem <= k / 2; rem++) 
    {
        int counterHalf = k - rem;
        if (mp[counterHalf] != mp[rem]) 
        {
            free(mp); // Free allocated memory
            return false;
        }
    }

    free(mp); // Free allocated memory
    return true;
}