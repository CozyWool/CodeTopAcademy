#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <Windows.h>

using namespace std;

class Shop
{
	static int current_id;
	int id;
	char* region;
	char* address;
public:
	Shop(const char* region, const char* address) : 
		region{ new char[sizeof(region)] },
		address{ new char[sizeof(address)] }
	{
		id = current_id++;
		strcpy(this->region, region);
		strcpy(this->address, address);
	}

	Shop() : Shop("", "")
	{}

	Shop(const Shop& shop) : Shop(shop.region, shop.address)
	{}

	~Shop()
	{
		if (region != nullptr)
		{
			delete[] region;
		}

		if (address != nullptr)
		{
			delete[] address;
		}
	}

	const char* getRegion()
	{
		return region;
	}

	void setRegion(const char* region)
	{
		strcpy(this->region, region);
	}

	const char* getAddress()
	{
		return address;
	}

	void setAddress(const char* address)
	{
		strcpy(this->address, address);
	}

	Shop& operator=(const Shop& shop)
	{
		strcpy(this->region, shop.region);
		strcpy(this->address, shop.address);
		return *this;
	}

	Shop& operator()()
	{
	}

	void print() const
	{
		cout << id << ". " << region << " " << address << endl;
	}

};
int Shop::current_id = 1;

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	Shop* shops = new Shop[2];
	shops[0].setRegion("Тюмень");
	shops[0].setAddress("Фабричная 9");
	shops[1].setRegion("Сургут");
	shops[1].setAddress("Ленина 23");


	Shop shop_temp = {"Курган", "Полевая 14"}; //
	Shop* shops_temp = shops;
	//shops = nullptr;
	shops = new Shop[3];

	for (int i = 0; i < 2; i++)
	{
		shops[i] = shops_temp[i];
	}

	shops_temp = nullptr;
	delete[] shops_temp;

	shops[2] = shop_temp;

	for (int i = 0; i < 2; i++)
	{
		shops[i].print();
	}


}#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <Windows.h>

using namespace std;

class Shop
{
	static int current_id;
	int id;
	char* region;
	char* address;
public:
	Shop(const char* region, const char* address) : 
		region{ new char[sizeof(region)] },
		address{ new char[sizeof(address)] }
	{
		id = current_id++;
		strcpy(this->region, region);
		strcpy(this->address, address);
	}

	Shop() : Shop("", "")
	{}

	Shop(const Shop& shop) : Shop(shop.region, shop.address)
	{}

	~Shop()
	{
		if (region != nullptr)
		{
			delete[] region;
		}

		if (address != nullptr)
		{
			delete[] address;
		}
	}

	const char* getRegion()
	{
		return region;
	}

	void setRegion(const char* region)
	{
		strcpy(this->region, region);
	}

	const char* getAddress()
	{
		return address;
	}

	void setAddress(const char* address)
	{
		strcpy(this->address, address);
	}

	Shop& operator=(const Shop& shop)
	{
		strcpy(this->region, shop.region);
		strcpy(this->address, shop.address);
		return *this;
	}

	Shop& operator()()
	{
	}

	void print() const
	{
		cout << id << ". " << region << " " << address << endl;
	}

};
int Shop::current_id = 1;

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	Shop* shops = new Shop[2];
	shops[0].setRegion("Тюмень");
	shops[0].setAddress("Фабричная 9");
	shops[1].setRegion("Сургут");
	shops[1].setAddress("Ленина 23");


	Shop shop_temp = {"Курган", "Полевая 14"}; //
	Shop* shops_temp = shops;
	//shops = nullptr;
	shops = new Shop[3];

	for (int i = 0; i < 2; i++)
	{
		shops[i] = shops_temp[i];
	}

	shops_temp = nullptr;
	delete[] shops_temp;

	shops[2] = shop_temp;

	for (int i = 0; i < 2; i++)
	{
		shops[i].print();
	}
}