#include <iostream>
#include <Windows.h>
#include <map>

using namespace std;

struct DateTime
{
	unsigned short day: 5;
	unsigned short month: 4;
	unsigned short year : 12;
	unsigned short hour : 5;
	unsigned short minute : 6;
	unsigned short second : 6;
} dt;


int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	cout << sizeof(dt) << endl;
}
//struct PointS 
//{
//	long long int x;
//	int y;
//	short int z;
//} d;
//
//union Point
//{
//	char c; // 1
//	int h[3]; // 12
//	double* p; // 8
//} myUnion; // 16

	/*int n;
	int m;
	int k;
	while(true)
	{
		do
		{
			cout << "Введите длину шоколадки:";
			cin >> n;
			cout << "Введите ширину шоколадки:";
			cin >> m;
			cout << "Введите кол-во долек, которые вы хотите отломить:";
			cin >> k;
			cout << (n < 0 || m < 0 || k < 0 ? "\nВведите не отрицательное число\n" : "") << endl;
		} while (n < 0 && m < 0 && k < 0);
		cout << "Ваш ответ:" << ((k % n == 0 || k % m == 0) && n * m > k ? "Можно" : "Нельзя") << endl;
	}*/