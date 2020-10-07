using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minesweper
{
    [Serializable]
    public class GameField
    {
        public int[] FieldData { get; } //данные о поле
        public bool[] UserField { get; }  //данные об известной пользователю части поля
        public int SizeX { get; }
        public int SizeY { get; }
        public int Bombs { get; set; }
        public List<int[]> ForUpdate { get; set; }
        public GameField(int sizeX, int sizeY, int bombs)
        {
            ForUpdate = new List<int[]>();
            SizeX = sizeX;
            SizeY = sizeY;
            FieldData = new int[sizeX * sizeY];
            UserField = new bool[sizeX * sizeY];
            Bombs = bombs;

            for (int i = 0; i < SizeY; i++) //инициализация поля
                for (int j = 0; j < SizeX; j++)
                {
                    FieldData[i * SizeX + j] = 0;
                    UserField[i * SizeX + j] = false;
                }

            var rand = new Random();

            if (Bombs >= SizeX * SizeY)
            {                                               //расставление бомб
                for (int i = 0; i < SizeY; i++)
                    for (int j = 0; j < SizeX; j++)
                        FieldData[i * SizeX + j] = 9;
            }
            else
                for (int i = 0, x = 0, y = 0; i < Bombs;)
                    if (FieldData[(y = rand.Next(SizeY)) * SizeX + (x = rand.Next(SizeX))] == 0)
                    {
                        FieldData[y * SizeX + x] = 9;                                      //0-8 количество бомб вокруг пустой клетки, 9 - бомба в клетке
                        i++;
                    }

            for (int i = 0; i < SizeY; i++)                               //подсчет бомб вокруг
                for (int j = 0, count = 0; j < SizeX; j++)
                {
                    if (FieldData[i * SizeX + j] != 9)
                    {
                        for (int y = i - 1; y - i < 2; y++)
                            for (int x = j - 1; x - j < 2; x++)
                                if (y >= 0 && y < SizeY && x >= 0 && x < SizeX)
                                    if (FieldData[y * SizeX + x] == 9) count++;

                        FieldData[i * SizeX + j] = count;
                        count = 0;
                    }
                }
        }

        public bool Open(int x, int y)
        {
            if (!((x >= 0) && (y >= 0) && (x < SizeX) && (y < SizeY))) //проверка на выход за пределы поля
                return true; 

            if (!UserField[y * SizeX + x])
            {
                if (FieldData[y * SizeX + x] >= 10)   //проверка на флаг
                    return true;

                UserField[y * SizeX + x] = true;
                ForUpdate.Add(new int[2] { x, y });

                if (FieldData[y * SizeX + x] == 9)  //проверка на бомбу
                    return false;

                if (FieldData[y * SizeX + x] == 0) //рекурсивное открытие площадей из нулей
                    for (int i = y - 1; i < y + 2; i++)
                        for (int j = x - 1; j < x + 2; j++)
                            if ((j >= 0) && (i >= 0) && (j < SizeX) && (i < SizeY))
                                if (!UserField[i * SizeX + j])
                                    Open(j, i);

                return true;
            }
            else return true;
        }
        public int OpenAround(int x, int y) //открытие клеток вокруг
        {
            int i, j, count = 0, a = 0;
            if (UserField[y * SizeX + x])
            {
                for (i = y - 1; i < y + 2; i++)
                    for (j = x - 1; j < x + 2; j++)
                        if ((i >= 0) && (i < SizeY) && (j >= 0) && (j < SizeX))
                            if (FieldData[i * SizeX + j] >= 10) //если клетка помечена флажком
                                count++;
                if (FieldData[y * SizeX + x] == count)  //если количество флажков вокруг совпало с цифрой на клетке, открываем все закрытые клетки вокруг данной
                    for (i = y - 1; i < y + 2; i++)
                        for (j = x - 1; j < x + 2; j++)
                            if (!Open(j, i)) a++;
                return a; //0 - всё хорошо, >0 - наступил на a бомб
            }
            else return 0;
        }
        public void PutFlag(int x, int y)
        {
            if (!UserField[y * SizeX + x])
                if (FieldData[y * SizeX + x] >= 10)
                {
                    FieldData[y * SizeX + x] -= 10;
                    Bombs++;
                }
                else
                {
                    FieldData[y * SizeX + x] += 10;
                    Bombs--;
                }
        }
        public bool CheckWin()
        {
            for (int i = 0; i < SizeY; i++)
                for (int j = 0; j < SizeX; j++)
                    if (UserField[i * SizeX + j] == true || FieldData[i * SizeX + j] >= 9) continue;
                    else return false;
            return true;
        }
        protected void printFieldData()
        {
            for (int i = 0; i < SizeY; i++)
            {
                for (int j = 0; j < SizeX; j++)
                    System.Diagnostics.Debug.Write(FieldData[i * SizeX + j] + " ");
                System.Diagnostics.Debug.WriteLine("");
            }
        }
    }
}