#include <iostream>
using namespace std;

int main()
{
	setlocale(0, "");

	const int SIZE = 10;
	const int SIZE2 = 5;
	int ARR[SIZE]{};
	int ARR2[SIZE2]{};
	int ARR3[SIZE2]{};


	for (int i = 0; i < SIZE2; i++)
	{
		cout << "Введите число в 1-ый массив:";
		cin >> ARR2[i];
		
	}
	for (int i = 0; i < SIZE2; i++)
	{
		cout << "Введите число в 2-ой массив:";
		cin >> ARR3[i];
	}
	for (int j = 0; j < SIZE2; j++)
		for (int i = 0; i < SIZE; i++)
		{
			if (ARR2[j] > 0)
				ARR[i] = ARR2[j];
			if (ARR2[j] == 0)
				ARR[i] = ARR2[j];
			else
				ARR[i] = ARR2[j];
		}
	for (int i = 5; i < SIZE; i++)
		for (int j = 0; j < SIZE2; j++)
		{
			if (ARR3[j] > 0)
				ARR[i] = ARR3[j];
			if (ARR3[j] == 0)
				ARR[i] = ARR3[j];
			else
				ARR[i] = ARR3[j];
		}
	for (int i = 0; i < SIZE; i++)
		cout << ARR[i] << " ";
	
	/*const int SIZE = 10; // 1 задача
	int ARR[SIZE]{};

	for (int i = 0; i < SIZE; i++)
	{
		cout << "Введите число:";
		cin >> ARR[i];
	}
	
	for (int i = 0; i < SIZE - 1; i++)
	{
		if (ARR[i] == 0)
		{ 
			ARR[i] = ARR[i+1];
			ARR[i+1] = -1;
		}	
		for (int i = 0; i < SIZE - 2; i++)
		{
			if (ARR[i+1] == -1)
			{
				ARR[i + 1] = ARR[i + 2];
				ARR[i + 2] = -1;
			}
		}	
	}

	for (int i = 0; i < SIZE; i++)
		cout << ARR[i] << " ";*/

	/*const int SIZE = 6; // 1 задача
	int ARR[SIZE]{};
	int sum = 0;

	for (int i = 0; i < SIZE; i++)
	{
		cout << "Введите прибыль за " << i+1 << " месяц: ";
		cin >> ARR[i];
		sum += ARR[i];
	}
	cout << "Общая прибыль за 6 месяцев: " << sum;*/

	/*const int SIZE = 6; // 2 задача
	int ARR[SIZE]{5,6,4,7,2,8};

	for (int i = SIZE-1; i >= 0; i--)
		cout << ARR[i] << " ";*/

	/*const int SIZE = 5; // 3 задача
	int ARR[SIZE]{};
	int sum = 0;

	for (int i = 0; i < SIZE; i++)
	{
		cout << "Введите сторону пятиугольника: ";
		cin >> ARR[i];
		sum += ARR[i];
	}
	cout << "Периметр пятиугольника: " << sum;*/

	/*const int SIZE = 12; // 4 задача
	int ARR[SIZE]{};
	int MAX;
	int MIN;

	for (int i = 0; i < SIZE; i++)
	{
		cout << "Введите прибыль за " << i + 1 << " месяц: ";
		cin >> ARR[i];
	}
	MAX = ARR[0];
	MIN = ARR[0];
	for (int i = 0; i < SIZE; i++)
	{
		if (ARR[i] > MAX)
			MAX = ARR[i];
		if (ARR[i] < MIN)
			MIN = ARR[i];
	}
	cout << "Месяц с максимальной прибылью: " << MAX << endl;
	cout << "Месяц с минимальной прибылью: " << MIN << endl;*/
}		