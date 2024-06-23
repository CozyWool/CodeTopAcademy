#include<string>
#include <iostream>
#include <windows.h>
#include <vector>
using namespace std;
class Person {
protected:
	int x = 0;
	int y = 0;
	int health = 100;
public:
	Person() {}
	Person(int x, int y, int health) {
		this->x = x;
		this->y = y;
		this->health = health;
	}
	virtual int getX() = 0;
	virtual int getY() = 0;
	virtual int getHealth() = 0;
	virtual bool Damage(int damage) = 0;
};
class Player : public Person {
private:
	int level = 1;
	int xp = 0;
	int money = 0;
	int cellCount = 5;
	vector<string> items;
public:
	int damage;
	int step = 1;
	bool canAttack = false;
	Player(int x, int y, int health, int damage) : Person(x, y, health) {
		this->damage = damage;
	}
	int getCellCount()
	{
		return cellCount;
	}
	void setCellCount(int cellCount)
	{
		this->cellCount = cellCount;
	}
	int getMoney()
	{
		return money;
	}
	void setMoney(int m)
	{
		money += m;
	}
	void setItems(string item)
	{
		if (items.size() < cellCount)
		{
			items.push_back(item);
		}
	}
	int getX() override 
	{
		return x;
	}

	int getY() override 
	{
		return y;
	}

	void setXP(int p) 
	{
		xp += p;
		if (xp > 100 * level) 
		{
			xp -= 100 * level;
			level += 1;
			damage += 10;
			
		}
	}

	int moveX(int step) 
	{
		return x += step;
	}

	int moveY(int step) 
	{
		return y += step;
	}

	int getHealth() override 
	{
		return health;
	}

	bool Damage(int damage) override 
	{
		health -= damage;
		if (health <= 0)
		{
			cout << "Игра окончена" << endl;
			return false;
		}
		return true;
	}

	void PlayerInfo() 
	{
		cout << "x: " << y << "\t y:" << x << endl;
		cout << "Level: " << level << "\t XP: " << xp << endl;
		cout << "Health: " << health << "\tMoney:" << money << endl;
	}
	void PlayerInventory()
	{
		for (auto& i : items)
		{
			cout << i << endl;
		}
	}
};
class Enemy : public Person {
private:
	int xp = 0;
	string name = "";
	string sign = "";
public:
	bool isDead = false;
	Enemy(){}
	Enemy(int x, int y, int health, string name, int xp, string sign) : Person(x, y, health) 
	{
		this->name = name;
		this->xp = xp;
		this->sign = sign;
	}
	string getSign()
	{
		return this->sign;
	}
	void setPos(int x,int y)
	{
		this->x = x;
		this->y = y;
	}
	int getX() override {
		return x;
	}

	int getY() override {
		return y;
	}

	string getName() {
		return name;
	}

	int getHealth() override {
		return health;
	}

	int getXP() {
		return xp;
	}

	bool Damage(int damage) override {
		health -= damage;
		if (health <= 0)
		{
			this->isDead = true;
			return true;
		}
		return false;
	}
	
};
class River {
private:
	int* x = new int[5];
	int* y = new int[5];
public:
	River(int* x, int* y) {
		this->x = x;
		this->y = y;
	}

	int* getX()
	{
		return x;
	}

	int* getY()
	{
		return y;
	}
};
class Money
{
private:
	int count = 0;
	int x;
	int y;
	bool isActive = true;
public:
	Money(int count,int x,int y)
	{
		this->count = count;
		this->x = x;
		this->y = y;
	}
	bool getActive()
	{
		return isActive;
	}
	void setActive(bool a) 
	{
		isActive = a;
	}
	int getCount()
	{
		return count;
	}
	int getX()  
	{
		return x;
	}

	int getY() 
	{
		return y;
	}
};
void map(Player& p, vector<Enemy>& enemies, vector<Money>& moneys, int mapSize)
{
	HANDLE hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
	for (int i = -mapSize + p.getX(); i < mapSize + + p.getX(); i++)
	{
		for (int j = -mapSize + p.getY(); j < mapSize + p.getY(); j++)
		{
			if (i == 0 && j == 0)
			{
				cout << "+";
				continue;
			}
			bool isEnemy = false;
			for (auto& e : enemies)
			{
				if (p.getX() == i && p.getY() == j && p.getX() == e.getX() && p.getY() == e.getY() && !e.isDead)
				{
					SetConsoleTextAttribute(hConsole, 10);
					cout << "?";
					isEnemy = true;
					continue;
				}
				if (e.getX() == i && e.getY() == j && !e.isDead)
				{
					SetConsoleTextAttribute(hConsole, 12);
					cout << e.getSign();
					isEnemy = true;
					continue;
				}
			}
			for (auto& m : moneys)
			{
				if (p.getX() == m.getX() && p.getY() == m.getY() && m.getActive())
				{
					SetConsoleTextAttribute(hConsole, 14);
					cout << "Вы нашли монетку ценой " << m.getCount() << "!" << endl;
					p.setMoney(m.getCount());
					m.setActive(false);
				}
				if (m.getX() == i && m.getY() == j && m.getActive())
				{
					SetConsoleTextAttribute(hConsole, 14);
					cout << "X";
					isEnemy = true;
					continue;
				}
				
			}
			SetConsoleTextAttribute(hConsole, 15);
			if (!isEnemy)
			{
				//рисовка игрока
				if (p.getX() == i && p.getY() == j)
				{
					cout << "*";
					continue;
				}
				cout << " ";
			}
		}
		cout << endl;
	}
}
int main()
{
	//1 БАГ - Враги могут стоять на одном месте друг с другом - исправлено
	//2 БАГ - Если враг умер, сообщение об атаке все равно будет - исправлено
	//3 БАГ - Оси координат 'X' и 'Y' перемешаны друг с другом - псевдоисправлено
	//ЗАДАЧА - ИСПРАВИТЬ БАГИ
	srand(time(NULL));
	Player p(0, 0, 100, 10);
	p.setItems("Диск");
	p.setItems("Пули");
	p.setItems("Пистолет");
	p.setItems("Нож");
	p.setItems("Меч");
	p.setItems("Пулёмет");
	p.PlayerInfo();
	setlocale(LC_ALL, "RU");
	const int size = 5;
	Enemy e0(3, 4, 10, "Волк", 50,"*");
	Enemy e1(3, 4, 20, "Волк", 40,"^");
	Enemy e2(3, 4, 20, "Волк", 10,"#");
	Enemy e3(3, 4, 30, "Волк", 10,"&");
	Enemy e4(3, 4, 30, "Волк", 10, "@");
	Money m0(10, 4, 4);
	Money m1(10, 2, 2);
	Money m2(20,-2,-2);
	vector<Money> moneys = { m0,m1,m2 };

	vector<Enemy> enemies = { e0,e1,e2,e3,e4 };
	for (int i = 0; i < enemies.size(); i++)
	{
		for (int j = 1; j < enemies.size(); j++)
		{
			if (enemies[i].getX() == enemies[j].getX() && enemies[i].getY() == enemies[j].getY())
			{
				int x = (rand() % 5 - 2) + enemies[j].getX();
				int y = (rand() % 5 - 2) + enemies[j].getY();
				enemies[j].setPos(x,y);
				break;
			}
		}
	}
	int* x = new int[5]{ 100,101,102,103,104 };
	int* y = new int[5]{ 100,101,102,103,104 };
	River r(x, y);
	bool inventoryActive = false;

	while (true)
	{
		if (inventoryActive)
		{
			goto command;
		}
		//проверка на врага
		{
			for (auto& e : enemies)
			{
				
				if (p.getX() == e.getX() && p.getY() == e.getY() && !e.isDead)
				{
					cout << "Враг " << e.getName() << "(" << e.getHealth() << "hp) в данной клетке" << endl;
					cout << "5 - атаковать" << endl;
					p.canAttack = true;
					break;
				}
				else
				{
					p.canAttack = false;
				}
			}
		}

		map(p, enemies, moneys,5);

		//плаваем
		{
			for (size_t i = 0; i < (sizeof r.getX() / sizeof r.getX()[0]); i++)
			{

				if (p.getX() == r.getX()[i])
				{
					cout << "Игрок утонул" << endl;
					return true;
				}
			}
			for (size_t i = 0; i < (sizeof r.getY() / sizeof r.getY()[0]); i++)
			{

				if (p.getY() == r.getY()[i])
				{
					cout << "Игрок утонул" << endl;
					return true;
				}
			}
		}

		command:
		int command;
		cout << "Напишите комманду(10 для помощи): ";
		cin >> command;
		cout << endl;

		switch (command)
		{
		case 1:
			if (inventoryActive)
			{
				break;
			}
			if (!p.canAttack) {
				p.moveY(p.step);
			}
			system("cls");
			p.PlayerInfo();
			break;
		case 2:
			if (inventoryActive)
			{
				break;
			}
			if (!p.canAttack) {
				p.moveY(-p.step);
			}
			system("cls");
			p.PlayerInfo();
			break;
		case 3:
			if (inventoryActive)
			{
				break;
			}
			if (!p.canAttack) {
				p.moveX(p.step);
			}
			system("cls");
			p.PlayerInfo();
			break;
		case 4:
			if (inventoryActive)
			{
				break;
			}
			if (!p.canAttack) {
				p.moveX(-p.step);
			}
			system("cls");
			p.PlayerInfo();
			break;

		case 5:
			if (inventoryActive)
			{
				break;
			}
			system("cls");
			p.PlayerInfo();
			if (p.canAttack)
			{
				for (auto &e : enemies)
				{
					if (p.getX() == e.getX() && p.getY() == e.getY() && !e.isDead)
					{
						cout << "Вы нанесли " << p.damage << " урона" << endl;
						if (e.Damage(p.damage))
						{
							p.setXP(e.getXP());
							system("cls");
							p.PlayerInfo();
							cout << "Монстр убит,вы получили " << e.getXP() << " опыта!" << endl;
								
						}
					}
					else
					{
						p.canAttack = false;
					}
						
				}
			}
				
			break;
		case 6:
			inventoryActive = true;
			system("cls");
			p.PlayerInfo();
			cout << "Текущий инвентарь:" << endl;
			p.PlayerInventory();
			cout << "\n7 - выйти из инвентаря" << endl;
			break;
		case 7:
			if (!inventoryActive)
			{
				break;
			}
			inventoryActive = false;
			system("cls");
			p.PlayerInfo();
			break;
		case 9:
			cout << "Игра окончена" << endl;
			return false;
		case 10:
			system("cls");
			cout << "1 - переместится на ячейку вверх " << endl;
			cout << "2 - переместится на ячейку вниз " << endl;
			cout << "3 - переместится на ячейку вправо" << endl;
			cout << "4 - переместится на ячейку влево" << endl;
			cout << "6 - открыть инвентарь" << endl;
		default:
			system("cls");
			cout << "Неверная команда" << endl;
			p.PlayerInfo();
			break;
			}
		}
	}


