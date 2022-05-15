using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace PasswordTable
{
    public partial class MainForm : Form
    {
        private System.Collections.ArrayList tableRowInArrayList, boolInFormArrayList = new System.Collections.ArrayList();
        private Random random = new Random();
        private int d = 3;
        private bool rowWindowFilling, rowHeaderSizing, ifVerticalScrollBarExists;

        public MainForm()
        {
            InitializeComponent();
            setUp();
        }

        private void initializeBoolInFormArrayList()
        {
            boolInFormArrayList.RemoveRange(0, boolInFormArrayList.Count);
            boolInFormArrayList.Add(dataGridView1.AllowUserToAddRows);
            boolInFormArrayList.Add(dataGridView1.AllowUserToResizeRows);
            boolInFormArrayList.Add(dataGridView1.AllowUserToResizeColumns);
            boolInFormArrayList.Add(rowHeaderSizing);
            boolInFormArrayList.Add(rowWindowFilling);
            boolInFormArrayList.Add(dataGridView1.RowHeadersVisible);
        }

        private void updateAndWrite(System.IO.StreamWriter streamWriter)
        {
            initializeBoolInFormArrayList();
            streamWriter.Write("SetUp;");
            for (int i = 0; i < boolInFormArrayList.Count; i++)
            {
                streamWriter.Write(getArrayListElementBool(i).ToString() + ";");
            }
        }

        private void writeColumns(System.IO.StreamWriter streamWriter)
        {
            foreach (DataGridViewTextBoxColumn column in dataGridView1.Columns)
            {
                streamWriter.Write(column.HeaderText + "|");
            }
            streamWriter.WriteLine();
        }

        private void setUp()
        {
            initializeBoolInFormArrayList();
            int boolArrayLength = boolInFormArrayList.Count;
            boolInFormArrayList.RemoveRange(0, boolArrayLength);
            string[] array = Application.StartupPath.ToString().Split('\\');
            if (array[array.Length - 1].Equals("PasswordTable"))
            {
                encode(Application.StartupPath.ToString() + "\\TableMainForm.txt", 0);
                System.IO.StreamReader streamReader = new System.IO.StreamReader(Application.StartupPath.ToString() + "\\TableMainForm.txt");
                string currentRow = streamReader.ReadLine();
                while (!streamReader.EndOfStream)
                {
                    currentRow = streamReader.ReadLine(); 
                }
                string[] currentRowArray = currentRow.Split(';');
                if (currentRowArray[0] == "SetUp")
                {
                    for (int i = 1; i < boolArrayLength + 1; i++)
                    {
                        if (currentRowArray[i] == "True")
                        {
                            boolInFormArrayList.Add(true);
                        }
                        else
                        {
                            boolInFormArrayList.Add(false); 
                        }
                    }
                }
                updateValuesBool();
                streamReader.Close();
            }
        }

        private void autoSize(bool addColumn, bool anyWidth) //метод для автоматического выставление размеров таблицы
        {
            int tableWidth;
            if (addColumn) //если addColumn = true, то добавляем колонку и подстраиваем размеры
            {
                dataGridView1.ColumnCount += 1; //добавление колонку
                
            }
            if ((dataGridView1.ScrollBars & ScrollBars.Vertical) != ScrollBars.None)
            {
                ifVerticalScrollBarExists = true;
            }
            if (!anyWidth)
            {
                if (dataGridView1.RowHeadersVisible) //проверка, включил ли пользователь указатель строки и выравнивание столбов взависимости от этого
                {
                    tableWidth = 59;
                    for (int i = 0; i < dataGridView1.ColumnCount; i++) //выставление одинаковой ширины для всех колонок
                    {
                        dataGridView1.Columns[i].Width = (int)760 / dataGridView1.ColumnCount;
                        tableWidth += dataGridView1.Columns[i].Width;
                    }
                    this.Width = tableWidth; //присвоение форме ширины таблицы + некоторое определённое количество пикселей, чтобы она идеально умещалась на экране, а пользователь ничего не замечал
                }
                else {
                    tableWidth = 19;
                    for (int i = 0; i < dataGridView1.ColumnCount; i++) //выставление одинаковой ширины для всех колонок
                    {
                        dataGridView1.Columns[i].Width = (int) 801 / dataGridView1.ColumnCount;
                        tableWidth += dataGridView1.Columns[i].Width;
                    }
                    this.Width = tableWidth; //присвоение форме ширины таблицы + некоторое определённое количество пикселей, чтобы она идеально умещалась на экране, а пользователь ничего не замечал
                }
            }else
            {
                if (dataGridView1.RowHeadersVisible) //проверка, включил ли пользователь указатель строки и выравнивание столбов взависимости от этого
                {
                    tableWidth = 59;
                    for (int i = 0; i < dataGridView1.ColumnCount; i++) //выставление одинаковой ширины для всех колонок
                    {
                        dataGridView1.Columns[i].Width = (int) (this.Width - 59) / dataGridView1.ColumnCount;
                        tableWidth += dataGridView1.Columns[i].Width;
                    }
                    this.Width = tableWidth; //присвоение форме ширины таблицы + некоторое определённое количество пикселей, чтобы она идеально умещалась на экране, а пользователь ничего не замечал
                }
                else
                {
                    tableWidth = 19;
                    for (int i = 0; i < dataGridView1.ColumnCount; i++) //выставление одинаковой ширины для всех колонок
                    {
                        dataGridView1.Columns[i].Width = (int) (this.Width - 18) / dataGridView1.ColumnCount;
                        tableWidth += dataGridView1.Columns[i].Width;
                    }
                    this.Width = tableWidth; //присвоение форме ширины таблицы + некоторое определённое количество пикселей, чтобы она идеально умещалась на экране, а пользователь ничего не замечал
                }
            }
            
        }

        private char addRandomSymbol(int i) //метод для получения рандомного символа по цифре кода
        {
            switch (i)
            {
                case 1: return 'a';
                case 2: return '?';
                case 3: return 'h';
                case 4: return 't';
                case 5: return '.';
                case 6: return 'b';
                case 7: return 'f';
                case 8: return ')';
                case 9: return 'q';
                default: return 'e';
            }
        }

        private void switchPlacesAll(System.Collections.ArrayList tableRowInArrayList, int a, int b, int c) //метод для перемены местами символов в кодируемой строке
        {
            switchPlaces(tableRowInArrayList, a); //переменами местами символов по 1-ой цифре трёхзначного кода
            switchPlaces(tableRowInArrayList, b); //переменами местами символов по 2-ой цифре трёхзначного кода
            switchPlaces(tableRowInArrayList, c); //переменами местами символов по 3-ой цифре трёхзначного кода
        }

        private void switchPlaces(System.Collections.ArrayList tableRowInArrayList, int a) //перемена местами символов по цифре а
        {
            char e = 'a';
            bool check = false;
            int index1 = 0, index2 = 0;
            for (int i = 0; i < tableRowInArrayList.Count; i++)
            {
                if ((i % a == 0) && (!check))
                {
                    e = getArrayListElementChar(tableRowInArrayList, i);
                    index1 = i;
                    check = true;
                }
                if ((i % a == 0) && (check) && (i != index1))
                {
                    char f = getArrayListElementChar(tableRowInArrayList, i);
                    index2 = i;
                    check = false;
                    tableRowInArrayList.RemoveAt(index2);
                    tableRowInArrayList.Insert(index2, e);
                    tableRowInArrayList.RemoveAt(index1);
                    tableRowInArrayList.Insert(index1, f);
                }
                if ((i % a == 0) && (!check))
                {
                    e = getArrayListElementChar(tableRowInArrayList, i);
                    index1 = i;
                    check = true;
                }
            }
        }

        private char getArrayListElementChar(System.Collections.ArrayList tableRowInArrayList, int i) //получение элемента ArrayList по id
        {
            object[] array = tableRowInArrayList.ToArray();
            return (char)array[i];
        }

        private bool getArrayListElementBool(int i) //получение элемента ArrayList по id
        {
            object[] array = boolInFormArrayList.ToArray();
            return (bool)array[i];
        }

        private void updateValuesBool()
        {
            ToolStripMenuItem fileItem = (ToolStripMenuItem)menuStrip1.Items[0];
            ToolStripMenuItem settingsItem = (ToolStripMenuItem)fileItem.DropDownItems[2];
            for (int i = 0; i < boolInFormArrayList.Count; i++)
            {
                ((ToolStripMenuItem)settingsItem.DropDownItems[i]).Checked = getArrayListElementBool(i);
            }
        }

        private string getArrayListString(System.Collections.ArrayList tableRowInArrayList) //преобразование char ArrayList в строку
        {
            string outPut = "";
            object[] array = tableRowInArrayList.ToArray();
            for (int i = 0; i < tableRowInArrayList.Count; i++)
            {
                outPut += ((char)array[i]).ToString();
            }
            return outPut;
        }

        private int sumShorts(int[] passwordInIntArrayShort, int i, int k) //изменение цифры трёхзначного кода взависимости от i
        {
            if ((passwordInIntArrayShort[k] + d * i) % 9 != 0)
            {
                return (passwordInIntArrayShort[k] + d * i) % 9;
            }
            else
            {
                return 1;
            }
        }

        private void saveFileToImport(int code) //сохранение и шифрование таблицы в файл, для дальнейшего импорта
        {
            if (code == 0)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string path = saveFileDialog1.FileName + ".txt"; //получения имени файла и добавление к нему расширения
                    int password = 0;
                    int[] passwordInIntArray = new int[6];
                    int[] passwordInIntArrayShort = new int[3];
                    for (int i = 0; i < 6; i++) //рандомная генерация шестизначного кода
                    {
                        passwordInIntArray[i] = random.Next(1, 10);
                        password += (int) Math.Pow(10, 5 - i) * passwordInIntArray[i];
                    }
                    for (int i = 0; i < 3; i++) //генерация трёхзначного кода
                    {
                        if ((passwordInIntArray[i] + passwordInIntArray[5 - i]) % 9 != 0)
                        {
                            passwordInIntArrayShort[i] = (passwordInIntArray[i] + passwordInIntArray[5 - i]) % 9;
                        }
                        else
                        {
                            passwordInIntArrayShort[i] = 1;
                        }
                    }
                    System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(path);
                    writeColumns(streamWriter);
                    string[] tableRow = new string[dataGridView1.Columns.Count]; //создание массива, содержащего в себе значения ячеек
                    for (int i = 0; i < dataGridView1.Rows.Count; i++) //цикл, осуществляющий шифрование и запись в файл таблицы
                    {
                        if ((string)dataGridView1.Rows[i].Cells[0].Value != null)
                        {
                            streamWriter.Write((string)dataGridView1.Rows[i].Cells[0].Value + "|"); //запись первой ячейки в файл без шифровки, т.к. она является названием сервиса, посему её можно использовать для расшифровки кода
                        }
                        else
                        {
                            streamWriter.Write("----|"); //запись первой ячейки в файл без шифровки, т.к. она является названием сервиса, посему её можно использовать для расшифровки кода
                        }
                        for (int j = 1; j < dataGridView1.Columns.Count; j++)
                        {
                            dataGridView1.Rows[i].Cells[j].ReadOnly = true; //закрытие доступа к ячейке, чтобы сохранить её, если её до активации метода редактировал пользователь и не вышел с режима редактирования
                            tableRow[j] = (string)dataGridView1.Rows[i].Cells[j].Value;
                            dataGridView1.Rows[i].Cells[j].ReadOnly = false; //открытие доступа к ячейке
                            try
                            { //конструкция try-catch на случай если ячейка пустая
                                tableRowInArrayList = new System.Collections.ArrayList();
                                for (int z = 0; z < tableRow[j].Length; z++) //цикл переводящий string в ArrayList из char
                                {
                                    tableRowInArrayList.Add(tableRow[j][z]);
                                }
                                for (int z = 0; z < 6; z++) //цикл, который подставляет в строку рандомные символы для её шифровки
                                {
                                    if (passwordInIntArray[5 - z] < tableRowInArrayList.Count)
                                    {
                                        tableRowInArrayList.Insert(passwordInIntArray[5 - z], addRandomSymbol(sumShorts(passwordInIntArray, z, i)));
                                    }
                                    else
                                    {
                                        tableRowInArrayList.Insert(tableRowInArrayList.Count, addRandomSymbol(passwordInIntArray[z]));
                                    }
                                }
                                switchPlacesAll(tableRowInArrayList, sumShorts(passwordInIntArrayShort, j, 0), sumShorts(passwordInIntArrayShort, j, 1), sumShorts(passwordInIntArrayShort, j, 2)); //вызов метода, меняющего символы в строке местами
                                String outPut = getArrayListString(tableRowInArrayList); //получение строки с помощью метода, т.к. дефолтный ToString() не работает
                                streamWriter.Write(outPut + "|"); //запись try-catch в файл
                            }
                            catch (NullReferenceException e)
                            {
                                streamWriter.Write("----|"); //вывод ----, т.к. ячейка пустая и вернула NullReferenceException
                            }
                        }
                        streamWriter.WriteLine(""); //переход на следующую строку в файле
                    }
                    streamWriter.Close();
                    EncryptingPasswordForm form = new EncryptingPasswordForm(password); //создание формы, которая позволит пользователю скопировать пароль и передача пароля внутрь её
                    form.ShowDialog(); //вызов формы, показывающей пользователю пароль
                }else
                {
                    MessageBox.Show("При выборе директории произошла ошибка");
                }
            }
            else
            {
                string appPath = Application.StartupPath.ToString();
                string[] array = appPath.Split('\\');
                string path;
                if (!array[array.Length - 1].Equals("PasswordTable"))
                {
                    System.IO.Directory.CreateDirectory(appPath + "\\PasswordTable");
                    System.IO.File.Move(Application.ExecutablePath, appPath + "\\PasswordTable\\PasswordTable.exe");
                    path = appPath + "\\PasswordTable\\TableMainForm.txt"; //получения имени файла и добавление к нему расширения
                }
                else
                {
                    path = appPath + "\\TableMainForm.txt"; //получения имени файла и добавление к нему расширения
                }
                int[] passwordInIntArray = new int[6];
                int[] passwordInIntArrayShort = new int[3];
                for (int i = 0; i < 6; i++) //рандомная генерация шестизначного кода
                {
                    passwordInIntArray[i] = (int) ((code / (int) Math.Pow(10, 5 - i)) % 10);
                }
                for (int i = 0; i < 3; i++) //генерация трёхзначного кода
                {
                    if ((passwordInIntArray[i] + passwordInIntArray[5 - i]) % 9 != 0)
                    {
                        passwordInIntArrayShort[i] = (passwordInIntArray[i] + passwordInIntArray[5 - i]) % 9;
                    }
                    else
                    {
                        passwordInIntArrayShort[i] = 1;
                    }
                }
                System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(path, false);
                writeColumns(streamWriter);
                string[] tableRow = new string[dataGridView1.Columns.Count]; //создание массива, содержащего в себе значения ячеек
                for (int i = 0; i < dataGridView1.Rows.Count; i++) //цикл, осуществляющий шифрование и запись в файл таблицы
                {
                    if ((string)dataGridView1.Rows[i].Cells[0].Value != null)
                    {
                        streamWriter.Write((string)dataGridView1.Rows[i].Cells[0].Value + "|"); //запись первой ячейки в файл без шифровки, т.к. она является названием сервиса, посему её можно использовать для расшифровки кода
                    }
                    else
                    {
                        streamWriter.Write("----|");
                    }
                    for (int j = 1; j < dataGridView1.Columns.Count; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].ReadOnly = true; //закрытие доступа к ячейке, чтобы сохранить её, если её до активации метода редактировал пользователь и не вышел с режима редактирования
                        tableRow[j] = (string)dataGridView1.Rows[i].Cells[j].Value;
                        dataGridView1.Rows[i].Cells[j].ReadOnly = false; //открытие доступа к ячейке
                        try
                        { //конструкция try-catch на случай если ячейка пустая
                            tableRowInArrayList = new System.Collections.ArrayList();
                            for (int z = 0; z < tableRow[j].Length; z++) //цикл переводящий string в ArrayList из char
                            {
                                tableRowInArrayList.Add(tableRow[j][z]);
                            }
                            
                            for (int z = 0; z < 6; z++) //цикл, который подставляет в строку рандомные символы для её шифровки
                            {
                                if (passwordInIntArray[5 - z] < tableRowInArrayList.Count)
                                {
                                    tableRowInArrayList.Insert(passwordInIntArray[5 - z], addRandomSymbol(sumShorts(passwordInIntArray, z, i)));
                                }else
                                {
                                    tableRowInArrayList.Insert(tableRowInArrayList.Count, addRandomSymbol(passwordInIntArray[z]));
                                }
                            }
                            switchPlacesAll(tableRowInArrayList, sumShorts(passwordInIntArrayShort, j, 0), sumShorts(passwordInIntArrayShort, j, 1), sumShorts(passwordInIntArrayShort, j, 2)); //вызов метода, меняющего символы в строке местами
                            String outPut = getArrayListString(tableRowInArrayList); //получение строки с помощью метода, т.к. дефолтный ToString() не работает
                            streamWriter.Write(outPut + "|"); //запись try-catch в файл
                        }
                        catch (NullReferenceException e)
                        {
                            streamWriter.Write("----|"); //вывод ----, т.к. ячейка пустая и вернула NullReferenceException
                        }
                    }
                    streamWriter.WriteLine(""); //переход на следующую строку в файле
                }
                updateAndWrite(streamWriter);
                streamWriter.Close();
            }
        }

        private void initializeColumns(System.IO.StreamReader streamReader)
        {
            string columnRow = streamReader.ReadLine();
            string[] columns = columnRow.Split('|');
            dataGridView1.Columns.Clear();
            for (int i = 0; i < columns.Length - 1; i++)
            {
                dataGridView1.Columns.Add("Column" + i.ToString(), columns[i]);
            }
            autoSize(false, true);
        }

        private void encode(string path, int code)
        {
            if (code == 0)
            {
                int[] passwordInIntArray = new int[6];
                int[] passwordInIntArrayShort = new int[3];
                for (int i = 0; i < 6; i++)
                {
                    passwordInIntArray[i] = (int) ((664175 / (int)Math.Pow(10, 5 - i)) % 10);
                }
                for (int i = 0; i < 3; i++) //генерация трёхзначного кода
                {
                    if ((passwordInIntArray[i] + passwordInIntArray[5 - i]) % 9 != 0)
                    {
                        passwordInIntArrayShort[i] = (passwordInIntArray[i] + passwordInIntArray[5 - i]) % 9;
                    }
                    else
                    {
                        passwordInIntArrayShort[i] = 1;
                    }
                }
                System.IO.StreamReader streamReader = new System.IO.StreamReader(path);
                initializeColumns(streamReader);
                int index = 0;
                string currentRow = streamReader.ReadLine();
                while (!streamReader.EndOfStream)
                {
                    string[] currentRowInArray = currentRow.Split('|');
                    dataGridView1.Rows.Add();
                    for (int i = 1; i < currentRowInArray.Length - 1; i++)
                    {
                        if (currentRowInArray[0] != "----")
                        {
                            dataGridView1.Rows[index].Cells[0].Value = currentRowInArray[0];
                        }
                        if (currentRowInArray[i] != "----")
                        {
                            string finalString = "";
                            System.Collections.ArrayList currentCellInArrayList = new System.Collections.ArrayList();
                            for (int j = 0; j < currentRowInArray[i].Length; j++)
                            {
                                currentCellInArrayList.Add(currentRowInArray[i][j]);
                            }
                            unswitchPlacesAll(currentCellInArrayList, sumShorts(passwordInIntArrayShort, i, 0), sumShorts(passwordInIntArrayShort, i, 1), sumShorts(passwordInIntArrayShort, i, 2));
                            for (int j = 5; j >= 0; j--)
                            {
                                if (passwordInIntArray[5 - j] < currentCellInArrayList.Count)
                                {
                                    currentCellInArrayList.RemoveAt(passwordInIntArray[5 - j]);
                                }
                                else
                                {
                                    currentCellInArrayList.RemoveAt(currentCellInArrayList.Count - 1);
                                }
                            }
                            finalString = getArrayListString(currentCellInArrayList);
                            dataGridView1.Rows[index].Cells[i].Value = finalString;
                        }
                    }
                    index++;
                    currentRow = streamReader.ReadLine();
                }
                streamReader.Close();
            }else
            {
                int[] passwordInIntArray = new int[6];
                int[] passwordInIntArrayShort = new int[3];
                for (int i = 0; i < 6; i++)
                {
                    passwordInIntArray[i] = (int)((code / (int)Math.Pow(10, 5 - i)) % 10);
                }
                for (int i = 0; i < 3; i++) //генерация трёхзначного кода
                {
                    if ((passwordInIntArray[i] + passwordInIntArray[5 - i]) % 9 != 0)
                    {
                        passwordInIntArrayShort[i] = (passwordInIntArray[i] + passwordInIntArray[5 - i]) % 9;
                    }
                    else
                    {
                        passwordInIntArrayShort[i] = 1;
                    }
                }
                System.IO.StreamReader streamReader = new System.IO.StreamReader(path);
                initializeColumns(streamReader);
                int index = 0;
                string currentRow = streamReader.ReadLine();
                string[] currentRowInArray;
                while (!streamReader.EndOfStream)
                {
                    currentRowInArray = currentRow.Split('|');
                    dataGridView1.Rows.Add();
                    for (int i = 1; i < currentRowInArray.Length - 1; i++)
                    {
                        if (currentRowInArray[0] != "----")
                        {
                            dataGridView1.Rows[index].Cells[0].Value = currentRowInArray[0];
                        }
                        if (currentRowInArray[i] != "----")
                        {
                            string finalString = "";
                            System.Collections.ArrayList currentCellInArrayList = new System.Collections.ArrayList();
                            for (int j = 0; j < currentRowInArray[i].Length; j++)
                            {
                                currentCellInArrayList.Add(currentRowInArray[i][j]);
                            }
                            unswitchPlacesAll(currentCellInArrayList, sumShorts(passwordInIntArrayShort, i, 0), sumShorts(passwordInIntArrayShort, i, 1), sumShorts(passwordInIntArrayShort, i, 2));
                            for (int j = 5; j >= 0; j--)
                            {
                                if (passwordInIntArray[5 - j] < currentCellInArrayList.Count)
                                {
                                    currentCellInArrayList.RemoveAt(passwordInIntArray[5 - j]);
                                }
                                else
                                {
                                    currentCellInArrayList.RemoveAt(currentCellInArrayList.Count - 1);
                                }
                            }
                            finalString = getArrayListString(currentCellInArrayList);
                            dataGridView1.Rows[index].Cells[i].Value = finalString;
                        }
                    }
                    index++;
                    currentRow = streamReader.ReadLine();
                }
                currentRowInArray = currentRow.Split('|');
                dataGridView1.Rows.Add();
                for (int i = 1; i < currentRowInArray.Length - 1; i++)
                {
                    if (currentRowInArray[0] != "----")
                    {
                        dataGridView1.Rows[index].Cells[0].Value = currentRowInArray[0];
                    }
                    if (currentRowInArray[i] != "----")
                    {
                        string finalString = "";
                        System.Collections.ArrayList currentCellInArrayList = new System.Collections.ArrayList();
                        for (int j = 0; j < currentRowInArray[i].Length; j++)
                        {
                            currentCellInArrayList.Add(currentRowInArray[i][j]);
                        }
                        unswitchPlacesAll(currentCellInArrayList, sumShorts(passwordInIntArrayShort, i, 0), sumShorts(passwordInIntArrayShort, i, 1), sumShorts(passwordInIntArrayShort, i, 2));
                        for (int j = 5; j >= 0; j--)
                        {
                            if (passwordInIntArray[5 - j] < currentCellInArrayList.Count)
                            {
                                currentCellInArrayList.RemoveAt(passwordInIntArray[5 - j]);
                            }
                            else
                            {
                                currentCellInArrayList.RemoveAt(currentCellInArrayList.Count - 1);
                            }
                        }
                        finalString = getArrayListString(currentCellInArrayList);
                        dataGridView1.Rows[index].Cells[i].Value = finalString;
                    }
                }
                streamReader.Close();
            }
            
        }
        private void unswitchPlacesAll(System.Collections.ArrayList currentCellInArrayList, int a, int b, int c)
        {
            unswitchPlaces(currentCellInArrayList, c);
            unswitchPlaces(currentCellInArrayList, b);
            unswitchPlaces(currentCellInArrayList, a);
        }

        private void unswitchPlaces(System.Collections.ArrayList currentCellInArrayList, int a)
        {
            char e = 'a';
            bool check = false;
            int index1 = 0, index2 = 0;
            for (int i = currentCellInArrayList.Count - 1; i >= 0; i--)
            {
                if ((i % a == 0) && (!check))
                {
                    e = getArrayListElementChar(currentCellInArrayList, i);
                    index1 = i;
                    check = true;
                }
                if ((i % a == 0) && (check) && (i != index1))
                {
                    char f = getArrayListElementChar(currentCellInArrayList, i);
                    index2 = i;
                    check = false;
                    currentCellInArrayList.RemoveAt(index2);
                    currentCellInArrayList.Insert(index2, e);
                    currentCellInArrayList.RemoveAt(index1);
                    currentCellInArrayList.Insert(index1, f);
                    
                }
                if ((i % a == 0) && (!check))
                {
                    e = getArrayListElementChar(currentCellInArrayList, i);
                    index1 = i;
                    check = true;
                }
            }
        }

        private void добавитьСтолбецToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColumnChangingNameForm columnChangingNameForm = new ColumnChangingNameForm();
            DialogResult dialogResult = columnChangingNameForm.ShowDialog(); //вызов формы, позволяющей пользователю ввести название таблицы
            if (dialogResult != DialogResult.Cancel)
            {
                autoSize(true, true); //вызов метода AutoSize(), который создаёт новую колонну и автоматически выравнивает столбцы
                dataGridView1.Columns[dataGridView1.ColumnCount - 1].HeaderText = ColumnNameData.columnName; //присвоение имени созданной таблице
            }
            ColumnNameData.nullValues(); //обнуление переменных в классе ColumnNameData для дальнейшего его использования и безопасности
        }

        private void добавитьСтрокуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rowWindowFilling) //проверка, включил ли пользователь заполнение строки с помощью формы
            {
                RowChangingNameForm rowChangingNameForm = new RowChangingNameForm();
                DialogResult dialogResult = rowChangingNameForm.ShowDialog(); //вызов формы, позволяющей пользователю ввести данные строки
                if (dialogResult != DialogResult.Cancel)
                {
                    dataGridView1.Rows.Add(RowNameData.service, RowNameData.login, RowNameData.password, RowNameData.rCode); //добавление строки с полученными данными
                }
                RowNameData.nullValues(); //обнуление переменных в классе RowNameData для дальнейшего его использования и безопасности
            }
            else
            {
                dataGridView1.Rows.Add(); //добавление пустого ряда
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsUserSure form = new IsUserSure("Вы уверены, что хотите закрыть программу?");
            if (form.ShowDialog() == DialogResult.OK)
            {
                saveFileToImport(664175);
            }else
            {
                e.Cancel = true;
            }
        }

        private void разрешитьДобавлениеСтрокToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = ((ToolStripMenuItem)sender).Checked; //присвоение переменной типа bool значения кнопки menuStrip1 т.к. включено изменение статуса Checked по клику пользователя
        }

        private void разрешитьИзменениеРазмеровСтрокиToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToResizeRows = ((ToolStripMenuItem)sender).Checked; //присвоение переменной типа bool значения кнопки menuStrip1 т.к. включено изменение статуса Checked по клику пользователя
        }

        private void разрешитьИзменениеРазмеровСтолбцаToolStripMenuItem_CheckStateChanged_1(object sender, EventArgs e)
        {
            rowWindowFilling = ((ToolStripMenuItem)sender).Checked; //присвоение переменной типа bool значения кнопки menuStrip1 т.к. включено изменение статуса Checked по клику пользователя
        }

        private void hfToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            rowHeaderSizing = ((ToolStripMenuItem)sender).Checked;
            if (rowHeaderSizing) //проверка, включил ли пользователь изменение размеров указателя строки
            {
                dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            }
            else
            {
                dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            }
        }

        private void включитьЗаполнениеСтрокиВОкнеToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            rowWindowFilling = ((ToolStripMenuItem)sender).Checked; //присвоение переменной типа bool значения кнопки menuStrip1 т.к. включено изменение статуса Checked по клику пользователя
        }

        private void включитьУказательСтрокиToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            dataGridView1.RowHeadersVisible = ((ToolStripMenuItem)sender).Checked; //присвоение переменной типа bool значения кнопки menuStrip1 т.к. включено изменение статуса Checked по клику пользователя
            autoSize(false, true); //вызов метода AutoSize(), для выравнивания столбоцов (метод не создаёт новую колонку, т.к. в него был передан параметр false 
        }

        private void разрешитьИзменениеРазмеровСтолбцаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToResizeColumns = ((ToolStripMenuItem)sender).Checked;
        }

        private void импортироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportCodeForm form = new ImportCodeForm();
            try
            {
                DialogResult dialogResult = form.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    encode(ImportPasswordData.path, ImportPasswordData.password);
                }else if (dialogResult != DialogResult.Cancel)
                {
                    MessageBox.Show("При при ввод пароля произошла ошибка");
                }
                ImportPasswordData.nullValues();
            }catch (Exception)
            {
                MessageBox.Show("Ошибка при открытии формы");
            }
        }

        private void удалитьСтолбецToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColumnDeletingForm form = new ColumnDeletingForm(dataGridView1.Columns);
            DialogResult dialogResult = form.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                dataGridView1.Columns.RemoveAt(ColumnDeletingData.idOfTheColumn);
            }else
            {
                if (dialogResult != DialogResult.Cancel)
                {
                    MessageBox.Show("При выборе удаляемого элемента произошла ошибка");
                }
            }
            autoSize(false, true);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            autoSize(false, true);
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Выберите директорию для сохранения файла");
            saveFileToImport(0); //вызов метода, который сохраняет таблицу для импорта и показывает пользователю пароль
        }

        private void вернутьТаблицуВИсходноеСостояниеToolStripMenuItem_Click(object sender, EventArgs e) //метод, возвращающий таблицу в исходное состояние
        {
            dataGridView1.RowHeadersWidth = 41;
            dataGridView1.Height = 489;
            autoSize(false, false); //вызов метода AutoSize(), для выравнивания столбоцов (метод не создаёт новую колонку, т.к. в него был передан параметр false
        }
    }
}