#include <iostream>
#include <Windows.h>

using namespace std;

template<typename T>
void print(T* begin, T* end, char delimiter = ' ')
{
	while (begin != end)
	{
		cout << *begin++ << delimiter;
	}
	cout << endl;
}

template<typename T, typename Predicate>
int copy_if(T* sourceBegin, T* sourceEnd, T* destBegin, T* destEnd, Predicate pred)
{
	int copyCount{ 0 };
	while (destBegin != destEnd && sourceBegin != sourceEnd)
	{
		if (pred(*sourceBegin))
		{
			*destBegin++ = *sourceBegin;
			copyCount++;
		}
		sourceBegin++;
	}
	return copyCount;
}

bool even(const int elem)
{
	return elem % 2 == 0;
}

bool odd(const int elem)
{
	return elem % 2 == 1;
}

bool all(const int elem)
{
	return 1;
}

bool greater3(const int elem)
{
	return elem > 3;
}

class Counter
{
private:
	int cnt;
public:
	Counter(int start) : cnt{ start } {}
	Counter() : Counter{0} {}

	int operator()()
	{
		return cnt++;
	}

	void resetTo(int start)
	{
		cnt = start;
	}
};

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	const int size{ 10 };
	int arr1[size]{ 1,2,3,4,5,6,7,8,9,10 };
	int arr2[size]{};

	int* const arr1Begin{ arr1 };
	int* const arr1End{ arr1 + size };

	int* const arr2Begin{ arr2 };
	int* const arr2End{ arr2 + size };

	int* arr2NewEnd{};

	cout << "Оригнинальный arr1: " << endl;
	print(arr1Begin, arr1End);
	cout << "Оригинальный arr2: " << endl;
	print(arr2Begin, arr2End);
	cout << endl;

	cout << "Копирование четных элементов из arr1 в arr2:" << endl;
	arr2NewEnd = arr2Begin + copy_if(arr1Begin, arr1End, arr2Begin, arr2End, even);
	print(arr2Begin, arr2NewEnd);
	cout << endl;

	cout << "Копирование нечетных элементов из arr1 в arr2:" << endl;
	arr2NewEnd = arr2Begin + copy_if(arr1Begin, arr1End, arr2Begin, arr2End, odd);
	print(arr2Begin, arr2NewEnd);
	cout << endl;

	cout << "Копирование элементов, больших 3, из arr1 в arr2:" << endl;
	arr2NewEnd = arr2Begin + copy_if(arr1Begin, arr1End, arr2Begin, arr2End, greater3);
	print(arr2Begin, arr2NewEnd);
	cout << endl;

	cout << "Копирование всех элементов из arr1 в arr2:" << endl;
	arr2NewEnd = arr2Begin + copy_if(arr1Begin, arr1End, arr2Begin, arr2End, all);
	print(arr2Begin, arr2NewEnd);
	cout << endl;

	/*const int maxCnt{ 5 };
	Counter cnt1{};
	Counter cnt2{ 100 };

	for (int i{ 0 }; i < maxCnt; i++)
	{
		cout << "cnt1(): " << cnt1() << '\n';
		cout << "cnt2(): " << cnt2() << '\n';
	}
	cout << endl;

	cnt1.resetTo(10);
	cnt1.resetTo(200);

	for (int i{ 0 }; i < maxCnt; i++)
	{
		cout << "cnt1(): " << cnt1() << '\n';
		cout << "cnt2(): " << cnt2() << '\n';
	}
	cout << endl;*/
}