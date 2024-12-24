// See https://aka.ms/new-console-template for more information

CustomerOrder customerOrder1 = new CustomerOrder(GetOrderDiscount)
{
    PaymentMethod = PaymentMethods.Cash,
    Country = "Latvia",
    Amount = 2000
};
CustomerOrder customerOrder2 = new CustomerOrder(GetOrderDiscount)
{
    PaymentMethod = PaymentMethods.CreditCard,
    Country = "USA",
    Amount = 3000
};

Console.WriteLine(customerOrder1);
Console.WriteLine(customerOrder2);

static int GetOrderDiscount(CustomerOrder order)
{
    return (order.PaymentMethod, order.Country) switch
    {
        (PaymentMethods.CreditCard, "USA") when order.Amount > 1000 => 10,
        (PaymentMethods.Cash, "Latvia") => 15,
        (_, _) when order.Amount > 5000 => 25,
        _ => 0 // unknown or Default
    };
}

class CustomerOrder(Func<CustomerOrder, int> getOrderDiscountDelegate)
{
    public PaymentMethods PaymentMethod { get; set; }
    public required string Country { get; set; }
    public double Amount { get; set; }
    
    public override string ToString() => $"Country: {Country}, Payment Method : {PaymentMethod}, Order Discount : {getOrderDiscountDelegate(this)}";
}
enum PaymentMethods
{
    CreditCard,
    Cash
}