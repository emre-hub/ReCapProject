using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //UserTest();
            //CustomerTest();
            //RentalTest();


        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            rentalManager.Add(new Rental
            {
                CarId = 2,
                CustomerId = 7,
                RentDate = DateTime.Now,
                ReturnDate = DateTime.Now
            });

            var result = rentalManager.GetAll();
            foreach (var r in result.Data)
            {
                Console.WriteLine(r.Id);
            }
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            var result = customerManager.GetAll();
            foreach (var c in result.Data)
            {
                Console.WriteLine(c.CompanyName);
            }
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());

            var result = userManager.GetAll();
            foreach (var u in result.Data)
            {
                Console.WriteLine(u.FirstName + " - " + u.LastName + " - " + u.Email + " - " + u.Password);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetAll();
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.CarName);
            }
        }
    }
}