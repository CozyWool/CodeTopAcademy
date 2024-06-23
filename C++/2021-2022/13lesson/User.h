#pragma once
#include <iostream>
#include <string>
#include <vector>
#include "Library.h"
using namespace std;
class User
{
private:
	
public:
	string nickname;
	vector<string> achievements;
	string country;
	int age;
	Library myLib;
	User()
	{

	}
	User(string nickname, string country, int age)
	{
		this->nickname = nickname;
		this->country = country;
		this->age = age;
	}
	User(string nickname, vector<string> achievements, string country, int age)
	{
		this->nickname = nickname;
		this->achievements = achievements;
		this->country = country;
		this->age = age;
	}
	void AddAchievement(string ach)
	{
		achievements.push_back(ach);
	}
	void Set(string nickname, vector<string> achievements, string country, int age)
	{
		this->nickname = nickname;
		this->achievements = achievements;
		this->country = country;
		this->age = age;
	}
	void SetOnKeyboard()
	{
		cout << "Write a user's nickname: ";
		cin >> nickname;
		cout << "Write a user's country: ";
		cin >> country;
		cout << "Write a user's age: ";
		cin >> age;
		int size;
		cout << "Write a user's achievement amount: ";
		cin >> size;
		for (int i = 0; i < size; i++)
		{
			string a;
			cout << "Write achievement:";
			cin >> a;
			achievements.push_back(a);
		}
		cout << "\n----------------------------------\n" << endl;
	}
	void Print()
	{
		cout << "User: " << nickname << endl;
		cout << "Achievements: " << endl;
		for (int i = 0; i < achievements.size(); i++)
		{
			cout << achievements[i] << ", ";
		}
		cout << endl;
		cout << "Country: " << country << endl;
		cout << "Age: " << age << endl;
		cout << "\n-----------------------------------\n" << endl;
	}
};

