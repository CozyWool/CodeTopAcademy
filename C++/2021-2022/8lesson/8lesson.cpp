
#include <ctime>
#include <iostream>
#include <stdlib.h>
#include <clocale>
//#define PI 3.14;
//#define sqr(x) ((x)*(x))
//#define cube(x) (sqr(x) * (x))
//#define summ(x) (cube(x) + sqr(x))
using namespace std;

const int SIZE = 6;

template <typename T1, typename T2, typename T3 >
void Sum(T1 a, T2 b, T3 c)
{
    cout << a + b + c;
}

void first(int arr[SIZE])
{
    int max, maxIndex;
    int min, minIndex;
    for (int i = 0; i < SIZE; i++)
    {
        arr[i] = rand() % 100;
        cout << arr[i] << " ";
    }
    cout << endl;
    max = arr[0];
    min = arr[0];
    for (int i = 0; i < SIZE; i++)
    {
        if (arr[i] > max)
        {
            maxIndex = i;
            max = arr[i];
        }     
        if (arr[i] < min)
        {
            minIndex = i;
            min = arr[i];
        }
    }
    cout << "Максимальный элемент с индексом  " << maxIndex << " : " << max << endl;
    cout << "Минимальный элемент с индексом  " << minIndex << " : " << min << endl;
}
void second(int arr[SIZE])
{
    int temp;
    for (int i = 0; i < SIZE; i++)
    {
        arr[i] = rand() % 100;
        cout << arr[i] << " ";
    }
    cout << endl;
    for (int i = 0; i < SIZE / 2; i++)
    {
        temp = arr[i];
        arr[i] = arr[SIZE - 1 - i];
        arr[SIZE - 1 - i] = temp;
    }
    for (int i = 0; i < SIZE; i++)
        cout << arr[i] << " ";
}
void third(int arr[SIZE])
{
    int cnt = 0;
    for (int i = 0; i < SIZE; i++)
    {
        arr[i] = rand() % 50;
        cout << arr[i] << " ";
    }
    cout << endl;
    for (int i = 0; i < SIZE; i++)
    { 
        int k = 0;
        for (int j = 1; j <= arr[i] / 2; j++)
        {
            if (arr[i] % j == 0)
                k += 1;
        }
        if (k == 1)
            cnt++;
    }
    cout << "Кол-во простых чисел в массиве:" << cnt << endl;
}
int main()
{
    setlocale(0, "");
    srand(time(NULL));

    Sum(5.3, 25, 5.5);
   /*int x;
    cin >> x;
    cout << sqr(x) << endl;
    cout << cube(x) << endl;
    cout << summ(x) << endl;*/
    /*int arr[SIZE]{}; 1 задача
    first(arr, SIZE);*/
    /*int arr[SIZE]{}; 2 задача
    second(arr, SIZE);*/
    /*int arr[SIZE]{}; 3 задача
    third(arr, SIZE);*/
}