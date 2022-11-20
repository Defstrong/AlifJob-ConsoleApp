
string MyProduct, MyPhoneNumber;

int MySum, MyInstallment;

//Вводим все нужные данные

Console.Write("Enter product type: ");
MyProduct = Console.ReadLine();

Console.Write("Enter your sum: ");
MySum = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter your phone numbers: ");
MyPhoneNumber = Console.ReadLine();

Console.Write("Enter installment duration: ");
MyInstallment = Convert.ToInt32(Console.ReadLine());


Console.WriteLine();
//Выводим результат
Console.WriteLine(
    //Передаём все данные
    GetTotalAmount(MyProduct, MySum, MyPhoneNumber, MyInstallment));


string GetTotalAmount(string TipProduct, int Sum, string PhoneNumbers, int Installment)
{
    // InstallmentPercentage это обьший процент рассрочки
    int InstallmentPercentage = 0;
    string Product = "";
    // Определяем тип продукта
    if (TipProduct == "Phone")
    {
        
        Product = "Phone";
        //Передаём данные для получения коэффицента и умножаем на процент товара
        InstallmentPercentage = GetInstallment(9, Installment) * 3;

        //Преобразуем процент в сумму
        InstallmentPercentage = (Sum * InstallmentPercentage) / 100;
    }
    else if (TipProduct == "Komputer")
    {
        Product = "Komputer";
        //Передаём данные для получения коэфицента и умножаем на процент товара
        InstallmentPercentage = GetInstallment(12, Installment) * 4;
        //Преобразуем процент в сумму
        InstallmentPercentage = (Sum * InstallmentPercentage) / 100;
    }
    else if (TipProduct == "TV")
    {
        Product = "TV";
        //Передаём данные для получения коэфицента и умножаем на процент товара
        InstallmentPercentage = GetInstallment(18, Installment) * 5;
        //Преобразуем процент в сумму
        InstallmentPercentage = (Sum * InstallmentPercentage) / 100;
    }
    //Возврощаем Eror 404 если товар не найден
    else return "Eror 404. Produkt it's not found";

    //Передаём значения в SendMassege для отправки СМС и возврощаем результат
    return SendMassage(Product, InstallmentPercentage + Sum, Installment);

    //Получаем коэффицент процента
    int GetInstallment(int RangeStart, int RangeEnd)
    {
        int Procent = 0;
        List<int> RangeInstallment = new List<int>(6) { 3, 6, 9, 12, 18, 24 };
        for (int i = 0; i < RangeInstallment.Count; i++)
        {
            if (RangeInstallment[i] > RangeStart)
                Procent++;
            if (RangeInstallment[i] == RangeEnd) break;
        }
        return Procent;
    }
    //Отпровляем СМС
    string SendMassage(string TipProduct, int Sum, int Installment)
    {
        return $"Your product: {Product}\nInstallment duration: {Installment} months\nTotal amount: {Sum} smn\n";
    }
}
