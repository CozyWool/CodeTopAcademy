#pragma once
#include <iostream>
#include <string>
#include <vector>
#include "Comments.h"
using namespace std;
class Game
{
private:
	string name;
	string dev;
	string genre;
	int dateRel[3];
	
	int dateUpd[3];
	double price;
	Comments comm;
public:
	Game()
	{
		name = "None";
		dev = "None";
		genre = "None";
	}
	Game(string name, string dev, string genre, int dayR, int monthR, int yearR, double price) : name(name), dev(dev), genre(genre), dateRel{ dayR,monthR,yearR }
	{	

	}
	void SetPrice(double price)
	{
		this->price = price;
	}
	void SetDateUpd(int dayU, int monthU, int yearU)
	{
		dateUpd[0] = dayU;
		dateUpd[1] = monthU;
		dateUpd[2] = yearU;
	}
	void Set(string name, string dev, string genre, int dayR, int monthR, int yearR, double price)
	{
		this->name = name;
		this->dev = dev;
		this->genre = genre;
		dateRel[0] = dayR;
		dateRel[1] = monthR;
		dateRel[2] = yearR;
		this->price = price;
	}
	void Print()
	{
		cout << "Name: " << name << endl;
		cout << "Dev: " << dev << endl;
		cout << "Genre: " << genre << endl;
		cout << "Date of release: ";
		for (int i = 0; i < 3; i++)
			cout << dateRel[i] << ":";
		cout << endl;
		if (dateUpd != 0)
			for (int i = 0; i < 3; i++)
				cout << dateUpd[i] << ":";
		cout << endl;
		cout << "Price: " << price << endl;
		cout << "\n-----------------------------------\n" << endl;
	}
};

