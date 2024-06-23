#include <ctime>
#include <iostream>
#include <stdlib.h>
#include <clocale>

using namespace std;

int first()
{   
    cout << "1. Дан одномерный массив, состоящий из N вещественных элементов. \n" << // мне было скучно ¯\_(ツ)_/¯
            "1.1. Ввести массив с клавиатуры. \n" <<
            "1.2. Найти максимальный элемент. \n" << 
            "1.3. Вычислить среднеарифметическое положительных элементов массива. \n" << endl;
    int* arr;
    int size;
  
    cout << "n = ";
    cin >> size;

    if (size <= 0) 
    {
        cerr << "Неверный размер" << endl;
        return 1;
    }

    arr = new int[size]; 
    float avr;
    for (int i = 0; i < size; i++) 
    {
        cout << "arr[" << i << "] = ";
        cin >> arr[i];
    }
    for (int i = 0; i < size; i++)
        cout << arr[i] << " ";
    int max = arr[0];
    float sum = 0;
    for (int i = 0; i < size; i++)
    {
        if (arr[i] > max)
            max = arr[i];
        if (arr[i] > 0)
            sum += arr[i];
    }
    avr = sum / size;
    cout << "Максимальный элемент:" << max << endl;
    cout << "Среднеарифметическое положительных элементов массива:" << avr << endl;
    return 0;
}

int second()
{
    cout << "2. Дан одномерный массив, состоящий из N вещественных элементов. \n" << // мне было скучно ¯\_(ツ)_/¯
            "2.1. Заполнить массив случайными числами. \n" <<   
            "2.2. Найти минимальный элемент. \n" <<
            "2.3. Вычислить сумму отрицательных элементов массива. \n" << endl;
    int* arr;
    int size;

    cout << "n = ";
    cin >> size;

    if (size <= 0)
    {
        cerr << "Неверный размер" << endl;
        return 1;
    }

    arr = new int[size];

    for (int i = 0; i < size; i++)
    {
        arr[i] = rand() % 100 - 50;
        cout << arr[i] << " ";
    }
    cout << endl;
    int min = arr[0];
    int sum = 0;
    for (int i = 0; i < size; i++)
    {
        if (arr[i] < min)
            min = arr[i];
        if (arr[i] < 0)
            sum += arr[i];
    }
    cout << "Минимальный элемент:" << min << endl;
    cout << "Сумма отрицательных элементов массива:" << sum << endl;
    return 0;
}

int main()
{
    setlocale(0, "");
    srand(time(NULL));
    int t;
    cout << "Выберите 1 или 2 задачу:";
    cin >> t;
    t == 1 ? first() : second();
}