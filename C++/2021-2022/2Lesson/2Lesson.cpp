#include <iostream>
using namespace std;

int main()
{
	setlocale(LC_ALL, "Russian");

	int begin, end, temp, number = 0;

	cout << "От:";
	cin >> begin;

	cout << "До:";
	cin >> end;

	if (begin > end)
	{
		temp = begin;
		begin = end;
		end = temp;
	};
	do
	{
		cout << "Введите число, которое находится в диапазоне:";
		cin >> number;
	} while (number < begin || number > end);
	cout << number << " находится в диапазоне" << endl;
	/*
	int x = 1, sum = 0;

	while (x != 0)
	{
		cout << "Введите число:";
		cin >> x;
		sum += x;
	}
	
	cout << "Сумма чисел:" << sum;
	*/
	/*
	int begin,end,temp;

	cout << "От:";
	cin >> begin;

	cout << "До:";
	cin >> end;

	if (begin > end) 
	{
		temp = begin;
		begin = end;
		end = temp;
	}

	cout << "Диапазон:";
	for (int i = begin; i <= end; i++)
		cout << i << " ";

	cout << endl << "Четные:";
	for (int i = begin; i <= end; i++)
		if (i % 2 == 0)
			cout << i << " ";

	cout << endl << "Нечетные:";
	for (int i = begin; i <= end; i++)
		if (i % 2 != 0)
			cout << i << " ";

	cout << endl << "Кратные 7:";
	for (int i = begin; i <= end; i++)
		if (i % 7 == 0)
			cout << i << " ";
	*/
}