#pragma once
#include <iostream>
using namespace std;
class Rectangle
{
private:
	int a;
	int b;
	int S;
	int P;
public:
	Rectangle(int a, int b)
	{
		this->a = a;
		this->b = b;
	}
	int setA(int a)
	{
		this->a = a;
	}
	int setB(int b)
	{
		this->b = b;
	}
	int setP(int P)
	{
		this->P = P;
	}
	int setS(int S)
	{
		this->S = S;
	}
	int CalcS()
	{
		return a * b;
	}
	int CalcP()
	{
		return (a + b) * 2;
	}
	void PrintRect()
	{
		for (int i = 1; i <= b; i++)
		{
			for (int j = 1; j <= a; j++)
			{
				if (i > 1 && j > 1 && i < b && j < a) // вырезаем все кроме краев
					cout << " ";
				else
					cout << "*"; // рисуем края
			}
			cout << endl;
		}
	
	}
};

