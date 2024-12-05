namespace std
{

    class DZ_TUMAKOV
    {
        static void Main()
        {
            TASK1();
            TASK2();
            TASK3();
            TASK4();
        }
        static void TASK1()
        {
            /*Упражнение 7.1 Создать класс счет в банке с закрытыми полями: номер счета, баланс, тип
            банковского счета (использовать перечислимый тип из упр. 3.1). Предусмотреть методы для
            доступа к данным – заполнения и чтения. Создать объект класса, заполнить его поля и
            вывести информацию об объекте класса на печать.*/
            Console.WriteLine("Задание 7.1 Создать класс счет в банке c закрытыми полями");
            Banks bank = new Banks(1133557799224466, 123456, Bank.Сберегательный);
            bank.PrintInfoAcc();
            bank.ChangeInfoAcc();
        }
        static void TASK2()
        {
            /*Упражнение 7.2 Изменить класс счет в банке из упражнения 7.1 таким образом, чтобы
            номер счета генерировался сам и был уникальным. Для этого надо создать в классе
            статическую переменную и метод, который увеличивает значение этого переменной.*/
            Console.WriteLine("Задание 7.2 Изменить класс счет в банке из упражнения 7.1");
            AutoBank autoBank = new AutoBank(123456, Bank.Сберегательный);
            Banks bank = new Banks(1133557799224466, 123456, Bank.Сберегательный);
            bank.PrintInfoAcc();
            autoBank.PrintInfoAcc();;
        }
        static void TASK3()
        {
            /*Упражнение 7.3 Добавить в класс счет в банке два метода: снять со счета и положить на
            счет. Метод снять со счета проверяет, возможно ли снять запрашиваемую сумму, и в случае
            положительного результата изменяет баланс.*/
            Console.WriteLine("Задание 7.3 Добавить в класс счет в банке два метода");
            Banks bank = new Banks(1133557799224466, 123456, Bank.Сберегательный);
            bank.PrintInfoAcc();
            bank.GiveBalanceAcc();
            bank.TakeBalanceAcc();
        }
        static void TASK4()
        {
            /*Домашнее задание 7.1 Реализовать класс для описания здания (уникальный номер здания,
            высота, этажность, количество квартир, подъездов). Поля сделать закрытыми,
            предусмотреть методы для заполнения полей и получения значений полей для печати.
            Добавить методы вычисления высоты этажа, количества квартир в подъезде, количества
            квартир на этаже и т.д. Предусмотреть возможность, чтобы уникальный номер здания
            генерировался программно. Для этого в классе предусмотреть статическое поле, которое бы
            хранило последний использованный номер здания, и предусмотреть метод, который
            увеличивал бы значение этого поля.*/
            Console.WriteLine("Домашнее задание 7.1. Реализовать класс для описания здания");
            Building building = new Building();
            building.SetBuilding();
            building = new Building(150, 15, 3, 150);
            building.InfoBuilding();
            building.SetBuilding();
        }

        //К упражнению 7.1
    }
    enum Bank
    {
        Сберегательный,
        Текущий,
        Необозначенный
    }

    class Banks
    {
        private long idAcc;
        private decimal balanceAcc;
        private Bank typeAcc = Bank.Сберегательный;

        public void PrintInfoAcc()
        {
            Console.WriteLine($"Номер счета: {idAcc}\nБаланс счета: {balanceAcc}\nТип счета: {typeAcc}");
        }
        public Banks()
        {
            this.idAcc = 0;
            this.balanceAcc = 2200000000000000;
            this.typeAcc = Bank.Необозначенный;
        }
        public Banks(long idAcc, decimal balanceAcc, Bank typeAcc)
        {
            this.idAcc = idAcc;
            this.balanceAcc = balanceAcc;
            this.typeAcc = typeAcc;
        }
        public void ChangeInfoAcc()
        {
            Console.Write("Введите новый номер счета:");
            bool isLong = long.TryParse(Console.ReadLine(), out long newIdAcc);
            if (isLong && newIdAcc.ToString().Length == 16)
            {
                this.idAcc = newIdAcc;
            }
            else
            {
                this.idAcc = idAcc;
                Console.WriteLine("Номер должен состоять из 16 цифр, оставлено заданное ранее значение");
            }
            Console.Write("Введите текущий баланс счета:");
            bool isDecimal = decimal.TryParse(Console.ReadLine(), out decimal newBalanceAcc);
            if (isDecimal)
            {
                this.balanceAcc = newBalanceAcc;
            }
            else
            {
                this.balanceAcc = balanceAcc;
                Console.WriteLine("Такого баланса быть не может, оставлено заданное ранее значение");
            }
            Console.Write("На какой тип необходимо поменять(Сберегательный/текущий):");
            switch (Console.ReadLine().ToLower())
            {
                case "текущий":
                    typeAcc = Bank.Текущий;
                    break;
                case "сберегательный":
                    typeAcc = Bank.Сберегательный;
                    break;
                default:
                    this.typeAcc = typeAcc;
                    Console.WriteLine("Такого типа счета не существует, оставлено заданное ранее значение");
                    break;
            }
            this.PrintInfoAcc();
        }
        //к упражнению 7.3
        public void TakeBalanceAcc()
        {
            Console.Write("Введите сумму которую хотите снять:");
            bool isDecimal = decimal.TryParse(Console.ReadLine(), out decimal takenBalanceAcc);
            if (isDecimal)
            {
                if (takenBalanceAcc < this.balanceAcc)
                {
                    balanceAcc = balanceAcc - takenBalanceAcc;
                    Console.WriteLine($"Вы успешно сняли со счета\nТекущий баланс: {balanceAcc}");
                }
                else
                {
                    Console.WriteLine("У вас недостаточно средств");
                }
            }
            else
            {
                Console.WriteLine("Вы вввели не сумму");
            }
        }
        public void GiveBalanceAcc()
        {
            Console.Write("Введите сумму которую хотите положить:");
            bool isDecimal = decimal.TryParse(Console.ReadLine(), out decimal givenBalanceAcc);
            if (isDecimal)
            {
                balanceAcc = balanceAcc + givenBalanceAcc;
                Console.WriteLine($"Вы успешно пополнили счет\nТекущий баланс счета:{balanceAcc}");
            }
            else
            {
                Console.WriteLine("Вы вввели не сумму");
            }
        }
    }

    //К упражнению 7.2
    class AutoBank
    {
        static private long idAcc = 2200000000000000;
        private decimal balanceAcc;
        private Bank typeAcc = Bank.Сберегательный;

        public void PrintInfoAcc()
        {
            Console.WriteLine($"Номер счета: {idAcc}\nБаланс счета: {balanceAcc}\nТип счета: {typeAcc}");
        }
        public AutoBank()
        {
            this.Next();
            this.balanceAcc = 0;
            this.typeAcc = Bank.Необозначенный;
        }
        public AutoBank(decimal balanceAcc, Bank typeAcc)
        {
            this.Next();
            this.balanceAcc = balanceAcc;
            this.typeAcc = typeAcc;
        }
        public void Next()
        {
            idAcc++;
        }
        public void ChangeInfoAcc()
        {
            this.Next();
            Console.WriteLine("Создан новый номер счета");
            Console.Write("Введите текущий баланс счета:");
            bool isDecimal = decimal.TryParse(Console.ReadLine(), out decimal newBalanceAcc);
            if (isDecimal)
            {
                this.balanceAcc = newBalanceAcc;
            }
            else
            {
                this.balanceAcc = balanceAcc;
                Console.WriteLine("Такого баланса не может быть, оставлено заданное ранее значение");
            }
            Console.Write("На какой тип необходимо поменять(Сберегательный/текущий):");
            switch (Console.ReadLine().ToLower())
            {
                case "текущий":
                    this.typeAcc = Bank.Текущий;
                    break;
                case "сберегательный":
                    this.typeAcc = Bank.Сберегательный;
                    break;
                default:
                    this.typeAcc = typeAcc;
                    Console.WriteLine("Такого типа счета не существует, оставлено заданное ранее значение");
                    break;
            }
            this.PrintInfoAcc();
        }
    }

    //к домашнему заданию 7.1
    class Building
    {
        static private uint numBuilding = 0;
        private ushort heightBuilding;
        private byte numOfFloors;
        private byte numOfPods;
        private ushort numOfAparts;

        public Building()
        {
            Next();
            this.heightBuilding = 1;
            this.numOfFloors = 1;
            this.numOfPods = 1;
            this.numOfAparts = 1;
        }
        public Building(ushort heightBuilding, byte numOfFloors, byte numOfPods, ushort numOfApart)
        {
            Next();
            this.heightBuilding = heightBuilding;
            this.numOfFloors = numOfFloors;
            this.numOfPods = numOfPods;
            this.numOfAparts = numOfApart;
        }
        public void Next()
        {
            numBuilding++;
        }
        public void InfoBuilding()
        {
            Console.WriteLine($"Номер здания: {numBuilding}\n" +
                $"Высота здания: {heightBuilding}\n" +
                $"Количество этажей: {numOfFloors}\n" +
                $"Количество подъездов: {numOfPods}\n" +
                $"Количество квартир: {numOfAparts}\n" +
                $"Высота 1 этажа: {this.HeightOfFloor()}\n" +
                $"Количество квартир в подъезде: {this.NumOfApartsInPods()}\n" +
                $"Количество квартир на этаже: {this.NumOfApartsInFloor()}");
        }
        public void SetBuilding()
        {
            Console.Write("Введите высоту здания: ");
            bool isValid = ushort.TryParse(Console.ReadLine(), out ushort newHeightBuilding);
            if (isValid)
            {
                this.heightBuilding = newHeightBuilding;
            }
            else
            {
                this.heightBuilding = 1;
                Console.WriteLine("Такой высоты не может быть, выставлено значение по умолчанию - 1");
            }
            Console.Write("Введите количество этажей в здании: ");
            isValid = byte.TryParse(Console.ReadLine(), out byte newNumOfFloors);
            if (isValid)
            {
                this.numOfFloors = newNumOfFloors;
            }
            else
            {
                this.numOfFloors = 1;
                Console.WriteLine("Такого количества этажей не может быть, выставлено значение по умолчанию - 1");
            }
            Console.Write("Введите количество подъездов в здании: ");
            isValid = byte.TryParse(Console.ReadLine(), out byte newNumOfPods);
            if (isValid)
            {
                this.numOfPods = newNumOfPods;
            }
            else
            {
                this.numOfPods = 1;
                Console.WriteLine("Такого количества подъездов не может быть, выставлено значение по умолчанию - 1");
            }
            Console.Write("Введите количество квартир в здании: ");
            isValid = ushort.TryParse(Console.ReadLine(), out ushort newNumOfAparts);
            if (isValid)
            {
                this.numOfAparts = newNumOfAparts;
            }
            else
            {
                this.numOfAparts = 1;
                Console.WriteLine("Такого количества квартир не может быть, выставлено значение по умолчанию - 1");
            }
            this.InfoBuilding();
        }
        public double HeightOfFloor()
        {
            return this.heightBuilding / this.numOfFloors;
        }
        public uint NumOfApartsInPods()
        {
            if (this.numOfAparts % this.numOfPods == 0)
            {
                return (uint)this.numOfAparts / this.numOfPods;
            }
            else
            {
                throw new Exception("С таким количеством квартир здание не может иметь столько подъездов");
            }
        }
        public uint NumOfApartsInFloor()
        {
            if (this.numOfAparts % this.numOfFloors == 0)
            {
                return (uint)this.numOfAparts / this.numOfFloors;
            }
            else
            {
                throw new Exception("С таким количеством квартир здание не может иметь столько этажей");
            }
        }
    }
}