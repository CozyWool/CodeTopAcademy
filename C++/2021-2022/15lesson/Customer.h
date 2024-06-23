#pragma once
#include <iostream>
#include <map>
#include <string.h>
#include "Shop.h"
using namespace std;
class Customer
{
private:
	int money;
	map<string, int> shoppingCart_;
	Shop currentShop;
public:
	Customer(int money, Shop currentShop)
	{
		this->currentShop = currentShop;
		if (money > 0)
			this->money = money;
	}
	void addMoney(int money)
	{
		if (money > 0)
			this->money += money;
	}
	void getProduct(string name, int count, Shop& s)
	{
		if (&currentShop == &s)
		{
			cout << "�����" << endl;
		}
		else
		{
			cout << "�����" << endl;
		}
		if (s.subtractProduct(name, count))
		{
			cout << "�������� ������� \"" << name << "\" � ������� � ����������:" << count << endl;
			shoppingCart_[name] += count;
		}
	}
	void ShoppingCart()
	{
		cout << "\t�������" << endl;
		if (shoppingCart_.size() == 0)
		{
			cout << "������� �����" << endl;
			return;
		}
		for (auto it = shoppingCart_.begin(); it != shoppingCart_.end(); it++)
		{
			cout << "�������:" << it->first << " � ����������:" << it->second << endl;
		}
		
	}
	void buyProducts(Shop& s)
	{
		cout << "\n\t������� ���������" << endl;
		s.buyerCount(shoppingCart_, money);
		cout << "�������� �������:" << money << endl;
	}
};

