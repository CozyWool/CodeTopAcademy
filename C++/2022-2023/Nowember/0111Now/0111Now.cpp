#include <iostream>

using namespace std;

#define underline "\033[4m"

void merge(int arr[], int size, int left1, int right1) {
    int middle = (size / 2) + (size % 2) - 1;
    int last = size - 1;

    int left = left1;
    int start = left;
    int right = right1;

    int arr_new[size];

    for (int i = start; i <= last; i++) {
        if ((left <= middle) and ((right > last) || (arr[left] < arr[right]))) {
            arr_new[i] = arr[left];
            left++;
        }
        else {
            arr_new[i] = arr[right];
            right++;
        }
    }

    for (int i = start; i <= last; i++) {
        arr[i] = arr_new[i];
    }
}

void sortMerge(int arr[], int size, int index) {
    if (size > 2) {
        sortMerge(arr, (size / 2) + (size % 2), index);
        sortMerge(arr, (size / 2), (size / 2) + (size % 2));
        merge(arr, size, index, (size / 2) + (size % 2));
    }
    else {
        if (size > 1 and (arr[index] > arr[index + 1])) {
            arr[index] ^= arr[index + 1];
            arr[index + 1] ^= arr[index];
            arr[index] ^= arr[index + 1];
        }
    }
}



int main()
{
    int size = 8;
    int arr[size] = { 5, 6, 9, 12, 5, 2, 4, 6 };
    sortMerge(arr, size, 0);

    for (int i = 0; i < size; i++) {
        cout << arr[i] << " ";
    }
    cout << endl;
}