public interface IExpirable
{
    DateTime ExpiryDate { get; }
    bool IsExpired => DateTime.Now > ExpiryDate;
}


