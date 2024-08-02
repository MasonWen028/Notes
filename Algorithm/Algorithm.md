``` Time complexity
1. constant time operation


```

```bitwise XOR == bitwise addition
1. 0 ^ n = n  n ^ n = 0

2. a ^ b = b ^ a, a ^ b ^ c = a ^ (b ^ c) = (a ^ b) ^ c

so, when swapping two int, we can do like this:

int a = m;
int b = n;

a = b ^ a = m ^ n;
b = a ^ b = m ^ n ^ n = m ^ (n ^ n) = m ^ 0 = m;
a = a ^ b = m ^ n ^ m = (m ^ m) ^ n = 0 ^ n = n;

we just completed the process of swapping like this.

but what we should pay attention to is that it can not be defined on the same memory location

question about XOR

int[] nums,

1. only 1 element repeats an odd number of times, all others apears an even number of times.
2. only 2 element repeats an odd number of times, all others apears an even number of times.

requirements: time complexity O(N) space complexity: O(1)

public static int Xor1(int[] nums)
{
	int result  = 0;
	for (int i = 0; i < nums.length - 1; i++)
	{
		result = result ^ nums[i];
	}
	return result;
}


public static void Xor2(int[] nums)
{
	int a = 0;
	int b = 0;
	for (int i = 0; i < nums.length - 1; i++)
	{
		result = result ^ nums[i];
	}
	return result;
}





```

``` Selection sort

```c#

public static void SelectionSort(int[] nums)
{
	for(int i = 0; i < nums.length - 1; i++)
	{
		int minIndex = i;
		for(int j = i + 1; j < nums.length; j++>)
		{
			minIndex = nums[minIndex] < nums[j] ? minIndex : j;
		}

		nums[i] = nums[i] ^ nums[minIndex];
		nums[minIndex] = nums[minIndex] ^ nums[i];
		nums[i] = nums[i] ^ nums[minIndex];
	}
}

```

```

``` Bubble sort

```c#
public static void BubbleSort(int[] nums)
{
	if (nums == null || nums.length < 2)
	{
		return;
	}

	for(int i = nums.length - 1; i > 0; i--)
	{
		for(int j = 0; j < i; j++)
		{
			if(nums[i] > nums[i + 1])
			{
				nums[i] = nums[i] ^ nums[i+1];
				nums[i + 1] = nums[i + 1] ^ nums[i];
				nums[i] = nums[i] ^ nums[i+1];
			}
		}
	}
}
```


```
