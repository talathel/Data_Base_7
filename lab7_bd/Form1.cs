using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using FirebirdSql.Data.FirebirdClient;

namespace lab7_bd
{
    public partial class Form1 : Form
    {
        OleDbConnection cn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""C:\DataBase\database.accdb"";");

        public Form1()
        {
            InitializeComponent();
        }
        private List<string[]> getTable(string commandStr)
        {
            List<string[]> res = new List<string[]>();
            cn.Open();
            try
            {

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText = commandStr;
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        string[] temp = new string[rd.FieldCount];
                        for (int i = 0; i < rd.FieldCount; i++)
                        {
                            temp[i]=(rd[i].ToString());
                        }
                        res.Add(temp);
                    }
                }


            }
            
            catch (System.Data.OleDb.OleDbException ex)
            {
                MessageBox.Show(ex.ToString(),"Ошибка");
            }
            finally
            {
                cn.Close();
            }

            return res;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("НомерАвтобуса", "НомерАвтобуса");
            dataGridView1.Columns.Add("КоличествоМест", "КоличествоМест");
            dataGridView1.Columns.Add("СрокЭксплуатации", "СрокЭксплуатации");

            foreach (var i in getTable("SELECT * FROM Автобус"))
            {
                dataGridView1.Rows.Add(i);
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("НомерАвтовокзала", "НомерАвтовокзала");
            dataGridView1.Columns.Add("Город", "Город");
            dataGridView1.Columns.Add("Телефон", "Телефон");
          
            foreach (var i in getTable("SELECT * FROM Автовокзал"))
            {
                dataGridView1.Rows.Add(i);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("НомерБилета", "НомерБилета");
            dataGridView1.Columns.Add("Дата", "Дата");
            dataGridView1.Columns.Add("НомерРейса", "НомерРейса");
            dataGridView1.Columns.Add("ТабельныйНомер", "ТабельныйНомер");
            dataGridView1.Columns.Add("НомерАвтовокзала", "НомерАвтовокзала");
            dataGridView1.Columns.Add("НомерАвтобуса", "НомерАвтобуса");

            foreach (var i in getTable("SELECT * FROM Билет"))
            {
                dataGridView1.Rows.Add(i);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("ТабельныйНомер", "ТабельныйНомер");
            dataGridView1.Columns.Add("Фамилия", "Фамилия");
            dataGridView1.Columns.Add("Имя", "Имя");
            dataGridView1.Columns.Add("Отчество", "Отчество");
            dataGridView1.Columns.Add("ДатаРождения", "ДатаРождения");
            dataGridView1.Columns.Add("ПаспортныеДанные", "ПаспортныеДанные");
            dataGridView1.Columns.Add("Права", "Права");
            dataGridView1.Columns.Add("ИНН", "ИНН");
            dataGridView1.Columns.Add("Стаж", "Стаж");

            foreach (var i in getTable("SELECT * FROM Водитель"))
            {
                dataGridView1.Rows.Add(i);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("НазваниеОстановки", "НазваниеОстановки");
            dataGridView1.Columns.Add("Координаты", "Координаты");
            dataGridView1.Columns.Add("ПорядковыйНомер", "ПорядковыйНомер");
            dataGridView1.Columns.Add("НомерРейса", "НомерРейса");

            foreach (var i in getTable("SELECT * FROM Остановки"))
            {
                dataGridView1.Rows.Add(i);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("НомерРейса", "НомерРейса");
            dataGridView1.Columns.Add("ПунктНазначения", "ПунктНазначения");
            dataGridView1.Columns.Add("ВремяОтправления", "ВремяОтправления");
            dataGridView1.Columns.Add("ВремяПрибытия", "ВремяПрибытия");
            dataGridView1.Columns.Add("ТабельныйНомер", "ТабельныйНомер");
            dataGridView1.Columns.Add("НомерАвтовокзала", "НомерАвтовокзала");
            dataGridView1.Columns.Add("НомерАвтобуса", "НомерАвтобуса");

            foreach (var i in getTable("SELECT * FROM Рейс"))
            {
                dataGridView1.Rows.Add(i);
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("НазваниеОстановки", "НазваниеОстановки");
            dataGridView1.Columns.Add("Координаты", "Координаты");
            dataGridView1.Columns.Add("ПорядковыйНомер", "ПорядковыйНомер");
            dataGridView1.Columns.Add("НомерРейса", "НомерРейса");

            if (int.TryParse(textBox1.Text,out int id))
            {
                getTable("DELETE * FROM Остановки WHERE[ПорядковыйНомер] =" + id.ToString());
                foreach (var i in getTable("SELECT * FROM Остановки"))
                {
                    dataGridView1.Rows.Add(i);
                }
            }
            else
            {
                MessageBox.Show("Id должен быть числом","Ошибка");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("НазваниеОстановки", "НазваниеОстановки");
            dataGridView1.Columns.Add("Координаты", "Координаты");
            dataGridView1.Columns.Add("ПорядковыйНомер", "ПорядковыйНомер");
            dataGridView1.Columns.Add("НомерРейса", "НомерРейса");
            if (int.TryParse(textBox2.Text, out int id))
            {
                getTable("INSERT INTO Остановки VALUES('Город N', 'Там, не знаю где', " + id.ToString() + ", '410')");
                foreach (var i in getTable("SELECT * FROM Остановки"))
                {
                    dataGridView1.Rows.Add(i);
                }
            }
            else
            {
                MessageBox.Show("Id должен быть числом", "Ошибка");
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("НазваниеОстановки", "НазваниеОстановки");
            dataGridView1.Columns.Add("Координаты", "Координаты");
            dataGridView1.Columns.Add("ПорядковыйНомер", "ПорядковыйНомер");
            dataGridView1.Columns.Add("НомерРейса", "НомерРейса");
            if (int.TryParse(textBox3.Text, out int id))
            {
                getTable("UPDATE Остановки SET [Координаты] = \""+textBox4.Text+"\" WHERE[ПорядковыйНомер] = "+id.ToString());
                foreach (var i in getTable("SELECT * FROM Остановки"))
                {
                    dataGridView1.Rows.Add(i);
                }
            }
            else
            {
                MessageBox.Show("Id должен быть числом", "Ошибка");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("ТабельныйНомер", "ТабельныйНомер");
            dataGridView1.Columns.Add("Фамилия", "Фамилия");
            dataGridView1.Columns.Add("Имя", "Имя");
            dataGridView1.Columns.Add("Отчество", "Отчество");
            dataGridView1.Columns.Add("ДатаРождения", "ДатаРождения");
            dataGridView1.Columns.Add("ПаспортныеДанные", "ПаспортныеДанные");
            dataGridView1.Columns.Add("Права", "Права");
            dataGridView1.Columns.Add("ИНН", "ИНН");
            dataGridView1.Columns.Add("Стаж", "Стаж");

            foreach (var i in getTable("SELECT * FROM Водитель WHERE(((Водитель.[Стаж]) < All(SELECT AVG([Стаж]) FROM Водитель)))"))
            {
                dataGridView1.Rows.Add(i);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("ТабельныйНомер", "ТабельныйНомер");
            dataGridView1.Columns.Add("Фамилия", "Фамилия");
            dataGridView1.Columns.Add("Имя", "Имя");
            dataGridView1.Columns.Add("Отчество", "Отчество");
            dataGridView1.Columns.Add("ДатаРождения", "ДатаРождения");
            dataGridView1.Columns.Add("ПаспортныеДанные", "ПаспортныеДанные");
            dataGridView1.Columns.Add("Права", "Права");
            dataGridView1.Columns.Add("ИНН", "ИНН");
            dataGridView1.Columns.Add("Стаж", "Стаж");

            foreach (var i in getTable("SELECT * FROM Водитель WHERE ДатаРождения =  ANY (SELECT ДатаРождения FROM Водитель WHERE ДатаРождения > #01/01/1991#);"))
            {
                dataGridView1.Rows.Add(i);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Номер магазина", "Номер магазина");
            dataGridView1.Columns.Add("Название магазина", "Название магазина");
            dataGridView1.Columns.Add("Специализация", "Специализация");
            dataGridView1.Columns.Add("ИНН", "ИНН");
            dataGridView1.Columns.Add("Адрес", "Адрес");
            dataGridView1.Columns.Add("Табельный номер директора", "Табельный номер директора");

            foreach (var i in getTable("SELECT Город, COUNT(*) FROM Автовокзал GROUP BY Город HAVING COUNT(*)>1;"))
            {
                dataGridView1.Rows.Add(i);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("НомерРейса", "НомерРейса");
            dataGridView1.Columns.Add("ПунктНазначения", "ПунктНазначения");
            dataGridView1.Columns.Add("ВремяОтправления", "ВремяОтправления");
            dataGridView1.Columns.Add("ВремяПрибытия", "ВремяПрибытия");
            dataGridView1.Columns.Add("ТабельныйНомер", "ТабельныйНомер");
            dataGridView1.Columns.Add("НомерАвтовокзала", "НомерАвтовокзала");
            dataGridView1.Columns.Add("НомерАвтобуса", "НомерАвтобуса");
            if (int.TryParse(textBox5.Text, out int num))
            {

                foreach (var i in getTable("SELECT * FROM Рейс WHERE ТабельныйНомер = " + num.ToString()))
                {
                    dataGridView1.Rows.Add(i);
                }
            }
            else
            {
                MessageBox.Show("ТабельныйНомер должен быть числом", "Ошибка");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("НомерАвтобуса", "НомерАвтобуса");
            dataGridView1.Columns.Add("КоличествоМест", "КоличествоМест");
            dataGridView1.Columns.Add("СрокЭксплуатации", "СрокЭксплуатации");

            if (int.TryParse(textBox6.Text, out int num))
            {

                foreach (var i in getTable("SELECT * FROM Автобус WHERE (((Автобус.[СрокЭксплуатации])>"  + num.ToString() + ")); ") )
                {
                    dataGridView1.Rows.Add(i);
                }
            }
            else
            {
                MessageBox.Show("Срок эусплуатации должен быть числом", "Ошибка");
            }
        }
        private void button15_Click(object sender, EventArgs e)
        {

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("НомерБилета", "НомерБилета");
            dataGridView1.Columns.Add("Дата", "Дата");
            dataGridView1.Columns.Add("НомерРейса", "НомерРейса");
            dataGridView1.Columns.Add("ТабельныйНомер", "ТабельныйНомер");
            dataGridView1.Columns.Add("НомерАвтовокзала", "НомерАвтовокзала");
            dataGridView1.Columns.Add("НомерАвтобуса", "НомерАвтобуса");
            if (int.TryParse(textBox7.Text, out int num))
            {
                foreach (var i in getTable("SELECT * FROM Билет WHERE Номербилета=" + num.ToString()))
                {
                    dataGridView1.Rows.Add(i);
                }
            }
            else
            {
                MessageBox.Show("Номер билета должен быть числом", "Ошибка");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("", "");
            dataGridView1.Columns.Add("", "");
            dataGridView1.Columns.Add("", "");
            dataGridView1.Columns.Add("", "");
            dataGridView1.Columns.Add("", "");
            dataGridView1.Columns.Add("", "");
            dataGridView1.Columns.Add("", "");
            dataGridView1.Columns.Add("", "");
            dataGridView1.Columns.Add("", "");
            dataGridView1.Columns.Add("", "");
            dataGridView1.Columns.Add("", "");
            dataGridView1.Columns.Add("", "");
            dataGridView1.Columns.Add("", "");
            dataGridView1.Columns.Add("", "");
            dataGridView1.Columns.Add("", "");
            dataGridView1.Columns.Add("", "");
            dataGridView1.Columns.Add("", "");
            foreach (var i in getTable("SELECT * FROM MSysObjects"))
            {
                dataGridView1.Rows.Add(i);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
