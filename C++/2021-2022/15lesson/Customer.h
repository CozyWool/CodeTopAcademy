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
			cout << "Чееее" << endl;
		}
		else
		{
			cout << "Чтооо" << endl;
		}
		if (s.subtractProduct(name, count))
		{
			cout << "Положили продукт \"" << name << "\" в корзину в количестве:" << count << endl;
			shoppingCart_[name] += count;
		}
	}
	void ShoppingCart()
	{
		cout << "\tКОРЗИНА" << endl;
		if (shoppingCart_.size() == 0)
		{
			cout << "Корзина пуста" << endl;
			return;
		}
		for (auto it = shoppingCart_.begin(); it != shoppingCart_.end(); it++)
		{
			cout << "Продукт:" << it->first << " в количестве:" << it->second << endl;
		}
		
	}
	void buyProducts(Shop& s)
	{
		cout << "\n\tПОКУПКА ПРОДУКТОВ" << endl;
		s.buyerCount(shoppingCart_, money);
		cout << "Осталось средств:" << money << endl;
	}
};

