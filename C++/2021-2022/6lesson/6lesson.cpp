#include <iostream>
#include <ctime>
#include <stdlib.h>
#include <clocale>

using namespace std;

int main()
{
	setlocale(0, "");

	/* 1 задача
	
	srand(time(NULL));
	const int ROW = 6;
	const int COL = 6;
	int count = ROW * COL;
	int avr;
	int max;
	int min;
	int sum = 0;
	int arr[ROW][COL];
	for (int i = 0; i < ROW; i++)
	{
		for (int j = 0; j < COL; j++)
		{
			arr[i][j] = rand() % 100;
			cout << arr[i][j] << " ";
			sum += arr[i][j];
		}
		cout << endl;
	}
	max = arr[0][0];
	min = arr[0][0];
	avr = sum / count;
	for (int i = 0; i < ROW; i++)
		for (int j = 0; j < COL; j++)
		{
			if (arr[i][j] > max)
				max = arr[i][j];
			if (arr[i][j] < min)
				min = arr[i][j];
		}
	cout << "Сумма элементов: " << sum << endl;
	cout << "Срденее арифметическое элементов: " << avr << endl;
	cout << "Максимальный элемент: " << max << endl;
	cout << "Минимальный элемент: " << min << endl;*/
	/* 2 задача
	
	srand(time(NULL));
	const int ROW = 6;
	const int COL = 6;
	int sum = 0;
	int allsum = 0;
	int arr[ROW][COL];
	for (int i = 0; i < ROW; i++)
	{
		sum = 0;
		for (int j = 0; j < COL; j++)
		{
			arr[i][j] = rand() % 10;
			cout << arr[i][j] << "  ";
			sum += arr[i][j];
			allsum += arr[i][j];
		}
		cout << " | " << sum;
		cout << endl;
	}
	cout << "-------------------------------" << endl;
	for (int j = 0; j < COL; j++)
	{
		sum = 0;
		for (int i = 0; i < ROW; i++)
		{
			sum += arr[i][j];
		}
		cout << sum << " ";
	}
	cout << " | " << allsum;*/
	/* 3 задача
	
	srand(time(NULL));
	const int ROW1 = 5;
	const int COL1 = 10;
	const int ROW2 = 5;
	const int COL2 = 5;

	int arr1[ROW1][COL1];
	int arr2[ROW2][COL2];
	cout << "\n\tПервый массив\n-------------------------------------------" << endl;
	for (int i = 0; i < ROW1; i++)
	{
		for (int j = 0; j < COL1; j++)
		{
			arr1[i][j] = rand() % 50;
			cout << arr1[i][j] << " ";
		}
		cout << endl;
	}
	cout << "\n\tВторой массив\n-------------------------------------------" << endl;
	int j1 = 0;
	for (int i = 0; i < ROW2; i++)
	{
		j1 = 0;
		for (int j = 0; j < COL2; j++)
		{
			arr2[i][j] = arr1[i][j1] + arr1[i][j1 + 1];
			cout << arr2[i][j] << " ";
			j1 += 2;
		}

		cout << endl;
	}*/
}
