#pragma once
#include <iostream>
#include <fstream>	
#include <string>	
#include <Windows.h>
#include <vector>
#include <algorithm>

const std::string programName = "\t��������� \"������������������ �������������� ������� �� �������\"\n";

struct Train
{
	int number;
	std::string departureTime; // �� ���� �������� � time_t, �� ����� ��� �� ��������
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
		std::cout << "������ �����?(Y/N): ";
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
		std::cout << "������� ����� ������:";
		std::cin >> number;

		std::cout << "������� ����� �����������:";
		std::cin >> depTime;

		std::cout << "������� ������� ����������:";
		std::cin >> destStation;

		std::cout << "������� ������������ ��������:";
		std::cin >> duration;

		trains.push_back(Train(number, depTime, destStation, duration));
	}
}
void print(const std::vector<Train>& trains)
{
	std::cout << "\t������" << std::endl;
	for (Train t : trains)
	{
		std::cout << "����� ������: " << t.number << std::endl;
		std::cout << "����� �����������: " << t.departureTime << std::endl;
		std::cout << "������� ����������: " << t.destinationStation << std::endl;
		std::cout << "������������ ��������: " << t.duration << std::endl;
		std::cout << std::endl;
	}
}
void print(const Train& train)
{
	std::cout << "����� ������: " << train.number << std::endl;
	std::cout << "����� �����������: " << train.departureTime << std::endl;
	std::cout << "������� ����������: " << train.destinationStation << std::endl;
	std::cout << "������������ ��������: " << train.duration << std::endl;
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
			<< "1 - ������ ������ � �������" << std::endl
			<< "2 - ������� ��� ������" << std::endl
			<< "3 - ������� ���������� �����" << std::endl
			<< "0 - ����� �� ���������" << std::endl
			<< "�������� ��������: ";

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
			std::cout << "������� ����� �������������� ������: ";
			std::cin >> number;
			print(findTrain(trains, number));
			break;
		case 0:
			system("cls");
			std::cout << "\n\t�� ��������!\n\n";
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