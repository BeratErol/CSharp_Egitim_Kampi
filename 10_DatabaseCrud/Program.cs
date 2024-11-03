using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_DatabaseCrud
{
    class Program
    {
        static void Main(string[] args)
        {
            //Crud-->Create-Read-Update-Delete

            Console.WriteLine("***** Menü Sipariş İşlem Paneli *****");
            Console.WriteLine();

            Console.WriteLine("---------------------------------");

            #region Kategori Ekleme İşlemi

            //Console.Write("Eklemek istediğiniz kategori adı: ");
            //string categoryName = Console.ReadLine();

            //SqlConnection connection = new SqlConnection("Data Source = BERAT\\SQLEXPRESS; initial catalog = EgitimKampiDB; integrated security = true");
            //// Data Source, sql'deki server name'i; initial catalog database'in adını; integrated security de bağlantı güvenliğini tutar

            //connection.Open();

            //SqlCommand command = new SqlCommand("insert into TblCategory (CategoryName) values (@p1)" , connection);
            //// insert ekleme komutudur, into da içine ekleme demek. CategoryName TblCategory'deki özellikten gelir.
            //// values = değerleri, (@p1) = 1.parametreden al, connection = bağlantı

            //command.Parameters.AddWithValue("@p1", categoryName); // parametleri giriyoruz

            //command.ExecuteNonQuery();
            //// NonQuery = koşulsuz şekilde sorguyu çalıştır

            //connection.Close();

            //Console.WriteLine("Kategori başarıyla eklendi!");
            // eklendikten sonra sql'de TblCategory'e gidip sağ tık yapıp execute sql dersek eklendiğini görebiliriz

            #endregion

            #region Ürün Ekleme İşlemi

            //string productName;
            //decimal productPrice;
            ////bool productStatus;

            //Console.Write("Ürün Adı: ");
            //productName = Console.ReadLine();
            //Console.Write("Ürün Fiyatı: ");
            //productPrice = Decimal.Parse(Console.ReadLine());

            //SqlConnection connection = new SqlConnection("Data source = BERAT\\SQLEXPRESS; initial catalog = EgitimKampiDB; integrated security = true"); 

            //connection.Open();

            //SqlCommand command = new SqlCommand("insert into TblProduct (ProductName, ProductPrice, ProductStatus) values (@productName,@productPrice,@productStatus)", connection);

            //command.Parameters.AddWithValue("@productName", productName);
            //command.Parameters.AddWithValue("@productPrice", productPrice);
            //command.Parameters.AddWithValue("@productStatus", true); // değerini direkt true'ya atadık

            //command.ExecuteNonQuery();

            //connection.Close();

            //Console.Write("Ürün eklemesi başarılı!");

            #endregion

            #region Ürün Listeleme İşlemi

            //SqlConnection connection = new SqlConnection("Data Source = BERAT\\SQLEXPRESS; initial Catalog = EgitimKampiDb; integrated security = true");

            //connection.Open();
            //SqlCommand command = new SqlCommand("Select * From TblProduct", connection); // sonuna connection ekleriz ki bağlantıyla ilişkilendirelim
            //SqlDataAdapter adapter = new SqlDataAdapter(command); // sqlden verileri c# tarafına köprü görevi görerek çekmemizi sağlar
            //DataTable dataTable = new DataTable();
            //adapter.Fill(dataTable); // dataTable ile adapter'ın içini dolduruyoruz

            //foreach (DataRow row in dataTable.Rows) // satıları gezer
            //{
            //    foreach (var item in row.ItemArray) // satırın içindeki değerleri gezer
            //    {
            //        Console.Write(item.ToString() + " ");
            //    }
            //    Console.WriteLine();
            //}

            //connection.Close();

            #endregion

            #region Ürün Silme İşlemi

            //Console.Write("Silinecek Ürün Id: ");
            //int productId = int.Parse(Console.ReadLine());

            //SqlConnection connection = new SqlConnection("Data Source = BERAT\\SQLEXPRESS; initial Catalog = EgitimKampiDb; integrated security = true");

            //connection.Open();
            //SqlCommand command = new SqlCommand("Delete From TblProduct Where ProductId = @productId", connection);
            //command.Parameters.AddWithValue("@productId" , productId);
            //command.ExecuteNonQuery();

            //connection.Close();

            //Console.WriteLine("Silme işlemi yapıldı!");

            #endregion

            #region Ürün Güncelleme İşlemi

            Console.Write("Güncellenecek Ürün Id: ");
            int productId = int.Parse(Console.ReadLine());

            Console.Write("Güncellenecek Ürün Adı: ");
            string productName = Console.ReadLine();

            Console.Write("Güncellenecek Ürün Fiyatı: ");
            decimal productPrice = decimal.Parse(Console.ReadLine());


            SqlConnection connection = new SqlConnection("Data Source = BERAT\\SQLEXPRESS; initial Catalog = EgitimKampiDb; integrated security = true"); // bağlantı
            connection.Open();
            SqlCommand command = new SqlCommand("Update TblProduct Set ProductName = @productName, ProductPrice = @productPrice where ProductID = @productId", connection);
            // Set = ayarla  // Güncellemek yaparken şartı yazmak çok önemli (where) yoksa bütün kayıtları günceller
            command.Parameters.AddWithValue("@productName" , productName);
            command.Parameters.AddWithValue("@productPrice" , productPrice);
            command.Parameters.AddWithValue("@productId" , productId);
            command.ExecuteNonQuery(); // değişikleri kaydediyoruz
            
            connection.Close();

            Console.WriteLine("Güncelleme başarılı!");

            #endregion

            Console.Read();

            #region ÖZET

            /*
        
            1) Create Kısmı İçin: Bağlantıyı kurma + bağlantıyı açma + komut ekleme + 
            komuta parametreleri girme + değişikleri koşulsuz kaydetme + bağlantıyı kapatma şeklindedir.
            Sorgusu: insert into TblCategory (CategoryName) values (@p1) şeklinde olur.

            2) Update Kısmı İçin: Create ile aynı şekilde ilerler.
            Sorgusu: Update TblProduct Set ProductName = @productName, ProductPrice = @productPrice where ProductID = @productId şeklinde olur.
           
            3) Delete Kısmı İçin: Create ile aynı şekilde ilerler.
            Sorgusu: Delete From TblProduct Where ProductId = @productId şeklinde olur.

            4) Read Kısmı İçin: Bağlantıyı kurma + bağlantıyı açma + komut ekleme +
            adapter ekleme + dataTable ekleme + adapter'ı dataTable ile doldurma + çift foreach ile listeleme şeklindedir.
            Sorgusu: Select * From TblProduct şeklinde olur.

            */

            #endregion
        }
    }
}
