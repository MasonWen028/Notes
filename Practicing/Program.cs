#region selection sort

static void SelectionSort(int[] nums)
{
	if (nums == null || nums.Length < 2)
	{
		return;
	}

	for (int i = 0; i < nums.Length - 1; i++)
	{
		int minIndex = i;
		for (int j = i + 1; j < nums.Length; j++) 
		{
			minIndex = nums[j] > nums[minIndex] ? minIndex : j;
		}
		Swap(nums, minIndex, i);

    }
}

static void Swap(int[] nums, int i, int j)
{
	nums[i] = nums[i] ^ nums[j];
	nums[j] = nums[i] ^ nums[j];
	nums[i] = nums[i] ^ nums[j];
}


#endregion


#region Bubble Sort

static void BubbleSort(int[] nums) 
{
	if (nums == null || nums.Length < 2)
	{
		return;
	}

	for (int i = nums.Length - 1; i > 0 ; i--)
	{
		for (int j = 0; j < i; j++)
		{
			if (nums[j] > nums[j + 1])
			{
				Swap(nums, j , j + 1);
			}
		}
	}
}

#endregion


#region comparator


#endregion
