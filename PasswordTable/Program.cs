using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordTable
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }

    static class ColumnNameData
    {
        public static string columnName { get; set; }
        public static bool isEmpty { get; set; }
        public static void nullValues()
        {
            ColumnNameData.columnName = "";
            ColumnNameData.isEmpty = true;
        }
    }

    static class RowNameData
    {
        public static string service { get; set; }
        public static string login { get; set; }
        public static string password { get; set; }
        public static string rCode { get; set; }
        public static bool isEmpty { get; set; }
        public static void nullValues()
        {
            RowNameData.service = "";
            RowNameData.login = "";
            RowNameData.password = "";
            RowNameData.rCode = "";
            RowNameData.isEmpty = true;
        }
    }

    static class ImportPasswordData
    {
        public static int password { get; set; }
        public static string path { get; set; }
        public static void nullValues()
        {
            ImportPasswordData.password = 0;
            ImportPasswordData.path = "";
        }
    }

    static class ColumnDeletingData
    {
        public static int idOfTheColumn { get; set; }
        public static void nullValues()
        {
            idOfTheColumn = 0;
        }
    }
}
