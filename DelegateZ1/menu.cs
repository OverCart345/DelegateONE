using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateZ1
{
    public delegate double OperaGX(double x, double y);
    internal class Menu
    {
        private enum Alpha { sum, sub, mul, del, exit };
        int button_count;
        private Alpha current_Button;

        private string[] button_Name;

        private Real R;
        private OperaGX sum_Opera;
        private OperaGX sub_Opera;
        private OperaGX mul_Opera;
        private OperaGX del_Opera;


        public Menu()
        {


            button_count = Enum.GetValues(typeof(Alpha)).Length;
            button_Name = new string[button_count];
            R = new Real();

            button_Name[0] = " Сумма ";
            button_Name[1] = " Вычитание ";
            button_Name[2] = " Умножение ";
            button_Name[3] = " Деление ";
            button_Name[4] = " Выход ";

            sum_Opera = new OperaGX(R.Sum);
            sub_Opera = new OperaGX(R.Sub);
            mul_Opera = new OperaGX(R.Mul);
            del_Opera = new OperaGX(R.Del);

            
            Choise();
        }


        private void Start()
        {
            Console.Clear();

            int down = button_count;

            for (int i = 0; i < button_count; i++)
            {

                int centerX = (Console.WindowWidth / 2) - (button_Name[i].Length / 2);
                int centerY = (Console.WindowHeight / 2) - down;

                int eValue = (int)current_Button;

                Console.SetCursorPosition(centerX, centerY);
                if (eValue == i)
                {
                    Console.Write(button_Name[i], Console.BackgroundColor = ConsoleColor.White,
                    Console.ForegroundColor = ConsoleColor.Black);
                }
                else
                {
                    Console.Write(button_Name[i], Console.BackgroundColor = ConsoleColor.Black,
                    Console.ForegroundColor = ConsoleColor.White);
                }

                down -= 2;
            }
            Console.ResetColor();
        }

        private void magic(int arg) {
            Console.Clear();
            Console.SetCursorPosition(2, 1);
            Console.Write($"А у нас тут ");
            Console.Write(button_Name[arg], Console.BackgroundColor = ConsoleColor.White,
                    Console.ForegroundColor = ConsoleColor.Black);
            Console.Write($"!!!", Console.BackgroundColor = ConsoleColor.Black,
                    Console.ForegroundColor = ConsoleColor.White);

            Console.SetCursorPosition(2, 3);
            Console.Write($"Введите аргумент 1: ");
            int x = int.Parse( Console.ReadLine() );

            Console.SetCursorPosition(2, 4);
            Console.Write($"Введите аргумент 2: ");
            int y = int.Parse(Console.ReadLine());

            Console.SetCursorPosition(2, 6);

            switch (arg) {
                case 0:
                    Console.WriteLine($"Ответ = {sum_Opera(x,y)}");
                    break;
                case 1:
                    Console.WriteLine($"Ответ = {sub_Opera(x, y)}");
                    break;
                case 2:
                    Console.WriteLine($"Ответ = {mul_Opera(x, y)}");
                    break;
                case 3:
                    Console.WriteLine($"Ответ = {del_Opera(x, y)}");
                    break;           
            }

            Console.SetCursorPosition(3, 8);
            Console.WriteLine(" Для продолжение нажмите на любую кнопку ", Console.BackgroundColor = ConsoleColor.White,
                Console.ForegroundColor = ConsoleColor.Black);

            Console.ReadKey();
            Console.ResetColor();
            Choise();
        }


        private void Choise()
        {
            Start();
            ConsoleKeyInfo chose_Button;

            Console.ResetColor();
            do
            {
                chose_Button = Console.ReadKey();

                if (chose_Button.Key == ConsoleKey.UpArrow)
                {

                    if (current_Button > 0)
                    {
                        current_Button--;
                        Start();
                    }
                }

                if (chose_Button.Key == ConsoleKey.DownArrow)
                {
                    if ((int)current_Button < button_count - 1)
                    {
                        current_Button++;
                        Start();
                    }
                }

                if (chose_Button.Key == ConsoleKey.Enter)
                {
                    
                    switch (current_Button)
                    {
                        case Alpha.exit: Environment.Exit(1); break;
                        default: magic(Convert.ToInt32(current_Button)); break;
                    }
                }



            } while (chose_Button.Key != ConsoleKey.Escape);

        }

       
    }
}
