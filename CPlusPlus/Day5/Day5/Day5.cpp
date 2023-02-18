#include <iostream>
#include <string>
#include <vector>

using namespace std;

string Solution(string new_id);

int TEST3_01(int x, int y);
void TEST3_02(int x, int y);
void TEST3_03(int x);
int TEST3_04(int arr[11]);
string TEST3_05(string str);
string TEST3_06(string str);
void TEST3_07(vector<int> vec);

int main()
{
#pragma region TEST1
	/*
	cout << "문자열을 입력하시오 : ";
	int a = 0, b = 0, c = 0;
	string str;
	getline(cin, str);

	for (auto &c:str)
	{
		switch (c)
		{
		case 'a':
		case 'A':
			a++;
		case 'b':
		case 'B':
			b++;
		case 'c':
		case 'C':
			c++;
		}
	}
	cout << "a 또는 A의 개수 : " << a << ", b 또는 B의 개수 : " << b << ", c또는 C의 개수 : " << c;
	*/
#pragma endregion

#pragma region TEST2
	/*
	cout << Solution("...!@BaT#*..y.abcdefghijklm") << endl;
	*/
#pragma endregion

#pragma region TEST3_01
	
	int x, y;
	cin >> x >> y;
	cout << TEST3_01(x, y);
	
#pragma endregion

#pragma region TEST3_02
	/*
	int x, y;
	cin >> x >> y;
	TEST3_02(x, y);
	*/
#pragma endregion

#pragma region TEST3_03
	/*
	int x;
	cin >> x;
	TEST3_03(x);
	*/
#pragma endregion

#pragma region TEST3_04
	/*
	int arr[11];
	for (int i = 0; i < 11; i++)
		cin >> arr[i];
	cout << TEST3_04(arr);
	*/
#pragma endregion

#pragma region TEST3_05
	/*
	string str;
	cin >> str;
	cout << TEST3_05(str);
	*/
#pragma endregion

#pragma region TEST3_06
	/*
	string str;
	getline(cin, str);
	cout << TEST3_06(str);
	*/
#pragma endregion

#pragma region TEST3_07 // 고장남 
	/*
	int index = 0;
	cin >> index;
	vector<int> vec;
	for (int i = 0; i < index; i++)
	{
		int j;
		cin >> j;
		vec.push_back(j);
	}
	TEST3_07(vec);
	*/
#pragma endregion
}

string Solution(string new_id)
{
	string answer = "";

	//1단계 new_id의 모든 대문자를 대응되는 소문자로 치환합니다.
	for (int i = 0; i < new_id.length(); i++)
		new_id[i] = tolower(new_id[i]);

	//2단계 new_id에서 알파벳 소문자, 숫자, 빼기(-), 밑줄(_), 마침표(.)를 제외한 모든 문자를 제거합니다.
	for (int i = 0; i < new_id.size(); i++)
		if (new_id[i] >= 'a' && new_id[i] <= 'z' || new_id[i] >= '0' && new_id[i] <= '9' || new_id[i] == '-' || new_id[i] == '_' || new_id[i] == '.')
			answer += new_id[i];

	//3단계 new_id에서 마침표(.)가 2번 이상 연속된 부분을 하나의 마침표(.)로 치환합니다.
	for (int i = 0; i < answer.size() - 1; i++)
	{
		if (answer[i] == '.' && answer[i + 1] == '.')
		{
			answer.erase(i, 1);
			i--;
		}
	}

	//4단계 new_id에서 마침표(.)가 처음이나 끝에 위치한다면 제거합니다.
	if (answer.front() == '.')
		answer.erase(0, 1);
	if (answer.back() == '.')
		answer.pop_back();

	//5단계 new_id가 빈 문자열이라면, new_id에 "a"를 대입합니다.
	if (answer.empty())
		answer = 'a';

	//6단계 new_id의 길이가 16자 이상이면, new_id의 첫 15개의 문자를 제외한 나머지 문자들을 모두 제거합니다.
	//만약 제거 후 마침표(.)가 new_id의 끝에 위치한다면 끝에 위치한 마침표(.) 문자를 제거합니다.
	while (answer.length() > 15)
		answer.erase(answer.length() - 1, 1);

	if (answer.back() == '.')
		answer.pop_back();

	//7단계 new_id의 길이가 2자 이하라면, new_id의 마지막 문자를 new_id의 길이가 3이 될 때까지 반복해서 끝에 붙입니다.
	if (answer.size() <= 2)
		while (answer.size() < 3)
			answer += answer.back();

	return answer;
}

int TEST3_01(int x, int y)
{
	int index = 0;
	for (int i = y; i < x; i++)
		index += i;
	return index;
}

void TEST3_02(int x, int y)
{
	int index = 0;

	for (int i = x; i <= y; i++)
	{
		cout << i << " ";
		if (i != y)
			cout << "+ ";
		index += i;
	}

	cout << "= " << index;
}

void TEST3_03(int x)
{
	vector<int> arr;
	int index = 0;

	for (int i = 1; i < x; i++)
	{
		if (x % i == 0)
			arr.push_back(i);
	}

	for (int i = 0; i < arr.size(); i++)
	{
		cout << arr[i] << " ";
		if (i != arr.size() - 1)
			cout << "+ ";
		index += arr[i];
	}

	cout << "= " << index;
}

int TEST3_04(int arr[11])
{
	int small = 2147483647, big = 0;

	for (int i = 0; i < 11; i++)
	{
		if (arr[i] < small)
			small = arr[i];
		if (arr[i] > big)
			big = arr[i];
	}

	return big - small;
}

string TEST3_05(string str)
{
	string answer;

	for (int i = 0; i < str.size(); i++)
	{
		switch (str[i])
		{
		case '1':
		case '2':
		case '3':
		case '4':
		case '5':
		case '6':
		case '7':
		case '8':
		case '9':
			answer += str[i];
		default:
			break;
		}
	}

	return answer;
}

string TEST3_06(string str)
{
	for (int i = 0; i < str.size(); i++)
	{
		if (str[i] == ' ')
		{
			str.erase(i, 1);
			i--;
		}

		str[i] = tolower(str[i]);
	}

	return str;
}

void TEST3_07(vector<int> vec)
{
	vector<int> vec2;
	vec2 = vec;

	for (int i = 0; i < vec2.size(); i++)
	{
		for (int j = 0; j < i; i++)
		{
			if (vec[i] < vec[j])
			{
				int temp = vec[i];
				vec[i] = vec[j];
				vec[j] = temp;
			}
		}
	}

	for (int i = 0; i < vec.size(); i++)
		for (int j = 0; j < vec.size(); j++)
			if (vec[i] == vec[j])
				cout << j << ' ';
}
