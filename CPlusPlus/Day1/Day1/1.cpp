#include <iostream> // # >> ��ó���� �ؼ��ϱ� ���� �̰ź��� ó�� ��Ű�ڴ�. iostreamdm�� ���Խ�Ű�ڴ�. 
                    // iostreamdm >> ����� �ϴ� ģ�� 
#include <string> // string ��� �����ϰ� ���ִ� �ش�
using namespace std; // �ҽ����Ͽ��� std���� �������ڴ�?? ���� � �������� �����ϴ� ���� 
					 // �̰� ���ٸ� cout�̰Ÿ� std::cout�̷������� ����Ѵ� 

// ������ ���� ������ ������ �Ǿ��־���Ѵ�. �ƴϸ� ������ ����.
void InOut(); // �����
void TEST1(); // ����1
float TEST2(float index); // ����2
void String(); // string ����
string TEST3(string str); // ����3
void TEST4(string str); // ����4
string TEST5(int index); // ����5
char TEST6(int index); // ����6
void TEST7(int index); // ����7
void TEST8(int index); // ����8

int main() // ���α׷��� ������. ��ȯ������ int. ���� ��� �ִ� ������ش� 
{
#pragma region InOut
	// InOut();
#pragma endregion

#pragma region TEST1
	// TEST1();
#pragma endregion

#pragma region TEST2
	// cout << TEST2(12) << endl;
#pragma endregion

#pragma region String
	// String();
#pragma endregion

#pragma region TEST3
	// cout << "���ڿ��� �Է��Ͻÿ� : ";
	// string str;
	// cin >> str;
	// cout << TEST3(str);
#pragma endregion

#pragma region TEST4
	// cout << "Input string : ";
	// string str;
	// getline(cin, str);
	// TEST4(str);
#pragma endregion

#pragma region TEST5
	// cout << "Input Int : ";
	// int index;
	// cin >> index;
	// cout << TEST5(index);
#pragma endregion

#pragma region TEST6
	// cout << "������ �Է��ϼ���. : ";
	// int index;
	// cin >> index;
	// TEST6(index);
	// cout << "����� " << TEST6(index) << "�Դϴ�.";
#pragma endregion

#pragma region TEST7
	cout << "�Ҽ��� ���� �ִ� ���ڸ� �Է��ϼ���. : ";
	int index;
	cin >> index;
	TEST7(index);
#pragma endregion

#pragma region TEST8
	cout << "���̸� �Է��ϼ���. : ";
	int index;
	cin >> index;
	TEST8(index);
#pragma endregion
}

void InOut()
{
	char arr[100]; // char�� �ڷ����� 100�� ũ��� 
	cout << "What's your name?" << endl; // cout ����ϴ°� ����Ҷ� <<�� ������ �־��־���Ѵ�.
										 // " "���� cout�� �����شٰ� �����ϸ� �ȴ�. 
										 // endl �ٹٲ�.
	cin >> arr /* >> arr2 */; // �Է� �޾Ƽ� arr�� �ְڴ�.
				// ���� ���� arr�� �����شٶ�� ���� �ϸ� �ȴ�. 
				// ������ ������ �׳� ������. �� "Don gYeop"�̶�� "Don"�� ���. ���⸦ �������� �Ѵ�.
				// ���⵵ �ְ� �ʹٸ� "cin.getline" ������ �޴´�. Enter�� �������� �޴´�. 
				// ���� >> cin.getline(arr, 100);
	cout << "hi" << " " << arr; // cout �������� �����ڷ� ����.

	// cout cin �̷��Ŵ� �Լ��� �ƴϴ�
}

void TEST1()
{
	char name[100];
	int old;
	char anythigSay[100];
	cout << "What's your name?" << endl << "How old are you?" << endl;
	cin >> name >> old;
	cout << "hi " << name << "You are " << old << "years old ~ !" << endl;
	cout << "Do you  anything to say?" << endl;
	cin.ignore(); // ���͹��۸� �Դ´� 
				  // cin�� ���Ͱ� �� �ִ°� �� �������ִ� ���� 
	cin.getline(anythigSay, 100);
	cout << anythigSay;
}

float TEST2(float index)
{
	const float pi = 3.14;
	return (index * index * pi);
}

void String()
{
	string str = "hello";
	cout << str[4] << str.at(4); // str�� 4��° �ܾ� o�� ���
	cout << str[5]; // Enter�� ���ִ�. �� ��µȴ�.
	// cout << str[6]; // Out of range�� ���. ������ ���������� ������ �̸� üũ�� �� ���� 
	// cout << str.at(6); // ���ܰ� ó������������ ���. ������ ���������� ������ �̸� üũ�� �� ����. �� ��Ȯ���� �߿���Ҷ� 
}

string TEST3(string str)
{
	for (int i = 0; i < str.length(); i++)
	{
		if (str[i] == 'o')
			str[i] = 'x';
		else if (str[i] == 'O')
			str[i] = 'X';
	}
	return str;
}

void TEST4(string str)
{
	for (int i = 0; i < str.length(); i++)
	{
		char front = str.front();
		for (int j = 0; j < str.length(); j++)
		{
			str[j] = str[j + 1];
		}
		str.back() = front;
		cout << str << endl;
	}
}

string TEST5(int index)
{
	return index % 2 == 0 ? "¦���Դϴ�." : "Ȧ���Դϴ�.";
}

char TEST6(int index)
{
	switch (index / 10)
	{
	case 10:
	case 9:
		return 'A';
	case 8:
		return 'B';
	case 7:
		return 'C';
	case 6:
		return 'D';
	default:
		return 'E';
		break;
	}
}

void TEST7(int index)
{
	int i;
	int j;
	int count = 0;
	for (i = 2; i <= index; i++)
	{
		for (j = 2; j < i; j++)
		{
			if (i % j == 0)
				break;
		}
		if (j == i)
		{
			cout << i << " ";
			count++;
		}
	}
	cout << endl << "2���� " << index << "������ �Ҽ��� ������ " << count << "�� �Դϴ�. ";
}

void TEST8(int index)
{
	for (int i; i <= index; i++)
	{
		for (int j = 1; j < i; j++)
			cout << " ";
		//for (int j =1; j <)
	}
}
