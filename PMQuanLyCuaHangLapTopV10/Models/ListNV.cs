using PMQuanLyCuaHangLapTopV10.Models.PMQuanLyCuaHangLaptop.Models; // Correct namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PMQuanLyCuaHangLapTopV10.Models
{
    public class ListNV
    {
        public List<NhanVien> listNV = new List<NhanVien>();
        public NhanVienDAO nhanVienDAO = new NhanVienDAO();
        // Logger instance for logging errors/information
        private readonly Logger logger = Logger.Instance();


        public ListNV()
        {
            // Initialize the list (if needed, though it's initialized inline)
            // listNV = new List<NhanVien>();  // Not really necessary
            LoadNhanVienDataFromDatabase();
            // Consider loading data from a file or database here when the ListNV object is created.
            // This avoids having an empty list every time the application starts.
            // Example: LoadDataFromFile("nhanvien_data.txt");  // Create a method to load data
        }
        private void LoadNhanVienDataFromDatabase()
        {
            try
            {
                List<NhanVien> dataFromDb = nhanVienDAO.GetAllNhanVien(); // Fetch data from database
                if (dataFromDb != null)
                {
                    listNV.AddRange(dataFromDb); // Add the fetched data to listNV
                    logger.LogInformation($"Successfully loaded {listNV.Count} NhanVien records from database.");
                }
                else
                {
                    logger.LogWarning("No NhanVien data retrieved from the database.");
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Error loading NhanVien data from database: {ex.Message}");
                logger.LogException(ex);
                // Consider how to handle the error - e.g., throw an exception, display a message to the user
            }
        }

        // Method to add a NhanVien to the list
        public void AddNhanVien(NhanVien nhanVien)
        {
            if (nhanVien == null)
            {
                logger.LogError("Attempted to add a null NhanVien object.");  // Log the error
                throw new ArgumentNullException(nameof(nhanVien), "Cannot add a null NhanVien object.");
            }

            listNV.Add(nhanVien);
            logger.LogInformation($"Added NhanVien: {nhanVien.MaNV} - {nhanVien.HoTenNV}"); // Log success

        }

        // Method to remove a NhanVien from the list by ID
        public bool RemoveNhanVien(string maNV)
        {
            if (string.IsNullOrEmpty(maNV))
            {
                logger.LogError("Attempted to remove NhanVien with a null or empty ID.");
                throw new ArgumentException("ID cannot be null or empty.", nameof(maNV));
            }

            NhanVien nhanVienToRemove = listNV.FirstOrDefault(nv => nv.MaNV == maNV);
            if (nhanVienToRemove != null)
            {
                listNV.Remove(nhanVienToRemove);
                logger.LogInformation($"Removed NhanVien: {maNV} - {nhanVienToRemove.HoTenNV}");
                return true; // Indicate successful removal
            }
            else
            {
                logger.LogWarning($"NhanVien with ID {maNV} not found for removal.");
                return false; // Indicate not found
            }
        }

        // Method to find a NhanVien by ID
        public NhanVien FindNhanVien(string maNV)
        {
            if (string.IsNullOrEmpty(maNV))
            {
                logger.LogError("Attempted to find NhanVien with a null or empty ID.");
                throw new ArgumentException("ID cannot be null or empty.", nameof(maNV));
            }

            NhanVien foundNhanVien = listNV.FirstOrDefault(nv => nv.MaNV == maNV);

            if (foundNhanVien == null)
            {
                logger.LogWarning($"NhanVien with ID {maNV} not found.");
            }
            else
            {
                logger.LogInformation($"NhanVien with ID {maNV} found.");
            }

            return foundNhanVien;
        }

        // Method to update a NhanVien in the list
        public bool UpdateNhanVien(NhanVien updatedNhanVien)
        {
            if (updatedNhanVien == null)
            {
                logger.LogError("Attempted to update with a null NhanVien object.");
                throw new ArgumentNullException(nameof(updatedNhanVien), "Cannot update with a null NhanVien object.");
            }

            NhanVien existingNhanVien = listNV.FirstOrDefault(nv => nv.MaNV == updatedNhanVien.MaNV);
            if (existingNhanVien != null)
            {
                // Update the properties of the existing NhanVien
                existingNhanVien.HoTenNV = updatedNhanVien.HoTenNV;
                existingNhanVien.GioiTinh = updatedNhanVien.GioiTinh;
                existingNhanVien.DiaChiNV = updatedNhanVien.DiaChiNV;
                existingNhanVien.SoDienThoai = updatedNhanVien.SoDienThoai;
                existingNhanVien.Password = updatedNhanVien.Password;
                // ... update other properties as needed

                logger.LogInformation($"Updated NhanVien: {updatedNhanVien.MaNV} - {updatedNhanVien.HoTenNV}");
                return true; // Indicate successful update
            }
            else
            {
                logger.LogWarning($"NhanVien with ID {updatedNhanVien.MaNV} not found for update.");
                return false; // Indicate not found
            }
        }
        // Method to check login credentials
        //public bool CheckDangNhap(string sdt, string password)
        //{

        //    if (string.IsNullOrEmpty(sdt))
        //    {
        //        logger.LogError("Username khong duoc phep de trong ! ");
        //        return false;
        //    }

        //    if (string.IsNullOrEmpty(password))
        //    {
        //        logger.LogError("Attempted login with a null or empty password.");
        //        return false;
        //    }

        //    NhanVien nhanVien = listNV.FirstOrDefault(nv => nv.SoDienThoai == sdt);

        //    if (nhanVien != null)
        //    {
        //        // In a real application, you would hash and salt passwords for security.
        //        // Here, for simplicity, we are doing a direct string comparison.
        //        if (nhanVien.Password == password)
        //        {
        //            logger.LogInformation($"Login successful for user: {sdt}");
        //            return true; // Login successful
        //        }
        //        else
        //        {
        //            logger.LogWarning($"Login failed for user: {sdt} - Incorrect password.");
        //            return false; // Incorrect password
        //        }
        //    }
        //    else
        //    {
        //        logger.LogWarning($"Login failed for user: {sdt} - User not found.");
        //        return false; // User not found
        //    }
        //}
        // Method to return all the NhanVien
        public List<NhanVien> GetAllNhanVien()
        {
            return listNV;
        }

    }
}