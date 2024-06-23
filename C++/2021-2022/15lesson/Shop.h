#pragma once
#include <iostream>
#include <map>
#include <string.h>
using namespace std;
class Shop
{
private:
	map<string, int> product;
	map<string, int> price;
public:
	Shop()
	{

	}
	Shop(map<string, int> product, map<string, int> price) : product(product), price(price)
	{

	}
	void addProduct(string name, int count, int priceProduct)
	{
		product[name] = count;
		price[name] = priceProduct;
	}
	void addProductOnKeyboard()
	{
		string name;
		int count;
		int priceProduct;
		cout << "������� ��� ��������, ��� ���-�� � ����:";
		cin >> name >> count >> priceProduct;
		product[name] = count;
		price[name] = priceProduct;
	}
	void changeProductPrice(string name)
	{
		if (!price.count(name)) {
			cout << "������ ����� ���" << endl;
			return;
		}
		int newPrice;
		cout << "������� ����� ���� ��� �������� \"" << name << "\":";
		cin >> newPrice;
		price[name] = newPrice;
	}
	void ProductInfo()
	{
		cout << "\t�������� � ��������\n";
		for (auto it = product.begin(); it != product.end(); it++)
		{
			
			cout << "������� \"" << it->first << "\" � ����������:" << it->second << endl;
		}
	}
	bool subtractProduct(string name,int count)
	{
		if (product[name] >= count)
		{
			product[name] -= count;
			return true;
		}
		cout << "�������� ������� ���!" << endl;
		return false;
	}
	void buyerCount(map<string, int>& shoppingCart_, int& money)
	{
		int endprice = 0;
		for (auto it = shoppingCart_.begin(); it != shoppingCart_.end(); it++)
		{
			string name = it->first;
			for (int i = 0; i < it->second; i++)
			{

			}
			endprice += price[name] * it->second;
		}
		if (endprice <= money)
		{
			money -= endprice;
			shoppingCart_.clear();
		}
		else
		{
			cout << "������������ �������" << endl;
		}
	}
};