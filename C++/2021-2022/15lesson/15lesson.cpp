#include <iostream>
#include <map>
#include "Customer.h"
#include "Shop.h"
#include <Windows.h>
using namespace std;
void auf() 
{
	int sum = 0;
	for (int i = 0; i < 10; i++)
	{
		for (int j = 0; j < 10; j++)
			for (int k = 0; k < 10; k++)
			{
				for (int m = 0; m < 10; m++)
				{
					cout << i << j << k << m << " ";
					sum++;
				}
				cout << endl;
			}
		cout << "Next" << endl;
	}
	cout << "Итого:" << sum;
	string trash;
	cin >> trash;
}
int main()
{
	auf();
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	/*
	map<string, int> prod{ {"Молоко", 100},{"Хлеб",500},{"Мясо",30} };
	map<string, int> price{ {"Молоко", 100},{"Хлеб",50},{"Мясо",300} };

	Shop s(prod, price);
	Customer c(1000,s);
	c.addMoney(10000);

	
	s.addProductOnKeyboard();
	s.changeProductPrice("Мясо");
	s.ProductInfo();

	string product;
	int count;
	cout << "Введите продукт и его кол-во:";
	cin >> product >> count;
	
	c.getProduct(product,count,s);
	c.ShoppingCart();
	c.buyProducts(s);
	c.ShoppingCart();
	s.ProductInfo();*/
}