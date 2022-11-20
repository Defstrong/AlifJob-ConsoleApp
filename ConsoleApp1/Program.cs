
string MyProduct, MyPhoneNumber;

int MySum, MyInstallment;

Console.Write("Enter product type: ");
MyProduct = Console.ReadLine();

Console.Write("Enter your sum: ");
MySum = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter your phone numbers: ");
MyPhoneNumber = Console.ReadLine();

Console.Write("Enter installment duration: ");
MyInstallment = Convert.ToInt32(Console.ReadLine());


Console.WriteLine();
Console.WriteLine(GetTotalAmount(MyProduct, MySum, MyPhoneNumber, MyInstallment));


string GetTotalAmount(string TipProduct, int Sum, string PhoneNumbers, int Installment)
{
    int InstallmentPercentage = 0;
    string Product = "";
    if (TipProduct == "Phone")
    {
        Product = "Phone";
        InstallmentPercentage = GetInstallment(9, Installment) * 3;
        InstallmentPercentage = (Sum * InstallmentPercentage) / 100;
    }
    else if (TipProduct == "Komputer")
    {
        Product = "Komputer";
        InstallmentPercentage = GetInstallment(12, Installment) * 4;
        InstallmentPercentage = (Sum * InstallmentPercentage) / 100;
    }
    else if (TipProduct == "TV")
    {
        Product = "TV";
        InstallmentPercentage = GetInstallment(18, Installment) * 5;
        InstallmentPercentage = (Sum * InstallmentPercentage) / 100;
    }
    else return "Eror 404. Produkt it's not found";

    return SendMassage(Product, InstallmentPercentage + Sum, Installment);


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
    string SendMassage(string TipProduct, int Sum, int Installment)
    {
        return $"Your product: {Product}\nInstallment duration: {Installment} months\nTotal amount: {Sum} smn\n";
    }
}