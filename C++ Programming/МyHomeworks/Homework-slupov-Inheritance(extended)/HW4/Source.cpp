#include <iostream>
#include <string>
#include <vector>
#include "Item.h"
#include "Sale.h"
using namespace std;

void keyA(vector<Item> &itemsList, Sale &currentSale, vector<Item> &currentSalePurchases)
{
	bool found = false;

	string code;
	cout << "Enter the item's 10-digit code: ";
	cin >> code;

	for each (Item item in itemsList)
	{
		if (item.itemCode == code)
		{
			found = true;
			cout << "Item found!" << endl;
			currentSale += item;
			currentSalePurchases.push_back(item);
		}
	}

	if (found == false)
	{
		cout << "Item cannot be found!" << endl;
	}

}

void changeItemPrice(vector<Item> &itemsList, vector<Item> &currentPurchases, Sale &currentSale)
{
	string code;
	cout << "Enter the code of the item whose price you want to change: ";
	cin >> code;
	float newPrice;
	cout << "Enter the new price: ";
	cin >> newPrice;

	//searches through the items that has already been checked and replaces and swaps the old value of the product with the new one
	for each (Item item in itemsList)
	{
		if (item.itemCode == code)
		{
			currentSale.totalValue -= item.price;
			item.price = newPrice;
			currentSale.totalValue += newPrice;
		}
	}

}

void printReceipt(Sale &currentSale, vector<Item> purchases)
{
	cout << currentSale.storeName << currentSale.BIC << endl << currentSale.address << endl;
	for (int i = 0; i < purchases.size() ; i++)
	{
		cout << purchases[i].name << " -> " << purchases[i].price << endl;
	}
	
	cout << "Money given : " << currentSale.moneyGiven << endl;
	cout << "Change : " << currentSale.moneyGiven - currentSale.totalValue << endl;
	cout << endl;
}

bool isInputValid(string input)
{
	if (input == "A" || input == "a" ||
	    input == "C" || input == "c" ||
		input == "T" || input == "t" ||
		input == "G" || input == "g" ||
		input == "U" || input == "u" ||
		input == "I" || input == "i" || 
		input =="shutdown")			
	{
		return true;
	}
	return false;
}

int main()
{
	string choice;
	bool isNotShutDown = true;
	bool nextCustomer = false;

	cout << "-------------------------------------MENU------------------------------------------------" << endl;
	cout << "Press A : write item's 10-digit code" << "  | " << "Press C : clear total value" << endl;
	cout << "Press T : display total value" << "         | " << "Press G : Enter the amount of money given" << endl;
	cout << "Press U : change the price of an item" << " | " << "Press I : Print receipt" << endl;
	cout << "NOTE: Write \"shutdown\" to end the program" << endl << endl;

	vector<Item> itemsList;
	vector<Sale> salesList;

	//adding default items (no info in the problem description)
	Item anItem1("food12345","Pork", 18.50); itemsList.push_back(anItem1);
	Item anItem2("food54321","Chicken", 9.12); itemsList.push_back(anItem2);
	Item anItem3("drink23345","Water", 4.50); itemsList.push_back(anItem3);
	Item anItem4("drink52345","Whiskey", 22.18); itemsList.push_back(anItem4);
	Item anItem5("other12645","dishes", 17.99); itemsList.push_back(anItem5);
	Item anItem6("other12345","flatting iron", 72.11); itemsList.push_back(anItem6);

	while (isNotShutDown)
	{
		Sale currentSale;
		vector<Item> currentSalePurchases;

		cout << "WELCOME TO " << currentSale.storeName << endl;
		cout << "--------------------" << endl;
		cout << "Enter your menu choice: ";
		getline(cin, choice);

		if (!isInputValid(choice) && choice != "shutdown")
		{
			cout << "NOT A MENU ITEM...TRY AGAIN" << endl;
			continue;
		}

		if (choice == "shutdown")
		{
			return 0;
		}
		
		while (nextCustomer == false)
		{
			switch (choice[0])
			{
			case 'A':
			case 'a': keyA(itemsList, currentSale, currentSalePurchases); break;
			case 'C':
			case 'c':
				currentSale.totalValue = 0;
				cout << "TOTAL VALUE CLEARED!!!" << endl;
				currentSalePurchases.clear();
				break;
			case 'T':
			case 't': cout << currentSale.totalValue << endl; break;
			case 'G':
			case 'g':
				float moneyGiven;
				cin >> moneyGiven;
				currentSale.setMoneyGiven(moneyGiven);
				cout << "The change is " << currentSale.moneyGiven - currentSale.totalValue << " leva" << endl;
				break;
			case 'U':
			case 'u': changeItemPrice(itemsList, currentSalePurchases, currentSale); break;
			case 'I':
			case 'i':
				printReceipt(currentSale, currentSalePurchases);
				nextCustomer = true;
				cout << "Welcome next customer" << endl;
				break;
			}
			
			//if we're done with the current customer, save the sale and give way to the next customer
			if (nextCustomer == true)
			{
				salesList.push_back(currentSale);
				break;
			}
			else
			{
				cout << "Enter your next menu choice: ";
				cin >> choice;

				if (!isInputValid(choice))
				{
					cout << "WRONG INPUT.NO SUCH OPTION IN THE MENU" << endl;
				}
				if (choice == "shutdown")
				{
					return 0;
				}
			}
			

		}

		nextCustomer = false;
	}


	system("pause");
	return 0;
}