#include <iostream>
#include <vector>
#include <Windows.h>
#include <iterator>

class VectorFunctor
{
private:
	std::vector<int> list;
public:
	VectorFunctor()
	{
		list = { 1,2,4,5,10,8,7,5 };
	}

	int minimum()
	{
		int res = list[0];
		for (int i = 1; i < list.size(); i++)
		{
			if (list[i] < res)
			{
				res = list[i];
			}
		}

		return res;
	}

	int maximum()
	{
		int res = list[0];
		for (int i = 1; i < list.size(); i++)
		{
			if (list[i] > res)
			{
				res = list[i];
			}
		}

		return res;
	}

	VectorFunctor& sortAscending()
	{
		for (int i = 1; i < list.size(); i++)
		{
			for (int j = 0; j < list.size() - i; j++)
			{
				if (list[j] > list[j + 1])
				{
					std::swap(list[j], list[j + 1]);
				}
			}
		}

		return *this;
	}

	VectorFunctor& sortDescending()
	{
		for (int i = 1; i < list.size(); i++)
		{
			for (int j = 0; j < list.size() - i; j++)
			{
				if (list[j] < list[j + 1])
				{
					std::swap(list[j], list[j + 1]);
				}
			}
		}

		return *this;
	}

	VectorFunctor& addValue(int value)
	{
		for (int i = 0; i < list.size(); i++)
		{
			list[i] += value;
		}

		return *this;
	}
	VectorFunctor& substractValue(int value)
	{
		for (int i = 0; i < list.size(); i++)
		{
			list[i] -= value;
		}

		return *this;
	}

	VectorFunctor& removeValue(int value)
	{
		// Моё решение
		for (int i = 0; i < list.size(); i++)
		{
			if (list[i] == value)
			{
				list.erase(list.begin() + i);
				i--; // раз сдвинули список на 1, значит надо сдвинуть i, чтобы не упустить значение
			}
		}

		/*Нашёл в интернете, разобрался в целом как работает
		std::erase_if(list, [value](const int& x) { return x == value; });
		*/

		return *this;
	}

	friend std::ostream& operator<<(std::ostream& out, const VectorFunctor& v)
	{
		for (int item : v.list)
		{
			out << item << " ";
		}
		return out;
	}
};

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	VectorFunctor vecFunc;

	std::cout << "Вектор: " << vecFunc << std::endl;
	std::cout << "\nМинимальное значение: " << vecFunc.minimum() << std::endl;
	std::cout << "Максимальное значение: " << vecFunc.maximum() << std::endl;

	std::cout << "\nСортировка по убыванию: " << vecFunc.sortDescending() << std::endl;
	std::cout << "Сортировка по убыванию: " << vecFunc.sortAscending() << std::endl;

	std::cout << "\nВектор + 5: " << vecFunc.addValue(5) << std::endl;
	std::cout << "Вектор - 10: " << vecFunc.substractValue(10) << std::endl;

	std::cout << "\nУдаление 0 из вектора: " << vecFunc.removeValue(0) << std::endl;
	std::cout << "Удаление 3 из вектора: " << vecFunc.removeValue(3) << std::endl;

}