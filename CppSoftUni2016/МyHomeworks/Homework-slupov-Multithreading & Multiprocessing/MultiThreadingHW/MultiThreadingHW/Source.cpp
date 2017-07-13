#include <iostream>
#include <mutex>
#include <thread>
#include <vector>
#include <climits>
#include <chrono>
#include <math.h> 
#include <ctime>

using namespace std;
mutex mtx;

int fibo1 = 1, fibo2 = 1;
int lastFib = 2;
int lastPrime;

bool isPrime(int i)
{
	int m = (int)round((sqrt(i)));

	if (i == 1 || i == 2)
		return true;

	for (int j = 2; j <= m; j++)
		if (i % j == 0) return false;

	return true;
}

void calculateNextFibonacci()
{
	lastFib = fibo1 + fibo2;

	fibo1 = fibo2;
	fibo2 = lastFib;
}

bool isFibonacci(int i)
{
	if (lastFib == i || i == 1)
	{
		calculateNextFibonacci();
		return true;
	}
	return false;
}

int main()
{


	for (unsigned long long i = 1; i <= ULONG_MAX; ++i)
	{
		cout << "Current number: " << i << endl;

		double start = clock();
		if (isPrime(i))
		{
			thread primes(isPrime, i);
			mtx.lock();
			cout << "Prime: " << i << endl;
			cout << "Time taken in millisecs: " << (double)(clock() - start) / CLOCKS_PER_SEC << endl;
			this_thread::sleep_for(std::chrono::seconds(1));
			primes.join();
			mtx.unlock();
		}

		start = clock();
		if (isFibonacci(i))
		{
			thread fibonacci(calculateNextFibonacci);
			cout << "Fibonacci: " << i << endl;
			//if we've found a fibonacci member , calculate the next one
			calculateNextFibonacci();
			cout << "Time taken in millisecs: " << (double)(clock() - start) / CLOCKS_PER_SEC << endl;
			this_thread::sleep_for(std::chrono::seconds(1));
			fibonacci.join();

		}



		if (i > ULLONG_MAX)
		{
			cout << "Error! Number out of range exception" << endl;
			return 0;
		}

		cout << "---------------" << endl;

	}



	return 0;
}
