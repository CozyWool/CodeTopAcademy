//#include <iostream>
//#include <algorithm>
//
//template<typename T>
//T findMax(const T* arr, int size)
//{
//    T maxValue = arr[0];
//	for (int i = 0; i < size; i++)
//	{
//		if (arr[i] > maxValue)
//		{
//			maxValue = arr[i];
//		}
//	}
//
//	return maxValue;
//}
//
//template<typename T>
//void sortArr(const T* arr, int size)
//{
//	std::sort(arr, arr + size);
//}
//
//template<typename T>
//int	binSearchArr(const T* arr, int size, const T& key)
//{
//	int left = -1;
//	int right = size;
//	while (right - left > 1)
//	{
//		int mid = (right + left) / 2;
//
//		(arr[mid] <= key ? left : right) = mid;
//	}
//
//	return left;
//}
//
//template<typename T>
//int binarySearch(const T* arr, int size, const T& key) {
//	int left = 0;
//	int right = size - 1;
//	while (left <= right) {
//		int mid = left + (right - left) / 2;
//		if (arr[mid] == key) {
//			return mid;
//		}
//		else if (arr[mid] < key) {
//			left = mid + 1;
//		}
//		else {
//			right = mid - 1;
//		}
//
//	}
//	return -1;
//}
//
//int main()
//{
//	std::cout << binSearchArr(new int[7] {1, 2, 3, 3, 3, 4, 5}, 7, 3); 
//	std::cout << binarySearch(new int[7] {1, 2, 3, 3, 3, 4, 5}, 7, 3); 
//}

#include <iostream>
#include <unordered_map>
#include <vector>

using namespace std;

int main()
{
	string input;
	cin >> input;

	unordered_map<char, int> dict;
	vector<char> dictKey;
	vector<int> dictVal;

	if (isdigit(input[1]))
	{
		dictKey.push_back(input[0]);
		dictVal.push_back(input[1] - '1');
	}
	else if (input[1] != '1')
	{
		dictKey.push_back(input[1]);
		dictVal.push_back(1);
	}
	for (int i = 2; i < input.length(); i++)
	{
		if (input[i] == '1')
		{
			continue;
		}

		if (isdigit(input[i]))
		{
			find(dictKey.begin(), dictKey.end(), input[i - 1]) += input[i] - '0';
			continue;
		}

		if (!isdigit(input[i + 1]) || input[i + 1] == '1')
		{
			auto var = find(dictKey.begin(), dictKey.end(), input[i])++;
			if ()
			{

			}
		}
	}

	for (int i = 0; i < dictKey.size(); i++)
	{
		cout << dictKey[i];
		if (dictVal[i] == 1)
		{
			continue;
		}

		cout << dictVal[i];
	}

	return 0;
}