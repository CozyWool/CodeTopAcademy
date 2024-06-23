#pragma once
#include <iostream>
#include <fstream>	
#include <string>	
#include <Windows.h>
#include <vector>
#include <algorithm>

const std::string programName = "\tПрограмма \"Автоматизированная информационная система ЖД вокзала\"\n";

struct Train
{
	int number;
	std::string departureTime; // не стал мучаться с time_t, не помню как он работает
	std::string destinationStation;
	int duration;
	Train(int _number, std::string _departureTime, std::string _destinationStation, int _duration) :
		number{ _number },
		departureTime{ _departureTime },
		destinationStation{ _destinationStation },
		duration{ _duration }
	{

	}
};

void inputTrains(std::vector<Train>& trains)
{
	while (true)
	{
		std::cout << "Ввести поезд?(Y/N): ";
		char ans;
		std::cin >> ans;
		if (ans == 'N' or ans == 'n')
		{
			return;
		}

		int number;
		std::string depTime;
		std::string destStation;
		int duration;
		std::cout << "Введите номер поезда:";
		std::cin >> number;

		std::cout << "Введите время отправления:";
		std::cin >> depTime;

		std::cout << "Введите станцию назначения:";
		std::cin >> destStation;

		std::cout << "Введите длительность маршрута:";
		std::cin >> duration;

		trains.push_back(Train(number, depTime, destStation, duration));
	}
}
void print(const std::vector<Train>& trains)
{
	std::cout << "\tПоезда" << std::endl;
	for (Train t : trains)
	{
		std::cout << "Номер поезда: " << t.number << std::endl;
		std::cout << "Время отправления: " << t.departureTime << std::endl;
		std::cout << "Станция назначения: " << t.destinationStation << std::endl;
		std::cout << "Длительность маршрута: " << t.duration << std::endl;
		std::cout << std::endl;
	}
}
void print(const Train& train)
{
	std::cout << "Номер поезда: " << train.number << std::endl;
	std::cout << "Время отправления: " << train.departureTime << std::endl;
	std::cout << "Станция назначения: " << train.destinationStation << std::endl;
	std::cout << "Длительность маршрута: " << train.duration << std::endl;
	std::cout << std::endl;
}

Train findTrain(const std::vector<Train>& trains, int trainNumber)
{
	for (Train t : trains)
	{
		if (t.number == trainNumber)
		{
			return t;
		}
	}
}

int Program()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	std::vector<Train> trains;

	while (true)
	{
		std::cout << programName << std::endl
			<< "1 - Ввести данные о поездах" << std::endl
			<< "2 - Вывести все поезда" << std::endl
			<< "3 - Вывести конкретный поезд" << std::endl
			<< "0 - Выход из программы" << std::endl
			<< "Выберите действие: ";

		std::string lineToFind;
		std::string oldString;
		std::string newString;
		std::vector<std::pair<size_t, size_t>> positions;

		int t;
		std::cin >> t;

		system("cls");

		switch (t)
		{
		case 1:
			inputTrains(trains);
			break;
		case 2:
			print(trains);
			break;
		case 3:
			int number;
			std::cout << "Введите номер запрашиваемого поезда: ";
			std::cin >> number;
			print(findTrain(trains, number));
			break;
		case 0:
			system("cls");
			std::cout << "\n\tДо свидания!\n\n";
			return 0;
			break;
		default:
			break;
		}

		std::cout << "\n\n";
		system("pause");
		system("cls");
	}

}