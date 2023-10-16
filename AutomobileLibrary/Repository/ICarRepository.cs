using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomobileLibrary.BusinessObject;

namespace AutomobileLibrary.Repository
{
    //Class interface: định nghĩa một tập hợp mà đối tượng đối tượng phải triển khai có thể thể hiện
    //Có thể hiểu giống như mình đang khai báo Method nhưng chưa code method đó
    //Mình sẽ code phần body của những phương thức này trong class CarRepository
    public interface ICarRepository
    {
        // Khai báo hàm lấy danh sách car (carList)
        IEnumerable<Car> GetCars();
        
        // Khai báo hàm lấy ra 1 object car trong danh sách car 
        Car GetCarById(int carId);

        // Khai báo hàm thêm mới 1 car 
        void InsertCar(Car car);
        
        // Khai báo hàm xóa 1 car trong danh sách car
        void DeleteCar(int carId);

        // Khai báo hàm chỉnh sửa thông tin của một car
        void UpdateCar(Car car);    
    }
}
