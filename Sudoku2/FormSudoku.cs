using Sudoku2.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku2
{
    public partial class FormSudoku : Form
    {
        public FormSudoku()
        {
            InitializeComponent();
        }
        Thread thread1, thread2, thread3, thread4, thread5, thread6 , thread7, thread8, thread9, thread10;
        int counter1 = 0, counter2 = 0, counter3 = 0, counter4 = 0, counter5 = 0, counter6 = 0, counter7 = 0, counter8 = 0, counter9 = 0, counter10;
        string arr_sudoku1 = "", arr_sudoku2 = "", arr_sudoku3 = "", arr_sudoku4 = "", arr_sudoku5 = "", arr_sudoku6 = "", arr_sudoku7 = "", arr_sudoku8 = "", arr_sudoku9 = "", arr_sudoku10 = "";
        string[,] txtSudoku1, txtSudoku2, txtSudoku3, txtSudoku4, txtSudoku5, txtSudoku6, txtSudoku7, txtSudoku8, txtSudoku9, txtSudoku10;
        bool isTurn1 = true, isTurn2 = true, isTurn3 = true, isTurn4 = true, isTurn5 = true, isTurn6 = true, isTurn7 = true, isTurn8 = true, isTurn9 = true, isTurn10 = true;
        ComboData combdata1, combdata2, combdata3, combdata4, combdata5, combdata6, combdata7, combdata8, combdata9, combdata10;
        Stopwatch swatch1, swatch2, swatch3, swatch4, swatch5, swatch6, swatch7, swatch8, swatch9, swatch10;
        StreamWriter sw1, sw2, sw3, sw4, sw5, sw6, sw7, sw8, sw9, sw10;
        DateTime dateStart, dateFinish;
        string[,] dataStrArray1, dataStrArray2, dataStrArray3, dataStrArray4, dataStrArray5, dataStrArray6, dataStrArray7, dataStrArray8, dataStrArray9, dataStrArray10;
        string savePath = "";
        int[,] startArray;
        string startPath;
        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            string index = comboBox6.Text.Replace(".adım", "");
            ChangeLabelsText(combdata6, Convert.ToInt32(index) - 1, 6);
            lblDesc6.Text = combdata6.Desc[Convert.ToInt32(index) - 1];
        }
        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            string index = comboBox7.Text.Replace(".adım", "");
            ChangeLabelsText(combdata7, Convert.ToInt32(index) - 1, 7);
            lblDesc7.Text = combdata7.Desc[Convert.ToInt32(index) - 1];
        }
        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            string index = comboBox8.Text.Replace(".adım", "");
            ChangeLabelsText(combdata8, Convert.ToInt32(index) - 1, 8);
            lblDesc8.Text = combdata8.Desc[Convert.ToInt32(index) - 1];
        }
        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            string index = comboBox9.Text.Replace(".adım", "");
            ChangeLabelsText(combdata9, Convert.ToInt32(index) - 1, 9);
            lblDesc9.Text = combdata9.Desc[Convert.ToInt32(index) - 1];
        }
        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            string index = comboBox10.Text.Replace(".adım", "");
            ChangeLabelsText(combdata10, Convert.ToInt32(index) - 1, 10);
            lblDesc10.Text = combdata10.Desc[Convert.ToInt32(index) - 1];
        }
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string index = comboBox5.Text.Replace(".adım", "");
            ChangeLabelsText(combdata5, Convert.ToInt32(index) - 1, 5);
            lblDesc5.Text = combdata5.Desc[Convert.ToInt32(index) - 1];
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string index = comboBox4.Text.Replace(".adım", "");
            ChangeLabelsText(combdata4, Convert.ToInt32(index) - 1, 4);
            lblDesc4.Text = combdata4.Desc[Convert.ToInt32(index) - 1];
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string index = comboBox3.Text.Replace(".adım", "");
            ChangeLabelsText(combdata3, Convert.ToInt32(index) - 1, 3);
            lblDesc3.Text = combdata3.Desc[Convert.ToInt32(index) - 1];
        }
        private bool SearchCol(int index, int num, int[,] dizi)
        {
            for (int i = 0; i < 9; i++)
            {
                if (dizi[i, index] == num) return false;
            }
            return true;
        }
        private bool SearchRow(int index, int num, int[,] dizi)
        {
            for (int i = 0; i < 9; i++)
            {
                if (dizi[index, i] == num) return false;
            }
            return true;
        }
        private bool SearchBox(int row, int col, int num, int[,] dizi)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (dizi[row - (row % 3) + i, col - (col % 3) + j] == num) return false;
                }
            }
            return true;
        }
        private bool MoveControl(int col, int row, int num, int[,] dizi)
        {
            if (!SearchRow(row, num, dizi)) return false;
            if (!SearchCol(col, num, dizi)) return false;
            if (!SearchBox(row, col, num, dizi)) return false;
            return true;
        }
        private string SolveSudoku(int num, int px, int py, int[,] dizi, ref int sayac, ref string strArr, string fileName, string[,] txtArray, ref bool isTurn, GroupBox gBoxS , int gIndex, ComboData combData)
        {
            if (isTurn)
            {
                sayac++;
                int[,] temp = new int[9, 9];
                Array.Copy(dizi, temp, dizi.Length);
                temp[px, py] = num;
                txtArray[px, py] = num.ToString();
                WriteToFile(txtArray,num.ToString(), px, py, fileName, gIndex);
                //WriteArrayToFile(txtArray, fileName, gIndex);
                SetLabelNum(px, py, num, gBoxS, gIndex);
                combData.Desc.Add(String.Format("x:{0}, y:{1} - {2} eklendi.", (px+1), (py+1), num));
                combData.ArrayLists.Add(temp);
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (temp[i, j] == 0)
                        {
                            for (int k = 1; k <= 9; k++)
                            {
                                if (MoveControl(j, i, k, temp))
                                {
                                    SolveSudoku(k, i, j, temp, ref sayac, ref strArr, fileName, txtArray, ref isTurn, gBoxS, gIndex, combData);
                                }
                            }
                            return null;
                        }
                    }
                }
                strArr = "";
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        int sayi = temp[i, j];
                        if (sayi == 0)
                            strArr += "*";
                        else
                            strArr += sayi.ToString();
                    }
                    strArr += "\n";
                }
                isTurn = false;
                return strArr;
            }
            else
            {
                return null;
            }
        }
        public void SetLabelNum(int px,int py, int num, GroupBox gBoxL, int index)
        {
            foreach(Control c in gBoxL.Controls)
                if(c is Label)
                    if (c.Name == String.Format("t{0}Lbl{1}{2}", index, px, py))
                        c.Text = num.ToString();
        }
        public string GetArrayText(int[,] arr,string startText)
        {
            string aText = startText;
            aText += System.Environment.NewLine;
            aText += "-----------------";
            aText += System.Environment.NewLine;
            for (int i = 0; i < 9; i++)
            {
                aText += System.Environment.NewLine;
                for (int j = 0; j < 9; j++)
                {
                    int k = arr[i, j];
                    if (k == 0)
                        aText += "*";
                    else
                        aText += k.ToString();
                    if (j != 8)
                        aText += "-";
                }
            }
            return aText;
        }
        private string GetFileDirection()
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Txt Files|*.txt";
            if (fd.ShowDialog() == DialogResult.OK)
                return fd.FileName;
            return "NotFound";
        }
        int[,] ExportSudokuFileToArray(string path)
        {
            int[,] arr = new int[9, 9];
            if (path != "NotFound")
            {
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                string fileStr = sr.ReadLine();
                int i = 0, j = 0;
                while (fileStr != null)
                {
                    foreach (char chr in fileStr)
                    {
                        if (chr == '*')
                        {
                            arr_sudoku1 += "*";
                            arr_sudoku2 += "*";
                            arr_sudoku3 += "*";
                            arr_sudoku4 += "*";
                            arr_sudoku5 += "*";
                            arr_sudoku6 += "*";
                            arr_sudoku7 += "*";
                            arr_sudoku8 += "*";
                            arr_sudoku9 += "*";
                            arr_sudoku10 += "*";
                            arr[i, j] = 0;
                        }
                        else
                        {
                            arr[i, j] = Convert.ToInt32(chr - '0');
                            arr_sudoku1 += arr[i, j].ToString();
                            arr_sudoku2 += arr[i, j].ToString();
                            arr_sudoku3 += arr[i, j].ToString();
                            arr_sudoku4 += arr[i, j].ToString();
                            arr_sudoku5 += arr[i, j].ToString();
                            arr_sudoku6 += arr[i, j].ToString();
                            arr_sudoku7 += arr[i, j].ToString();
                            arr_sudoku8 += arr[i, j].ToString();
                            arr_sudoku9 += arr[i, j].ToString();
                            arr_sudoku10 += arr[i, j].ToString();
                        }
                        j++;
                    }
                    i++;
                    j = 0;
                    arr_sudoku1 += "\n";
                    arr_sudoku2 += "\n";
                    arr_sudoku3 += "\n";
                    arr_sudoku4 += "\n";
                    arr_sudoku5 += "\n";
                    arr_sudoku6 += "\n";
                    arr_sudoku7 += "\n";
                    arr_sudoku8 += "\n";
                    arr_sudoku9 += "\n";
                    arr_sudoku10 += "\n";
                    fileStr = sr.ReadLine();
                }
                sr.Close();
                fs.Close();
                return arr;
            }
            return arr;
        }
        public void WriteToFile(string[,] arr, string word, int posX, int posY, string path,int index)
        {
            if (index == 1)
            {
                sw1 = File.AppendText("D:\\qwe1.txt");
                sw1.WriteLine(String.Format("x:{0}, y:{1} pozisyonuna {2} sayısı eklendi...", posX.ToString(), posY.ToString(), word));
                for (int i = 0; i < 9; i++)
                    sw1.WriteLine(String.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}\n\n", arr[i, 0], arr[i, 1], arr[i, 2], arr[i, 3], arr[i, 4], arr[i, 5], arr[i, 6], arr[i, 7], arr[i, 8]));
                sw1.Close();
            }
            if (index == 2)
            {
                sw2 = File.AppendText("D:\\qwe2.txt");
                sw2.WriteLine(String.Format("x:{0}, y:{1} pozisyonuna {2} sayısı eklendi...", posX.ToString(), posY.ToString(), word));
                for (int i = 0; i < 9; i++)
                    sw2.WriteLine(String.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}\n\n", arr[i, 0], arr[i, 1], arr[i, 2], arr[i, 3], arr[i, 4], arr[i, 5], arr[i, 6], arr[i, 7], arr[i, 8]));
                sw2.Close();
            }
            if (index == 3)
            {
                sw3 = File.AppendText("D:\\qwe3.txt");
                sw3.WriteLine(String.Format("x:{0}, y:{1} pozisyonuna {2} sayısı eklendi...", posX.ToString(), posY.ToString(), word));
                for (int i = 0; i < 9; i++)
                    sw3.WriteLine(String.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}\n\n", arr[i, 0], arr[i, 1], arr[i, 2], arr[i, 3], arr[i, 4], arr[i, 5], arr[i, 6], arr[i, 7], arr[i, 8]));
                sw3.Close();
            }
            if (index == 4)
            {
                sw4 = File.AppendText("D:\\qwe4.txt");
                sw4.WriteLine(String.Format("x:{0}, y:{1} pozisyonuna {2} sayısı eklendi...", posX.ToString(), posY.ToString(), word));
                for (int i = 0; i < 9; i++)
                    sw4.WriteLine(String.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}\n\n", arr[i, 0], arr[i, 1], arr[i, 2], arr[i, 3], arr[i, 4], arr[i, 5], arr[i, 6], arr[i, 7], arr[i, 8]));
                sw4.Close();
            }
            if (index == 5)
            {
                sw5 = File.AppendText("D:\\qwe5.txt");
                sw5.WriteLine(String.Format("x:{0}, y:{1} pozisyonuna {2} sayısı eklendi...", posX.ToString(), posY.ToString(), word));
                for (int i = 0; i < 9; i++)
                    sw5.WriteLine(String.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}\n\n", arr[i, 0], arr[i, 1], arr[i, 2], arr[i, 3], arr[i, 4], arr[i, 5], arr[i, 6], arr[i, 7], arr[i, 8]));
                sw5.Close();
            }
            if (index == 6)
            {
                sw6 = File.AppendText("D:\\qwe6.txt");
                sw6.WriteLine(String.Format("x:{0}, y:{1} pozisyonuna {2} sayısı eklendi...", posX.ToString(), posY.ToString(), word));
                for (int i = 0; i < 9; i++)
                    sw6.WriteLine(String.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}\n\n", arr[i, 0], arr[i, 1], arr[i, 2], arr[i, 3], arr[i, 4], arr[i, 5], arr[i, 6], arr[i, 7], arr[i, 8]));
                sw6.Close();
            }
            if (index == 7)
            {
                sw7 = File.AppendText("D:\\qwe7.txt");
                sw7.WriteLine(String.Format("x:{0}, y:{1} pozisyonuna {2} sayısı eklendi...", posX.ToString(), posY.ToString(), word));
                for (int i = 0; i < 9; i++)
                    sw7.WriteLine(String.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}\n\n", arr[i, 0], arr[i, 1], arr[i, 2], arr[i, 3], arr[i, 4], arr[i, 5], arr[i, 6], arr[i, 7], arr[i, 8]));
                sw7.Close();
            }
            if (index == 8)
            {
                sw8 = File.AppendText("D:\\qwe8.txt");
                sw8.WriteLine(String.Format("x:{0}, y:{1} pozisyonuna {2} sayısı eklendi...", posX.ToString(), posY.ToString(), word));
                for (int i = 0; i < 9; i++)
                    sw8.WriteLine(String.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}\n\n", arr[i, 0], arr[i, 1], arr[i, 2], arr[i, 3], arr[i, 4], arr[i, 5], arr[i, 6], arr[i, 7], arr[i, 8]));
                sw8.Close();
            }
            if (index == 9)
            {
                sw9 = File.AppendText("D:\\qwe9.txt");
                sw9.WriteLine(String.Format("x:{0}, y:{1} pozisyonuna {2} sayısı eklendi...", posX.ToString(), posY.ToString(), word));
                for (int i = 0; i < 9; i++)
                    sw9.WriteLine(String.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}\n\n", arr[i, 0], arr[i, 1], arr[i, 2], arr[i, 3], arr[i, 4], arr[i, 5], arr[i, 6], arr[i, 7], arr[i, 8]));
                sw9.Close();
            }
            if (index == 10)
            {
                sw10 = File.AppendText("D:\\qwe10.txt");
                sw10.WriteLine(String.Format("x:{0}, y:{1} pozisyonuna {2} sayısı eklendi...", posX.ToString(), posY.ToString(), word));
                for (int i = 0; i < 9; i++)
                    sw10.WriteLine(String.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}\n\n", arr[i, 0], arr[i, 1], arr[i, 2], arr[i, 3], arr[i, 4], arr[i, 5], arr[i, 6], arr[i, 7], arr[i, 8]));
                sw10.Close();
            }
            //StreamWriter sw;
            //sw = File.AppendText("D:\\" + path + ".txt");
            //////sw = File.AppendText(savePath + "\\sudokuCozumu" + index.ToString() + ".txt");
            //sw.WriteLine(String.Format("x:{0}, y:{1} pozisyonuna {2} sayısı eklendi...", posX.ToString(), posY.ToString(), word));
            //for (int i = 0; i < 9; i++)
            //    sw.WriteLine(String.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}\n\n", arr[i, 0], arr[i, 1], arr[i, 2], arr[i, 3], arr[i, 4], arr[i, 5], arr[i, 6], arr[i, 7], arr[i, 8]));
            //sw.Close();
        }
        public void WriteArrayToFile(string[,] arr, string path, int index)
        {
            StreamWriter sw;
            sw = File.AppendText("D:\\" + path + ".txt");
            //sw = File.AppendText(savePath + "\\sudokuCozumu" + index.ToString() + ".txt");
            for (int i = 0; i < 9; i++)
                sw.WriteLine(String.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}\n\n", arr[i, 0], arr[i, 1], arr[i, 2], arr[i, 3], arr[i, 4], arr[i, 5], arr[i, 6], arr[i, 7], arr[i, 8]));
            sw.Close();

        }
        public void ClearTxtFile()
        {
            StreamWriter sw1;
            sw1 = File.AppendText(savePath + "\\sudokuCozumu" + (1).ToString() + ".txt");
            sw1.Write("");
            sw1.Close();
            StreamWriter sw2;
            sw2 = File.AppendText(savePath + "\\sudokuCozumu" + (2).ToString() + ".txt");
            sw2.Write("");
            sw2.Close();
            StreamWriter sw3;
            sw3 = File.AppendText(savePath + "\\sudokuCozumu" + (3).ToString() + ".txt");
            sw3.Write("");
            sw3.Close();
            StreamWriter sw4;
            sw4 = File.AppendText(savePath + "\\sudokuCozumu" + (4).ToString() + ".txt");
            sw4.Write("");
            sw4.Close();
            StreamWriter sw5;
            sw5 = File.AppendText(savePath + "\\sudokuCozumu" + (5).ToString() + ".txt");
            sw5.Write("");
            sw5.Close();
            StreamWriter sw6;
            sw6 = File.AppendText(savePath + "\\sudokuCozumu" + (6).ToString() + ".txt");
            sw6.Write("");
            sw6.Close();
            StreamWriter sw7;
            sw7 = File.AppendText(savePath + "\\sudokuCozumu" + (7).ToString() + ".txt");
            sw7.Write("");
            sw7.Close();
            StreamWriter sw8;
            sw8 = File.AppendText(savePath + "\\sudokuCozumu" + (8).ToString() + ".txt");
            sw8.Write("");
            sw8.Close();
            StreamWriter sw9;
            sw9 = File.AppendText(savePath + "\\sudokuCozumu" + (9).ToString() + ".txt");
            sw9.Write("");
            sw9.Close();
            StreamWriter sw10;
            sw10 = File.AppendText(savePath + "\\sudokuCozumu" + (10).ToString() + ".txt");
            sw10.Write("");
            sw10.Close();
        }
        public void ClearDataFile()
        {
            if (sw1 != null) sw1.Close();
            if (sw2 != null) sw2.Close();
            if (sw3 != null) sw3.Close();
            if (sw4 != null) sw4.Close();
            if (sw5 != null) sw5.Close();
            if (sw6 != null) sw6.Close();
            if (sw7 != null) sw7.Close();
            if (sw8 != null) sw8.Close();
            if (sw9 != null) sw9.Close();
            if (sw10 != null) sw10.Close();

            StreamWriter s1 = new StreamWriter("D:\\qwe1.txt");
            StreamWriter s2 = new StreamWriter("D:\\qwe2.txt");
            StreamWriter s3 = new StreamWriter("D:\\qwe3.txt");
            StreamWriter s4 = new StreamWriter("D:\\qwe4.txt");
            StreamWriter s5 = new StreamWriter("D:\\qwe5.txt");
            StreamWriter s6 = new StreamWriter("D:\\qwe6.txt");
            StreamWriter s7 = new StreamWriter("D:\\qwe7.txt");
            StreamWriter s8 = new StreamWriter("D:\\qwe8.txt");
            StreamWriter s9 = new StreamWriter("D:\\qwe9.txt");
            StreamWriter s10 = new StreamWriter("D:\\qwe10.txt");
            s1.Write("");
            s2.Write("");
            s3.Write("");
            s4.Write("");
            s5.Write("");
            s6.Write("");
            s7.Write("");
            s8.Write("");
            s9.Write("");
            s10.Write("");
            s1.Close();
            s2.Close();
            s3.Close();
            s4.Close();
            s5.Close();
            s6.Close();
            s7.Close();
            s8.Close();
            s9.Close();
            s10.Close();
            //StreamWriter sw1 = new StreamWriter("D:\\qwe1.txt");
            //StreamWriter sw2 = new StreamWriter("D:\\qwe2.txt");
            //StreamWriter sw3 = new StreamWriter("D:\\qwe3.txt");
            //StreamWriter sw4 = new StreamWriter("D:\\qwe4.txt");
            //StreamWriter sw5 = new StreamWriter("D:\\qwe5.txt");
            //StreamWriter sw6 = new StreamWriter("D:\\qwe6.txt");
            //StreamWriter sw7 = new StreamWriter("D:\\qwe7.txt");
            //StreamWriter sw8 = new StreamWriter("D:\\qwe8.txt");
            //StreamWriter sw9 = new StreamWriter("D:\\qwe9.txt");
            //StreamWriter sw10 = new StreamWriter("D:\\qwe10.txt");
            //StreamWriter sw1;
            //StreamWriter sw2;
            //StreamWriter sw3;
            //StreamWriter sw4;
            //StreamWriter sw5;
            //StreamWriter sw6;
            //StreamWriter sw7;
            //StreamWriter sw8;
            //StreamWriter sw9;
            //StreamWriter sw10;
            //sw1 = File.AppendText("D:\\qwe1.txt");
            //sw2 = File.AppendText("D:\\qwe2.txt");
            //sw3 = File.AppendText("D:\\qwe3.txt");
            //sw4 = File.AppendText("D:\\qwe4.txt");
            //sw5 = File.AppendText("D:\\qwe5.txt");
            //sw6 = File.AppendText("D:\\qwe6.txt");
            //sw7 = File.AppendText("D:\\qwe7.txt");
            //sw8 = File.AppendText("D:\\qwe8.txt");
            //sw9 = File.AppendText("D:\\qwe9.txt");
            //sw10 = File.AppendText("D:\\qwe10.txt");
            //sw1.Write("");
            //sw2.Write("");
            //sw3.Write("");
            //sw4.Write("");
            //sw5.Write("");
            //sw6.Write("");
            //sw7.Write("");
            //sw8.Write("");
            //sw9.Write("");
            //sw10.Write("");
            //sw1.Close();
            //sw2.Close();
            //sw3.Close();
            //sw4.Close();
            //sw5.Close();
            //sw6.Close();
            //sw7.Close();
            //sw8.Close();
            //sw9.Close();
            //sw10.Close();
        }
        private void ThreadSolve1(int[,] arr,int rndX,int rndY)
        {
            SolveSudoku(0, rndX, rndY, arr, ref counter1, ref arr_sudoku1, "qwe1", txtSudoku1, ref isTurn1, gBoxT1, 1, combdata1);
            ThreadStop(1);
        }
        private void ThreadSolve2(int[,] arr, int rndX, int rndY)
        {
            SolveSudoku(0, rndX, rndY, arr, ref counter2, ref arr_sudoku2, "qwe2", txtSudoku2, ref isTurn2, gBoxT2, 2, combdata2);
            ThreadStop(2);
        }
        private void ThreadSolve3(int[,] arr, int rndX, int rndY)
        {
            SolveSudoku(0, rndX, rndY, arr, ref counter3, ref arr_sudoku3, "qwe3", txtSudoku3, ref isTurn3, gBoxT3, 3, combdata3);
            ThreadStop(3);
        }
        private void ThreadSolve4(int[,] arr, int rndX, int rndY)
        {
            SolveSudoku(0, rndX, rndY, arr, ref counter4, ref arr_sudoku4, "qwe4", txtSudoku4, ref isTurn4, gBoxT4, 4, combdata4);
            ThreadStop(4);
        }
        private void ThreadSolve5(int[,] arr, int rndX, int rndY)
        {
            SolveSudoku(0, rndX, rndY, arr, ref counter5, ref arr_sudoku5, "qwe5", txtSudoku5, ref isTurn5, gBoxT5, 5, combdata5);
            ThreadStop(5);
        }
        private void ThreadSolve6(int[,] arr, int rndX, int rndY)
        {
            SolveSudoku(0, rndX, rndY, arr, ref counter6, ref arr_sudoku6, "qwe6", txtSudoku6, ref isTurn6, gBoxT6, 6, combdata6);
            ThreadStop(6);
        }
        private void ThreadSolve7(int[,] arr, int rndX, int rndY)
        {
            SolveSudoku(0, rndX, rndY, arr, ref counter7, ref arr_sudoku7, "qwe7", txtSudoku7, ref isTurn7, gBoxT7, 7, combdata7);
            ThreadStop(7);
        }
        private void ThreadSolve8(int[,] arr, int rndX, int rndY)
        {
            SolveSudoku(0, rndX, rndY, arr, ref counter8, ref arr_sudoku8, "qwe8", txtSudoku8, ref isTurn8, gBoxT8, 8, combdata8);
            ThreadStop(8);
        }
        private void ThreadSolve9(int[,] arr, int rndX, int rndY)
        {
            SolveSudoku(0, rndX, rndY, arr, ref counter9, ref arr_sudoku9, "qwe9", txtSudoku9, ref isTurn9, gBoxT9, 9, combdata9);
            ThreadStop(9);
        }
        private void ThreadSolve10(int[,] arr, int rndX, int rndY)
        {
            SolveSudoku(0, rndX, rndY, arr, ref counter10, ref arr_sudoku10, "qwe10", txtSudoku10, ref isTurn10, gBoxT10, 10, combdata10);
            ThreadStop(10);
        }
        public void CleanLabels()
        {
            foreach (Control f in this.Controls)
                if (f is GroupBox)
                    foreach (Control item in f.Controls)
                        if (item is Label)
                            item.Text = "*";
        }
        public void CleanForm()
        {
            ClearDataFile();
            isTurn1 = true; isTurn2 = true; isTurn3 = true; isTurn4 = true; isTurn5 = true; isTurn6 = true; isTurn7 = true; isTurn8 = true; isTurn9 = true; isTurn10 = true;
            counter1 = 0; counter2 = 0; counter3 = 0; counter4 = 0; counter5 = 0; counter6 = 0; counter7 = 0; counter8 = 0; counter9 = 0; counter10 = 0;
            arr_sudoku1 = ""; arr_sudoku2 = ""; arr_sudoku3 = ""; arr_sudoku4 = ""; arr_sudoku5 = ""; arr_sudoku6 = ""; arr_sudoku7 = ""; arr_sudoku8 = ""; arr_sudoku9 = ""; arr_sudoku10 = "";
            Array.Clear(txtSudoku1, 0, txtSudoku1.Length);
            Array.Clear(txtSudoku2, 0, txtSudoku2.Length);
            Array.Clear(txtSudoku3, 0, txtSudoku3.Length);
            Array.Clear(txtSudoku4, 0, txtSudoku4.Length);
            Array.Clear(txtSudoku5, 0, txtSudoku5.Length);
            Array.Clear(txtSudoku6, 0, txtSudoku6.Length);
            Array.Clear(txtSudoku7, 0, txtSudoku7.Length);
            Array.Clear(txtSudoku8, 0, txtSudoku8.Length);
            Array.Clear(txtSudoku9, 0, txtSudoku9.Length);
            Array.Clear(txtSudoku10, 0, txtSudoku10.Length);
            combdata1.Desc.Clear();
            combdata2.Desc.Clear();
            combdata3.Desc.Clear();
            combdata4.Desc.Clear();
            combdata5.Desc.Clear();
            combdata6.Desc.Clear();
            combdata7.Desc.Clear();
            combdata8.Desc.Clear();
            combdata9.Desc.Clear();
            combdata10.Desc.Clear();
            combdata1.ArrayLists.Clear();
            combdata2.ArrayLists.Clear();
            combdata3.ArrayLists.Clear();
            combdata4.ArrayLists.Clear();
            combdata5.ArrayLists.Clear();
            combdata6.ArrayLists.Clear();
            combdata7.ArrayLists.Clear();
            combdata8.ArrayLists.Clear();
            combdata9.ArrayLists.Clear();
            combdata10.ArrayLists.Clear();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox6.Items.Clear();
            comboBox7.Items.Clear();
            comboBox8.Items.Clear();
            comboBox9.Items.Clear();
            comboBox10.Items.Clear();
            lblDesc1.Text = "";
            lblDesc2.Text = "";
            lblDesc3.Text = "";
            lblDesc4.Text = "";
            lblDesc5.Text = "";
            lblDesc6.Text = "";
            lblDesc7.Text = "";
            lblDesc8.Text = "";
            lblDesc9.Text = "";
            lblDesc10.Text = "";
            lblRuntime.Text = "ZAMAN";
            Array.Clear(dataStrArray1, 0, dataStrArray1.Length);
            Array.Clear(dataStrArray2, 0, dataStrArray2.Length);
            Array.Clear(dataStrArray3, 0, dataStrArray3.Length);
            Array.Clear(dataStrArray4, 0, dataStrArray4.Length);
            Array.Clear(dataStrArray5, 0, dataStrArray5.Length);
            Array.Clear(dataStrArray6, 0, dataStrArray6.Length);
            Array.Clear(dataStrArray7, 0, dataStrArray7.Length);
            Array.Clear(dataStrArray8, 0, dataStrArray8.Length);
            Array.Clear(dataStrArray9, 0, dataStrArray9.Length);
            Array.Clear(dataStrArray10, 0, dataStrArray10.Length);
            CleanGBoxBackColor();
            ClearRuntimeStopWatch();
        }
        public void SetComboItems()
        {
            for(int i = 0; i < combdata1.Desc.Count; i++)
                comboBox1.Items.Add(String.Format("{0}.adım", (i + 1).ToString()));
            for (int i = 0; i < combdata2.Desc.Count; i++)
                comboBox2.Items.Add(String.Format("{0}.adım", (i + 1).ToString()));
            for (int i = 0; i < combdata3.Desc.Count; i++)
                comboBox3.Items.Add(String.Format("{0}.adım", (i + 1).ToString()));
            for (int i = 0; i < combdata4.Desc.Count; i++)
                comboBox4.Items.Add(String.Format("{0}.adım", (i + 1).ToString()));
            for (int i = 0; i < combdata5.Desc.Count; i++)
                comboBox5.Items.Add(String.Format("{0}.adım", (i + 1).ToString()));
            for (int i = 0; i < combdata6.Desc.Count; i++)
                comboBox6.Items.Add(String.Format("{0}.adım", (i + 1).ToString()));
            for (int i = 0; i < combdata7.Desc.Count; i++)
                comboBox7.Items.Add(String.Format("{0}.adım", (i + 1).ToString()));
            for (int i = 0; i < combdata8.Desc.Count; i++)
                comboBox8.Items.Add(String.Format("{0}.adım", (i + 1).ToString()));
            for (int i = 0; i < combdata9.Desc.Count; i++)
                comboBox9.Items.Add(String.Format("{0}.adım", (i + 1).ToString()));
            for (int i = 0; i < combdata10.Desc.Count; i++)
                comboBox10.Items.Add(String.Format("{0}.adım", (i + 1).ToString()));
        }
        public void ChangeLabelsText(ComboData cmbData,int index, int tIndex)
        {
            int[,] combArr = cmbData.ArrayLists[Convert.ToInt32(index)];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var lbl = this.Controls.Find(String.Format("t{0}Lbl{1}{2}", tIndex, i, j), true).FirstOrDefault();
                    if (combArr[i, j] == 0)
                        lbl.Text = "*";
                    else
                        lbl.Text = combArr[i, j].ToString();
                }
            }
        }
        private void BtnTextOpen_Click(object sender, EventArgs e)
        {
            CleanForm();
            startPath = GetFileDirection();
            if(startPath!="NotFound")
                CleanLabels();
            startArray = ExportSudokuFileToArray(startPath);
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    int num = startArray[i, j];
                    if (num != 0)
                    {
                        SetLabelStartValue(i, j, num, gBoxT1, 1);
                        SetLabelStartValue(i, j, num, gBoxT2, 2);
                        SetLabelStartValue(i, j, num, gBoxT3, 3);
                        SetLabelStartValue(i, j, num, gBoxT4, 4);
                        SetLabelStartValue(i, j, num, gBoxT5, 5);
                        SetLabelStartValue(i, j, num, gBoxT6, 6);
                        SetLabelStartValue(i, j, num, gBoxT7, 7);
                        SetLabelStartValue(i, j, num, gBoxT8, 8);
                        SetLabelStartValue(i, j, num, gBoxT9, 9);
                        SetLabelStartValue(i, j, num, gBoxT10, 10);
                    }
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string index = comboBox1.Text.Replace(".adım", "");
            ChangeLabelsText(combdata1, Convert.ToInt32(index) - 1, 1);
            lblDesc1.Text = combdata1.Desc[Convert.ToInt32(index)-1];
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string index = comboBox2.Text.Replace(".adım", "");
            ChangeLabelsText(combdata2, Convert.ToInt32(index) - 1, 2);
            lblDesc2.Text = combdata2.Desc[Convert.ToInt32(index) - 1];
        }
        public string GetRuntimeStopWatch(int index)
        {
            Stopwatch stopWatch;
            if (index == 1) stopWatch = swatch1;
            else if (index == 2) stopWatch = swatch2;
            else if (index == 3) stopWatch = swatch3;
            else if (index == 4) stopWatch = swatch4;
            else if (index == 5) stopWatch = swatch5;
            else if (index == 6) stopWatch = swatch6;
            else if (index == 7) stopWatch = swatch7;
            else if (index == 8) stopWatch = swatch8;
            else if (index == 9) stopWatch = swatch9;
            else stopWatch = swatch10;
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",ts.Hours, ts.Minutes, ts.Seconds,ts.Milliseconds / 10);
            return elapsedTime;
        }
        public void ClearRuntimeStopWatch()
        {
            swatch1.Reset(); swatch4.Reset(); swatch5.Reset(); swatch8.Reset(); swatch9.Reset();
            swatch2.Reset(); swatch3.Reset(); swatch6.Reset(); swatch7.Reset(); swatch10.Reset();
        }
        public void SetLabelFinish(int index)
        {
            int runHour = dateFinish.Hour - dateStart.Hour;
            int runMinute = dateFinish.Minute - dateStart.Minute;
            int runSecond = dateFinish.Second - dateStart.Second;
            int runMilisecond = (dateFinish.Millisecond > dateStart.Millisecond) ? (dateFinish.Millisecond - dateStart.Millisecond) : -(dateFinish.Millisecond - dateStart.Millisecond);
            lblRuntime.Text = String.Format("0{0}:0{1}:0{2}:{3}. İlk Bitiren : Thread {4}", runHour.ToString(), runMinute.ToString(), runSecond.ToString(), runMilisecond.ToString(),index.ToString());
        }
        public void ThreadStop(int index)
        {
            dateFinish = DateTime.Now;
            if (index == 1)
            {
                thread2.Abort();
                thread3.Abort();
                thread4.Abort();
                thread5.Abort();
                thread6.Abort();
                thread7.Abort();
                thread8.Abort();
                thread9.Abort();
                thread10.Abort();
                SetLabelFinish(1);
                gBoxT1.BackColor = Color.Lime;
                SetComboItems();
                SaveTxtDatabase();
                BtnSolve.Enabled = true;
                thread1.Abort();
            }
            if (index == 2)
            {
                thread1.Abort();
                thread3.Abort();
                thread4.Abort();
                thread5.Abort();
                thread6.Abort();
                thread7.Abort();
                thread8.Abort();
                thread9.Abort();
                thread10.Abort();
                SetLabelFinish(2);
                gBoxT2.BackColor = Color.Lime;
                SetComboItems();
                SaveTxtDatabase();
                BtnSolve.Enabled = true;
                thread2.Abort();
            }
            if (index == 3)
            {
                thread1.Abort();
                thread2.Abort();
                thread4.Abort();
                thread5.Abort();
                thread6.Abort();
                thread7.Abort();
                thread8.Abort();
                thread9.Abort();
                thread10.Abort();
                SetLabelFinish(3);
                gBoxT3.BackColor = Color.Lime;
                SetComboItems();
                SaveTxtDatabase();
                BtnSolve.Enabled = true;
                thread3.Abort();
            }
            if (index == 4)
            {
                thread1.Abort();
                thread3.Abort();
                thread2.Abort();
                thread5.Abort();
                thread6.Abort();
                thread7.Abort();
                thread8.Abort();
                thread9.Abort();
                thread10.Abort();
                SetLabelFinish(4);
                gBoxT4.BackColor = Color.Lime;
                SetComboItems();
                SaveTxtDatabase();
                BtnSolve.Enabled = true;
                thread4.Abort();
            }
            if (index == 5)
            {
                thread1.Abort();
                thread3.Abort();
                thread4.Abort();
                thread2.Abort();
                thread6.Abort();
                thread7.Abort();
                thread8.Abort();
                thread9.Abort();
                thread10.Abort();
                SetLabelFinish(5);
                gBoxT5.BackColor = Color.Lime;
                SetComboItems();
                SaveTxtDatabase();
                BtnSolve.Enabled = true;
                thread5.Abort();
            }
            if (index == 6)
            {
                thread1.Abort();
                thread3.Abort();
                thread4.Abort();
                thread5.Abort();
                thread2.Abort();
                thread7.Abort();
                thread8.Abort();
                thread9.Abort();
                thread10.Abort();
                SetLabelFinish(6);
                gBoxT6.BackColor = Color.Lime;
                SetComboItems();
                SaveTxtDatabase();
                BtnSolve.Enabled = true;
                thread6.Abort();
            }
            if (index == 7)
            {
                thread1.Abort();
                thread3.Abort();
                thread4.Abort();
                thread5.Abort();
                thread6.Abort();
                thread2.Abort();
                thread8.Abort();
                thread9.Abort();
                thread10.Abort();
                SetLabelFinish(7);
                gBoxT7.BackColor = Color.Lime;
                SetComboItems();
                SaveTxtDatabase();
                BtnSolve.Enabled = true;
                thread7.Abort();
            }
            if (index == 8)
            {
                thread1.Abort();
                thread3.Abort();
                thread4.Abort();
                thread5.Abort();
                thread6.Abort();
                thread7.Abort();
                thread2.Abort();
                thread9.Abort();
                thread10.Abort();
                SetLabelFinish(8);
                gBoxT8.BackColor = Color.Lime;
                SetComboItems();
                SaveTxtDatabase();
                BtnSolve.Enabled = true;
                thread8.Abort();
            }
            if (index == 9)
            {
                thread1.Abort();
                thread2.Abort();
                thread3.Abort();
                thread4.Abort();
                thread5.Abort();
                thread6.Abort();
                thread7.Abort();
                thread8.Abort();
                thread10.Abort();
                SetLabelFinish(9);
                gBoxT9.BackColor = Color.Lime;
                SetComboItems();
                SaveTxtDatabase();
                BtnSolve.Enabled = true;
                thread9.Abort();
            }
            if (index == 10)
            {
                thread1.Abort();
                thread2.Abort();
                thread3.Abort();
                thread4.Abort();
                thread5.Abort();
                thread6.Abort();
                thread7.Abort();
                thread8.Abort();
                thread9.Abort();
                SetLabelFinish(10);
                gBoxT10.BackColor = Color.Lime;
                SetComboItems();
                SaveTxtDatabase();
                BtnSolve.Enabled = true;
                thread10.Abort();
            }
        }
        public void SaveTxtDatabase()
        {

        }
        public void CleanGBoxBackColor()
        {
            foreach(Control item in this.Controls)
            {
                if (item is GroupBox)
                    item.BackColor = Color.Transparent;
            }
        }
        public bool StatusSavePath()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Kaydetmek istediğiniz yeri seçin.";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                savePath = dialog.SelectedPath;
                return true;
            }
            return false;
        }
        public void AddLabelToGroupbox(GroupBox gBoxFrm, int index, string color)
        {
            Color colorDark = ColorTranslator.FromHtml("#00dcff");
            Color colorLight = ColorTranslator.FromHtml("#94eefd");
            if (color == "kırmızı")
            {
                colorDark = ColorTranslator.FromHtml("#ff2929");
                colorLight = ColorTranslator.FromHtml("#ff9797");
            }
            if (color == "mavi")
            {
                colorDark = ColorTranslator.FromHtml("#00dcff");
                colorLight = ColorTranslator.FromHtml("#94eefd");
            }
            if (color == "turuncu")
            {
                colorDark = ColorTranslator.FromHtml("#ff6a00");
                colorLight = ColorTranslator.FromHtml("#ffa768");
            }
            if (color == "yeşil")
            {
                colorDark = ColorTranslator.FromHtml("#00c30f");
                colorLight = ColorTranslator.FromHtml("#5df468");
            }
            if (color == "sarı")
            {
                colorDark = ColorTranslator.FromHtml("#e3f200");
                colorLight = ColorTranslator.FromHtml("#e7f054");
            }
            if (color == "mor")
            {
                colorDark = ColorTranslator.FromHtml("#8600cb");
                colorLight = ColorTranslator.FromHtml("#c282e4");
            }
            if (color == "gri")
            {
                colorDark = ColorTranslator.FromHtml("#858585");
                colorLight = ColorTranslator.FromHtml("#d3d3d3");
            }
            if (color == "pembe")
            {
                colorDark = ColorTranslator.FromHtml("#ff00c8");
                colorLight = ColorTranslator.FromHtml("#ff84e4");
            }
            if (color == "lacivert")
            {
                colorDark = ColorTranslator.FromHtml("#0013fa");
                colorLight = ColorTranslator.FromHtml("#b1b7ff");
            }
            int x = 25, y = 25;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Label lbl = new Label();
                    lbl.Name = String.Format("t{0}Lbl{1}{2}", index, i, j);
                    lbl.Text = "*";
                    lbl.Location = new Point(x, y);
                    lbl.Width = 25;
                    lbl.Height = 25;
                    lbl.BorderStyle = BorderStyle.FixedSingle;
                    lbl.Font = new Font("Arial", 12);
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.BackColor = ((i + j) % 2 == 0) ? colorDark : colorLight;
                    gBoxFrm.Controls.Add(lbl);
                    x += 25;
                }
                x = 25;
                y += 25;
            }
        }
        public void SetLabelStartValue(int x,int y,int num, GroupBox gBoxStart, int index)
        {
            foreach (Control item in gBoxStart.Controls)
                if (item is Label)
                    if (item.Name == String.Format("t{0}Lbl{1}{2}", index, x, y))
                        item.Text = num.ToString();
                    
        }
        private void FormSudoku_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            //ClearDataFile();
            txtSudoku1 = new string[9, 9];
            txtSudoku2 = new string[9, 9];
            txtSudoku3 = new string[9, 9];
            txtSudoku4 = new string[9, 9];
            txtSudoku5 = new string[9, 9];
            txtSudoku6 = new string[9, 9];
            txtSudoku7 = new string[9, 9];
            txtSudoku8 = new string[9, 9];
            txtSudoku9 = new string[9, 9];
            txtSudoku10 = new string[9, 9];
            AddLabelToGroupbox(gBoxT1, 1, "kırmızı");
            AddLabelToGroupbox(gBoxT2, 2, "mavi");
            AddLabelToGroupbox(gBoxT3, 3, "turuncu");
            AddLabelToGroupbox(gBoxT4, 4, "yeşil");
            AddLabelToGroupbox(gBoxT5, 5, "sarı");
            AddLabelToGroupbox(gBoxT6, 6, "mor");
            AddLabelToGroupbox(gBoxT7, 7, "gri");
            AddLabelToGroupbox(gBoxT8, 8, "pembe");
            AddLabelToGroupbox(gBoxT9, 9, "lacivert");
            AddLabelToGroupbox(gBoxT10, 10, "kırmızı");
            dataStrArray1 = new string[9, 9];
            dataStrArray2 = new string[9, 9];
            dataStrArray3 = new string[9, 9];
            dataStrArray4 = new string[9, 9];
            dataStrArray5 = new string[9, 9];
            dataStrArray6 = new string[9, 9];
            dataStrArray7 = new string[9, 9];
            dataStrArray8 = new string[9, 9];
            dataStrArray9 = new string[9, 9];
            dataStrArray10 = new string[9, 9];
            combdata1 = new ComboData();
            combdata2 = new ComboData();
            combdata3 = new ComboData();
            combdata4 = new ComboData();
            combdata5 = new ComboData();
            combdata6 = new ComboData();
            combdata7 = new ComboData();
            combdata8 = new ComboData();
            combdata9 = new ComboData();
            combdata10 = new ComboData();
            swatch1 = new Stopwatch();
            swatch2 = new Stopwatch();
            swatch3 = new Stopwatch();
            swatch4 = new Stopwatch();
            swatch5 = new Stopwatch();
            swatch6 = new Stopwatch();
            swatch7 = new Stopwatch();
            swatch8 = new Stopwatch();
            swatch9 = new Stopwatch();
            swatch10 = new Stopwatch();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
        }
        private void BtnSolve_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int rndX1 = rnd.Next(0, 9);
            int rndX2 = rnd.Next(0, 9);
            int rndX3 = rnd.Next(0, 9);
            int rndX4 = rnd.Next(0, 9);
            int rndX5 = rnd.Next(0, 9);
            int rndX6 = rnd.Next(0, 9);
            int rndX7 = rnd.Next(0, 9);
            int rndX8 = rnd.Next(0, 9);
            int rndX9 = rnd.Next(0, 9);
            int rndX10 = rnd.Next(0, 9);
            int rndY1 = rnd.Next(0, 9);
            int rndY2 = rnd.Next(0, 9);
            int rndY3 = rnd.Next(0, 9);
            int rndY4 = rnd.Next(0, 9);
            int rndY5 = rnd.Next(0, 9);
            int rndY6 = rnd.Next(0, 9);
            int rndY7 = rnd.Next(0, 9);
            int rndY8 = rnd.Next(0, 9);
            int rndY9 = rnd.Next(0, 9);
            int rndY10 = rnd.Next(0, 9);
            if (startPath != null)
            {
                CleanLabels();
                CleanForm();
                Thread.Sleep(500);
                BtnSolve.Enabled = false;
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        int num = startArray[i, j];
                        if (num != 0)
                        {
                            SetLabelStartValue(i, j, num, gBoxT1, 1);
                            SetLabelStartValue(i, j, num, gBoxT2, 2);
                            SetLabelStartValue(i, j, num, gBoxT3, 3);
                            SetLabelStartValue(i, j, num, gBoxT4, 4);
                            SetLabelStartValue(i, j, num, gBoxT5, 5);
                            SetLabelStartValue(i, j, num, gBoxT6, 6);
                            SetLabelStartValue(i, j, num, gBoxT7, 7);
                            SetLabelStartValue(i, j, num, gBoxT8, 8);
                            SetLabelStartValue(i, j, num, gBoxT9, 9);
                            SetLabelStartValue(i, j, num, gBoxT10, 10);
                        }
                    }
                }
                MessageBox.Show("Ekran temizlendi. Şimdi Çözülecek...");
                dateStart = DateTime.Now;
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        int num = startArray[i, j];
                        if (num != 0)
                        {
                            txtSudoku1[i, j] = num.ToString();
                            txtSudoku2[i, j] = num.ToString();
                            txtSudoku3[i, j] = num.ToString();
                            txtSudoku4[i, j] = num.ToString();
                            txtSudoku1[i, j] = num.ToString();
                            txtSudoku5[i, j] = num.ToString();
                            txtSudoku6[i, j] = num.ToString();
                            txtSudoku7[i, j] = num.ToString();
                            txtSudoku8[i, j] = num.ToString();
                            txtSudoku9[i, j] = num.ToString();
                            txtSudoku10[i, j] = num.ToString();
                            dataStrArray1[i, j] = num.ToString();
                            dataStrArray2[i, j] = num.ToString();
                            dataStrArray3[i, j] = num.ToString();
                            dataStrArray4[i, j] = num.ToString();
                            dataStrArray5[i, j] = num.ToString();
                            dataStrArray6[i, j] = num.ToString();
                            dataStrArray7[i, j] = num.ToString();
                            dataStrArray8[i, j] = num.ToString();
                            dataStrArray9[i, j] = num.ToString();
                            dataStrArray10[i, j] = num.ToString();
                        }
                        else
                        {
                            txtSudoku1[i, j] = "*";
                            txtSudoku2[i, j] = "*";
                            txtSudoku3[i, j] = "*";
                            txtSudoku4[i, j] = "*";
                            txtSudoku5[i, j] = "*";
                            txtSudoku6[i, j] = "*";
                            txtSudoku7[i, j] = "*";
                            txtSudoku8[i, j] = "*";
                            txtSudoku9[i, j] = "*";
                            txtSudoku10[i, j] = "*";
                            dataStrArray1[i, j] = "*";
                            dataStrArray2[i, j] = "*";
                            dataStrArray3[i, j] = "*";
                            dataStrArray4[i, j] = "*";
                            dataStrArray5[i, j] = "*";
                            dataStrArray6[i, j] = "*";
                            dataStrArray7[i, j] = "*";
                            dataStrArray8[i, j] = "*";
                            dataStrArray9[i, j] = "*";
                            dataStrArray10[i, j] = "*";
                        }
                    }
                }
                thread1 = new Thread(() => ThreadSolve1(startArray, rndX1, rndY1));
                thread2 = new Thread(() => ThreadSolve2(startArray, rndX2, rndY2));
                thread3 = new Thread(() => ThreadSolve3(startArray, rndX3, rndY3));
                thread4 = new Thread(() => ThreadSolve4(startArray, rndX4, rndY4));
                thread5 = new Thread(() => ThreadSolve5(startArray, rndX5, rndY5));
                thread6 = new Thread(() => ThreadSolve6(startArray, rndX6, rndY6));
                thread7 = new Thread(() => ThreadSolve7(startArray, rndX7, rndY7));
                thread8 = new Thread(() => ThreadSolve8(startArray, rndX8, rndY8));
                thread9 = new Thread(() => ThreadSolve9(startArray, rndX9, rndY9));
                thread10 = new Thread(() => ThreadSolve10(startArray, rndX10, rndY10));
                thread1.IsBackground = true;
                thread2.IsBackground = true;
                thread3.IsBackground = true;
                thread4.IsBackground = true;
                thread5.IsBackground = true;
                thread6.IsBackground = true;
                thread7.IsBackground = true;
                thread8.IsBackground = true;
                thread9.IsBackground = true;
                thread10.IsBackground = true;

                thread1.Start();
                thread2.Start();
                thread3.Start();
                thread4.Start();
                thread5.Start();
                thread6.Start();
                thread7.Start();
                thread8.Start();
                thread9.Start();
                thread10.Start();
            }
            else
                MessageBox.Show("Henüz dosya seçmediniz...");
            
        }
    }
}
