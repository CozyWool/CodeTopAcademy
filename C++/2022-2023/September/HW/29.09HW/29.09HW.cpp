#include <iostream>
#include <Windows.h>
#include <malloc.h>
#include <vector>
#include <algorithm>
using namespace std;

void sortStudents(string* students, int size)
{
	for (int i = 0; i < size - 1; i++)
	{
		if (students[i] > students[i + 1])
		{
			swap(students[i], students[i + 1]);
		}
	}
}
void printStudents(string* students, int size)
{
	cout << "\tСписок студентов\n" << endl;
	cout << "Фамилия" << endl;
	cout << "-------" << endl;
	for (int i = 0; i < size; i++)
	{
		cout << students[i] << endl;
	}
}

int** initializeArr(int** arr, int row, int col)
{
	arr = new int*[row];
	for (int i = 0; i < row; i++)
	{
		arr[i] = new int[col];
	}
	return arr;
}

int** fillArr(int** arr)
{
	int row = _msize(arr) / sizeof(int*);
	int col = _msize(arr[0]) / sizeof(int);
	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < col; j++)
		{
			cout << "Введите значение для [" << i << "][" << j << "] элемента:";
			cin >> arr[i][j];
		}
	}
	return arr;
}

vector<int> findSameValues(int** arr1, int** arr2)
{
	vector<int> arr;

	int row1 = _msize(arr1) / sizeof(int*);
	int col1 = _msize(arr1[0]) / sizeof(int);
	int row2 = _msize(arr2) / sizeof(int*);
	int col2 = _msize(arr2[0]) / sizeof(int);

	for (int i1 = 0; i1 < row1; i1++)
		for (int j1 = 0; j1 < col1; j1++)
			for (int i2 = 0; i2 < row2; i2++)
				for (int j2 = 0; j2 < col2; j2++)
				{
					if (arr1[i1][j1] == arr2[i2][j2] && find(arr.begin(),arr.end(),arr1[i1][j1]) == arr.end()) 
					{
						arr.push_back(arr1[i1][j1]);
					}
				}
	
	return arr;
}
int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	cout << "Многомерные динамические массивы\nДомашенее задание №3\n" << endl;

	int cmd;
	bool key = true;

	int stdSize = 5; // размер массива с студентами
	string* students = new string[5];

	int row, col;
	int** a = nullptr;
	int** b = nullptr;
	int** c = nullptr;
	vector<int> sameValues;
	while (key)
	{
		cout << "Введите номер задания от 1 до 2(0 для выхода):";
		cin >> cmd;
		system("cls");
		switch (cmd)
		{
		case 1:
			for (int i = 0; i < stdSize; i++)
			{
				cout << "Введите фамилию " << i + 1 << " студента:";
				cin >> students[i];
			}
			sortStudents(students, stdSize);
			cout << "\n(Отсортированный по возрастнию)" << endl;
			printStudents(students, stdSize);
			break;
		case 2:
			// смог сделать только общие значения для двух массивов, как сделать для трех не знаю
			cout << "Введите кол-во строк для A:";
			cin >> row;
			cout << "Введите кол-во столбцов для A:";
			cin >> col;
			a = initializeArr(a, row, col);
			a = fillArr(a);
			/*cout << "Введите кол-во строк для B:";
			cin >> row;
			cout << "Введите кол-во столбцов для B:";
			cin >> col;
			b = initializeArr(b, row, col);
			b = fillArr(b);*/
			cout << "Введите кол-во строк для C:";
			cin >> row;
			cout << "Введите кол-во столбцов для C:";
			cin >> col;
			c = initializeArr(c, row, col);
			c = fillArr(c);
			sameValues = findSameValues(a, c);
			cout << "Общие значения A и C" << endl;
			for (int i = 0; i < sameValues.size(); i++)
			{
				cout << sameValues[i] << " ";
			}
			cout << endl;
			break;
		case 3:

		case 0:
			key = false;
			cout << "\t\nДо свидания!" << endl;
			break;
		default:
			cout << "Нет такого задания!" << endl;
			break;
		}
	}
}