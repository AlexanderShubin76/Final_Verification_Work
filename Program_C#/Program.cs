// Задача: Написать программу, которая из имеющегося
// массива строк формирует новый массив из строк, 
// длина которых меньше, либо равна 3 символам. 
// Первоначальный массив можно ввести с клавиатуры, 
// либо задать на старте выполнения алгоритма. 
// При решении не рекомендуется пользоваться коллекциями, 
// лучше обойтись исключительно массивами.
// Примеры:
// [“Hello”, “2”, “world”, “:-)”] → [“2”, “:-)”]
// [“1234”, “1567”, “-2”, “computer science”] → [“-2”]
// [“Russia”, “Denmark”, “Kazan”] → []
Console.WriteLine("Задайте первоначальный массив, вводя символы с клавиатуры в терминал.");
System.Console.WriteLine("Элементы разделите между собой через запятую.");
System.Console.WriteLine("Если внутри элемента необходимо разделить символы,");
System.Console.Write("используйте не более одного пробела:");
string[] array = GetArray(Console.ReadLine()!);
System.Console.WriteLine($"Первоначальный массив: [{string.Join(", ", array)}]");

System.Console.Write("Массив, состоящий из элементов длиной не более 3 символов:");
System.Console.WriteLine($"[{string.Join(", ", MakeArray3Symbols(array))}]");

string[] GetArray(string words)
{
    int size = words.Length;
    int length = 1;
    for (int i = 0; i < size; i++)
    {
        if (words[i] == ',')
        {
            length++;
        }
    }
    string[] massive = new string[length];
    int k = 0;
    for (int j = 0; j < size; j++)
    {
        string temp = string.Empty;
        while (words[j] != ',')
        {

            if (words[j] == ' ' && j != size - 1 && words[j + 1] != ' ' && words[j - 1] != ' '
               && words[j - 1] != ',' && words[j + 1] != ',')
            {
                temp += words[j].ToString();
                j++;
            }

            else if (words[j] == ' ' && j != size - 1)
            {
                j++;
            }

            else if (words[j] == ' ' && j == size - 1)
            {
                break;
            }

            else if (j != size - 1)
            {
                temp += words[j].ToString();
                j++;
            }

            else if (j == size - 1)
            {
                temp += words[j].ToString();
                break;
            }
        }

        massive[k] = temp;
        k++;
    }
    return massive;
}

string[] MakeArray3Symbols(string[] array)
{

    for (int i = 0; i < array.Length; i++)
    {
        if (array[i].Length > 3)
        {
            for (int s = i; s < array.Length - 1; s++)
            {
                array[s] = array[s + 1];
            }
            Array.Resize(ref array, array.Length - 1);
            i --;
        }  
    }
    return array;
}