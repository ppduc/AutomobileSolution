using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomobileLibrary.BusinessObject;
using AutomobileLibrary.DataAccess;

namespace AutomobileLibrary.Repository
{
    //Code phần thân cho ICarRepository
    public class CarRepository : ICarRepository
    {
        // Gọi đến các phương thức đã được khai báo trong CarDBContext

        // Xóa Car
        public void DeleteCar(int carId) => CarDBContext.Instance.Remove(carId);

        // Lấy 1 car trong danh sách list
        public Car GetCarById(int carId) => CarDBContext.Instance.GetCarByID(carId);

        // Lấy danh sách car
        public IEnumerable<Car> GetCars() => CarDBContext.Instance.GetCarList;

        // Thêm car
        public void InsertCar(Car car) => CarDBContext.Instance.AddNew(car);

        //Update car
        public void UpdateCar(Car car) => CarDBContext.Instance.Update(car);
    }
}
