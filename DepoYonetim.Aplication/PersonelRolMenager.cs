using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepoYonetim.DataAccess.Repostories;
using DepoYonetim.Models.Entities;


namespace DepoYonetim.Application
{
    public class PersonelRolMenager
    {
        private readonly Repository _repository;

        public PersonelRolMenager(Repository repository)=> _repository = repository;

        // Get all personnel with their roles
        public List<PersonelRol> GetAllPersonelRol()
        {
            try
            {
                // Retrieve user data
                var request_Kullanici = _repository.GetByData("SELECT * FROM Tbl_Kullanici");

                // Check if the data retrieval was failed
                if (request_Kullanici._state != Core.Enums.State.Success) throw new Exception("Kullanıcı verileri alınamadı: " + request_Kullanici.message);

                // Retrieve role data
                var request_Rol = _repository.GetByData("SELECT * FROM Tbl_Role");

                // Check if the data retrieval was failed
                if (request_Rol._state != Core.Enums.State.Success) throw new Exception("Rol verileri alınamadı: " + request_Rol.message);

                // Join user and role data

                var query = from kullanici in request_Kullanici.dt.AsEnumerable()
                            join rol in request_Rol.dt.AsEnumerable()
                            on kullanici.Field<int>("RoleID") equals rol.Field<int>("ID")
                            // Project the result into PersonelRol objects
                            select new PersonelRol
                            {
                                ID = kullanici.Field<int>("Id"),
                                AdSoyad = kullanici.Field<string>("AdSoyad"),
                                KullaniciAdi = kullanici.Field<string>("KullaniciAdi"),
                                SifreHash = kullanici.Field<string>("SifreHash"),
                                RoleName = rol.Field<string>("RoleName"),
                                Status = kullanici.Field<bool>("Status")
                            };
                #region Alternatif
                //foreach (DataRow item in request_Kullanici.dt.Rows)
                //{
                //    item["SifreHash"] = "********";
                //    item.["KullaniciAdi"] = item["KullaniciAdi"].ToString();]
                //} 
                #endregion
                // Return the result as a list
                return query.ToList();
            }
            catch (Exception ex)
            {
                // Burada log da atabilirsin
                throw new Exception("Personel-Rol listesi oluşturulurken hata oluştu.", ex);
            }
        }

        // Get role by role name
        public TblRole GetRoleByRoleName(string roleName)
        {
            var request_Rol = _repository.GetByData($"SELECT * FROM Tbl_Role WHERE RoleName = '{roleName}'");

            // Check if the data retrieval was failed
            if (request_Rol._state != Core.Enums.State.Success) throw new Exception("Rol verileri alınamadı: " + request_Rol.message);

            // Get the first matching role
            var rolRow = request_Rol.dt.AsEnumerable().FirstOrDefault();

            // If no matching role is found, throw an exception
            if (rolRow == null) throw new Exception("Belirtilen rol bulunamadı.");

            // Map the DataRow to TblRole object and return

            return new TblRole
            {
                ID = rolRow.Field<int>("ID"),
                RoleName = rolRow.Field<string>("RoleName"),
                Explanation = rolRow.Field<string>("Explanation")
            };
        }
        // Get all roles
        public List<TblRole> GetAllRoles()
        {
            var request_Rol = _repository.GetByData("SELECT * FROM Tbl_Role");
            if (request_Rol._state != Core.Enums.State.Success) throw new Exception("Rol verileri alınamadı: " + request_Rol.message);

            // Map DataTable rows to TblRole objects
            var roles = request_Rol.dt.AsEnumerable().Select(rolRow => 
            new TblRole
            {
                ID = rolRow.Field<int>("ID"),
                RoleName = rolRow.Field<string>("RoleName"),
                Explanation = rolRow.Field<string>("Explanation")
            }).ToList();
            return roles;
        }
        // Add new personnel
        public bool PersonelKaydet(TblKullanici tblKullanici)
        {
            string insertQuery = $"INSERT INTO Tbl_Kullanici (AdSoyad, KullaniciAdi, SifreHash, RoleID, Status) " +
                                 $"VALUES ('{tblKullanici.AdSoyad}', '{tblKullanici.KullaniciAdi}', '{tblKullanici.SifreHash}', {tblKullanici.RoleID}, {1})";
            var result = _repository.ExecuteSql(insertQuery, null);
            if (result._state != Core.Enums.State.Success)
            {
                return false;
            }
            return true;
        }
        // Get personnel by ID
        public TblKullanici GetPersonelById(int personelId)
        {
            // Retrieve user data
            var request_Kullanici = _repository.GetByData($"SELECT * FROM Tbl_Kullanici WHERE ID = {personelId}");

            // Check if the data retrieval was failed
            if (request_Kullanici._state != Core.Enums.State.Success) throw new Exception("Kullanıcı verileri alınamadı: " + request_Kullanici.message);

            // Get the first matching user
            var kullaniciRow = request_Kullanici.dt.AsEnumerable().FirstOrDefault();

            // If no matching user is found, throw an exception
            if (kullaniciRow == null) throw new Exception("Belirtilen kullanıcı bulunamadı.");

            // Map the DataRow to TblKullanici object and return
            return new TblKullanici
            {
                ID = kullaniciRow.Field<int>("ID"),
                AdSoyad = kullaniciRow.Field<string>("AdSoyad"),
                KullaniciAdi = kullaniciRow.Field<string>("KullaniciAdi"),
                SifreHash = kullaniciRow.Field<string>("SifreHash"),
                RoleID = kullaniciRow.Field<int>("RoleID"),
                Status = kullaniciRow.Field<bool>("Status")
            };
        }

        // Update personnel
        public bool PersonelGuncelle(TblKullanici tblKullanici)
        {
            string updateQuery = $"UPDATE Tbl_Kullanici SET " +
                                 $"AdSoyad = '{tblKullanici.AdSoyad}', " +
                                 $"KullaniciAdi = '{tblKullanici.KullaniciAdi}', " +
                                 $"SifreHash = '{tblKullanici.SifreHash}', " +
                                 $"RoleID = {tblKullanici.RoleID}, " +
                                 $"Status = {(tblKullanici.Status ? 1 : 0)} " +
                                 $"WHERE ID = {tblKullanici.ID}";
            var result = _repository.ExecuteSql(updateQuery, null);
            if (result._state != Core.Enums.State.Success)
            {
                return false;
            }
            return true;
        }

        // Soft delete personnel
        public bool PersonelSoftSil(int personelId)
        {
            string updateQuery = $"UPDATE Tbl_Kullanici SET Status = 0 WHERE ID = {personelId}";
            var result = _repository.ExecuteSql(updateQuery, null);
            if (result._state != Core.Enums.State.Success)
            {
                return false;
            }
            return true;
        }

        // Hard delete personnel
        public bool PersonelKaldir(int personelId)
        {
            string deleteQuery = $"DELETE FROM Tbl_Kullanici WHERE ID = {personelId}";
            var result = _repository.ExecuteSql(deleteQuery, null);
            if (result._state != Core.Enums.State.Success)
            {
                return false;
            }
            return true;
        }
    }
}
