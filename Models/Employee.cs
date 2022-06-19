namespace ADO.NET.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{ID} {FirstName} {LastName}";
        }
    }
}
