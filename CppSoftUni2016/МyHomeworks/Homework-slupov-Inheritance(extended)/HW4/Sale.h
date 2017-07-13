#pragma once
#include<iostream>
#include<string>
#include"Item.h"
using namespace std;
class Sale
{
public:
	float totalValue;
	const string storeName = "Kaufgaria";
	const string BIC = "BUINBGSF";
	const string address = "bul.Maria Luiza 123";
	float moneyGiven;

	void setMoneyGiven(float _moneyGiven) { this->moneyGiven = _moneyGiven; };

	Sale()
	{
		totalValue = 0;
		moneyGiven = 0;
	}
	
	Sale &operator+=(const Item &anItem)
	{
		this->totalValue += anItem.price;
		return *this;
	}
};