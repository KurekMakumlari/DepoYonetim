using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepoYonetim.DataAccess.Repostories;
using DepoYonetim.Models.Entities;


namespace DepoYonetim.Aplication
{
    public class PersonelRolMenager
    {
        private readonly Repository _repository;

        public PersonelRolMenager(Repository repository)
        {
            _repository = repository;
        }

        public List<PersonelRol> GetAllPersonelRol()
        {
            var request_Kullanici = _repository.GetByData("SELECT * FROM Tbl_Kullanici");

            if (request_Kullanici._state != Core.Enums.State.Success)
            {
                throw new Exception("Kullanıcı verileri alınamadı: " + request_Kullanici.message);
            }

            var request_Rol = _repository.GetByData("SELECT * FROM Tbl_Role");

            if (request_Rol._state != Core.Enums.State.Success)
            {
                throw new Exception("Rol verileri alınamadı: " + request_Rol.message);
            }
            var query = from kullanici in request_Kullanici.dt.AsEnumerable()
                        join rol in request_Rol.dt.AsEnumerable()
                        on kullanici.Field<int>("RoleID") equals rol.Field<int>("ID")
                        select new PersonelRol
                        {
                            ID = kullanici.Field<int>("Id"),
                            AdSoyad = kullanici.Field<string>("AdSoyad"),
                            KullaniciAdi = kullanici.Field<string>("KullaniciAdi"),
                            SifreHash = kullanici.Field<string>("SifreHash"),
                            RoleName = rol.Field<string>("RoleName"),
                            Status = kullanici.Field<bool>("Status")
                        };
            return query.ToList();
        }

        public TblRole GetRoleByRoleName(string roleName)
        {
            var request_Rol = _repository.GetByData($"SELECT * FROM Tbl_Role WHERE RoleName = '{roleName}'");
            if (request_Rol._state != Core.Enums.State.Success)
            {
                throw new Exception("Rol verileri alınamadı: " + request_Rol.message);
            }
            var rolRow = request_Rol.dt.AsEnumerable().FirstOrDefault();
            if (rolRow == null)
            {
                throw new Exception("Belirtilen rol bulunamadı.");
            }
            return new TblRole
            {
                ID = rolRow.Field<int>("ID"),
                RoleName = rolRow.Field<string>("RoleName"),
                Explanation = rolRow.Field<string>("Explanation")
            };
        }

        public List<TblRole> GetAllRoles()
        {
            var request_Rol = _repository.GetByData("SELECT * FROM Tbl_Role");
            if (request_Rol._state != Core.Enums.State.Success)
            {
                throw new Exception("Rol verileri alınamadı: " + request_Rol.message);
            }
            var roles = request_Rol.dt.AsEnumerable().Select(rolRow => new TblRole
            {
                ID = rolRow.Field<int>("ID"),
                RoleName = rolRow.Field<string>("RoleName"),
                Explanation = rolRow.Field<string>("Explanation")
            }).ToList();
            return roles;
        }
        public bool PersonelKaydet(TblKullanici tblKullanici)
        {
            string insertQuery = $"INSERT INTO Tbl_Kullanici (AdSoyad, KullaniciAdi, SifreHash, RoleID, Status) " +
                                 $"VALUES ('{tblKullanici.AdSoyad}', '{tblKullanici.KullaniciAdi}', '{tblKullanici.SifreHash}', {tblKullanici.RoleID}, {(tblKullanici.Status ? 1 : 0)})";
            var result = _repository.ExecuteSql(insertQuery, null);
            if (result._state != Core.Enums.State.Success)
            {
                return false;
            }
            return true;
        }
        public TblKullanici GetPersonelById(int personelId)
        {
            var request_Kullanici = _repository.GetByData($"SELECT * FROM Tbl_Kullanici WHERE ID = {personelId}");
            if (request_Kullanici._state != Core.Enums.State.Success)
            {
                throw new Exception("Kullanıcı verileri alınamadı: " + request_Kullanici.message);
            }
            var kullaniciRow = request_Kullanici.dt.AsEnumerable().FirstOrDefault();
            if (kullaniciRow == null)
            {
                throw new Exception("Belirtilen kullanıcı bulunamadı.");
            }
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
