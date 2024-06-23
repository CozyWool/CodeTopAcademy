#include <iostream>
#include <vector>

using namespace std;

vector<int> quickSort(vector<int> arr)
{
    if (arr.size() < 2)
        return arr;
    
    int pivot = arr[0];
    vector<int> left;
    vector<int> right;
    for (int i = 1; i < arr.size(); i++)
    {
        if (pivot > arr[i])
        {
            left.push_back(arr[i]);
        }
        else
        {
            right.push_back(arr[i]);
        }
    }

    left = quickSort(left);
    right = quickSort(right);
    vector<int> newArr;

    for (int i = 0; i < left.size(); i++)
    {
        newArr.push_back(left[i]);
    }
    newArr.push_back(pivot);
    for (int i = 0; i < right.size(); i++)
    {
        newArr.push_back(right[i]);
    }
    
    return newArr;
}

int main()
{
    // пытался сделать через динамические массивы, в итоге не получилось :/
    vector<int> arr{ 9, 5, 4, 2, 8, 6, 3, 1, 0, 10 };
  
    for (int i = 0; i < arr.size(); i++)
    {
        cout << arr[i] << " ";
    }
    cout << endl;

    arr = quickSort(arr);

    for (int i = 0; i < arr.size(); i++)
    {
        cout << arr[i] << " ";
    }
}