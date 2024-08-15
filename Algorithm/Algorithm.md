``` Time complexity
1. constant time operation


```

```bitwise XOR == bitwise addition
1. 0 ^ n = n  n ^ n = 0

2. a ^ b = b ^ a, a ^ b ^ c = a ^ (b ^ c) = (a ^ b) ^ c

1. swap the values of 2 numbers without using a third variable.
int a = m;
int b = n;
a = a ^ b = m ^ n;
b = a ^ b = m ^ n ^ n = m ^ 0 = m;
a = a ^ b = m ^ n ^ m = 0 ^ n = n;
tips: This method won't work if a and b are defined as same element of an array, such as arr[i]. In this case, they refer to the same memory location, meaning you can't swap the values of arr[i] with itself.

2. only 1 element repeats an odd number of times, all others apears an even number of times.
public static int Xor1(int[] nums)
{
	int result = 0;
	for (int i = 0; i < nums.length; i++)
	{
		result = result ^ nums[i];
	}
	return result;
}

3. How to find the position of the rightmost set bit (1) in an integer?
bitwise NOT
N & (~N + 1)

N				10110011100
~N				01001100011
~N+1			01001100100
N & (~N + 1)	00000000100 it's the rightmost set bit

public static int RightMostOne(int targetNum)
{
	return targetNum & (~targetNum + 1);
}

4. only 2 element repeats an odd number of times, all others apears an even number of times.

requirements: time complexity O(N) space complexity: O(1)

public static void Xor2(int[] nums)
{
	int eor = 0;
	for(int i = 0; i < nums.length; i++)
	{
		eor = eor ^ nums[i];
	}

	int a = 0;
	int b = 0;

	int rightMostOne = eor & (~eor + 1);

	for(int i = 0; i < nums.length; i++)
	{
		if ((nums[i] & rightMostOne) != 0)
		{
			a = a ^ nums[i];
		}
	}
	b = a ^ eor;
}

nums[i]			111110100111
rightMostOne    000001000000
&				000000000000


5. count the bit 1 counts

public static int bit1Counts(int N)
{
	int counts = 0;
	while(N != 0)
	{
		int rightOne = N & (~N + 1);
		counts++;
		N ^= rightOne;
	}

	return counts;
}


we just completed the process of swapping like this.

but what we should pay attention to is that it can not be defined on the same memory location

question about XOR

int[] nums,











```

``` Selection sort

```c#

public static void SelectionSort(int[] nums)
{
	if(nums == null || nums.length < 2)
	{
		return;
	}
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


``` Binary search


mid = (L + R) / 2: Simple, but at risk of overflow.

mid = L + ((R - L) >> 1): Safer, avoids overflow, and is commonly used in implementations where large values of L and R are possible.

The first equation is equivalent to the second one. but the second one is much more safer than the former one, and faster than it either.

2n = n << 1  2n + 1 = (n << 1) > 1

1. finding an existing number in a sorted array

/// O(logN)
public static int ExistingNumIndex(int[] sortedArr, int targetNum)
{
	if (sortedArr == null || sortedArr.lentgh == 0)
	{
		return -1;
	}
	int L = 0;
	int R = sortedArr.length - 1;

	while(L <= R)
	{
		mid = L + ((R - L) >> 1);
		if (targetNum == sortedArr[mid])
		{
			return mid;
		}
		else if (targetNum < sortedArr[mid])
		{
			R = mid - 1;	
		} 
		else
		{
			L = mid + 1;
		}
	}
	return -1;
}

// comparator for existingNumIndex
// O(n)
public static int ExistingNumIndexTestor(int[] sortedArr, int targetNum)
{
	if (sortedArr == null || sortedArr.lentgh == 0)
	{
		return -1;
	}

	for(int i = 0; i < sortedArr.length, i++)
	{
		if (targetNum == sortedArr[i])
		{
			return i;
		}
	}
	return -1;
}

2. Finding the leftmost index of an existing number

public static int LeftMostOfExistingNum(int[] sortedArr, int targetNum)
{
	if (sortedArr == null || sortedArr.length == 0)
	{
		return -1;
	}

	int L = 0;
	int R = sortedArr.length - 1;
	int index = -1;

	while(L <= R)
	{
		int mid = L + ((R - L) >> 1);
		if (sortedArr[mid] >= targetNum)
		{
			index = mid;
			R = mid - 1;
		} else
		{
			L = mid + 1;
		}
	}
	return index;
}

3. finding the right most index of an existing number

public static int RightMostOfExistingNum(int[] sortedArr, int targetNum)
{
	if(sortedArr == null || sortedArr.length == 0)
	{
		return -1;
	}

	int L = 0;
	int R = sortedArr.length - 1;
	int index = -1;
	while(L <= R)
	{
		int mid = L + ((R - L) >> 1);
		if (sortedArr[mid] <=  targetNum)
		{
			index = mid;
			L = mid + 1;
		}
		else
		{
			R = mid - 1;
		}
	}
	return index;
}

4. local minimum

Given an unsorted array, find any local minimum where the neighboring elements are not equal.

public static int LocalMinimum(int[] unSortedArr)
{
	if (unSortedArr == null || unSortedArr.length < 2)
	{
		return -1;
	}
	if(unSortedArr[0] < unSortedArr[1])
	{
		return 0;
	}
	int len = unSortedArr.length;
	if(unSortedArr[len - 1] < unSprtedArr[len - 2])
	{
		return len - 1;	
	}

	int L = 0;
	int R = len - 1;

	while(L <= R)
	{
		int mid = L + ((R - L) >> 1);
		if ( mid == 0 || (unSortedArr[mid - 1] > unSortedArr[mid] && unSortedArr[mid + 1] > unSortedArr[mid]))
		{
			return mid;
		}
		else if (mid > 0 && unSortedArr[mid - 1] > unSortedArr[mid])
		{
			L = mid + 1;
		}
		else
		{
			R = mid - 1;
		}
	}
	return -1;
}

```


``` Linked List
1. Reversing a linked list with one or two nodes

1.a. single node

public class SingleNode
{
	public int value;
	public SingleNode next;
	public SingleNode(int v)
	{
		value = v;
	}
}


public static SingleNode ReversingSingleNode(SingleNode node)
{
	SingleNode pre = null;
	SingleNode next = null;
	while(SingleNode!=null)
	{
		next = node.next;
		node.next = pre;
		pre = node;
		node = next;
	}
	return pre;
}

1.b. double node

public class DoubleNode
{
	public int value;

	public DoubleNode next;

	public DoubleNode pre;

	public DoubleNode(int v)
	{
		value = v;
	}
}

public static DoubleNode ReversiongDoubleNode(DoubleNode node)
{
	DoubleNode pre = null;

	DoubleNode next = null;
	while(node != null)
	{
		next = node.next; // set the memory locatio of node.next to next
		
		node.next = pre; // modify node.next to pre
		node.pre = next; // modify node.pre to next;
						 // swap the memory location of next and pre
		pre = node;      // set node to pre

		node = node.next;// move to next node   
	}
	return pre;
}

2. giving a single node linked list, remove all nodes which value equals 3

public class SingleNode
{
	public int value;
	public SingleNode next;
	public SingleNode(int v)
	{
		value = v;
	}
}

public static SingleNode removeGavinNum(SingleNode node, int num)
{
	while(node != null)
	{
		if (node.value != num)
		{
			break;
		}
		node = node.next;
	}



	SingleNode cur = node;
	SingleNode pre = node;

	while(cur != null)
	{
		if (cur.value == num)
		{
			pre.next = cur.next;
		}
		else
		{
			pre = cur;
		}
		cur = cur.next;
	}
	return pre;
}

```
