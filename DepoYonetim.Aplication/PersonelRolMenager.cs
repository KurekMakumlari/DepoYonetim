using System;
using System.Collections.Generic;
using System.Linq;
using DepoYonetim.DataAccess.Repostories;
using DepoYonetim.Models.Entities;

namespace DepoYonetim.Application
{
    public class PersonelRolMenager
    {
        private readonly Repository _repository;
        public PersonelRolMenager(Repository repository) => _repository = repository;

        public List<PersonelRol> GetAllPersonelRol()
        {
            try
            {
                var kullanicilar = _repository.Query<TblKullanici>();
                var roller = _repository.Query<TblRole>();

                return (from kullanici in kullanicilar
                        join rol in roller on kullanici.RoleID equals rol.ID
                        select new PersonelRol
                        {
                            ID = kullanici.ID,
                            AdSoyad = kullanici.AdSoyad,
                            KullaniciAdi = kullanici.KullaniciAdi,
                            SifreHash = kullanici.SifreHash,
                            RoleName = rol.RoleName,
                            Status = kullanici.Status
                        }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Personel-Rol listesi oluşturulurken hata oluştu.", ex);
            }
        }

        public TblRole GetRoleByRoleName(string roleName)
        {
            var role = _repository.Query<TblRole>().FirstOrDefault(x => x.RoleName == roleName);
            if (role == null) throw new Exception("Belirtilen rol bulunamadı.");
            return role;
        }

        public List<TblRole> GetAllRoles()
        {
            return _repository.Query<TblRole>().ToList();
        }

        public bool PersonelKaydet(TblKullanici tblKullanici)
        {
            tblKullanici.Status = true;
            return _repository.Add(tblKullanici).state == Core.Enums.State.Success;
        }

        public TblKullanici GetPersonelById(int personelId)
        {
            var user = _repository.Query<TblKullanici>().FirstOrDefault(x => x.ID == personelId);
            if (user == null) throw new Exception("Belirtilen kullanıcı bulunamadı.");
            return user;
        }

        public bool PersonelGuncelle(TblKullanici tblKullanici)
        {
            var current = GetPersonelById(tblKullanici.ID);
            current.AdSoyad = tblKullanici.AdSoyad;
            current.KullaniciAdi = tblKullanici.KullaniciAdi;
            current.SifreHash = tblKullanici.SifreHash;
            current.RoleID = tblKullanici.RoleID;
            current.Status = tblKullanici.Status;

            return _repository.Update(current).state == Core.Enums.State.Success;
        }

        public bool PersonelSoftSil(int personelId)
        {
            var current = GetPersonelById(personelId);
            current.Status = false;
            return _repository.Update(current).state == Core.Enums.State.Success;
        }

        public bool PersonelKaldir(int personelId)
        {
            var current = GetPersonelById(personelId);
            return _repository.Delete(current).state == Core.Enums.State.Success;
        }
    }
}
