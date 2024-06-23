#include <iostream>
#include <map>
#include <vector>
#include <algorithm>
#include <Windows.h>
#include <unordered_map>

double average(std::vector<int> vec)
{
	double sum = 0;
	for (int i = 0; i < vec.size(); i++)
	{
		sum += vec[i];
	}
	return sum / vec.size();
}

bool ok(const std::pair<std::string, std::vector<int>>& a, const std::pair<std::string, std::vector<int>>& b)
{
	return average(a.second) < average(b.second);
}
void printStudents(const std::unordered_map<std::string, std::vector<int>>& students)
{
	for (const auto& [name, marks] : students)
	{
		std::cout << "студент " << name << " с оценками: ";
		for (int i = 0; i < marks.size(); i++)
		{
			std::cout << marks[i] << " ";
		}
		std::cout << "средний балл: " << average(marks) << std::endl;
	}
}
void printStudents(const std::vector<std::pair<std::string, std::vector<int>>>& students)
{
	for (const auto& [name, marks] : students)
	{
		std::cout << "студент " << name << " с оценками: ";
		for (int i = 0; i < marks.size(); i++)
		{
			std::cout << marks[i] << " ";
		}
		std::cout << "средний балл: " << average(marks) << std::endl;
	}
}

void sort(std::unordered_map<std::string, std::vector<int>>& m)
{
	std::vector<std::pair<std::string, std::vector<int>>> pairs;

	for (auto& it : m)
	{
		pairs.push_back(it);
	}

	sort(pairs.begin(), pairs.end(), ok);

	m.clear();
	for (auto& it : pairs)
	{
		m.insert(it);
	}
}


int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	std::unordered_map<std::string, std::vector<int>> students;
	students.insert(std::make_pair("Maksim", std::vector<int>{5, 3, 4}));
	students.insert(std::make_pair("Petr", std::vector<int>{5, 3, 5}));
	students.insert(std::make_pair("Victor", std::vector<int>{2, 2, 4}));
	students.insert(std::make_pair("Alexander", std::vector<int>{4, 3, 4}));

	std::cout << "\t\tДо сортировки" << std::endl;
	printStudents(students);

	sort(students);

	std::cout << "\n\t\tПосле сортировки" << std::endl;
	printStudents(students);
}