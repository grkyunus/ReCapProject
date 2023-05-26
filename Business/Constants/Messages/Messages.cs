using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants.Messages
{
    // static verilirse new kuralına gerek yoktur ve bu durum içinde gerekli değildir.
    public static class Messages
    {
        public static string CarAdded = "Araç eklendi";
        public static string CarNameInvalid = "Araç ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string CarListed = "Araç listelendi";
        public static string Process = "İşlem gerçekleştirildi";
        public static string ProcessError = "İşlem hatası";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu";
        public static string UserRegistered = "Kayıt başarılı";
        public static string AuthorizationDenied = "Yetkiniz yok";
    }


}
